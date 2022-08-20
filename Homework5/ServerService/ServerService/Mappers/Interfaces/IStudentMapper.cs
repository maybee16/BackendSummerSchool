using EF.DbModels;
using EF.DbModels.Filters;
using SchoolModels;
using StudentRequests;
using System.Collections.Generic;

namespace ServerService.Mappers.Interfaces
{
    public interface IStudentMapper
    {
        DbStudents ToDbStudent(CreateStudentRequest request);
        StudentModel ToStudent(DbStudents students);
        HashSet<StudentModel> ToStudentList(HashSet<DbStudents> dbStudents);
        FindStudentsFilter ToStudentsFilter(FindStudentRequest request);
    }
}
