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
    public ActionResult<Cat> Get(int id)
    {
      try
      {
        return Ok(_repo.GetCatById(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
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
    public ActionResult<string> Put(int id, [FromBody] Cat catToUpdate) { 
      try
      {
          _repo.UpdateByID(catToUpdate);
          return Ok("Seems to have worked");
      }
      catch (Exception e)
      {
          return BadRequest(e.Message);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id) 
    { 
      try
      {
          _repo.DeleteById(id);
          return Ok("Successfully delorted");
      }
      catch (System.Exception)
      {
          return BadRequest("Bad request");
      }
    }
  }
}