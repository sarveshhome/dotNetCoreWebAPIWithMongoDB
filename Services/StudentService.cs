using DotNetCoreWebAPIWithMongoDB.DB;
using DotNetCoreWebAPIWithMongoDB.Models;
using MongoDB.Driver;

namespace DotNetCoreWebAPIWithMongoDB.Serivecs
{
    public class StudentService
    {
        private readonly MongoDBContext _context;

        public StudentService(MongoDBContext context)
        {
            _context = context;
        }

        public async Task CreateStudent(Student student)
        {
            var collection = _context.GetCollection<Student>("students");
            await collection.InsertOneAsync(student);
        }

        public async Task<Student> GetStudent(string id)
        {
            var collection = _context.GetCollection<Student>("students");
            var filter = Builders<Student>.Filter.Eq("_id", id);
            return await collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            var collection = _context.GetCollection<Student>("students");
            return await collection.Find(x => true).ToListAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            var collection = _context.GetCollection<Student>("students");
            var filter = Builders<Student>.Filter.Eq("_id", (student.Id));
            await collection.ReplaceOneAsync(filter, student);
        }

        public async Task DeleteStudent(string id)
        {
            var collection = _context.GetCollection<Student>("students");
            var filter = Builders<Student>.Filter.Eq("_id", id);
            await collection.DeleteOneAsync(filter);
        }
    }
}