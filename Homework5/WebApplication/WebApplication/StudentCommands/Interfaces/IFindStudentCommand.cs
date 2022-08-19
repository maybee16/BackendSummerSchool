using SchoolModels;
using StudentRequests;
using StudentResponses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientService.StudentCommands.Interfaces
{
    public interface IFindStudentCommand
    {
        Task<BrokerResponse<List<StudentModel>>> ExecuteAsync(FindStudentRequest request);
    }
}
