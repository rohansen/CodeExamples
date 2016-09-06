using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Models
{
    public class Review
    {
        public Review()
        {
            //Reviews are not used (yet?)
        }

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        //No need for required since double is a valuetype
        public double Rating { get; set; }
        
        public int DrinkId { get; set; }
        public virtual Drink Drink { get; set; }
    }
}
