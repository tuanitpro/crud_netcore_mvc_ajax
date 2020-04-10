/* FileName: DataContext.cs
Project Name: dotNetCore
Date Created: 10/04/2020 8:49:08 AM
Description: Auto-generated
Version: 1.0.0.0
Author:	Lê Thanh Tuấn - Khoa CNTT
Author Email: tuanitpro@gmail.com
Author Mobile: 0976060432
Author URI: http://tuanitpro.com
License: 

*/
using Microsoft.EntityFrameworkCore;

namespace dotNetCore.Models
{
    // Code table Students
    //string db = @"CREATE TABLE [dbo].[Students](
    //             [StudentId] [int] IDENTITY(1,1) NOT NULL,
    //             [Name] [nvarchar](max) NULL,
    //             [Status] [nvarchar](max) NULL)";

    /// <summary>
    /// DataContext class
    /// CRUD
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>();

        }
    }
}