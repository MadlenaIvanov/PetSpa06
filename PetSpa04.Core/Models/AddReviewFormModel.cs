using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models
{
    public class AddReviewFormModel
    {
        public string Title { get; init; }

        public string Description { get; init; }

        [Display(Name = "Image")]
        public string ImageUrl { get; init; }

        public int CategoryId { get; init; }
    }
}
