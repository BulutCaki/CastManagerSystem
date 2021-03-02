using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ProjectDetailDto : IDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProducerName { get; set; } //producer
        public string CategoryName { get; set; } // category
        public string LeadingRoles { get; set; } 
        public string Director { get; set; }
        public string PlatformName { get; set; } // Platform
        public string City { get; set; }
    }
}
