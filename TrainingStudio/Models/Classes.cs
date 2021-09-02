using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingStudio.Models
{
    public class Classes
    {
        //classes model 
        public int Id { get; set; }

        [Display(Name = "Training Type")]
        public string TrainingType { get; set; }

        [Display(Name = "Time")]
        public string Time { get; set; }


        [Display(Name = "Price ")]
        public string Price { get; set; }


    }
}
