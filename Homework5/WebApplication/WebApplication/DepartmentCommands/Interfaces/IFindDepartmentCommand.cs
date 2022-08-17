﻿using ClientService.DepartmentRequests;
using ClientService.DepartmentResponses;
using ClientService.StudentRequests;
using ClientService.StudentResponses;

namespace ClientService.DepartmentCommands.Interfaces
{
    public interface IFindDepartmentCommand
    {
        FindDepartmentResponse Execute(FindDepartmentRequest request);
    }
}