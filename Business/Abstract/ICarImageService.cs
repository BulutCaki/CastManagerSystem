using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IActorImageService
    {
        IResult Add(ActorImage carImage, IFormFile file);
        IResult Delete(ActorImage carImage);
        IResult Update(ActorImage carImage, IFormFile file);
        IDataResult<List<ActorImage>> GetAll();
        IDataResult<List<ActorImage>> GetAllByActorId(int actorId);
        IDataResult<ActorImage> GetById(int id);

    }
}
