﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectdal;
        public ProjectManager(IProjectDal projectdal)
        {
            _projectdal = projectdal;
        }
        [CacheRemoveAspect("IProducerService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(Project project)
        {
            if (project.ProjectName.Length<2)
            {
                return new ErrorResult(Messages.InvalidValue);
            }
            _projectdal.Add(project);
            return new SuccessResult(Messages.OperationSuccessful);
        }

        public IResult Delete(Project project)
        {
            _projectdal.Delete(project);
            return new SuccessResult(Messages.OperationSuccessful);
        }
        [CacheAspect]
        [LogAspect(typeof(FileLogger))]
        [PerformanceAspect(5)]
        public IDataResult<List<Project>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Project>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Project>>(_projectdal.GetAll(),Messages.OperationSuccessful);
        }

        public IDataResult<List<Project>> GetByCategoryId(int CategoryId)
        {
            return new SuccessDataResult<List<Project>>(_projectdal.GetAll(c=>c.CategoryId==CategoryId), Messages.OperationSuccessful);
        }

        public IDataResult<List<Project>> GetByCity(string City)
        {
            return new SuccessDataResult<List<Project>>(_projectdal.GetAll(c => c.City == City), Messages.OperationSuccessful);
        }

        public IDataResult<List<Project>> GetByDirector(string Director)
        {
            return new SuccessDataResult<List<Project>>(_projectdal.GetAll(c => c.Director == Director), Messages.OperationSuccessful);
        }
        [CacheAspect]
        public IDataResult<List<ProjectDetailDto>> GetProjectDetail()
        {
            return new SuccessDataResult<List<ProjectDetailDto>>(_projectdal.GetProjectDetailDtos());
        }
        [CacheRemoveAspect("IProducerService.Get")]
        public IResult Update(Project project)
        {
            _projectdal.Update(project);
            return new SuccessResult(Messages.OperationSuccessful);
        }
    }
}
