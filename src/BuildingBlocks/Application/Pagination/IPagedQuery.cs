using CompanyName.MyProjectName.BuildingBlocks.Application.Mediator.Core;

namespace CompanyName.MyProjectName.BuildingBlocks.Application.Pagination;

public interface IPagedQuery<T> : IQuery<T>
{
    int Page { get; set; }
    int Results { get; set; }
}