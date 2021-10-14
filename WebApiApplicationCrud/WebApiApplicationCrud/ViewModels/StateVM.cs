using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApiApplicationCrud.ViewModels
{
	public class StateVM
	{
		[Key]
		public int StateId { get; set; }
		[Required]
		public string Name { get; set; }
		public List<CityVM> City { get; set; }
	}
}