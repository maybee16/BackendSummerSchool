using System;

namespace SchoolDBModelsLibrary
{
    public interface IPerson
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Patronymic { get; set; }
        Guid DepartmentId { get; set; }
    }
}
