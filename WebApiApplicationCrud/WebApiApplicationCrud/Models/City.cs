using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiApplicationCrud.Models
{
	public class City
	{
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        //Adding Foreign Key Constraints for State  
        public int StateId { get; set; }
        public State State { get; set; }
    }
}