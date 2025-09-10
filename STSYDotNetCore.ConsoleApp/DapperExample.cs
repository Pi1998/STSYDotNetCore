using Dapper;
using STSYDotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSYDotNetCore.ConsoleApp
{
    internal class DapperExample
    {
        public readonly string _connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=DotNetTraining;User ID=sa;Password=16121998*StSy";
        public void Read()
        {
            //using (IDbConnection db = new SqlConnection(_connectionString)) 
            //{
            //    string query = "select * from tbl_blog where DeleteFlag = 0;";
            //    var list = db.Query(query).ToList();

            //    foreach (var item in list)
            //    {
            //        Console.WriteLine(item.BlogId);
            //        Console.WriteLine(item.BlogTitle);
            //        Console.WriteLine(item.BlogAuthor);
            //        Console.WriteLine(item.BlogContent);
            //    }
            //} //runtime error tet lo...

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where DeleteFlag = 0;";
                var list = db.Query<BlogDapperDataModel>(query).ToList();

                foreach (var item in list)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }

            // DTO --> Data Transfer Object
            // Models thone......

        }

        public void Create(string title, string author, string content)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDapperDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                });
                Console.WriteLine(result == 1 ? "Saving Successful.." : "Saving Failed.....");
            }
        }

        public void checkId(int id) 
        {
            string query = "SELECT * FROM Tbl_Blog WHERE BlogId = @BlogId and DeleteFlag = 0;";

            using (IDbConnection db = new SqlConnection(_connectionString)) {
                //var item = db.Query<BlogDapperDataModel>(query, new BlogDapperDataModel
                //{
                //    BlogId = id
                //}).FirstOrDefault();

                var item = db.QueryFirstOrDefault<BlogDapperDataModel>(query, new BlogDapperDataModel
                { 
                    BlogId = id 
                }); //more efficient

                if (item is null)
                {
                    Console.WriteLine("No data found!!!");
                    return;
                }

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Update(int id, string title, string author, string content)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = @DeleteFlag
 WHERE BlogId = @BlogId";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
              
                int result = db.Execute(query, new BlogDapperDataModel
                {
                    BlogId = id,
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                    DeleteFlag = 0
                });
                Console.WriteLine(result == 1 ? "Update Successful!" : "Update failed!!!");
            }
        }

        public void Delete(int id) {

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [DeleteFlag] = 1
 WHERE BlogId = @BlogId";


            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDapperDataModel
                {
                    BlogId = id
                });
                Console.WriteLine(result == 1 ? "Deleting Successful!!!" : "Deleting Failed!!!!");
            }

        }

    }
}
