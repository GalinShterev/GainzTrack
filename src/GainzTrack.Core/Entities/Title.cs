using System;
using System.Collections.Generic;
using System.Text;

namespace GainzTrack.Core.Entities
{
    public class Title : BaseEntity
    {
        public string Name { get; set; }
        public int RequiredAP { get; set; }
        public string Color { get; set; }
    }
}
