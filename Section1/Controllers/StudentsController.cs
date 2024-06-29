using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Section1.Models;

namespace Section1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> students = new List<Student>
        {
            new Student{Id=1, Name="Tariq", Bio="I'm Tariq"},
            new Student{Id=2, Name="Sara", Bio="I'm Sara"},
            new Student{Id=3, Name="Wael", Bio="I'm Wael"}
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = students.Find(student => student.Id == id);

            if(student is null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Add(Student request)
        {
            if(request is null)
                return BadRequest();

            var student = new Student
            {
                Id = request.Id,
                Name = request.Name,
                Bio = request.Bio
            };

            students.Add(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student request)
        {
            var currentStudent = students.FirstOrDefault(student => student.Id == id);

            if (currentStudent is null)
            {
                return NotFound();
            }

            currentStudent.Name = request.Name;
            currentStudent.Bio = request.Bio;

            return Ok(currentStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(student => student.Id == id);

            if (student is null)
                return NotFound();

            students.Remove(student);
            return Ok(student);
        }
    }
}
