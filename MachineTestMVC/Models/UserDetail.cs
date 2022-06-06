using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MachineTestMVC.Models
{
    public partial class UserDetail
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string Name { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Display(Name = "Birthday")]
        [Required(ErrorMessage = "Birthday is required")]
        public DateTime Birthday { get; set; }

        public string Status { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        public TimeSpan Time { get; set; }

        public bool? IsActive { get; set; }
    }
}
