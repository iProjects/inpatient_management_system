using inpatient_management_system.business;
using inpatient_management_system.commonlib;
using inpatient_management_system.dto;
using inpatient_management_system.ui.web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace inpatient_management_system.ui.web.Controllers
{
    public class LogsController : Controller
    {
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        //list to hold messages
        public List<notificationdto> _lstnotificationdto = new List<notificationdto>();

        public LogsController()
        {
            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new
UnhandledExceptionEventHandler(UnhandledException);
            System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished LogsController initialization", TAG));

        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //set_up_databases();
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // GET: /doctors/
        public ActionResult Index([Bind] log_dto search_model)
        {
            try
            {
                log_dto dto = new log_dto();
                logs_view_model model = new logs_view_model();
                List<log_dto> _lst_dtos = new List<log_dto>();

                _lst_dtos = populate_dtos(_lst_dtos);

                if (_lst_dtos != null)
                {
                    Console.WriteLine("Logs count: " + _lst_dtos.Count());
                    TempData["success_message"] = "Retrieved [ " + _lst_dtos.Count() + " ] records.";
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("Retrieved [ " + _lst_dtos.Count() + " ] records.", TAG));
                    helper_utils.getInstance(_notificationmessageEventname).log_messages("Retrieved [ " + _lst_dtos.Count() + " ] records.", TAG);
                }
                else
                {
                    model.dto = populate_model(dto);
                    TempData["error_message"] = "Error retrieving data.";
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("Error retrieving data.", TAG));
                    helper_utils.getInstance(_notificationmessageEventname).log_messages("Error retrieving data.", TAG);
                    return View();
                }

                model.lst_dto = _lst_dtos;
                model.dto = populate_model(dto);

                //Display the records
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["error_message"] = ex.ToString();
                helper_utils.getInstance(_notificationmessageEventname).log_messages(ex.ToString(), TAG);
                error_handler_view_model error_model = new error_handler_view_model();
                error_model.ex = ex;
                return View("Error_View", error_model);
            }
        }

        private List<log_dto> populate_dtos(List<log_dto> _lst_dtos)
        {
            DataTable dt = null;
            string query = "";
            bool showinactive = true;

            if (showinactive)
            {
                query = DBContract.logs_entity_table.SELECT_ALL_QUERY;
            }
            else
            {
                query = DBContract.logs_entity_table.SELECT_ALL_FILTER_QUERY;
            }

            dt = businesslayerapisingleton.getInstance(_notificationmessageEventname).get_logs(showinactive, query, DBContract.sqlite);

            if (dt != null)
            {
                _lst_dtos = utilzsingleton.getInstance(_notificationmessageEventname).Convert_DataTable_To_list<log_dto>(dt);
                _lst_dtos = _lst_dtos.OrderByDescending(i => i.id).ThenBy(t => t.message).ToList();

                Console.WriteLine("Logs count: " + _lst_dtos.Count());
            }
            else
            {
                return null;
            }

            return _lst_dtos;
        }

        private log_dto populate_model(log_dto model)
        {
            return model;
        }


        // GET: Logs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Logs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Logs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Logs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Logs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Logs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
