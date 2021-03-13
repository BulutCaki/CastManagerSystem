using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProducerManager : IProducerService
    {
        IProducerDal _producerDal;

        public ProducerManager(IProducerDal producerDal)
        {
            _producerDal = producerDal;
        }
        [ValidationAspect(typeof(ProducerValidator))]
        [CacheRemoveAspect("IProducerService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(Producer producer)
        {
            if (producer.ProducerName.Length<2 && producer.ProducerOwner.Length<2)
            {
                return new ErrorResult(Messages.InvalidValue);
            }
            _producerDal.Add(producer);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        public IResult Delete(Producer producer)
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Producer>>(Messages.MaintenanceTime);
            }
            _producerDal.Delete(producer);
            return new SuccessResult(Messages.OperationSuccessful);
        }
        [CacheAspect]
        public IDataResult<List<Producer>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Producer>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Producer>>(_producerDal.GetAll(), Messages.OperationSuccessful);
        }
        public IDataResult<List<Producer>> GetByCity(string City)
        {
            return new SuccessDataResult<List<Producer>>(_producerDal.GetAll(c=>c.City==City), Messages.OperationSuccessful);
        }
        [CacheRemoveAspect("IPlatformService.Get")]
        public IResult Update(Producer producer)
        {
            _producerDal.Update(producer);
            return new SuccessResult(Messages.OperationSuccessful);
        }
    }
}
