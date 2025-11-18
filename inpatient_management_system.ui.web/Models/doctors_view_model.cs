using inpatient_management_system.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inpatient_management_system.ui.web.Models
{
    public class doctors_view_model
    {
        public IEnumerable<doctor_dto> lst_dto { get; set; }
        public doctor_dto dto { get; set; }
    }
}