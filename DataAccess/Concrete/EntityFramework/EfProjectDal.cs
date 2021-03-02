using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProjectDal : EfEntityRepositoryBase<Project,CastManagerSystemContext> , IProjectDal 
    {
        public List<ProjectDetailDto> GetProjectDetailDtos()
        {
            using (CastManagerSystemContext context = new CastManagerSystemContext())
            {
                var result = from p in context.Projects
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             join producer in context.Producers
                             on p.ProducerId equals producer.ProducerId
                             join platform in context.Platforms
                             on p.PlatformId equals platform.PlatformId
                             select new ProjectDetailDto
                             {
                                 ProjectId = p.ProjectId,
                                 ProjectName = p.ProjectName,
                                 ProducerName = producer.ProducerName,
                                 CategoryName = c.CategoryName,
                                 LeadingRoles = p.LeadingRoles,
                                 Director = p.Director,
                                 PlatformName = platform.PlatformName,
                                 City = p.City
                             };
                return result.ToList();
            }
        }
    }
}
