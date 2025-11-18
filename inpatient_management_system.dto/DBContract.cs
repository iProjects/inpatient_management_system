using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inpatient_management_system.dto
{
    public static class DBContract
    {
        public static String DATABASE_NAME = "inpatient_management_system_db";
        public static String SQLITE_DATABASE_NAME = "inpatient_management_system_db.sqlite3";

        public static String error = "error";
        public static String info = "info";
        public static String warn = "warn";

        public static String mssql = "mssql";
        public static String mysql = "mysql";
        public static String sqlite = "sqlite";
        public static String mongodb = "mongodb";
        public static String postgresql = "postgresql";


        //doctors table
        public static class doctors_entity_table
        {
            public static String TABLE_NAME = "tbl_doctors";
            //Columns of the table
            public static String ID = "id";
            public static String NAME = "name";
            public static String EMAIL = "email";
            public static String PHONE_NO = "phone_no";
            public static String ADDRESS = "address";
            public static String GENDER = "gender";
            public static String YEAR = "year";
            public static String MONTH = "month";
            public static String DAY = "day";
            public static String DEPARTMENT = "department";
            public static String TYPE = "type";
            public static String STATUS = "status";
            public static String CREATED_DATE = "created_date";

            //query
            public static String SELECT_ALL_QUERY = "SELECT * FROM " +
                                        DBContract.doctors_entity_table.TABLE_NAME;

            public static String SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
                                DBContract.doctors_entity_table.TABLE_NAME +
                                " where " +
                                DBContract.doctors_entity_table.STATUS +
                                " = " +
                                "'active'";

        }

        //users table
        public static class users_entity_table
        {
            public static String TABLE_NAME = "tbl_users";
            //Columns of the table
            public static String ID = "id";
            public static String EMAIL = "email";
            public static String PASSWORD = "password";
            public static String FULLNAMES = "fullnames";
            public static String DOB = "dob";
            public static String YEAR = "year";
            public static String MONTH = "month";
            public static String DAY = "day";
            public static String PASSWORD_SALT = "password_salt";
            public static String PASSWORD_HASH = "password_hash";
            public static String GENDER = "gender";
            public static String STATUS = "status";
            public static String CREATED_DATE = "created_date";

            //query
            public static String SELECT_ALL_QUERY = "SELECT * FROM " +
                                        DBContract.users_entity_table.TABLE_NAME;

            public static String SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
                                DBContract.users_entity_table.TABLE_NAME +
                                " where " +
                                DBContract.users_entity_table.STATUS +
                                " = " +
                                "'active'";

        }

        //logs table
        public static class logs_entity_table
        {
            public static String TABLE_NAME = "tbl_logs";
            //Columns of the table
            public static String ID = "id";
            public static String MESSAGE = "message";
            public static String TIMESTAMP = "timestamp";
            public static String TAG = "tag";
            public static String STATUS = "status";
            public static String CREATED_DATE = "created_date";

            //users query
            public static String SELECT_ALL_QUERY = "SELECT * FROM " +
                                        DBContract.logs_entity_table.TABLE_NAME;

            public static String SELECT_ALL_FILTER_QUERY = "SELECT * FROM " +
                                DBContract.logs_entity_table.TABLE_NAME +
                                " where " +
                                DBContract.logs_entity_table.STATUS +
                                " = " +
                                "'active'";

        }


        public static string[] table_names_arr = {
		    "tbl_buildings",
		    "tbl_houses",
            "tbl_users",
            "tbl_logs"
	    };

        public static string[] _entities = {
			"mssql", 
			"mysql",
			"postgresql", 
			"sqlite"
		};



    }
}
