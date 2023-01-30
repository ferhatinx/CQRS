using Data;

namespace Cqrs
{
    public class RemoveStudentCommand
    {
        public RemoveStudentCommand(int id)
        {
            this.Id = id;
        }
        public int Id { get; set; }
    }
    public class RemoveStudentHandler
    {
        private readonly StudentContext _context;

        public RemoveStudentHandler(StudentContext context)
        {
            _context = context;
        }
        public void Handle(RemoveStudentCommand command)
        {

            var removestudent =_context.Students.Find(command.Id);
            _context.Students.Remove(removestudent);
            _context.SaveChanges();
        }
    }
}