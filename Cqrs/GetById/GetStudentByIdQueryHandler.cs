using System.Linq;
using Data;

namespace Cqrs
{
    public class GetStudentByIdQueryHandler
    {
        private readonly StudentContext _context;

        public GetStudentByIdQueryHandler(StudentContext context)
        {
            _context = context;
        }

        public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
        {
            var student = _context.Students.SingleOrDefault(x=>x.Id == query.Id);
            return new GetStudentByIdQueryResult(){Name=student.Name,Surname=student.Surname,Age=student.Age};
        }
    }
}