using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.Processor
{
    public class StudentProcessor
    {
        public static int CreateStudent(int id, string name, string surName,
        string studentNo, string universityMail, string university, string department,
        string grade, string password, string studentState)
        {
            StudentModel data = new StudentModel
            {
                Id = id,
                Name = name,
                SurName = surName,
                StudentNo = studentNo,
                UniversityMail = universityMail,
                University = university,
                Department = department,
                Grade = grade,
                Password = password,
                StudentState = studentState,
            };
            string sql = @"insert into dbo.Student (Id, Name, SurName, StudentNo, UniversityMail, University, Department,
                            Grade, Password, StudentState)
                         values (@Id, @Name, @SurName, @StudentNo, @UniversityMail, @University, @Department,
                            @Grade, @Password, @StudentState);";
            return SqlDataAccess.SaveData(sql, data);
        }




        public static List<StudentModel> LoadModels()
        {
            string sql = @"select Id, Name, SurName, StudentNo, UniversityMail, University, Department,
                            Grade, Password, StudentState
                          from dbo.Student;";
            return SqlDataAccess.LoadData<StudentModel>(sql);
        }


        public static bool CheckLog(string email, string password)
        {
            StudentModel data = new StudentModel
            {
                UniversityMail = email,
                Password = password,
            };

            string sql = @"SELECT* FROM dbo.Student WHERE UniversityMail='" + data.UniversityMail + "' AND Password='" + data.Password + "'";
            return SqlDataAccess.CheckLog(sql, data);
        }
    }
}
