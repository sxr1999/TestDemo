﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Area.Models
{
    [Serializable]
    public class StaffInfoModel
    {
        [Display(Name = "Work Number")]
        public string workNum { get; set; }
    }
}
