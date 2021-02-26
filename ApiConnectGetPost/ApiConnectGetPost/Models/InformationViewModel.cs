using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiConnectGetPost.Models
{
    public class InformationViewModel
    {
        //Autogenerating Id
        [System.ComponentModel.DataAnnotations.Key]
        [System.ComponentModel.DataAnnotations.Schema.DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }//Name
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }//Address

        //Mobile Number
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.PhoneNumber)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", ErrorMessage = "The Mobile Number field is not a valid phone number")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Number is required.")]
        public string Mobile { get; set; }

        //Email Id
        [System.ComponentModel.DataAnnotations.DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Email form abc@xyz.com is required.")]
        public string Email { get; set; }
    }
}