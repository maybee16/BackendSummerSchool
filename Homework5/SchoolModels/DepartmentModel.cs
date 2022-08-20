using System;

namespace SchoolModels
{
    public record DepartmentModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public HashSet<StudentModel> Students { get; set; }
        public HashSet<MentorModel> Mentors { get; set; }
    }
}
