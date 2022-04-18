using CourseProject.Mvc2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseProject.Mvc2.ViewModels
{
    [Keyless]
    public class IndexViewModel
    {
        public IEnumerable<Film> Films { get; set; }
        public Film Film { get; set; }
        public IEnumerable<State> States { get; set; }
    }
    
}
