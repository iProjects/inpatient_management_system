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
	public class database_names_dto
	{
		private string database_name;
		
		public database_names_dto(){}
		
		public string getdatabase_name(){
			return database_name;
		}
		
		public void setdatabase_name(string _database_name){
			database_name = _database_name;
		}
		
	}
}
