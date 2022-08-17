﻿using System;
using System.Collections.Generic;

namespace ClientService.StudentResponses
{
    public class UpdateStudentResponse
    {
        public Guid? Id { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}