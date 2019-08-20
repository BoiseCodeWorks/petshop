using System;

namespace Petshop.Models
{
  public class Cat
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public bool Fur { get; set; }

    public Cat(string name, int age)
    {
      Name = name;
      Age = age;
    }
    public Cat() {}

  }
}