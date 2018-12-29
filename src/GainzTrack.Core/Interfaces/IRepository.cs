using GainzTrack.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(string id) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        IEnumerable<T> List<T>(Func<T,bool> predicate) where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        IEnumerable<T> List<T>(IExpression<T> expression) where T : BaseEntity;
        T GetBy<T>(IExpression<T> expression) where T : BaseEntity;
        T GetBy<T>(Func<T, bool> predicate)where T : class;
        void DeleteAllBy<T>(IExpression<T> expression) where T : BaseEntity;
    }
}
