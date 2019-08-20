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

    public IEnumerable<Cat> GetCats(){
      return _db.Query<Cat>("SELECT * FROM cats");
    }


  }
}