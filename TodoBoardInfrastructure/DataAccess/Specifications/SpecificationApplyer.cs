using Microsoft.EntityFrameworkCore;
using TodoBoardCore.Data.Common;

namespace TodoBoardInfrastructure.DataAccess.Specifications
{
    public static class SpecificationApplyer
    {
        public static IQueryable<TEnt> GetQuery<TEnt>(
            IQueryable<TEnt> inputQuery,
            Specification<TEnt> specification)
            where TEnt : BaseEntity
        {
            var query = inputQuery;
            
            if(specification.Predicate != null)
                query = query.Where(specification.Predicate);

            query = specification.IncludeExpressions.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }
    }
}
