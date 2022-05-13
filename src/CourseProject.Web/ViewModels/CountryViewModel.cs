using CourseProject.Web.Shared.Models.Responses;
using System.Collections.Generic;

namespace CourseProject.Mvc2.ViewModels
{
    public class CountryViewModel
    {
        public IEnumerable<CountryModelResponse> CountryModelResponses { get; set; }
        public string Country { get; set; }
    }
}