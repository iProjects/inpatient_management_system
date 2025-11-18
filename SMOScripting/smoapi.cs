/*
 * Created by SharpDevelop.
 * User: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 11/28/2018
 * Time: 05:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;

namespace SMOScripting
{
    /// <summary>
    /// Description of smoapi.
    /// </summary>
    public class smoapi
    {
        private Server server;

        public smoapi()
        {

        }

        mssql_connection_string_dto getconnectionobjectwithdefaults()
        {

            mssql_connection_string_dto _connectionstringdto = new mssql_connection_string_dto();

            _connectionstringdto.datasource = System.Configuration.ConfigurationManager.AppSettings["mssql_datasource"];
            _connectionstringdto.database = System.Configuration.ConfigurationManager.AppSettings["mssql_database"];
            _connectionstringdto.userid = System.Configuration.ConfigurationManager.AppSettings["mssql_userid"];
            _connectionstringdto.password = System.Configuration.ConfigurationManager.AppSettings["mssql_password"];
            _connectionstringdto.port = System.Configuration.ConfigurationManager.AppSettings["mssql_port"];

            return _connectionstringdto;

        }

        string buildconnectionstringfromobject(mssql_connection_string_dto _connectionstringdto)
        {
            string CONNECTION_STRING = @"Data Source=" + _connectionstringdto.datasource + ";" +
            "Database=" + _connectionstringdto.database + ";" +
            "User Id=" + _connectionstringdto.userid + ";" +
            "Password=" + _connectionstringdto.password;
            return CONNECTION_STRING;
        }

        public Server buildserver()
        {
            mssql_connection_string_dto _connectionstringdto = getconnectionobjectwithdefaults();

            if (_connectionstringdto == null) return null;

            ServerConnection conn = new ServerConnection(_connectionstringdto.datasource, _connectionstringdto.userid, _connectionstringdto.password);

            server = new Server(conn);

            return server;

        }

        public List<database_names_dto> getdtodatabases()
        {
            //			try{

            Server server = buildserver();

            if (server == null) return null;

            List<database_names_dto> server_databases = new List<database_names_dto>();

            foreach (Database database in server.Databases)
            {
                database_names_dto _dto = new database_names_dto();
                _dto.setdatabase_name(database.Name);
                server_databases.Add(_dto);
            }

            return server_databases;

            //		 	}catch(Exception ex){  
            //				loggerutility(ex.Message);
            //				return null;
            //			}
        }

        public List<string> getdatabases()
        {
            //			try{

            Server server = buildserver();

            if (server == null) return null;

            List<string> server_databases = new List<string>();

            foreach (Database database in server.Databases)
            {
                server_databases.Add(database.Name);
            }

            return server_databases;

            //		 	}catch(Exception ex){  
            //				loggerutility(ex.Message);
            //				return null;
            //			}
        }

        public string getappsettinggivenkey(string key = "", string defaultvalue = "")
        {
            //			try{

            string configvalue = "";

            configvalue = System.Configuration.ConfigurationManager.AppSettings[key];

            if (configvalue == null || String.IsNullOrEmpty(configvalue))
            {
                return defaultvalue;
            }
            else
            {
                return configvalue;
            }

            //			}catch(Exception ex){  
            //				loggerutility(ex.Message);
            //				return defaultvalue;
            //			}
        }

        void loggerutility(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }







    }








}
