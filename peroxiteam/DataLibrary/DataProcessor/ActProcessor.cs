using DataLibrary.DataAccess;
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
        public static int CreateAct(int id, string type, string name, string category,
                string descriptopn, string comments, string imagePth)
        {
            Act data = new Act
            {
                Id = id,
                Name = name,
                Type = type,
                Category = category,
                Description = descriptopn,
                Comments = comments,
                ImagePath = imagePth,
            };
            string sql = @"insert into dbo.Act (Id, Name, Type, Category, Description, Comments, ImagePath)
                         values (@Id, @Name, @Type, @Category, @Description, @Comments, @ImagePath);";
            return SqlDataAccess.SaveData(sql, data);
        }




        public static List<Act> LoadModels()
        {
            string sql = @"select Id, Name, Type, Category, Description, Comments, ImagePath
                          from dbo.Act;";
            return SqlDataAccess.LoadData<Act>(sql);
        }




        public static List<Act> LoadSpecificModel(int id)
        {
            string sql = @"select Id, Name, Type, Category, Description, Comments, ImagePath
                          from dbo.Act where Id='" + id + "';";
            return SqlDataAccess.LoadData<Act>(sql);
        }



    }
}
