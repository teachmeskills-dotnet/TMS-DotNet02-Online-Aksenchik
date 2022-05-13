using CourseProject.Web.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Mvc2.ViewModels
{
    public class CountryViewModel
    {
        public IEnumerable<CountryModelResponse> CountryModelResponses { get; set; }
        public string Country { get; set; }
    }
}
