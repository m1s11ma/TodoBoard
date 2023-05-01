using System.Linq.Expressions;
using TodoBoardCore.Data.Common;

namespace TodoBoardInfrastructure.DataAccess.Specifications
{
    public abstract class Specification<TEnt>
        where TEnt : BaseEntity
    {
        protected Specification(Expression<Func<TEnt, bool>> predicate) =>
            Predicate = predicate;
        public Expression<Func<TEnt, bool>>? Predicate { get; }
        public List<Expression<Func<TEnt, object>>> IncludeExpressions { get; } = new();

        protected void AddInclude(Expression<Func<TEnt, object>> includeExpression) => 
            IncludeExpressions.Add(includeExpression);
    }
}
