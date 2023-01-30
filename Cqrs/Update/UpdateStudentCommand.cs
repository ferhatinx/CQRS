using Data;

namespace Cqrs
{
    public class UpdateStudentCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
        public int Age { get; set; }
    }
    public class UpdateStudentCommandHandler
    {
        private readonly StudentContext _context;

        public UpdateStudentCommandHandler(StudentContext context)
        {
            _context = context;
        }
        public void Handle(UpdateStudentCommand command)
        {
           var updatedstudent = _context.Students.Find(command.Id);
            updatedstudent.Name=command.Name;
            updatedstudent.Surname = command.Surname;
            updatedstudent.Age = command.Age;
            _context.SaveChanges();
        }

    }
}