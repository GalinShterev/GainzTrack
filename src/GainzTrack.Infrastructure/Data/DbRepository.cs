using GainzTrack.Core.Entities;
using GainzTrack.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GainzTrack.Infrastructure.Data
{
    public class DbRepository : IRepository
    {
        private readonly ApplicationDbContext _context;
        public DbRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            
        }

        public T GetBy<T>(IExpression<T> expression) where T : BaseEntity
        {
            var resultWithAllIncludes = expression.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            return resultWithAllIncludes
                 .SingleOrDefault(expression.Criteria);
        }

        public T GetById<T>(string id) where T : BaseEntity
        {
            return _context.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public List<T> List<T>() where T : BaseEntity
        {
            return _context.Set<T>().ToList();
        }

        public IEnumerable<T> List<T>(IExpression<T> expression) where T : BaseEntity
        {
            var resultWithAllIncludes = expression.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            return resultWithAllIncludes
                 .Where(expression.Criteria)
                 .AsEnumerable();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
