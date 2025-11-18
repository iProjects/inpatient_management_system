/*
 * Created by: "kevin mutugi, kevinmk30@gmail.com, +254717769329"
 * Date: 04/04/2020
 * Time: 01:58
 */
using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using inpatient_management_system.dto;

namespace inpatient_management_system.commonlib
{
    /// <summary>
    /// Description of utilzsingleton.
    /// </summary>
    public sealed class utilzsingleton
    {
        // Because the _instance member is made private, the only way to get the single
        // instance is via the static Instance property below. This can also be similarly
        // achieved with a GetInstance() method instead of the property. 
        private static utilzsingleton singleInstance;

        public static utilzsingleton getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            // The first call will create the one and only instance.
            if (singleInstance == null)
                singleInstance = new utilzsingleton(notificationmessageEventname);
            // Every call afterwards will return the single instance created above.
            return singleInstance;
        }

        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        public string TAG;

        private utilzsingleton(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            TAG = this.GetType().Name;
            _notificationmessageEventname = notificationmessageEventname;
        }

        private utilzsingleton()
        {

        }

        public Color AlternatingRowsDefaultCellStyleBackColor = Color.Chocolate;
        public Color AlternatingRowsDefaultCellStyleForeColor = Color.White;

        public Color DefaultCellStyleBackColor = Color.DarkMagenta;
        public Color DefaultCellStyleForeColor = Color.WhiteSmoke;

        public string CryptographyMD5(string source)
        {
            // Creates an instance of the default implementation of the MD5 hash algorithm.
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(source);
                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);
                // Convert hash byte array to string
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
                // Output the MD5 hash
                Console.WriteLine("The MD5 hash of " + source + " is: " + hash);
                return hash;
            }
        }

        public string CryptographySHA1(string source)
        {
            using (SHA1 sha1Hash = SHA1.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                Console.WriteLine("The SHA1 hash of " + source + " is: " + hash);
                return hash;
            }
        }

        public string CryptographySHA256(string source)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                Console.WriteLine("The SHA256 hash of " + source + " is: " + hash);
                return hash;
            }
        }

        public string CryptographySHA384(string source)
        {
            using (SHA384 sha384Hash = SHA384.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha384Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                Console.WriteLine("The SHA384 hash of " + source + " is: " + hash);
                return hash;
            }
        }

        public string CryptographySHA512(string source)
        {
            using (SHA512 sha512Hash = SHA512.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                Console.WriteLine("The SHA512 hash of " + source + " is: " + hash);
                return hash;
            }
        }

        public static byte[] GenerateRandomData(int length)
        {
            var rnd = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(rnd);
            return rnd;
        }

        public static int GenerateRandomInt(int minVal = 0, int maxVal = 100)
        {
            var rnd = new byte[4];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(rnd);
            var i = Math.Abs(BitConverter.ToInt32(rnd, 0));
            return Convert.ToInt32(i % (maxVal - minVal + 1) + minVal);
        }

        public static string GenerateRandomString(int length, string allowableChars = null)
        {
            if (string.IsNullOrEmpty(allowableChars))
                allowableChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            // Generate random data
            var rnd = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(rnd);
            // Generate the output string
            var allowable = allowableChars.ToCharArray();
            var l = allowable.Length;
            var chars = new char[length];
            for (var i = 0; i < length; i++)
                chars[i] = allowable[rnd[i] % l];
            return new string(chars);
        }

        public string getappsettinggivenkey(string key = "", string defaultvalue = "")
        {
            try
            {

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

            }
            catch (Exception ex)
            {
                this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.Message, this.TAG));
                return defaultvalue;
            }
        }

        public doctor_dto build_doctors_dto_given_datatable(DataTable dt, int _index)
        {
            doctor_dto _dto = new doctor_dto();
            _dto.id = Convert.ToInt64(dt.Rows[_index]["id"]);
            _dto.name = Convert.ToString(dt.Rows[_index]["name"]);
            _dto.email = Convert.ToString(dt.Rows[_index]["email"]);
            _dto.phone_no = Convert.ToString(dt.Rows[_index]["phone_no"]);
            _dto.address = Convert.ToString(dt.Rows[_index]["address"]);
            _dto.gender = Convert.ToString(dt.Rows[_index]["gender"]);
            _dto.year = Convert.ToString(dt.Rows[_index]["year"]);
            _dto.month = Convert.ToString(dt.Rows[_index]["month"]);
            _dto.day = Convert.ToString(dt.Rows[_index]["day"]);
            _dto.department = Convert.ToString(dt.Rows[_index]["department"]);
            _dto.type = Convert.ToString(dt.Rows[_index]["type"]);
            _dto.status = Convert.ToString(dt.Rows[_index]["status"]);
            _dto.created_date = Convert.ToString(dt.Rows[_index]["created_date"]);

            return _dto;
        }

        public user_dto build_users_dto_given_datatable(DataTable dt, int _index)
        {
            user_dto _dto = new user_dto();
            _dto.id = Convert.ToInt64(dt.Rows[_index]["id"]);
            _dto.email = Convert.ToString(dt.Rows[_index]["email"]);
            _dto.password = Convert.ToString(dt.Rows[_index]["password"]);
            _dto.fullnames = Convert.ToString(dt.Rows[_index]["fullnames"]);
            _dto.year = Convert.ToString(dt.Rows[_index]["year"]);
            _dto.month = Convert.ToString(dt.Rows[_index]["month"]);
            _dto.day = Convert.ToString(dt.Rows[_index]["day"]);
            _dto.gender = Convert.ToString(dt.Rows[_index]["gender"]);
            _dto.status = Convert.ToString(dt.Rows[_index]["status"]);
            _dto.created_date = Convert.ToString(dt.Rows[_index]["created_date"]);

            return _dto;
        }
        public log_dto build_logs_dto_given_datatable(DataTable dt, int _index)
        {
            log_dto _dto = new log_dto();
            _dto.id = Convert.ToInt64(dt.Rows[_index]["id"]);
            _dto.message = Convert.ToString(dt.Rows[_index]["message"]);
            _dto.timestamp = Convert.ToString(dt.Rows[_index]["timestamp"]);
            _dto.tag = Convert.ToString(dt.Rows[_index]["tag"]);
            _dto.status = Convert.ToString(dt.Rows[_index]["status"]);
            _dto.created_date = Convert.ToString(dt.Rows[_index]["created_date"]);

            return _dto;
        }
        public DataTable Convert_List_To_Datatable<T>(List<T> data)
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }

            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public List<T> Convert_DataTable_To_list<T>(DataTable dt)
        {
            if (dt == null) return null;
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item;
                try
                {
                    item = GetItem<T>(row);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    continue;
                }
                data.Add(item);
            }
            return data;
        }

        private T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (dr[column.ColumnName] == null || dr[column.ColumnName] == DBNull.Value)
                    {
                        continue;
                    }

                    if (pro == null)
                    {
                        continue;
                    }
                    if (obj == null)
                    {
                        continue;
                    }

                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }





    }
}
