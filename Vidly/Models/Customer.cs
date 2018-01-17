using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //Data annotations, required means non-nullable in db
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //what to display in view
        [Display(Name = "Date of Birth")]
        //apply custom validation
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        //navigation property - associates Customer class with membership type 
        //(allows to navigate from one type to another)
        public MembershipType MembershipType { get; set; }

        //type byte is implicitly required (add byte? for optional)
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

    }
}