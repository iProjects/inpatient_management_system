namespace SMOScripting
{
    partial class ScriptForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScriptForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkNoIdentities = new System.Windows.Forms.CheckBox();
            this.chkNoFileGroups = new System.Windows.Forms.CheckBox();
            this.chkNoCollation = new System.Windows.Forms.CheckBox();
            this.chkScriptDatabase = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboServerVersion = new System.Windows.Forms.ComboBox();
            this.cboDatabase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.chkTables = new System.Windows.Forms.CheckBox();
            this.chkUserDefinedFunctions = new System.Windows.Forms.CheckBox();
            this.chkViews = new System.Windows.Forms.CheckBox();
            this.chkStoredProcedures = new System.Windows.Forms.CheckBox();
            this.chkDBContext = new System.Windows.Forms.CheckBox();
            this.chkScriptDrop = new System.Windows.Forms.CheckBox();
            this.chkScriptIfNotExists = new System.Windows.Forms.CheckBox();
            this.chkScriptExtendedProperties = new System.Windows.Forms.CheckBox();
            this.chkScriptPermissions = new System.Windows.Forms.CheckBox();
            this.chkScriptHeaders = new System.Windows.Forms.CheckBox();
            this.btnScript = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtProgress = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextScript = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkNoIdentities);
            this.groupBox1.Controls.Add(this.chkNoFileGroups);
            this.groupBox1.Controls.Add(this.chkNoCollation);
            this.groupBox1.Controls.Add(this.chkScriptDatabase);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.chkDBContext);
            this.groupBox1.Controls.Add(this.chkScriptDrop);
            this.groupBox1.Controls.Add(this.chkScriptIfNotExists);
            this.groupBox1.Controls.Add(this.chkScriptExtendedProperties);
            this.groupBox1.Controls.Add(this.chkScriptPermissions);
            this.groupBox1.Controls.Add(this.chkScriptHeaders);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 151);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scripting Options";
            // 
            // chkNoIdentities
            // 
            this.chkNoIdentities.AutoSize = true;
            this.chkNoIdentities.Checked = true;
            this.chkNoIdentities.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoIdentities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkNoIdentities.Location = new System.Drawing.Point(518, 43);
            this.chkNoIdentities.Name = "chkNoIdentities";
            this.chkNoIdentities.Size = new System.Drawing.Size(112, 17);
            this.chkNoIdentities.TabIndex = 10;
            this.chkNoIdentities.Text = "Script No Identities";
            this.chkNoIdentities.UseVisualStyleBackColor = true;
            // 
            // chkNoFileGroups
            // 
            this.chkNoFileGroups.AutoSize = true;
            this.chkNoFileGroups.Checked = true;
            this.chkNoFileGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoFileGroups.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkNoFileGroups.Location = new System.Drawing.Point(518, 19);
            this.chkNoFileGroups.Name = "chkNoFileGroups";
            this.chkNoFileGroups.Size = new System.Drawing.Size(115, 17);
            this.chkNoFileGroups.TabIndex = 9;
            this.chkNoFileGroups.Text = "Script No FileGroup";
            this.chkNoFileGroups.UseVisualStyleBackColor = true;
            // 
            // chkNoCollation
            // 
            this.chkNoCollation.AutoSize = true;
            this.chkNoCollation.Checked = true;
            this.chkNoCollation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoCollation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkNoCollation.Location = new System.Drawing.Point(398, 43);
            this.chkNoCollation.Name = "chkNoCollation";
            this.chkNoCollation.Size = new System.Drawing.Size(110, 17);
            this.chkNoCollation.TabIndex = 8;
            this.chkNoCollation.Text = "Script No Collation";
            this.chkNoCollation.UseVisualStyleBackColor = true;
            // 
            // chkScriptDatabase
            // 
            this.chkScriptDatabase.AutoSize = true;
            this.chkScriptDatabase.Checked = true;
            this.chkScriptDatabase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScriptDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkScriptDatabase.Location = new System.Drawing.Point(398, 19);
            this.chkScriptDatabase.Name = "chkScriptDatabase";
            this.chkScriptDatabase.Size = new System.Drawing.Size(99, 17);
            this.chkScriptDatabase.TabIndex = 7;
            this.chkScriptDatabase.Text = "Script Database";
            this.chkScriptDatabase.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboServerVersion);
            this.groupBox2.Controls.Add(this.cboDatabase);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblDatabase);
            this.groupBox2.Controls.Add(this.chkTables);
            this.groupBox2.Controls.Add(this.chkUserDefinedFunctions);
            this.groupBox2.Controls.Add(this.chkViews);
            this.groupBox2.Controls.Add(this.chkStoredProcedures);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(661, 82);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Objects";
            // 
            // cboServerVersion
            // 
            this.cboServerVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboServerVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboServerVersion.FormattingEnabled = true;
            this.cboServerVersion.Location = new System.Drawing.Point(395, 51);
            this.cboServerVersion.Name = "cboServerVersion";
            this.cboServerVersion.Size = new System.Drawing.Size(180, 21);
            this.cboServerVersion.TabIndex = 6;
            // 
            // cboDatabase
            // 
            this.cboDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(395, 18);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Size = new System.Drawing.Size(180, 21);
            this.cboDatabase.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Version:";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(336, 21);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(56, 13);
            this.lblDatabase.TabIndex = 7;
            this.lblDatabase.Text = "Database:";
            // 
            // chkTables
            // 
            this.chkTables.AutoSize = true;
            this.chkTables.Checked = true;
            this.chkTables.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkTables.Location = new System.Drawing.Point(152, 42);
            this.chkTables.Name = "chkTables";
            this.chkTables.Size = new System.Drawing.Size(55, 17);
            this.chkTables.TabIndex = 4;
            this.chkTables.Text = "Tables";
            this.chkTables.UseVisualStyleBackColor = true;
            // 
            // chkUserDefinedFunctions
            // 
            this.chkUserDefinedFunctions.AutoSize = true;
            this.chkUserDefinedFunctions.Checked = true;
            this.chkUserDefinedFunctions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserDefinedFunctions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUserDefinedFunctions.Location = new System.Drawing.Point(152, 19);
            this.chkUserDefinedFunctions.Name = "chkUserDefinedFunctions";
            this.chkUserDefinedFunctions.Size = new System.Drawing.Size(134, 17);
            this.chkUserDefinedFunctions.TabIndex = 3;
            this.chkUserDefinedFunctions.Text = "User Defined Functions";
            this.chkUserDefinedFunctions.UseVisualStyleBackColor = true;
            // 
            // chkViews
            // 
            this.chkViews.AutoSize = true;
            this.chkViews.Checked = true;
            this.chkViews.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViews.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkViews.Location = new System.Drawing.Point(6, 42);
            this.chkViews.Name = "chkViews";
            this.chkViews.Size = new System.Drawing.Size(51, 17);
            this.chkViews.TabIndex = 2;
            this.chkViews.Text = "Views";
            this.chkViews.UseVisualStyleBackColor = true;
            // 
            // chkStoredProcedures
            // 
            this.chkStoredProcedures.AutoSize = true;
            this.chkStoredProcedures.Checked = true;
            this.chkStoredProcedures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStoredProcedures.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkStoredProcedures.Location = new System.Drawing.Point(6, 19);
            this.chkStoredProcedures.Name = "chkStoredProcedures";
            this.chkStoredProcedures.Size = new System.Drawing.Size(111, 17);
            this.chkStoredProcedures.TabIndex = 1;
            this.chkStoredProcedures.Text = "Stored Procedures";
            this.chkStoredProcedures.UseVisualStyleBackColor = true;
            // 
            // chkDBContext
            // 
            this.chkDBContext.AutoSize = true;
            this.chkDBContext.Checked = true;
            this.chkDBContext.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDBContext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDBContext.Location = new System.Drawing.Point(279, 43);
            this.chkDBContext.Name = "chkDBContext";
            this.chkDBContext.Size = new System.Drawing.Size(107, 17);
            this.chkDBContext.TabIndex = 5;
            this.chkDBContext.Text = "Script DB Context";
            this.chkDBContext.UseVisualStyleBackColor = true;
            // 
            // chkScriptDrop
            // 
            this.chkScriptDrop.AutoSize = true;
            this.chkScriptDrop.Checked = true;
            this.chkScriptDrop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScriptDrop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkScriptDrop.Location = new System.Drawing.Point(279, 19);
            this.chkScriptDrop.Name = "chkScriptDrop";
            this.chkScriptDrop.Size = new System.Drawing.Size(84, 17);
            this.chkScriptDrop.TabIndex = 4;
            this.chkScriptDrop.Text = "Script DROP";
            this.chkScriptDrop.UseVisualStyleBackColor = true;
            // 
            // chkScriptIfNotExists
            // 
            this.chkScriptIfNotExists.AutoSize = true;
            this.chkScriptIfNotExists.Checked = true;
            this.chkScriptIfNotExists.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScriptIfNotExists.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkScriptIfNotExists.Location = new System.Drawing.Point(122, 43);
            this.chkScriptIfNotExists.Name = "chkScriptIfNotExists";
            this.chkScriptIfNotExists.Size = new System.Drawing.Size(129, 17);
            this.chkScriptIfNotExists.TabIndex = 3;
            this.chkScriptIfNotExists.Text = "Script IF NOT EXISTS";
            this.chkScriptIfNotExists.UseVisualStyleBackColor = true;
            // 
            // chkScriptExtendedProperties
            // 
            this.chkScriptExtendedProperties.AutoSize = true;
            this.chkScriptExtendedProperties.Checked = true;
            this.chkScriptExtendedProperties.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScriptExtendedProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkScriptExtendedProperties.Location = new System.Drawing.Point(122, 19);
            this.chkScriptExtendedProperties.Name = "chkScriptExtendedProperties";
            this.chkScriptExtendedProperties.Size = new System.Drawing.Size(148, 17);
            this.chkScriptExtendedProperties.TabIndex = 2;
            this.chkScriptExtendedProperties.Text = "Script Extended Properties";
            this.chkScriptExtendedProperties.UseVisualStyleBackColor = true;
            // 
            // chkScriptPermissions
            // 
            this.chkScriptPermissions.AutoSize = true;
            this.chkScriptPermissions.Checked = true;
            this.chkScriptPermissions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScriptPermissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkScriptPermissions.Location = new System.Drawing.Point(7, 43);
            this.chkScriptPermissions.Name = "chkScriptPermissions";
            this.chkScriptPermissions.Size = new System.Drawing.Size(108, 17);
            this.chkScriptPermissions.TabIndex = 1;
            this.chkScriptPermissions.Text = "Script Permissions";
            this.chkScriptPermissions.UseVisualStyleBackColor = true;
            // 
            // chkScriptHeaders
            // 
            this.chkScriptHeaders.AutoSize = true;
            this.chkScriptHeaders.Checked = true;
            this.chkScriptHeaders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScriptHeaders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkScriptHeaders.Location = new System.Drawing.Point(7, 20);
            this.chkScriptHeaders.Name = "chkScriptHeaders";
            this.chkScriptHeaders.Size = new System.Drawing.Size(93, 17);
            this.chkScriptHeaders.TabIndex = 0;
            this.chkScriptHeaders.Text = "Script Headers";
            this.chkScriptHeaders.UseVisualStyleBackColor = true;
            // 
            // btnScript
            // 
            this.btnScript.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScript.Location = new System.Drawing.Point(442, 20);
            this.btnScript.Name = "btnScript";
            this.btnScript.Size = new System.Drawing.Size(75, 23);
            this.btnScript.TabIndex = 0;
            this.btnScript.Text = "Script";
            this.btnScript.UseVisualStyleBackColor = false;
            this.btnScript.Click += new System.EventHandler(this.btnScript_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnScript);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 459);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(667, 62);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(555, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 151);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(667, 308);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtProgress);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(659, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Progress";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtProgress
            // 
            this.txtProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProgress.Location = new System.Drawing.Point(3, 3);
            this.txtProgress.Multiline = true;
            this.txtProgress.Name = "txtProgress";
            this.txtProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProgress.Size = new System.Drawing.Size(653, 276);
            this.txtProgress.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextScript);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(659, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Script";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextScript
            // 
            this.richTextScript.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextScript.Location = new System.Drawing.Point(3, 3);
            this.richTextScript.Name = "richTextScript";
            this.richTextScript.Size = new System.Drawing.Size(653, 276);
            this.richTextScript.TabIndex = 0;
            this.richTextScript.Text = "";
            // 
            // ScriptForm
            // 
            this.AcceptButton = this.btnScript;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LimeGreen;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(667, 521);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScriptForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Script";
            this.Load += new System.EventHandler(this.ScriptForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkScriptPermissions;
        private System.Windows.Forms.CheckBox chkScriptHeaders;
        private System.Windows.Forms.CheckBox chkDBContext;
        private System.Windows.Forms.CheckBox chkScriptDrop;
        private System.Windows.Forms.CheckBox chkScriptIfNotExists;
        private System.Windows.Forms.CheckBox chkScriptExtendedProperties;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkTables;
        private System.Windows.Forms.CheckBox chkUserDefinedFunctions;
        private System.Windows.Forms.CheckBox chkViews;
        private System.Windows.Forms.CheckBox chkStoredProcedures;
        private System.Windows.Forms.Button btnScript;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDatabase;
        private System.Windows.Forms.ComboBox cboServerVersion;
        private System.Windows.Forms.ComboBox cboDatabase;
        private System.Windows.Forms.CheckBox chkScriptDatabase;
        private System.Windows.Forms.CheckBox chkNoCollation;
        private System.Windows.Forms.CheckBox chkNoFileGroups;
        private System.Windows.Forms.CheckBox chkNoIdentities;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtProgress;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextScript;
        private System.Windows.Forms.Button btnClose;
    }
}

