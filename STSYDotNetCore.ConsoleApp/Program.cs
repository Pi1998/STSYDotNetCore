// See https://aka.ms/new-console-template for more information
using STSYDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadLine();


// C# <=> Database

// ADO.NET (old school)
//  Dapper (ORM)
// EFCore (ORM, Entity Framework Core) (Microsoft ka htote trr)


// Package Management
// nuget(backend) <==> npm(frontend)
// Ctrl + . --> suggestiong ko phwint pho

// Why connection open pee pyn close???
// for example--> max connection = 100 mhr 100 lone thone htrr yin, 101st ka win lo m ya twt...(Connection Time Out)... old school ty so pate pyy ya, khu twt auto pate pyy

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
//adoDotNetExample.Delete();

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create("dapper test title", "dapper test author", "dapper test content");
//dapperExample.Update(1006, "title title", "author author", "content content");
//dapperExample.Delete(1006);
//dapperExample.checkId(1005);


//AdoDotNet2 adoDotNet2 = new AdoDotNet2();
//adoDotNet2.View();
//adoDotNet2.Create();

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Create("Title efcore", "Author Efcore", "Content Efcore");
//eFCoreExample.Delete(4);
//eFCoreExample.Edit(1);
//eFCoreExample.Update(1, "ef title", "ef Author", "ef Content");


//custom service for Dapper Testing
DapperExample2 dapperExample2 = new DapperExample2();
//dapperExample2.Read();
Console.ReadKey();