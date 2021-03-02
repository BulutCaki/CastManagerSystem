using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PlatformManager : IPlatformService
    {
        IPlatformDal _platformDal;

        public PlatformManager(IPlatformDal platformDal)
        {
            _platformDal = platformDal;
        }

        public IResult Add(Platform platform)
        {
            if (platform.PlatformName.Length < 2)
            {
                return new ErrorResult(Messages.InvalidValue);
            }
            _platformDal.Add(platform);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        public IResult Delete(Platform platform)
        {
            _platformDal.Delete(platform);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        public IDataResult<List<Platform>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Platform>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Platform>>(_platformDal.GetAll(), Messages.OperationSuccessful);
        }

        public IResult Update(Platform platform)
        {
            _platformDal.Update(platform);
            return new SuccessResult(Messages.OperationSuccessful);
        }
    }
}
