using System;
using System.Security.Cryptography.X509Certificates;

namespace EFTest;

public class Tag
{
    public int Id {get; set;}
    public List<Post> Posts {get;} = [];
}

