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
    public class medicine_dto
    {
        [BsonElement("_id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Browsable(true)]
        public ObjectId mongodb_id { get; set; }
        public long id { get; set; }
        public int Doctorid { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime DOB { get; set; }
        public string Department { get; set; }
        public string phone_no { get; set; }
        public string Address { get; set; }



    }
}