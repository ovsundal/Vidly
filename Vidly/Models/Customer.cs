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
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }

        //navigation property - associates Customer class with membership type 
        //(allows to navigate from one type to another)
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }

    }
}