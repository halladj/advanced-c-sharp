using System;

namespace EFTest.Migrations;

public class BlogHeader
{
    public int ID {get; set;}
    public string HeaderContent {get; set;}
    public int BlogId {get; set;}
    public Blog Blog {get; set;}
}
