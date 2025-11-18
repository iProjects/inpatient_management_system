using inpatient_management_system.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inpatient_management_system.ui.web.Models
{
    public class error_handler_view_model
    {
        public Exception ex { get; set; }
        public string message { get; set; }
        public string stack_trace { get; set; }
    }
}