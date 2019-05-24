using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcDocument.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace MvcDocument.Controllers
{
    public class ADOController : Controller
    {

        [HttpGet, ActionName("Get")]
        public Document Get(int id)
        {

            Document doc = null;
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MvcDocumentContext2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string sqlExpression = "SELECT * FROM Document where Id="+id+"";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    
                    while (reader.Read())
                    {
                        doc = new Document();
                        doc.Id = Convert.ToInt32(reader.GetValue(0));
                        doc.Amount = Convert.ToInt32(reader.GetValue(1));
                        doc.Description = reader.GetValue(2).ToString();
                    }

                }
                reader.Close();
            }
            return doc;
        }

        [HttpGet, ActionName("GetAll")]
        public List<Document> Get()
        {
            List<Document> DocumentList = new List<Document>();
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MvcDocumentContext2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //SqlDataReader
                connection.Open();

                string sql = "Select * From Document"; SqlCommand command = new SqlCommand(sql, connection);
                using (SqlDataReader dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Document document = new Document();
                        document.Id = Convert.ToInt32(dataReader["Id"]);
                        document.Amount = Convert.ToInt32(dataReader["Amount"]);
                        document.Description = Convert.ToString(dataReader["Description"]);
                        DocumentList.Add(document);
                    }
                }
                connection.Close();
            }
            return DocumentList;
        }

        [HttpPost, ActionName("Create")]
        public void Post(Document document)
        {
            if (ModelState.IsValid)
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MvcDocumentContext2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string sql = $"Insert Into Document (Amount, Description) Values (60, 'Desc')";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandType = CommandType.Text;
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }

        [HttpPost, ActionName("Delete")]
        public void Delete(int id)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MvcDocumentContext2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete From Document Where Id='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        ViewBag.Result = "Operation got error:" + ex.Message;
                    }
                    connection.Close();
                }
            }
        }

    }
}