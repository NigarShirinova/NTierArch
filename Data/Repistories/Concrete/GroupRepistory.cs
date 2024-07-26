using Core.Entities;
using Data.Context;
using Data.Repistories.Abstract;
using Data.Repistories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repistories.Concrete
{
    public class GroupRepistory : Repistory<Group>, IGroupRepistory
    {

        private readonly AppDbContext _context;
        private readonly DbSet<Group> _dbTable;
        public GroupRepistory(AppDbContext context) : base(context)
        {
            _context = context;
            _dbTable = _context.Set<Group>();
        }
        
        public Group GetByName(string name)
        {
            Group foundedGroup = _dbTable.Find(name);
            return foundedGroup;
        }

    
    }
}
