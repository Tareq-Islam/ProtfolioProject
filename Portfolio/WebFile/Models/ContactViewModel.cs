using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFile.Models
{
    public class ContactViewModel
    {
        [Required]
        [Display(Name="Your Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required]
        [Display(Name = "Your Message")]
        public string  Message { get; set; }
    }
}