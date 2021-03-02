using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public  class ActorImage : IEntity
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
    }
}
