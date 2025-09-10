using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSYDotNetCore.ConsoleApp
{
    public class AdoDotNetExample
    {
        private readonly string _connectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=DotNetTraining;User ID=sa;Password=16121998*StSy";
        public void Read()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";

            SqlCommand cmd = new SqlCommand(query, connection);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adapter.Fill(dt);
            //Fill ==> Execute button nae tu, fill ka c# htae ka dt htae ko htae pee thrr....
            // Dr ka a yin ka thone tae pone
            // nout pine ka d lo thone tr ==> dt = adapter.Execute()

            //SqlDataReader reader = cmd.ExecuteReader();
            //while (reader.Read())
            //{
            //    Console.WriteLine(reader["BlogId"]);
            //    Console.WriteLine(reader["BlogTitle"]);
            //    Console.WriteLine(reader["BlogAuthor"]);
            //    Console.WriteLine(reader["BlogContent"]);
            //}

            
            connection.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
                Console.WriteLine(dr["DeleteFlag"]);
            }

            // DataSet --> in-memory collection of more than 1 data table, can do RU while disconnected from dbs(Disconnected data asset)
            // DataSet --> DataTables --> DataRows, DataColumns



            Console.ReadKey();

            //Console.WriteLine("Blog Title: ");
            //string title = Console.ReadLine();

            //Console.WriteLine("Blog Author: ");
            //string author = Console.ReadLine();

            //Console.WriteLine("Blog Content: ");
            //string content = Console.ReadLine();

            //string _connectionString = "Data Source=MSI\\SQLEXPRESS; Initial Catalog=DotNetTraining; User ID=sa; Password=16121998*StSy;";
            //SqlConnection connection = new SqlConnection(_connectionString);

            //connection.Open();

            //string queryInsert = $@"INSERT INTO [dbo].[Tbl_Blog]
            //           ([BlogTitle]
            //           ,[BlogAuthor]
            //           ,[BlogContent]
            //           ,[DeleteFlag])
            //     VALUES
            //           ('{title}'
            //           ,'{author}'
            //           ,'{content}'
            //           ,0)";

            //SqlCommand cmd = new SqlCommand(queryInsert, connection);

            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            //connection.Close();

            //Console.ReadKey();
        }

        public void Create()
        {
            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

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

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();

            //adapter.Fill(dt);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result == 1 ? "Saving Success!!!" : "Saving Failed!!!");
            Console.ReadKey();
        }

        public void Edit()
        {
            Console.Write("Blog Id: ");
            string id = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);

            connection.Open();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if(dt.Rows.Count == 0) {
                Console.WriteLine("No Data is found!!!");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }

        public void Update()
        {
            Console.WriteLine("Blog Id: ");
            string id = Console.ReadLine();

            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();



            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("Connection Opening.....");
            connection.Open();
            Console.WriteLine("Connection Opened!");

            string query = $@"
UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
	  ,[DeleteFlag] = 0
 WHERE BlogId = @BlogId
";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            Console.WriteLine(result == 1 ? "Updating Success!!!" : "Updating Failed!!!");
            Console.ReadKey();
        }

        public void Delete()
        {

            Console.WriteLine("Blog Id: ");
            string id = Console.ReadLine();


            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"
UPDATE [dbo].[Tbl_Blog]
   SET [DeleteFlag] = 1
 WHERE BlogId = @BlogId
";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();
            connection.Close();

            Console.WriteLine(result == 1 ? "Deleting Successful" : "Deleting Failed");
            Console.ReadKey();

        }
    }
}
