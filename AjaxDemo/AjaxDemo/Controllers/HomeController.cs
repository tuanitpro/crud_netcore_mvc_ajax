using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxDemo.Models;
namespace AjaxDemo.Controllers
{
    public class HomeController : Controller
    {
        StudentDB db = new StudentDB();


        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Get All Student
        /// </summary>
        /// <returns></returns>
        public JsonResult List()
        {
            return Json(db.All(), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Get student by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Get(int id)
        {
            var Student = db.All().Find(x => x.StudentId.Equals(id));
            return Json(Student, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Add new student
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public JsonResult Create(Student entity)
        {
            var rs = db.Add(entity);
            return Json(new { msg = rs }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Update student
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public JsonResult Update(Student entity)
        {
            var rs = db.Update(entity);
            return Json(new { msg = rs }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Delete student
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult Delete(int id)
        {
            var rs = db.Delete(id);
            return Json(new { msg = rs }, JsonRequestBehavior.AllowGet);
        }
    }
}