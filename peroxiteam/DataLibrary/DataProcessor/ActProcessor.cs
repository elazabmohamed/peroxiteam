using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;
using System.Runtime.CompilerServices;

namespace DataLibrary.DataProcessor
{
    public class ActProcessor
    {
        public static int CreateAct(int id, string type, string name, string category,
                string descriptopn, string comments, string imagePth, string nameOfActor)
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
                NameOfActor = nameOfActor,
            };
            string sql = @"insert into dbo.Act (Id, Name, Type, Category, Description, Comments, ImagePath, NameOfActor)
                         values (@Id, @Name, @Type, @Category, @Description, @Comments, @ImagePath, @NameOfActor);";
            return SqlDataAccess.SaveData(sql, data);
        }




        public static List<Act> LoadModels(string Type)
        {
            string sql = @"select Id, Name, Type, Category, Description, Comments, ImagePath, NameOfActor
                          from dbo.Act where Type='"+Type+"';";
            return SqlDataAccess.LoadData<Act>(sql);
        }




        public static List<Act> LoadSpecificModel(int id)
        {
            string sql = @"select Id, Name, Type, Category, Description, Comments, ImagePath, NameOfActor
                          from dbo.Act where Id='" + id + "';";
            return SqlDataAccess.LoadData<Act>(sql);
        }



    }
}
