using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class ActorManager : IActorService
    {
        IActorDal _actorDal;

        public ActorManager(IActorDal actorDal)
        {
            _actorDal = actorDal;
        }
        [ValidationAspect(typeof(ActorValidator))]
        [CacheRemoveAspect("IActorService.Get")]
        [SecuredOperation("admin")]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(Actor actor)
        {
            _actorDal.Add(actor);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        public IResult Delete(Actor actor)
        {
            _actorDal.Delete(actor);
            return new SuccessResult(Messages.OperationSuccessful);
        }
        [LogAspect(typeof(FileLogger))]
        [CacheAspect]
        //[PerformanceAspect(5)]
        [SecuredOperation("admin")]
        public IDataResult<List<Actor>> GetAll()
        {
            
            return new SuccessDataResult<List<Actor>>(_actorDal.GetAll(), "Başarılı");
        }

        public IDataResult<List<Actor>> GetAllByEyeCollor(string EyeCollor)
        {
            return new SuccessDataResult<List<Actor>>(_actorDal.GetAll(e => e.EyeColor == EyeCollor),Messages.OperationSuccessful);
        }

        public IDataResult<List<Actor>> GetAllByHairCollor(string HairCollor)
        {
            return new SuccessDataResult<List<Actor>>(_actorDal.GetAll(h => h.EyeColor == HairCollor), Messages.OperationSuccessful);
        }
        [CacheAspect]
        public IDataResult<List<Actor>> GetAllByJob(bool Job)
        {
            return new SuccessDataResult<List<Actor>>(_actorDal.GetAll(j => j.Job == Job), Messages.OperationSuccessful);
        }
        public IDataResult<List<Actor>> GetAllBySexuality(string Sexuality)
        {
            return new SuccessDataResult<List<Actor>>(_actorDal.GetAll(s => s.Sexuality == Sexuality), Messages.OperationSuccessful);
        }
        [CacheRemoveAspect("IActorService.Get")]
        public IResult Update(Actor actor)
        {
            _actorDal.Update(actor);
            return new SuccessResult(Messages.OperationSuccessful);
        }
    }
}
