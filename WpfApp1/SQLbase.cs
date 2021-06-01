﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WpfApp1
{
    class SQLbase
    {
        public SQLbase() { }

        static public void Insert(string str)
        {
            SqlConnection sqlConnection = new SqlConnection("server=localhost;Trusted_Connection=Yes;DataBase=Adjust;");
            sqlConnection.Open();
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandText = str;

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        static public DataTable Select(string str)
        {
            DataTable dataTable = new DataTable();

            SqlConnection sqlConnection = new SqlConnection("server=localhost;Trusted_Connection=Yes;DataBase=Adjust;");
            sqlConnection.Open();                                           // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand();          // создаём команду
            sqlCommand.CommandText = str;                             // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);                                 // возращаем таблицу с результатом

            return dataTable;
        }
    } 
}
