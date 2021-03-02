using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ActorImageManager : IActorImageService
    {
        IActorImageDal _actorImageDal;
        public ActorImageManager(IActorImageDal actorImageDal)
        {
            _actorImageDal = actorImageDal;
        }

        [ValidationAspect(typeof(ActorImageValidator))]
        public IResult Add(ActorImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.ActorId)
                );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = ActorImagesFileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _actorImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(ActorImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageExists(carImage.Id)
                );
            if (result != null)
            {
                return result;
            }
            string path = GetById(carImage.Id).Data.ImagePath;
            ActorImagesFileHelper.Delete(path);
            _actorImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<ActorImage>> GetAll()
        {
            return new SuccessDataResult<List<ActorImage>>(_actorImageDal.GetAll());
        }

        public IDataResult<List<ActorImage>> GetAllByActorId(int actorId)
        {
            return new SuccessDataResult<List<ActorImage>>(CheckIfCarHaveNoImage(actorId));
        }

        public IDataResult<ActorImage> GetById(int id)
        {
            return new SuccessDataResult<ActorImage>(_actorImageDal.Get(c => c.Id == id));
        }

        public IResult Update(ActorImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimitExpired(carImage.ActorId),
                CheckIfImageExists(carImage.Id)
                );

            if (result != null)
            {
                return result;
            }

            carImage.Date = DateTime.Now;
            string OldPath = GetById(carImage.Id).Data.ImagePath;
            ActorImagesFileHelper.Update(file, OldPath);
            _actorImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckIfImageLimitExpired(int actorId)
        {
            int result = _actorImageDal.GetAll(c => c.ActorId == actorId).Count;
            if (result >= 5)
                return new ErrorResult(Messages.ImageLimitExpiredForCar);
            return new SuccessResult();
        }

        //private IResult CheckIfImageExtensionValid(IFormFile file)
        //{
        //    bool isValidFileExtension = Messages.ValidImageFileTypes.Any(t => t == Path.GetExtension(file.FileName).ToUpper());
        //    if (!isValidFileExtension)
        //        return new ErrorResult(Messages.InvalidImageExtension);
        //    return new SuccessResult();

        //}

        private List<ActorImage> CheckIfCarHaveNoImage(int actorId)
        {
            string path = Directory.GetCurrentDirectory() + @"\wwwroot\Images\default.png"; //Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\Images\default.png");
            var result = _actorImageDal.GetAll(c => c.ActorId == actorId);
            if (!result.Any())
                return new List<ActorImage> { new ActorImage { ActorId = actorId, ImagePath = path } };
            return result;
        }

        private IResult CheckIfImageExists(int id)
        {
            if (_actorImageDal.IsExist(id))
                return new SuccessResult();
            return new ErrorResult(Messages.CarImageMustBeExists);
        }
    }
}
