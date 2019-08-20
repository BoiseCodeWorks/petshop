using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Petshop.Models;

namespace Petshop.Data
{
  public class CatsRepository
  {
    private readonly IDbConnection _db;

    public CatsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Cat> GetCats()
    {
      return _db.Query<Cat>("SELECT * FROM cats");
    }

    internal Cat CreateCat(Cat catData)
    {
      try
      {

        var id = _db.ExecuteScalar<int>(@"
        INSERT INTO cats (name, age, fur)
        VALUES (@Name, @Age, @fur);
        SELECT LAST_INSERT_ID();
      ", catData);
        catData.Id = id;
        return catData;
      }
      catch (Exception e)
      {
        throw e;
      }
    }
  }
}