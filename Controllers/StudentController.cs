using Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly GetStudentByIdQueryHandler _handler;
        private readonly GetStudentGetAllHandler _getallhandler;
        private readonly CreateStudentCommandHandler _createhandler;
        private readonly RemoveStudentHandler _removehandler;
        private readonly UpdateStudentCommandHandler _updatehandler;
        public StudentController(GetStudentByIdQueryHandler handler, GetStudentGetAllHandler getallhandler = null, CreateStudentCommandHandler createhandler = null, RemoveStudentHandler removehandler = null, UpdateStudentCommandHandler updatehandler = null)
        {
            _handler = handler;
            _getallhandler = getallhandler;
            _createhandler = createhandler;
            _removehandler = removehandler;
            _updatehandler = updatehandler;
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var result = _handler.Handle(new GetStudentByIdQuery(id));
            return Ok(result);
        }
         [HttpGet]
        public IActionResult GetAllStudent()
        {
            var result = _getallhandler.Handle(new GetStudentGetAllQuery());
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create(CreateStudentCommand command)
        {
            _createhandler.Handle(command);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _removehandler.Handle(new RemoveStudentCommand(id));
            return NoContent();
        }
        [HttpPut]
        public IActionResult Update(UpdateStudentCommand command)
        {
            _updatehandler.Handle(command);
            return NoContent();
        }
    }
}