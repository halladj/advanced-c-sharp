using System;

namespace EFTest;

public class SeedData
{
    public static void Seed(BloggingContext cnx)
    {
        if (!cnx.Posts.Any())
        {
            cnx.Posts.AddRange(
                new Post
                {
                    Title = "How to create a website",
                    content = "Bla Bla Bla",
                    BlogId = 1
                },
                new Post
                {
                    Title = "How to deploy to netlify",
                    content = "Bla Bla Bla",
                    BlogId = 2
                }
            );

            cnx.SaveChanges();
        }
        if (!cnx.Headers.Any())
        {
                cnx.Headers.AddRange();
        }
    }
}
