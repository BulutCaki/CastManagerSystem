using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProducerService
    {
        IResult Add(Producer producer);
        IResult Delete(Producer producer);
        IResult Update(Producer producer);
        IDataResult<List<Producer>> GetAll();
        IDataResult<List<Producer>> GetByCity(string City);
    }
}
