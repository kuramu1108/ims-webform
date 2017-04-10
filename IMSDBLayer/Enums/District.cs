using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IMSDBLayer.Enums
{
    public enum District
    {
        [Display(Name = "Urban Indonesi")]
        Urban_Indonesia,
        [Display(Name = "Rural Indonesia")]
        Rural_Indonesia,
        [Display(Name = "Urban Papua New Guinea")]
        Urban_Papua_New_Guinea,
        [Display(Name = "Rural Papua New Guinea")]
        Rural_Papua_New_Guinea,
        Sydney,
        [Display(Name = "Rural New South Wales")]
        Rural_New_South_Wales
    }
}
