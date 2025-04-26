using System;
using EFTest.Migrations;

namespace EFTest;

public class Blog
{
    public int BlogId {get; set;}
    public string Url {get; set;}
    public string BlogName {get; set;}
    public BlogHeader? Header {get; set;}

    public List<Post> Posts{get; } = new();
}

