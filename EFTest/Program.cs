using System.Net;
using EFTest;
using Microsoft.EntityFrameworkCore;

// Create a connection with db.
using var db = new BloggingContext();

// CREATE.
db.Add(new Blog{ Url= "http://hambz.netlify.app" });
db.Add(new Blog{ Url= "http://houssem.netlify.app" });
db.Add(new Blog{ Url= "http://ala.netlify.app" });
db.Add(new Blog{ Url= "http://sunny.netlify.app" });
db.SaveChanges();



// READ.
// var blogList = await db.Blogs.OrderBy(e => e.BlogId).ToListAsync();
// foreach (var item in blogList)
// {
//     Console.WriteLine($"Id: {item.BlogId}, ITEM: {item.Url}");
//     item.Url = "facebook.com";
// }


// // UPDATE.
// var blog = blogList.First();
// blog.Url = "X.com";
// await db.SaveChangesAsync();


// // DELETE 
// db.Remove(blog);
// await db.SaveChangesAsync();


// var aa = db.Blogs.Where(e => e.BlogId == 2).First();
// Console.WriteLine($"{aa.BlogId}, ${aa.Url}");
// db.Blogs.Remove(aa);
// await db.SaveChangesAsync();

SeedData.Seed(db);