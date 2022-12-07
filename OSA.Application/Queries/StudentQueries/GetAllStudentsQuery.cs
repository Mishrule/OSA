﻿using MediatR;
using OSA.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSA.Application.Queries.StudentQueries
{
    public record GetAllStudentsQuery : IRequest<BaseResponseList<StudentResponse>>
    {

    }
}
