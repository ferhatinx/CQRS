using Data;

namespace Cqrs
{
    public class CreateStudentCommand
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }
    }
    public class CreateStudentCommandHandler
    {
        private readonly StudentContext _context;

        public CreateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }
        public void Handle(CreateStudentCommand command)
        {
            _context.Students.Add(new Student(){Name=command.Name,Surname=command.Surname,Age=command.Age});
            _context.SaveChanges();
        }
    }
    
}