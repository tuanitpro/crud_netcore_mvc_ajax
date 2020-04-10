/* FileName: Student.cs
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

using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetCore.Models
{
    /// <summary>
    /// Class student
    /// </summary>
    /// 
    [Table("Student")]
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}