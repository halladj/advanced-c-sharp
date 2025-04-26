using System;
using EFTest.Migrations;
using Microsoft.EntityFrameworkCore;

namespace EFTest;

public class BloggingContext: DbContext
{
     static readonly string connectionString = "Server=localhost; User ID=root; Password=socode; Database=blog";
    // here we define the DBSets <tables>.
    public DbSet<Blog> Blogs {get; set;}
    public DbSet<Post> Posts{get; set;}
    public DbSet<BlogHeader> Headers{get; set;}
    public DbSet<Tag> Tag {get; set;}


    // Here we define the Database Connection.
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        =>  optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));   

}



