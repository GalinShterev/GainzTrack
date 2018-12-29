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

        public void DeleteAllBy<T>(IExpression<T> expression) where T : BaseEntity
        {
            var allEntites = _context.Set<T>().Where(expression.Criteria).ToArray();
            _context.Set<T>().RemoveRange(allEntites);
            _context.SaveChanges();
        }

        public T GetBy<T>(IExpression<T> expression) where T : BaseEntity
        {
            var queryableResultWithncludes = expression.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));


            var finalResult = expression.IncludeStrings
                .Aggregate(queryableResultWithncludes,
                    (current, include) => current.Include(include));

            if (expression.Criteria != null)
                finalResult = finalResult.Where(expression.Criteria);
            if (expression.OrderBy != null)
                finalResult = finalResult.OrderBy(expression.OrderBy);

            return finalResult
                 .SingleOrDefault();
        }

        public T GetBy<T>(Func<T, bool> prediacte) where T : class
        {
            return _context.Set<T>().SingleOrDefault(prediacte);
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
            var queryableResultWithncludes = expression.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));


            var finalResult = expression.IncludeStrings
                .Aggregate(queryableResultWithncludes,
                    (current, include) => current.Include(include));

            if(expression.Criteria != null)
                finalResult = finalResult.Where(expression.Criteria);


            if(expression.OrderBy != null)
                finalResult = finalResult.OrderBy(expression.OrderBy);

            return finalResult             
                 .ToList();
        }

        public IEnumerable<T> List<T>(Func<T, bool> predicate) where T : BaseEntity
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
