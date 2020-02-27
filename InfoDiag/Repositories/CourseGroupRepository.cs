namespace Repositories
{
    using System;
    using System.Collections.Generic;
    using Entity;
    using Microsoft.EntityFrameworkCore;
    using Repositories.Interfaces;

    internal class CourseGroupRepository : BaseRepository<CourseGroup, string>, ICourseGroupRepository
    {
        public CourseGroupRepository(DbContext context)
            : base(context)
        {
        }

        public override CourseGroup Insert(CourseGroup entity)
        {
            if (entity.GroupNumber > 100 || entity.GroupNumber < 1)
            {
                throw new FormatException("Entity is not valid");
            }

            entity.Id = GenerateId(entity);
            return base.Insert(entity);
        }

        public override IEnumerable<CourseGroup> Insert(IEnumerable<CourseGroup> entities)
        {
            foreach (var cg in entities)
            {
                cg.Id = GenerateId(cg);
            }

            return base.Insert(entities);
        }

        private string GenerateId(CourseGroup entity)
        {
            return entity.CourseId + '-' + entity.TermId + '-' + entity.GroupNumber;
        }
    }
}
