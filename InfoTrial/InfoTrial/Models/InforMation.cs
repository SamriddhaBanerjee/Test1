using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoTrial.Models
{
    public class InforMation
    {
        //Autogenerating Id
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Address must be Valid.")]
        public string Address { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Enter 10 digit Mobile Number")]
        public string Mobile_Num { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Enter Email Address like abc@xyz.com")]
        public string Email { get; set; }

        //public int Id { get; internal set; }
    }
}