using System.Threading.Tasks;
using dotNetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private DataContext dataContext;

        public StudentController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await dataContext.Set<Student>().AsQueryable().ToListAsync();

            return Ok(students);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await dataContext.Set<Student>().FirstOrDefaultAsync(x => x.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Post(StudentModel model)
        {
            model.StudentId = -1;
            if (!string.IsNullOrEmpty(model.Name))
            {
                dataContext.Set<Student>().Add(new Student { Name = model.Name, Status = model.Status });
                await dataContext.SaveChangesAsync();
                return Ok("Added");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(StudentModel model)
        {
            if (!string.IsNullOrEmpty(model.Name))
            {
                var find = await dataContext.Set<Student>().FirstOrDefaultAsync(x => x.StudentId == model.StudentId);
                if (find != null)
                {
                    find.Name = model.Name;
                    find.Status = model.Status;

                    dataContext.Set<Student>().Attach(find);
                    await dataContext.SaveChangesAsync();
                    return Ok("Saved");
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await dataContext.Set<Student>().FirstOrDefaultAsync(x => x.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            dataContext.Set<Student>().Remove(student);
            await dataContext.SaveChangesAsync();
            return Ok("Deleted");
        }
    }
}