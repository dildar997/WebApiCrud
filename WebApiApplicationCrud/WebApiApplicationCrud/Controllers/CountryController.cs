using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiApplicationCrud.Models;
using WebApiApplicationCrud.ServiceRepositories;
using WebApiApplicationCrud.ViewModels;

namespace WebApiApplicationCrud.Controllers
{
    public class CountryController : ApiController
    {
        ICountryRepository countryRepository;
        IMapper mapper;

        public CountryController(ICountryRepository _countryRepository, IMapper _mapper)
        {
            this.countryRepository = _countryRepository;
            this.mapper = _mapper;
        }

        // GET: api/Default
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await countryRepository.GetAllAsync();
                var mappedresult = mapper.Map<IEnumerable<CountryVM>>(result);
                if (mappedresult == null) return Content(HttpStatusCode.NotFound, "Records does not exits");
                return Ok(mappedresult);
            }
            catch (Exception e)
            {
                //TODO: add logging code here
                return InternalServerError(e);
            }
        }

        // GET: api/Default/5
        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id.ToString())) return BadRequest("id can not be null");
                var result = await countryRepository.GetAsync(id);
                var mappedresult = mapper.Map<CountryVM>(result);
                if (mappedresult == null) return Content(HttpStatusCode.NotFound, "Record does not exits");
                return Ok(mappedresult);
            }
            catch (Exception e)
            {
                //TODO: add logging code here
                return InternalServerError(e);
            }
        }

        // POST: api/Default

        [HttpPost]
        public async Task<IHttpActionResult> Post([FromBody] CountryVM model)
        {
            try
            {
                if (model != null && ModelState.IsValid)
                {
                    var mappedModel = mapper.Map<Country>(model);
                    if (await countryRepository.AddAsync(mappedModel)) return Content(HttpStatusCode.Created, "Added Successfully");
                }
                return Content(HttpStatusCode.BadRequest, ModelState);
            }
            catch (Exception e)
            {
                //TODO: add logging code here

                return InternalServerError(e);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(int id, [FromBody] CountryVM model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id.ToString())) return BadRequest("Id can not be null");
                if (ModelState.IsValid)
                {
                    var existingModel = await countryRepository.GetAsync(id);
                    if (existingModel != null)
                    {
                        var updatedMappedModel = mapper.Map<Country>(model);
                        if (await countryRepository.UpdateAsync(existingModel, updatedMappedModel)) return Content(HttpStatusCode.OK, "Updated Successfully");
                    }
                    else
                    {
                        return Content(HttpStatusCode.NotFound, "Item does not exist");
                    }
                }
                return Content(HttpStatusCode.BadRequest, ModelState);

            }
            catch (Exception e)
            {
                //TODO: add logging code here
                return InternalServerError(e);
            }
        }

        // DELETE: api/Default/5
        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(id.ToString())) return BadRequest("Id can not be null");
                var model = await countryRepository.GetAsync(id);
                if (model != null)
                {
                    if (await countryRepository.RemoveAsync(model)) return Content(HttpStatusCode.OK, "Deleted Successfully");
                }
                else
                {
                    return Content(HttpStatusCode.NotFound, "Item does not exist");
                }
                return BadRequest("Something Went wrong");
            }
            catch (Exception e)
            {
                //TODO: add logging code here

                return InternalServerError(e);
            }
        }
    }
}
