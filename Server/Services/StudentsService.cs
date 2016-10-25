using Dal;
using Domain;

namespace Services
{
    public interface IStudentsService
    {
        Student GetStudentById(string id);
    }
    public class StudentsService : IStudentsService
    {
        private IStudentsRepository _studentsRepo;

        public StudentsService(IStudentsRepository studentsRepo)
        {
            _studentsRepo = studentsRepo;
        }

        public Student GetStudentById(string id)
        {
            var data = _studentsRepo.Get(id);
            return new Student
            {
                FirstName = data.SISData.Data.Name.First,
                Id = data.Id.ToString(),
                LastName = data.SISData.Data.Name.Last
            };
        }
    }
}
