using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiApplicationCrud.ViewModels
{
	public class CountryVM
	{
		[Key]
		public int CountryId { get; set; }
		[Required]
		public string Name { get; set; }
		public List<StateVM> State { get; set; }
	}
}