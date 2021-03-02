using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Project : IEntity
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int ProducerId { get; set; }
        public int CategoryId { get; set; }
        public string LeadingRoles { get; set; }
        public string Director { get; set; }
        public int PlatformId { get; set; }
        public string City { get; set; }


    }
}
