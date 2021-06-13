﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace Library_Project.Resources.Classes
{
    public class DatabaseControl
    {
        public static DataTable Select(string inputCmd)
        {
            DataTable data = new DataTable();
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter sqldata = new SqlDataAdapter();

            sqlcon.ConnectionString = @"Data Source=.;Initial Catalog=db_Library;Integrated Security=True";
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();

            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = inputCmd;
            sqldata.SelectCommand = sqlcmd;
            sqldata.Fill(data);

            return data;
        }
        public static bool Exe(string inputCmd)
        {
            SqlConnection sqlcon = new SqlConnection();
            SqlCommand sqlcmd = new SqlCommand();

            sqlcon.ConnectionString = @"Data Source=.;Initial Catalog=db_Library;Integrated Security=True";
            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();

            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandText = inputCmd;
            try
            {
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlcon.Close();
            }
        }
        public static DataTable TableFiller(string commandText, SqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = commandText;

            SqlDataAdapter adaptor = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adaptor.Fill(table);

            return table;
        }

        public static void UpdateBookTable(string name)
        {
            SqlConnection connection = new SqlConnection();
            SqlCommand command = new SqlCommand();

            connection.ConnectionString = @"Data Source=.;Initial Catalog=db_Library;Integrated Security=True";

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            command.Connection = connection;

            int count = 0;

            var table = TableFiller("SELECT * FROM T_Books WHERE bookName = '" + name + "'", connection);

            count = Convert.ToInt32(table.Rows[0]["quantity"].ToString()) + 1;

            command.CommandText = "UPDATE T_Books SET quantity = '" + count + "' WHERE bookName = '" + name + "' ";

            command.ExecuteNonQuery();

            connection.Close();
        }


    }
}
