﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OSA.Application.Response;

namespace OSA.Application.Commands.StudentCommands
{
    public class DeleteStudentCommand:IRequest<BaseResponse<StudentResponse>>
    {
        public int Id { get; set; }
    }
}
