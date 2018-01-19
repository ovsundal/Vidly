﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        //Data annotations, required means non-nullable in db
        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //apply custom validation
        //[Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        //type byte is implicitly required (add byte? for optional)
        public byte MembershipTypeId { get; set; }
    }
}