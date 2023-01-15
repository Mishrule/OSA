using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OSA.Application.Commands.BatchCommands;
using OSA.Application.Commands.GuardianCommands;
using OSA.Application.Commands.StudentCommands;
using OSA.Application.Response;
using OSA.Domain.Entities;

namespace OSA.Application.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Batch, CreateBatchCommand>().ReverseMap();
            CreateMap<Batch, UpdateBatchCommand>().ReverseMap();
            CreateMap<Batch, DeleteBatchCommand>().ReverseMap();
            CreateMap<Batch, BatchResponse>().ReverseMap();
            CreateMap<UpdateBatchCommand, BatchResponse>().ReverseMap();


            CreateMap<Student, StudentResponse>().ReverseMap();
            CreateMap<Student, CreateStudentCommand>().ReverseMap();

            CreateMap<Guardian, GuardianResponse>().ReverseMap();
            CreateMap<Guardian, CreateGuardianCommand>().ReverseMap();
            
        }
    }
}
