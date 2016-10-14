using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal;
using Dal.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiCore.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IList<Student> List(string where)
        {
            IStudentsRepository repo = new StudentsRepository();
            return repo.List(where);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string GetItem(string id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
