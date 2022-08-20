using SchoolDBModelsLibrary;

namespace DatabaseLibrary
{
    internal interface IDatabase
    {
        void Create(Students student);
        void Create(Mentors mentor);
        void Create(Departments department);
        void Create(Grades grade);
        void ReadStudents();
        void ReadMentors();
        void ReadDepartments();
        void ReadGrades();
        void Update(Students student);
        void Update(Mentors mentor);
        void Update(Departments department);
        void Update(Grades grade);
        void Delete(Students student);
        void Delete(Mentors mentor);
        void Delete(Departments department);
        void Delete(Grades grade);
    }
}
