using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CBA.Models.BuyBuddie
{
    public class Issue
    {
        public int Score { get; set; }
        public int? Project_ID { get; set; }
        public int? Entity_ID { get; set; }
        public int? Check_ID { get; set; }
        public bool IsAlert { get; set; }
        public int Format { get; set; }
        public string FormatDescription { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
        public string Solution { get; set; }
    }
}