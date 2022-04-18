﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Project.Data.Models
{
    /// <summary>
    /// Film role.
    /// </summary>
    public class FilmActor
    {
        /// <summary>
        /// Identification.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Actor identification.
        /// </summary>
        public int ActorId { get; set; }
        /// <summary>
        /// Navigation property for actor.
        /// </summary>
        public Actor Actor { get; set; }
        /// <summary>
        /// Film identification.
        /// </summary>
        public int FilmId { get; set; }
        /// <summary>
        /// Navigation property for Film.
        /// </summary>
        public Film Film { get; set; }
    }
}
