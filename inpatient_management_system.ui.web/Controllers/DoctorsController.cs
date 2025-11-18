using inpatient_management_system.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using inpatient_management_system.commonlib;
using System.Threading;
using inpatient_management_system.ui.web.Models;
using System.Data;
using inpatient_management_system.business;

namespace inpatient_management_system.ui.web.Controllers
{
    public class DoctorsController : Controller
    {
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        //list to hold messages
        public List<notificationdto> _lstnotificationdto = new List<notificationdto>();
        
        public DoctorsController()
        {
            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new
UnhandledExceptionEventHandler(UnhandledException);
            System.Windows.Forms.Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished DoctorsController initialization", TAG));

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
        public ActionResult Index([Bind] doctor_dto search_model)
        {
            try
            {
                doctor_dto dto = new doctor_dto();
                doctors_view_model model = new doctors_view_model();
                List<doctor_dto> _lst_dtos = new List<doctor_dto>();

                _lst_dtos = populate_dtos(_lst_dtos);

                if (_lst_dtos != null)
                {
                    Console.WriteLine("Doctors count: " + _lst_dtos.Count());
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

        private List<doctor_dto> populate_dtos(List<doctor_dto> _lst_dtos)
        {
            DataTable dt = null;
            string query = "";
            bool showinactive = true;
            string server = "sqlite"; //selected_server.Key;

            if (showinactive)
            {
                query = DBContract.doctors_entity_table.SELECT_ALL_QUERY;
            }
            else
            {
                query = DBContract.doctors_entity_table.SELECT_ALL_FILTER_QUERY;
            }

            dt = businesslayerapisingleton.getInstance(_notificationmessageEventname).get_doctors(showinactive, query, DBContract.sqlite);

            if (dt != null)
            {
                _lst_dtos = utilzsingleton.getInstance(_notificationmessageEventname).Convert_DataTable_To_list<doctor_dto>(dt);
                _lst_dtos = _lst_dtos.OrderByDescending(i => i.id).ThenBy(t => t.name).ToList();

                Console.WriteLine("Doctors count: " + _lst_dtos.Count());
            }
            else
            {
                return null;
            }

            return _lst_dtos;
        }

        private doctor_dto populate_model(doctor_dto model)
        {
            List<SelectListItem> departments = new List<SelectListItem>();

            Dictionary<string, string> departments_dict = new Dictionary<string, string>()
            { 
                {"General Practitioner","General Practitioner"},
                {"Cardiologist","Cardiologist"}, 
                {"Dermatologist","Dermatologist"},
                {"Anesthesiologist","Anesthesiologist"},
                {"Psychiatrist","Psychiatrist"},
                {"Emergency Medical Physicians","Emergency Medical Physicians"},
                {"Gynecologist","Gynecologist"}, 
                {"Radiologist","Radiologist"},
                {"Podiatrist","Podiatrist"},
                {"Oncologist","Oncologist"},
                {"Immunologist","Immunologist"},
                {"Neurologist","Neurologist"},  
            };

            SelectListItem slim = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Type ---"
            };
             
            foreach (KeyValuePair<string, string> doctor_type in departments_dict)
            {
                SelectListItem sli = new SelectListItem()
                {
                    Value = doctor_type.Key,
                    Text = doctor_type.Value
                };
                departments.Add(sli);
            }

            departments.Insert(0, slim);

            model.departments = departments;

            return model;
        }

        [HttpPost]
        public JsonResult search([Bind] doctor_dto search_model)
        {
            doctor_dto dto = new doctor_dto();
            doctors_view_model model = new doctors_view_model();
            DataTable dt = null;
            List<doctor_dto> _lst_dtos = new List<doctor_dto>();

            dt = businesslayerapisingleton.getInstance(_notificationmessageEventname).search_doctors_in_database(search_model);

            if (dt != null)
            {
                _lst_dtos = utilzsingleton.getInstance(_notificationmessageEventname).Convert_DataTable_To_list<doctor_dto>(dt);
                _lst_dtos = _lst_dtos.OrderByDescending(i => i.id).ThenBy(t => t.name).ToList();

                Console.WriteLine("Doctors count: " + _lst_dtos.Count());
                TempData["success_message"] = "Retrieved [ " + _lst_dtos.Count() + " ] records.";
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("Retrieved [ " + _lst_dtos.Count() + " ] records.", TAG));
                helper_utils.getInstance(_notificationmessageEventname).log_messages("Retrieved [ " + _lst_dtos.Count() + " ] records.", TAG);
            }
            else
            {
                model.lst_dto = _lst_dtos;
                model.dto = populate_model(dto);

                TempData["error_message"] = "Error retrieving data.";
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("Error retrieving data.", TAG));
                helper_utils.getInstance(_notificationmessageEventname).log_messages("Error retrieving data.", TAG);
                return Json(model);
            }

            model.lst_dto = _lst_dtos;
            model.dto = populate_model(dto);

            //Display the records
            return Json(model);

        }

        //
        // GET: /doctor/Create
        public ActionResult Create()
        {
            doctor_dto model = new doctor_dto();
            model = populate_model(model);

            return View(model);
        }

        //
        // POST: /doctor/Create
        [HttpPost]
        public ActionResult Create([Bind] doctor_dto model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.name))
                {
                    ModelState.AddModelError("Name", "Name is required");
                }
                if (string.IsNullOrEmpty(model.address))
                {
                    ModelState.AddModelError("Address", "Address is required");
                }
                if (string.IsNullOrEmpty(model.type))
                {
                    ModelState.AddModelError("Type", "Type is required");
                }

                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    doctor_dto dto = new doctor_dto();
                    dto.name = Utils.ConvertFirstLetterToUpper(model.name);
                    dto.address = Utils.ConvertFirstLetterToUpper(model.address);
                    dto.type = model.type;
                    dto.status = "active";
                    dto.created_date = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");

