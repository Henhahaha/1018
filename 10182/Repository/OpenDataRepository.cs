﻿
using OpenDataImport.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OpenDataImport.Repository
{
    public class OpenDataRepository
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Henry\source\repos\10182\10182\Database1.mdf;Integrated Security=True";
                //return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+ Directory.GetCurrentDirectory() + @"\App_Data\nodeDB.mdf;Integrated Security=True";
            }

        }
        public void Insert(OpenData item)
        {
            var newItem = item;
            var connection = new SqlConnection(ConnectionString);
            connection.Open();


            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
        INSERT INTO OpenData(地區, 經度, 緯度) 
        VALUES              (N'{0}',N'{1}',N'{2}')
            ", newItem.地區, newItem.經度, newItem.緯度);

            command.ExecuteNonQuery();


            connection.Close();
        }



        //        public object Update(object item)
        //        {
        //            var updateItem = item as YC.Models.OpenData;
        //            var connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
        //            connection.Open();


        //            var command = new System.Data.SqlClient.SqlCommand("", connection);
        //            command.CommandText = string.Format(@"
        //UPDATE [OpenData]
        //   SET 
        //      [資料集名稱] = N'{0}'
        //      ,[服務分類] = N'{1}'
        //      ,[資料集描述] = N'{2}'
        //      ,[DisplaySqe] = N'{3}'
        // WHERE ID=N'{4}'
        //            ", updateItem.服務分類, updateItem.資料集名稱, updateItem.資料集描述, updateItem.DisplaySqe, updateItem.ID);

        //            command.ExecuteNonQuery();


        //            connection.Close();
        //            return item;
        //        }

        //        public void Delete(string ID)
        //        {
        //            var connection = new System.Data.SqlClient.SqlConnection(ConnectionString);
        //            connection.Open();


        //            var command = new System.Data.SqlClient.SqlCommand("", connection);
        //            command.CommandText = string.Format(@"
        //DELETE FROM [OpenData]
        // WHERE ID=N'{0}'
        //            ", ID);

        //            command.ExecuteNonQuery();


        //            connection.Close();
        //        }
    }
}
