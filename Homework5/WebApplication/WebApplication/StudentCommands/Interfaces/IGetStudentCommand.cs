using SchoolModels;
using StudentRequests;
using StudentResponses;
using System.Threading.Tasks;

namespace ClientService.StudentCommands.Interfaces
{
    public interface IGetStudentCommand
    {
        Task<BrokerResponse<StudentModel>> ExecuteAsync(GetStudentRequest request);
    }
}
