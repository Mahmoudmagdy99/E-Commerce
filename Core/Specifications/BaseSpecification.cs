
using System.Linq.Expressions;
using Core.Interfaces;

namespace Core.Specifications;

public class BaseSpecification<T> : ISpecification<T>
{

    // Default constructor
    protected BaseSpecification() : this(null)
    {
    }

    private readonly Expression<Func<T, bool>>? criteria;
    // Constructor with criteria
    public BaseSpecification(Expression<Func<T, bool>>? criteria)
    {
        this.criteria = criteria;
    }

    public Expression<Func<T, bool>>? Criteria => criteria;

    public Expression<Func<T, object>>? OrderBy { get; private set; }

    public Expression<Func<T, object>>? OrderByDescending { get; private set; }

    public bool IsDistinct {get; private set; }

    public int Take {get; private set; }

    public int Skip {get; private set; }

    public bool IsPagingEnabled {get; private set; }

    public List<Expression<Func<T, object>>> Includes { get; } = [];

    public List<string> IncludeStrings { get; } = []; // For ThenInclude

    protected void AddInclude(Expression<Func<T, object>> includeExpressions)
    {
        Includes.Add(includeExpressions);
    }
    
    protected void AddInclude(string includeString)
    {
        IncludeStrings.Add(includeString);
    }
    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }
    protected void ApplyDistinct()
    {
        IsDistinct = true;
    }

    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }

    public IQueryable<T> ApplyCriteria(IQueryable<T> query)
    {
        if (Criteria != null)
        {
            query = query.Where(Criteria);
        }
        return query;
    }
}

public class BaseSpecification<T, TResult> : BaseSpecification<T>, ISpecification<T, TResult>
{
    protected BaseSpecification() : this(null, null)
    {
        
    }
    private readonly Expression<Func<T, TResult>>? select;
    // Constructor with criteria and select
    protected BaseSpecification(Expression<Func<T, bool>>? criteria, Expression<Func<T, TResult>>? select)
        : base(criteria)
    {
        this.select = select;
    }

    public Expression<Func<T, TResult>>? Select { get; private set; }
    
    protected void AddSelect(Expression<Func<T, TResult>> selectExpression)
    {
        Select = selectExpression;
    }
}
