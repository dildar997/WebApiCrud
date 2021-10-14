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
    public class StateController : ApiController
    {
        IStateRepository stateRepository;
        IMapper mapper;

        public StateController(IStateRepository _stateRepository, IMapper _mapper)
        {
            this.stateRepository = _stateRepository;
            this.mapper = _mapper;
        }

        // GET: api/Default
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var result = await stateRepository.GetAllAsync();
                var mappedresult = mapper.Map<IEnumerable<StateVM>>(result);
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
                var result = await stateRepository.GetAsync(id);
                var mappedresult = mapper.Map<StateVM>(result);
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
                    var mappedModel = mapper.Map<State>(model);
                    if (await stateRepository.AddAsync(mappedModel)) return Content(HttpStatusCode.Created, "Added Successfully");
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
                    var existingModel = await stateRepository.GetAsync(id);
                    if (existingModel != null)
                    {
                        var updatedMappedModel = mapper.Map<State>(model);
                        if (await stateRepository.UpdateAsync(existingModel, updatedMappedModel)) return Content(HttpStatusCode.OK, "Updated Successfully");
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
                var model = await stateRepository.GetAsync(id);
                if (model != null)
                {
                    if (await stateRepository.RemoveAsync(model)) return Content(HttpStatusCode.OK, "Deleted Successfully");
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
