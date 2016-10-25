using System.Collections.Generic;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ApiCore.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private IStudentsService _service;

        public StudentsController(IStudentsService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Get()
        {
            return "hello world!";
        }

        [HttpGet("{id}")]
        public Student Get(string id)
        {
            return _service.GetStudentById(id);
        }

       // GET: api/values
       //[HttpGet]
       // public IList<Student> List(string where)
       // {
       //     IStudentsRepository repo = new StudentsRepository();
       //     return repo.List(where);
       // }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string GetItem(string id)
        //{
        //    return "value";
        //}

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
