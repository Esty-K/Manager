﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
   public class CategoryDataAccess
    {
public int InsertData(string connectionString)
        {
            string  Name;
            Console.WriteLine("insert name");
            Name = Console.ReadLine();


            string query = "INSERT INTO Categories (Name)" + 
                            "VALUES (@Name)";


            using (SqlConnection cn =new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query,cn))
            {
                cmd.Parameters.Add("@Name",SqlDbType.NVarChar, 20).Value = Name;
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
            string query = "select * from Categories";
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, cn) ;
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);
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