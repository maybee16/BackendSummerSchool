﻿using System;
using System.Collections.Generic;

namespace ClientService.GradeResponses
{
    public class UpdateGradeResponse
    {
        public Guid? Id { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
