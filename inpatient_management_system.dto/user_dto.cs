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
    public class user_dto
    {
        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Browsable(true)]
        public ObjectId mongodb_id { get; set; }
        public long id { get; set; }
        [Required(ErrorMessage = "Email cannot be null.")]
        [RegularExpression(@"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", ErrorMessage = "Not a valid Email")]
        [Display(Name = "Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Password cannot be null.")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z)(?=.*?[0-9])(?=.*?[#?!@$%^&*-_]).{8,}$", ErrorMessage = "Not a valid Password")]
        [Display(Name = "Password")]
        public string password { get; set; }
        public string password_salt { get; set; }
        public string password_hash { get; set; }

        [Required(ErrorMessage = "FullNames cannot be null")]
        [Display(Name = "FullNames")]
        public string fullnames { get; set; }
        
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
        public string status { get; set; }
        public string created_date { get; set; }


        public IEnumerable<SelectListItem> genders { get; set; }
        public IEnumerable<SelectListItem> years { get; set; }
        public IEnumerable<SelectListItem> months { get; set; }
        public IEnumerable<SelectListItem> days { get; set; }
    }
}
