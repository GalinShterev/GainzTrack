using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Models
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
    public class BaseEntity : BaseEntity<string>
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
