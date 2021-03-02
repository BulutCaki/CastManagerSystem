using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Platform : IEntity
    {
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }
    }
}
