using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSA.Domain.Entities;
using OSA.Domain.Repositories.Base;

namespace OSA.Domain.Repositories
{
    public interface IStudentRepository:IRepository<Student>
    {
    }
}
