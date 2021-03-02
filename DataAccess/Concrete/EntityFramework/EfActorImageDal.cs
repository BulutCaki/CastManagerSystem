using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfActorImageDal : EfEntityRepositoryBase<ActorImage, CastManagerSystemContext>, IActorImageDal
    {
        public bool IsExist(int id)
        {
            using (CastManagerSystemContext context = new CastManagerSystemContext())
            {
                return context.ActorImages.Any(p => p.Id == id);
            }
        }

    }
}
