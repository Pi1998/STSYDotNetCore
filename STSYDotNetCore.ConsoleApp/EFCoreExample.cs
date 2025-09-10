using Microsoft.EntityFrameworkCore;
using STSYDotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSYDotNetCore.ConsoleApp
{
    public class EFCoreExample
    {
        public void Read() 
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Blogs.Where(x=>x.DeleteFlag == false).ToList(); 
            //where clause ko ToList m tine khin lote, filter before convert to list from dbs [akone list lote pee mha true ty phel syr m lo twt]
            //x similar to item
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Create(string title, string author, string content) 
        { 
            AppDbContext db = new AppDbContext();
            BlogDataModel blog = new BlogDataModel
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(blog);
            var result = db.SaveChanges();

            Console.WriteLine(result == 1 ? "Insert Success" : "Insert Fail");
        }

        public void Edit(int id) 
        { 
            AppDbContext db = new AppDbContext();
            //var item = db.Blogs.Where(blog=>blog.BlogId == id && blog.DeleteFlag == false).FirstOrDefault();
            var item = db.Blogs.FirstOrDefault(blog => blog.BlogId == id);
            //d mhr ka result ka 1 khu htae htwet mhr moh filter m lote khin kw lote pee kw htae --> tutu pl

            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }


        public void Update(int id, string title, string author, string content) 
        {
            AppDbContext db = new AppDbContext();
            BlogDataModel blog = new BlogDataModel
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            var item = db.Blogs.AsNoTracking().FirstOrDefault(blog => blog.BlogId == id);

            //AsNoTracking() m pr tone ka dbs ko d tine direct win pee update lote, thu pr lr twt dbs ko direct update
            //m lote twt
            //ae tr htae lite twt EFCore ka dbs nae lite m track twt buu
            //So, after .AsNoTracking(), item is just a plain C# object (not tracked by EF).

            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            if(!string.IsNullOrEmpty(title))
            {
                item.BlogTitle = title;
            }

            if (!string.IsNullOrEmpty(author))
            {
                item.BlogAuthor = author;
            }

            if (!string.IsNullOrEmpty(content))
            {
                item.BlogContent = content;
            }

            db.Entry(item).State = EntityState.Modified;
            //Because of .AsNoTracking(), EF doesn’t “watch” your item. If you try to update it,
            //EF doesn’t care—it won’t generate an UPDATE statement. So you have to tell EF manually:

            var result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Updating successful!!!" : "Updating failed!!!");
        }


        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            var item = db.Blogs.AsNoTracking().FirstOrDefault(blog => blog.BlogId == id);

            if(item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            db.Entry(item).State = EntityState.Deleted;
            var result = db.SaveChanges();
            Console.WriteLine(result == 1 ? "Deleting Successful!!!" : "Deleting Failed!!!");
        }

    }
}
