using STSYDotNetCore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSYDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample2
    {

        public readonly string _connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=DotNetTraining;User ID=sa;Password=16121998*StSy";
        private readonly AdoDotNetService _adoDotNetService;
        public AdoDotNetExample2()
        {
            _adoDotNetService = new AdoDotNetService(_connectionString);

        }
        public void Read()
        {
            string query = @$"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";

            var dt = _adoDotNetService.Query(query);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
        }

        public void Edit()
        {
            Console.WriteLine("Blog Id: ");
            string id = Console.ReadLine()!;

            string query = @$"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0 AND BlogId = @BlogId";

            ////params m thone yin d lo yay
            //SqlParameterModel[] sqlParameters = new SqlParameterModel[1];
            //sqlParameters[0] = new SqlParameterModel
            //{
            //    Name = "@BlogId",
            //    Value = id
            //};

            //var dt = _adoDotNetService.Query(query,sqlParameters);



            var dt = _adoDotNetService.Query(query,
                new SqlParameterModel("@BlogId", id));

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }

        public void Create()
        {
            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();

            string query = $@"
                                INSERT INTO [dbo].[Tbl_Blog]
                                       ([BlogTitle]
                                       ,[BlogAuthor]
                                       ,[BlogContent]
                                       ,[DeleteFlag])
                                 VALUES
                                       (@BlogTitle
                                       ,@BlogAuthor
                                       ,@BlogContent
                                       ,0)
                            ";


            int result = _adoDotNetService.Execute(query, new SqlParameterModel("@BlogTitle", title)
            , new SqlParameterModel("@BlogAuthor", author)
            , new SqlParameterModel("BlogContent", content));
            //constructor method htae mhr parameter htae lite lo yay ya tae code to twrr tr....


            Console.WriteLine(result == 1 ? "Saving Successful" : "Saving Failed!!!");
        }

    }
}
