﻿using ClientService.DepartmentRequests;
using EF.DbModels;
using EF.DbModels.Filters;
using SchoolModels;

namespace ServerService.Mappers.Interfaces
{
    public interface IDepartmentMapper
    {
        DbDepartments ToDbDepartment(CreateDepartmentRequest request);
        DepartmentModel ToDepartment(DbDepartments department);
        FindDepartmentsFilter ToDepartmentsFilter(FindDepartmentRequest request);
    }
}
