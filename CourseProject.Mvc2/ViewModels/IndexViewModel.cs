using CourseProject.Web.Shared.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Mvc2.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<FilmShortModelResponse> FilmShortModelResponses { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
