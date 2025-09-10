using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STSYDotNetCore.ConsoleApp
{
    public class AdoDotNet2
    {
        public readonly string _connecctionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=DotNetTraining;User ID=sa;Password=16121998*StSy";
        public void View()
        {

            SqlConnection connection = new SqlConnection(_connecctionString);
            connection.Open();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            connection.Close();

            foreach (DataRow dr in table.Rows)
            {
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
                Console.WriteLine(dr["DeleteFlag"]);
            }
        }
        public void Create()
        {

            Console.WriteLine("BlogTitle: ");
            string blogTitle = Console.ReadLine();

            Console.WriteLine("Author: ");
            string blogAuthor = Console.ReadLine();

            Console.WriteLine("Content: ");
            string blogContent = Console.ReadLine();


            SqlConnection connection = new SqlConnection(_connecctionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0)";

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@BlogTitle", blogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blogContent);

            int result = cmd.ExecuteNonQuery();


            connection.Close();

            Console.WriteLine(result == 1 ? "Adding Successful" : "Adding Failed!!!!");
        }
        public void Edit()
        {

        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
    }
}
