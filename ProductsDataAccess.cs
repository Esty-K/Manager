﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Manager
{
   public class ProductsDataAccess
    {
public int InsertData(string connectionString)
        {
            string CategoryId,Name, Description, Price, Image;
            Console.WriteLine("insert CategoryId");
            CategoryId = Console.ReadLine();
            Console.WriteLine("insert Name");
            Name = Console.ReadLine();
            Console.WriteLine("insert Description");
            Description = Console.ReadLine();
            Console.WriteLine("insert Price");
            Price = Console.ReadLine();
            Console.WriteLine("insert Image");
            Image = Console.ReadLine();

            string query = "INSERT INTO Products (CategoryId,Name, Description, Price, Image)" +
                            "VALUES (@CategoryId,@Name, @Description, @Price, @Image)";


            using (SqlConnection cn =new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query,cn))
            {
                cmd.Parameters.Add("@CategoryId", SqlDbType.Int).Value = int.Parse(CategoryId);
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 20).Value = Name;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 100).Value = Description;
                cmd.Parameters.Add("@Price", SqlDbType.Float).Value = float.Parse(Price);
                cmd.Parameters.Add("@Image", SqlDbType.NVarChar, 10).Value = Image;


                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                cn.Close();

               Console.WriteLine("would you like to continue? (y/n)");
                string continueInsert = Console.ReadLine();
                if (continueInsert == "y")
                    InsertData(connectionString);
                return rowsAffected;
            }
        }
        public void ReadData(string connectionString)
        {
            string query = "select * from Products";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cn) ;
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}", reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
                Console.ReadLine();
            }
        }
    }
}
