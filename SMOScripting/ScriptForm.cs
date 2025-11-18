using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Configuration; 
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk.Sfc;

namespace SMOScripting
{
    public partial class ScriptForm : Form
    {
        StringCollection keywords = new StringCollection();
        Server server;
        Database db;

        public ScriptForm()
        {
            InitializeComponent();

            string serverstr = ConfigurationManager.AppSettings["Server"];
            string user = ConfigurationManager.AppSettings["User"];
            string password = ConfigurationManager.AppSettings["Password"];
            ServerConnection conn = new ServerConnection(serverstr, user, password);
            server = new Server(conn);
        }

        public ScriptForm(Server srv, string dbase)
        {
            InitializeComponent();

            if (srv != null) server = srv;

            if(!string.IsNullOrEmpty(dbase)) db = server.Databases[dbase];
        }

        private void btnScript_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker.RunWorkerAsync();
            }
        }

        private string ScriptObject(Urn[] urns, Scripter scripter)
        {
            
            StringCollection sc = scripter.Script(urns);

            StringBuilder sb = new StringBuilder();

            foreach (string str in sc)
            {
                sb.Append(str + Environment.NewLine + "GO" +
                  Environment.NewLine + Environment.NewLine);
            }

            return sb.ToString();

        }

        protected void ScriptingProgressEventHandler(object sender, ProgressReportEventArgs e)
        {
            if (e.Current.XPathExpression.Length > 2)
            {   
                this.Invoke(new MethodInvoker(delegate
                {
                    txtProgress.Text = txtProgress.Text + e.Current.XPathExpression[2].GetAttributeFromFilter("Name") + Environment.NewLine;
                }));
            }
        }


        private void ScriptForm_Load(object sender, EventArgs e)
        {
            System.IO.StreamReader file = new System.IO.StreamReader("SQL.txt");
            cboServerVersion.Items.Add("SQL Server 2000");
            cboServerVersion.Items.Add("SQL Server 2005");
            cboServerVersion.Items.Add("SQL Server 2010");
            cboServerVersion.SelectedIndex = 0;

            string line = "";
            while ((line = file.ReadLine()) != null)
            {
                keywords.Add(line);
            }

            file.Close();

            
            try
            {

                foreach (Database database in server.Databases)
                {
                    cboDatabase.Items.Add(database.Name);
                }
                cboDatabase.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Parse()
        {
            String line = "";

            this.Invoke(new MethodInvoker(delegate
            {
                line = richTextScript.Text;
            }));

            // Split the line into tokens.
            Regex r = new Regex("([ \\t\n{}(),;])");
            string[] tokens = r.Split(line);
            int index = 0;
            int tokenIndex = 0;
            for (int ii = 0; ii < tokens.Length; ii++)
            {
                string token = tokens[ii];

                this.Invoke(new MethodInvoker(delegate
                        {
                            richTextScript.SelectionStart = index;
                            richTextScript.SelectionLength = token.Length;
                            richTextScript.SelectionColor = Color.Black;
                            richTextScript.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                        }));
                // Check for a comment.
                if (token == "//" || token.StartsWith("//"))
                {
                    // Find the start of the comment and then extract the whole comment.
                    int length = line.Length - (index);
                    this.Invoke(new MethodInvoker(delegate
                        {
                            string commentText = richTextScript.Text.Substring(index, length);
                            richTextScript.SelectionStart = index;
                            richTextScript.SelectionLength = length;
                            richTextScript.SelectionColor = Color.LightGreen;
                            richTextScript.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                        }));
                    //break;
                }

                // Check whether the token is a keyword. 
                for (int i = 0; i < keywords.Count; i++)
                {
                    if (keywords[i].ToLower() == token.ToLower())
                    {
                        // Apply alternative color and font to highlight keyword.        
                        this.Invoke(new MethodInvoker(delegate
                        {
                            richTextScript.SelectionColor = Color.Blue; ;
                            richTextScript.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                        }));
                        break;
                    }
                }
                index += token.Length;
                tokenIndex++;
            }

            int prevIndex = 0;
            int prevLength = 0;

            string txt = "";

            this.Invoke(new MethodInvoker(delegate
            {
                txt = richTextScript.Text;
            }));

            foreach (Match match in Regex.Matches(txt, @"([""'])(?:(?=(\\?))\2.)*?\1"))
            {
                if (prevIndex == 0)
                {
                    this.Invoke(new MethodInvoker(delegate
                        {
                            richTextScript.SelectionStart = match.Index;
                            richTextScript.SelectionLength = match.Length;
                            richTextScript.SelectionColor = Color.Red;
                            richTextScript.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                        }));
                }
                else
                {
                    if (match.Index != prevLength + prevIndex)
                    {

                    
                        this.Invoke(new MethodInvoker(delegate
                        {

                            richTextScript.SelectionStart = match.Index;
                            richTextScript.SelectionLength = match.Length;
                            richTextScript.SelectionColor = Color.Red;
                            richTextScript.SelectionFont = new Font("Courier New", 10, FontStyle.Regular);
                        }));
                    }
                }
                prevIndex = match.Index;
                prevLength = match.Length;

            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            this.Invoke(new MethodInvoker(delegate
            {
                richTextScript.Text = "";
                txtProgress.Text = "";
            }));

            
            try
            {


                string dbname = "";

                this.Invoke(new MethodInvoker(delegate
                {
                    dbname = cboDatabase.SelectedItem.ToString();
                }));

                Database db = server.Databases[dbname];
                Scripter scripter = new Scripter(server);
                scripter.ScriptingProgress += new ProgressReportEventHandler(ScriptingProgressEventHandler);

                ScriptingOptions so = new ScriptingOptions();
                so.IncludeIfNotExists = chkScriptIfNotExists.Checked;
                so.IncludeHeaders = chkScriptHeaders.Checked;
                so.Permissions = chkScriptPermissions.Checked;
                so.ExtendedProperties = chkScriptExtendedProperties.Checked;
                so.ScriptDrops = chkScriptDrop.Checked;
                so.IncludeDatabaseContext = chkDBContext.Checked;
                so.NoCollation = chkNoCollation.Checked;
                so.NoFileGroup = chkNoFileGroups.Checked;
                so.NoIdentities = chkNoIdentities.Checked;

                StringBuilder sbScript = new StringBuilder();

                int version = 0;

                this.Invoke(new MethodInvoker(delegate
                {
                    version = cboServerVersion.SelectedIndex;
                }));

                switch (version)
                {
                    case 0:
                        so.TargetServerVersion = SqlServerVersion.Version80;
                        break;

                    case 1:
                        so.TargetServerVersion = SqlServerVersion.Version90;
                        break;
                    case 2:
                        so.TargetServerVersion = SqlServerVersion.Version100;
                        break;

                }

                scripter.Options = so;

                if (chkScriptDatabase.Checked)
                {
                    sbScript.Append(ScriptObject(new Urn[] { db.Urn }, scripter));
                }

                if (chkTables.Checked)
                {
                    server.SetDefaultInitFields(typeof(Table), "IsSystemObject");
                    foreach (Table tb in db.Tables)
                    {
                        if (!tb.IsSystemObject)
                        {
                            sbScript.Append(ScriptObject(new Urn[] { tb.Urn }, scripter));
                        }
                    }
                }

                if (chkViews.Checked)
                {
                    server.SetDefaultInitFields(typeof(Microsoft.SqlServer.Management.Smo.View), "IsSystemObject");
                    foreach (Microsoft.SqlServer.Management.Smo.View v in db.Views)
                    {
                        if (!v.IsSystemObject)
                        {
                            sbScript.Append(ScriptObject(new Urn[] { v.Urn }, scripter));
                        }
                    }
                }

                if (chkUserDefinedFunctions.Checked)
                {
                    server.SetDefaultInitFields(typeof(UserDefinedFunction), "IsSystemObject");
                    foreach (UserDefinedFunction udf in db.UserDefinedFunctions)
                    {
                        if (!udf.IsSystemObject)
                        {
                            sbScript.Append(ScriptObject(new Urn[] { udf.Urn }, scripter));
                        }
                    }
                }

                if (chkStoredProcedures.Checked)
                {
                    server.SetDefaultInitFields(typeof(StoredProcedure), "IsSystemObject");

                    foreach (StoredProcedure sp in db.StoredProcedures)
                    {
                        if (!sp.IsSystemObject)
                        {
                            sbScript.Append(ScriptObject(new Urn[] { sp.Urn }, scripter));
                        }
                    }
                }

                this.Invoke(new MethodInvoker(delegate
                {
                    richTextScript.Text = sbScript.ToString();
                }));

                Parse();
                //conn.Disconnect();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        delegate void SetProgressTextCallback(string text);

        private void SetProgressText(string text)
        {
            if (this.txtProgress.InvokeRequired)
            {
                SetProgressTextCallback d = new SetProgressTextCallback(SetProgressText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtProgress.Text = text;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
    }
}
