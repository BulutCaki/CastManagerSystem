using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IActorService
    {
        IResult Add(Actor actor);
        IResult Delete(Actor actor);
        IResult Update(Actor actor);

        IDataResult<List<Actor>> GetAll();
        IDataResult<List<Actor>> GetAllBySexuality(string Sexuality);
        IDataResult<List<Actor>> GetAllByJob(bool Job);
        IDataResult<List<Actor>> GetAllByHairCollor(string HairCollor);
        IDataResult<List<Actor>> GetAllByEyeCollor(string EyeCollor);

    }
}   
