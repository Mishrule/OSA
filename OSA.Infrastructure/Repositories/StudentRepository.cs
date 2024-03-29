﻿using OSA.Domain.Entities;
using OSA.Domain.Repositories;
using OSA.Infrastructure.Data;
using OSA.Infrastructure.Repositories.Base;

namespace OSA.Infrastructure.Repositories
{
  public class StudentRepository:Repository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
