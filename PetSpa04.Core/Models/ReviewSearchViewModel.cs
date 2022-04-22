﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetSpa04.Core.Models
{
    public class ReviewSearchViewModel
    {
        public string SearchTerm { get; init; }

        public ReviewSorting Sorting { get; init; }
        public IEnumerable<ReviewListingViewModel> Reviews { get; init; }
    }
}
