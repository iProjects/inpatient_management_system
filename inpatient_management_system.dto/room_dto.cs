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
    public class room_dto
    {
        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Browsable(true)]
        public ObjectId mongodb_id { get; set; }
        public long id { get; set; }
        public int doctor_id { get; set; }
        public string name { get; set; }
        public string no { get; set; }
        public string no_of_beds { get; set; }
        public string location { get; set; }
        public string status { get; set; }
        public string created_date { get; set; }

        public IEnumerable<SelectListItem> doctors { get; set; }


    }
}