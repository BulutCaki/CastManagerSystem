using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Actor : IEntity
    {
        public int ActorId { get; set; }
        public string Sexuality { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Job { get; set; }
        public string Age { get; set; }
        public string Lenght { get; set; }
        public string Kilo { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
        public string Country { get; set; }
        public string City { get; set; }


    }
}
