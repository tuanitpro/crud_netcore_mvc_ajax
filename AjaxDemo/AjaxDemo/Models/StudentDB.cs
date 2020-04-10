/* FileName: StudentDB.cs
Project Name: AjaxDemo
Date Created: 5/10/2015 8:49:08 AM
Description: Auto-generated
Version: 1.0.0.0
Author:	Lê Thanh Tuấn - Khoa CNTT
Author Email: tuanitpro@gmail.com
Author Mobile: 0976060432
Author URI: http://tuanitpro.com
License: 

*/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AjaxDemo.Models
{
    /// <summary>
    /// StudentDB class
    /// Insert - Update - Delete
    /// </summary>
    public class StudentDB
    {
        const string SqlConnectionString = @"Data Source =.\sqlexpress; Initial Catalog = DemoDI; User ID=sa; Password=sa";
        // Code table Students
        string db = @"CREATE TABLE [dbo].[Students](
	                [StudentId] [int] IDENTITY(1,1) NOT NULL,
	                [Name] [nvarchar](max) NULL,
	                [Status] [nvarchar](max) NULL)";
        public StudentDB()
        {

        }
        /// <summary>
        /// Get All Student
        /// </summary>
        /// <returns></returns>
        public List<Student> All()
        {
            var list = new List<Student>();
            using (SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                con.Open();
                string sql = "Select * from Students";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    list.Add(new Student
                    {
                        StudentId = int.Parse(reader["StudentId"].ToString()),
                        Name = reader["Name"].ToString(),
                        Status = reader["Status"].ToString()
                    });
                }
                return list;
            }
        }
        /// <summary>
        /// Insert new student
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(Student entity)
        {
            using (SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                con.Open();
                string sql = "INSERT INTO Students (Name, Status) VALUES(N'" + entity.Name + "', '" + entity.Status + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                int rs = cmd.ExecuteNonQuery();
                return rs;
            }
        }
        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(Student entity)
        {
            using (SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                con.Open();
                string sql = "UPDATE Students SET Name = N'" + entity.Name + "', Status = '" + entity.Status + "' WHERE StudentId=" + entity.StudentId + " ;";
                SqlCommand cmd = new SqlCommand(sql, con);
                int rs = cmd.ExecuteNonQuery();
                return rs;
            }
        }
        /// <summary>
        /// Delete Student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(SqlConnectionString))
            {
                con.Open();
                string sql = "DELETE Students WHERE StudentId = " + id + "";
                SqlCommand cmd = new SqlCommand(sql, con);
                int rs = cmd.ExecuteNonQuery();
                return rs;
            }
        }

    }
}