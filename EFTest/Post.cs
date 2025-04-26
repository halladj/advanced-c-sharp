using System;

namespace EFTest;

public class Post
{
    public int PostId {get; set;}
    public string Title {get; set;}
    public string content {get; set;}
    public DateOnly PublishedOn {get; set;}
    public bool Archived {get; set;}


    public int BlogId {get; set;}
    public Blog Blog {get; set;}


    public List<Tag> Tags {get;} = [];
}
