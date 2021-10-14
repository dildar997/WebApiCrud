using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiApplicationCrud.Models
{
	public class State
	{
        [Key]
        public int StateId { get; set; }
        public string Name { get; set; }
        public List<City> City { get; set; }
        //Adding Foreign Key constraints for country  
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}