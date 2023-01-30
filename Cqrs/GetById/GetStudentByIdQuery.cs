namespace Cqrs
{
    public class GetStudentByIdQuery
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}