using inpatient_management_system.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inpatient_management_system.ui.web.Models
{
    public class logs_view_model
    {
        public IEnumerable<log_dto> lst_dto { get; set; }
        public log_dto dto { get; set; }
    }
}