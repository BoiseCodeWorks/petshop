using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Petshop.Data;
using Petshop.Models;

namespace Petshop.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CatsController : ControllerBase
  {
    private readonly CatsRepository _repo;

    public CatsController(CatsRepository repo)
    {
      _repo = repo;
    }
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Cat>> Get()
    {
      try
      {
        return Ok(_repo.GetCats());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Cat> Get(string id)
    {
      return null;
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Cat> Post([FromBody] Cat catData)
    {
      try
      {
        var cat = _repo.CreateCat(catData);
        return Created($"/api/cats/{cat.Id}", cat);
      }
      catch (Exception e)
      {
        return BadRequest("Bad Data you make me sad :(");
      }

    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) { }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id) { }
  }
}