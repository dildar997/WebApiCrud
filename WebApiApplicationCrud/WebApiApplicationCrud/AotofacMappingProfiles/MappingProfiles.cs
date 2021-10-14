using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiApplicationCrud.Models;
using WebApiApplicationCrud.ViewModels;

namespace WebApiApplicationCrud.AotofacMappingProfiles
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Country, CountryVM>().ReverseMap();
			CreateMap<State, StateVM>().ReverseMap();
			CreateMap<City, CityVM>().ReverseMap();

		}
	}
}