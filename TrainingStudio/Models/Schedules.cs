using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingStudio.Models
{
    public class Schedules
    {
        // schedules table 
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Contact ")]
        public string Contact { get; set; }


        [Display(Name = "Number Of Persons")]
        public string NumberOfPersons { get; set; }

        [Display(Name = "Start Date")]
        public string StartDate { get; set; }

        [Display(Name = "ClassId")]
        public int ClassId { get; set; }
    }
}
