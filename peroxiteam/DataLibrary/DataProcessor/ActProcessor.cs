﻿using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;

namespace DataLibrary.DataProcessor
{
    public class ActProcessor
    {
        public static int CreateAct(int id, string name, string category,
                string descriptopn, string comments)
        {
            Act data = new Act
            {
                Id = id,
                Name = name,
                Category = category,
                Description = descriptopn,
                Comments = comments,
            };
            string sql = @"insert into dbo.Act (Id, Name, Category, Description, Comments)
                         values (@Id, @Name, @Category, @Description, @Comments);";
            return SqlDataAccess.SaveData(sql, data);
        }




        public static List<Act> LoadModels()
        {
            string sql = @"select Id, Name, Category, Description, Comments
                          from dbo.Act;";
            return SqlDataAccess.LoadData<Act>(sql);
        }


    }
}