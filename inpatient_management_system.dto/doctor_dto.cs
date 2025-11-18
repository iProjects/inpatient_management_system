using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace inpatient_management_system.dto
{
    public class doctor_dto
    {

        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Browsable(true)]
        public ObjectId mongodb_id { get; set; }
        public long id { get; set; }
        [Required(ErrorMessage = "Name cannot be null")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Email cannot be null")]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Phone No cannot be null")]
        [Display(Name = "Phone No")]
        public string phone_no { get; set; }
        [Required(ErrorMessage = "Department cannot be null")]
        [Display(Name = "Department")]
        public string address { get; set; }
        [Required(ErrorMessage = "Gender cannot be null")]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        public string dob { get; set; }
        [Required(ErrorMessage = "Year of Birth cannot be null")]
        [Display(Name = "Year of Birth")]
        public string year { get; set; }
        [Required(ErrorMessage = "Month of Birth cannot be null")]
        [Display(Name = "Month of Birth")]
        public string month { get; set; }
        [Required(ErrorMessage = "Day of Birth cannot be null")]
        [Display(Name = "Day of Birth")]
        public string day { get; set; }
        [Required(ErrorMessage = "Department cannot be null")]
        [Display(Name = "Department")]
        public string department { get; set; }
        [Required(ErrorMessage = "Type cannot be null")]
        [Display(Name = "Type")]
        public string type { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }

        public IEnumerable<SelectListItem> genders { get; set; }
        public IEnumerable<SelectListItem> years { get; set; }
        public IEnumerable<SelectListItem> months { get; set; }
        public IEnumerable<SelectListItem> days { get; set; }
        public IEnumerable<SelectListItem> departments { get; set; }
        public IEnumerable<SelectListItem> types { get; set; }

    }
}