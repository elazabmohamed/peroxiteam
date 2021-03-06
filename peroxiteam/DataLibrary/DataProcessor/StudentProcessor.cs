﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.DataProcessor
{
    public class StudentProcessor
    {
        public static int CreateStudent(int id, string name, string surName,
        string studentNo, string universityMail, string university, string department,
        string grade, string password, string studentState, string tag, string cvPath, string imagePath)
        {
            Student data = new Student
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
                Tag = tag,
                CvPath = cvPath,
                ImagePath = imagePath,
            };
            string sql = @"insert into dbo.Student (Id, Name, SurName, StudentNo, UniversityMail, University, Department,
                            Grade, Password, StudentState, Tag, CvPath, ImagePath)
                         values (@Id, @Name, @SurName, @StudentNo, @UniversityMail, @University, @Department,
                            @Grade, @Password, @StudentState, @Tag, @CvPath, @ImagePath);";
            return SqlDataAccess.SaveData(sql, data);
        }




        public static List<Student> LoadModels()
        {
            string sql = @"select Id, Name, SurName, StudentNo, UniversityMail, University, Department,
                            Grade, Password, StudentState, Tag, CvPath, ImagePath
                          from dbo.Student;";
            return SqlDataAccess.LoadData<Student>(sql);
        }


        public static bool CheckLog(string email, string password)
        {
            Student data = new Student
            {
                UniversityMail = email,
                Password = password,
            };

            string sql = @"SELECT* FROM dbo.Student WHERE UniversityMail='" + data.UniversityMail + "' AND Password='" + data.Password + "'";
            return SqlDataAccess.CheckLog(sql, data);
        }



        public static List<Student> LoadSpecificModel(int id)
        {
            string sql = @"select Id, Name, SurName, StudentNo, UniversityMail, University, Department,
                            Grade, StudentState, Tag, CvPath, ImagePath
                          from dbo.Student where Id='" + id + "';";
            return SqlDataAccess.LoadData<Student>(sql);
        }

    }
}
