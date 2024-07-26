using Core.Entities;
using Data.Context;
using Data.Repistories.Abstract;
using Data.Repistories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repistories.Concrete
{
    public class StudentRepistory :Repistory<Student>, IStudentRepistory
    {
        public StudentRepistory(AppDbContext context) : base(context)
        {
            
        }
    }
}
