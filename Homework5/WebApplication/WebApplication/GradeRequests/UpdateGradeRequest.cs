﻿using System;

namespace ClientService.GradeRequests
{
    public class UpdateGradeRequest
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public int Value { get; set; }
    }
}
