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

    internal Cat GetCatById(int id)
    {
      try
      {
        return _db.QuerySingle<Cat>(@"SELECT * FROM CATS WHERE id = @id", new {id});
      }
      catch (Exception e)
      {
        throw new Exception("Invalid Id");
      }
    }

    internal void DeleteById(int id)
    {
        var success = _db.Execute(@"DELETE FROM cats WHERE id = @id", new {id});
        if (success == 0)
        {
          throw new Exception("Delort Failed");
        }
    }

    internal void UpdateByID(Cat catToUpdate){
      var success = _db.Execute("UPDATE cats SET name = @Name, age = @Age, fur = @Fur WHERE id = @Id", catToUpdate);
      if(success == 0){
          throw new Exception("Delort didn't fail, because this is an update request. Which did fail.");
      }
    }
  }
}