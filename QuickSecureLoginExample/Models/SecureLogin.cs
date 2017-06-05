using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



using System.Web.Security; 




using System.ComponentModel.DataAnnotations;

namespace QuickSecureLoginExample.Models
{


    public class MyLoginModel
    {
        [Required]
        [Display(Name = "User")]
        public string User { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

    }






}