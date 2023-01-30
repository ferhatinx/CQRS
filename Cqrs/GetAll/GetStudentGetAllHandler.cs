using System.Collections.Generic;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;

namespace Cqrs
{
    public class GetStudentGetAllHandler
    {
        private readonly StudentContext _context;

        public GetStudentGetAllHandler(StudentContext context)
        {
            _context = context;
        }
        public List<GetStudentGetAllResult> Handle(GetStudentGetAllQuery query)
        {
            var students = _context.Students.
            Select(x=> new GetStudentGetAllResult {Id=x.Id,Name=x.Name,Surname=x.Surname,Age=x.Age}).
            AsNoTracking().ToList();
            return students;
        }
    }
}