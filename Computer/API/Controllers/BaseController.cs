using Data.Model;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<M, R> : ControllerBase where M : Base where R : BaseRepository<M>
    {
        R repository;
        public BaseController(R repository)
        {
            this.repository = repository;
        }

        //[HttpGet]
        //public List<M> Get()
        //{
        //    return repository.Read();
        //}

        //[HttpGet("{id}")]
        //public M Get(int id)
        //{
        //    return repository.ReadById(id);
        //}

        [HttpPost]
        public void Post([FromBody] M model)
        {
            repository.Create(model);
        }

        //[HttpPut("{id}")]
        //public void Put([FromBody] M model)
        //{
        //    repository.Update(model);
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    repository.Delete(id);
        //}
    }
}