                    //save data in database.
                    List<responsedto> _lstresponse = businesslayerapisingleton.getInstance(_notificationmessageEventname).create_doctor_in_database(dto);

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
                else
                {
                    TempData["error_message"] = "Validation Error.";
                    helper_utils.getInstance(_notificationmessageEventname).log_messages("Validation Error.", TAG);
                    model = populate_model(model);
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["error_message"] = ex.ToString();
                helper_utils.getInstance(_notificationmessageEventname).log_messages(ex.ToString(), TAG);
                model = populate_model(model);
                return View(model);
            }
        }

        //
        // GET: /doctor/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            doctor_dto model = new doctor_dto();
            //model = mysql_api.getInstance().get_doctor_given_id(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        //
        // GET: /doctor/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            doctor_dto model = new doctor_dto();
            //model = mysql_api.getInstance().get_doctor_given_id(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            List<string> departments = new List<string>();
            departments.Add("General Practitioner");
            departments.Add("Cardiologist");
            departments.Add("Dermatologist");
            departments.Add("Anesthesiologist");
            departments.Add("Psychiatrist");
            departments.Add("Emergency Medical Physicians");
            departments.Add("Gynecologist");
            departments.Add("Radiologist");
            departments.Add("Podiatrist");
            departments.Add("Oncologist");
            departments.Add("Immunologist");
            departments.Add("Neurologist");
            departments.Add("Surgeon");

            List<string> statuses = new List<string>();
            statuses.Add("active");
            statuses.Add("inactive");

            //model.departments = departments.ToList();
            //model.statuses = statuses.ToList();

            return View(model);
        }

        //
        // POST: /doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(doctor_dto model)
        {
            try
            {
                // TODO: Add update logic here
                if (string.IsNullOrEmpty(model.name))
                {
                    ModelState.AddModelError("names", "name is required");
                }
                if (string.IsNullOrEmpty(model.email))
                {
                    ModelState.AddModelError("email", "email is required");
                }
                if (string.IsNullOrEmpty(model.phone_no))
                {
                    ModelState.AddModelError("phone_no", "phone_no is required");
                }
                if (string.IsNullOrEmpty(model.department))
                {
                    ModelState.AddModelError("department", "department is required");
                }
                if (string.IsNullOrEmpty(model.address))
                {
                    ModelState.AddModelError("address", "address is required");
                }
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    //mysql_api.getInstance().update_doctor(model);
                    return RedirectToAction("list");

                }
                else
                {
                    return View(model);
                }
            }
            catch
            {
                ModelState.AddModelError("", "Error occured during updating of record.");
                return View(model);
            }
        }

        //
        // GET: /doctor/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            doctor_dto model = new doctor_dto();
            //model = mysql_api.getInstance().get_doctor_given_id(id);

            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        //
        // POST: /doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int doctor_id, FormCollection model)
        {
            try
            {
                // TODO: Add delete logic here

                if (doctor_id == null)
                {
                    ModelState.AddModelError("", "invalid model.");
                    return View(model);
                }

                //responsedto results = mysql_api.getInstance().delete_doctor(doctor_id);
                //ModelState.AddModelError("", results.ToString());

                return RedirectToAction("list");
            }
            catch
            {
                ModelState.AddModelError("", "Error occured during deleting of record.");
                return View(model);
            }
        }



    }

}
