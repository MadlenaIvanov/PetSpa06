﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa.Infrastructure.Data
{
    public class Review
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }


        [StringLength(500)]
        public string ImageUrl { get; set; }


        //[ForeignKey(nameof(User))]
        //public string UserId { get; set; }
        //public virtual ApplicationUser User { get; set; }

        //-
        public int ServiceId { get; set; }
        public Service Service { get; init; }
    }
}