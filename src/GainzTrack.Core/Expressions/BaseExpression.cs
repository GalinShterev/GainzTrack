using GainzTrack.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GainzTrack.Core.Expressions
{
    public abstract class BaseExpression<T> : IExpression<T>
    {

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; }

        protected BaseExpression(Expression<Func<T,bool>> criteria)
        {
            this.Criteria = criteria;
            this.Includes = new List<Expression<Func<T, object>>>();
        }
        
        protected virtual void AddInclude(Expression<Func<T,object>> expression)
        {
            this.Includes.Add(expression);
        }
    }
}
