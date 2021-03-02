using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Producer :  IEntity
    {
        
        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public string ProducerOwner { get; set; }
        public string MainOffice { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
    }
}
