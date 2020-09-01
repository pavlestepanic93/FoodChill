using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodListRazor.Model
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Food Name")]
        public string Name { get; set; }

        public string Chef { get; set; }

        public string Country { get; set; }
    }
}
