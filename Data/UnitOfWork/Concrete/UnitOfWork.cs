using Core.Constants;
using Data.Context;
using Data.Repistories.Concrete;
using Data.UnitOfWork.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly GroupRepistory Groups;
        public readonly StudentRepistory Students;
        private readonly AppDbContext _context;

        public UnitOfWork()
        {
            _context = new AppDbContext();
            Groups = new GroupRepistory(_context);
            Students = new StudentRepistory(_context);
            
        }

        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Messages.ErrorOccuredMessage();
            }

        }
    }
}
