﻿using AngleSharp;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.TestDataAccess
{
    class ExcelDataAccess
    {
        public static string ConnectTestDataFile()
        {
            var fileName = ConfigurationManager.AppSettings["TestDataSheetPath"];
            var con = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {0}; Extended Properties=Excel 12.0;", fileName);
            return con;
        }

        public static TestData GetTestData(string keyName)
        {
            using(var connection = new OleDbConnection(ConnectTestDataFile()))
            {
                connection.Open();
                var query = string.Format("select * from [DataSet$] where key='{0}'", keyName);
                var value = connection.Query<TestData>(query).FirstOrDefault();
                connection.Close();
                return value; 
            }
        }
    }
}
