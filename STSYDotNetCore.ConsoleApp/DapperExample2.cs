using STSYDotNetCore.ConsoleApp.Models;
using STSYDotNetCore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSYDotNetCore.ConsoleApp
{
    public class DapperExample2
    {
        public readonly string _connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=DotNetTraining;User ID=sa;Password=16121998*StSy";
        public readonly DapperService _dapperService;

        public DapperExample2() //constructor
        {
            _dapperService = new DapperService(_connectionString);

        }

        public void Read()
        {
            string query = @$"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";

            var list = _dapperService.Query<BlogDapperDataModel>(query).ToList();

            foreach (var item in list)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Edit(int id)
        {

            string query = @$"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0 AND BlogId = @BlogId";

            var item = _dapperService.QueryFirstOrDefault<BlogDapperDataModel>(query, new BlogDapperDataModel
            {
                BlogId = id,
            });

            if(item is null)
            {
                Console.WriteLine("There is no blog!!!");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(BlogDapperDataModel model)
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

            int result = _dapperService.Execute(query, new BlogDapperDataModel
            {
                BlogTitle = model.BlogTitle,
                BlogAuthor = model.BlogAuthor,
                BlogContent = model.BlogContent
            });
            Console.WriteLine(result == 1 ? "Saving Successful.." : "Saving Failed.....");
        }

        public void Update(BlogDapperDataModel model)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
 WHERE BlogId = @BlogId AND DeleteFlag = 0";


            int result = _dapperService.Execute(query, new BlogDapperDataModel
            {
                BlogId = model.BlogId,
                BlogTitle = model.BlogTitle,
                BlogAuthor = model.BlogAuthor,
                BlogContent = model.BlogContent
            });
            Console.WriteLine(result == 1 ? "Updating Successful.." : "Updating Failed.....");

        }

        public void Patch(BlogDapperDataModel model)
        {
            string condition = "";
            if (!string.IsNullOrEmpty(model.BlogTitle))
            {
                condition += " [BlogTitle] = @BlogTitle, ";
            }
            if (!string.IsNullOrEmpty(model.BlogAuthor))
            {
                condition += " [BlogAuthor] = @BlogAuthor, ";
            }
            if (!string.IsNullOrEmpty(model.BlogContent))
            {
                condition += " [BlogContent] = @BlogContent, ";
            }

            if (condition.Length == 0)
            {
                Console.WriteLine("No Data to Update");
                return;
            }

            condition = condition.Substring(0, condition.Length - 2);

            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET {condition}
 WHERE BlogId = @BlogId";

            int result = _dapperService.Execute(query, new BlogDapperDataModel
            {
                BlogId = model.BlogId,
                BlogTitle = model.BlogTitle,
                BlogAuthor = model.BlogAuthor,
                BlogContent = model.BlogContent
            });

            Console.WriteLine(result == 1 ? "Patching Successful.." : "Patching Failed.....");
        }

        
    }
}
