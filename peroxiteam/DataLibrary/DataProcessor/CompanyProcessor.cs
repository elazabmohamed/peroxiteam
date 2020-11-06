using DataLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.Models;



namespace DataLibrary.DataProcessor
{
    public class CompanyProcessor
    {

        public static int CreateCompany(int id, string companyName, string companyMail,
            string password, string tag)
        {
            Company data = new Company
            {
                Id = id,
                CompanyName = companyName,
                CompanyMail = companyMail,
                Password = password,
                Tag = tag,
            };
            string sql = @"insert into dbo.Company (Id, CompanyName, CompanyMail, Password, Tag)
                         values (@Id, @CompanyName, @CompanyMail, @Password, @Tag);";
            return SqlDataAccess.SaveData(sql, data);
        }




        public static List<Company> LoadModels()
        {
            string sql = @"select Id, CompanyName, CompanyMail, Password, Tag
                          from dbo.Company;";
            return SqlDataAccess.LoadData<Company>(sql);
        }


        public static bool CheckLogCompany(string email, string password)
        {
            Company data = new Company
            {
                CompanyMail = email,
                Password = password,
            };

            string sql = @"SELECT* FROM dbo.Company WHERE CompanyMail='" + data.CompanyMail + "' AND Password='" + data.Password + "'";
            return SqlDataAccess.CheckLogCompany(sql, data);
        }
    }
}
