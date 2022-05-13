using CourseProject.Web.Shared.Models.Responses;
using System.Collections.Generic;

namespace CourseProject.Mvc2.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<FilmShortModelResponse> FilmShortModelResponses { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}