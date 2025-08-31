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

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();

//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Edit();
adoDotNetExample.Delete();

Console.ReadKey();