using inpatient_management_system.business;
using inpatient_management_system.commonlib;
using inpatient_management_system.ui.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace inpatient_management_system.ui.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        //list to hold messages
        public List<notificationdto> _lstnotificationdto = new List<notificationdto>();

        public MvcApplication()
        {
            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new
UnhandledExceptionEventHandler(UnhandledException);
            System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished MvcApplication initialization", TAG));

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            set_up_databases();

        }
        public void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

            var assembly_version = Assembly.GetAssembly(typeof(MvcApplication)).GetName().Version.ToString();
            //var dll_ver = System.Reflection.Assembly.GetAssembly(typeof(MvcApplication)).GetName().Version.ToString();
            Session.Add("version", assembly_version);

            set_up_databases();

        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Log.Write_To_Log_File_web(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }

        private void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            Log.Write_To_Log_File_web(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }

        //Event handler declaration:
        private void notificationmessageHandler(object sender, notificationmessageEventArgs args)
        {
            try
            {
                /* Handler logic */
                notificationdto _notificationdto = new notificationdto();

                DateTime currentDate = DateTime.Now;
                String dateTimenow = currentDate.ToString("dd-MM-yyyy HH:mm:ss tt");

                String _logtext = Environment.NewLine + "[ " + dateTimenow + " ]   " + args.message;

                _notificationdto._notification_message = _logtext;
                _notificationdto._created_datetime = dateTimenow;
                _notificationdto.TAG = args.TAG;

                _lstnotificationdto.Add(_notificationdto);

                var _lstmsgdto = from msgdto in _lstnotificationdto
                                 orderby msgdto._created_datetime descending
                                 select msgdto._notification_message;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void set_up_databases()
        {
            try
            {
                List<responsedto> _lstresponse = businesslayerapisingleton.getInstance(_notificationmessageEventname).set_up_databases();

                foreach (var response in _lstresponse)
                {
                    if (!string.IsNullOrEmpty(response.responsesuccessmessage))
                    {
                        Console.WriteLine(response.responsesuccessmessage);
                        helper_utils.getInstance(_notificationmessageEventname).log_messages(response.responsesuccessmessage, TAG);
                    }
                    if (!string.IsNullOrEmpty(response.responseerrormessage))
                    {
                        Console.WriteLine(response.responseerrormessage);
                        helper_utils.getInstance(_notificationmessageEventname).log_messages(response.responseerrormessage, TAG);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }







    }
}
