using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiApplicationCrud.Models
{
	public class Country
	{
		[Key]
		public int CountryId { get; set; }
		public string Name { get; set; }
		public List<State> State { get; set; }
	}
}