using inpatient_management_system.business;
using inpatient_management_system.commonlib;
using inpatient_management_system.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inpatient_management_system.ui.web.Models
{
    public sealed class helper_utils
    {
        // Because the _instance member is made private, the only way to get the single
        // instance is via the static Instance property below. This can also be similarly
        // achieved with a GetInstance() method instead of the property.
        private static helper_utils singleInstance;

        public static helper_utils getInstance(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            // The first call will create the one and only instance.
            if (singleInstance == null)
                singleInstance = new helper_utils(notificationmessageEventname);
            // Every call afterwards will return the single instance created above.
            return singleInstance;
        }
        public helper_utils()
        {

        }
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        public helper_utils(EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            _notificationmessageEventname = notificationmessageEventname;
        }
        public void log_messages(string message, string TAG)
        {
            notificationdto _notificationdto = new notificationdto();
            DateTime currentDate = DateTime.Now;
            String dateTimenow = currentDate.ToString("dd-MM-yyyy HH:mm:ss tt");

            String _logtext = Environment.NewLine + "[ " + dateTimenow + " ]   " + message;

            _notificationdto._notification_message = _logtext;
            _notificationdto._created_datetime = dateTimenow;
            _notificationdto.TAG = TAG;

            create_log_in_database(_notificationdto);
        }
        private void create_log_in_database(notificationdto _notificationdto)
        {
            try
            {
                log_dto dto = new log_dto();
                dto.message = _notificationdto._notification_message;
                dto.timestamp = _notificationdto._created_datetime;
                dto.tag = _notificationdto.TAG;

                //save data in database.
                List<responsedto> _lstresponse = new List<responsedto>();
                _lstresponse = businesslayerapisingleton.getInstance(_notificationmessageEventname).create_log_in_database(dto);

                foreach (var response in _lstresponse)
                {
                    if (!string.IsNullOrEmpty(response.responsesuccessmessage))
                    {
                        Console.WriteLine(response.responsesuccessmessage);
                    }
                    if (!string.IsNullOrEmpty(response.responseerrormessage))
                    {
                        Console.WriteLine(response.responseerrormessage);
                    }
                }

                Write_To_Log_File_web(_notificationdto._notification_message);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void Write_To_Log_File_web(string msg)
        {
            try
            {
                Log.Write_To_Log_File_web(new Exception(msg));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }




    }
}