using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IResult Add(Project project);
        IResult Delete(Project project);
        IResult Update(Project project);
        IDataResult<List<Project>> GetAll();
        IDataResult<List<Project>> GetByCategoryId(int CategoryId);
        IDataResult<List<Project>> GetByDirector(string Director);
        IDataResult<List<Project>> GetByCity(string City);
        IDataResult<List<ProjectDetailDto>> GetProjectDetail();

    }
}
