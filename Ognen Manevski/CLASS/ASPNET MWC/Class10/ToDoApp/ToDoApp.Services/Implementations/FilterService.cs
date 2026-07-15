using ToDoApp.DataAccess.Interfaces;
using ToDoApp.Services.Interfaces;
using ToDoApp.Models.Dtos;
using ToDoApp.Mapper;
using ToDoApp.Domain;

namespace ToDoApp.Services.Implementations;

public class FilterService : IFilterService
{

    private readonly IRepository<Category> _categoryRepository;
    private readonly IRepository<Status> _statusRepository;

    public FilterService(IRepository<Category> categoryRepository, IRepository<Status> statusRepository)
    {
        _categoryRepository = categoryRepository;
        _statusRepository = statusRepository;
    }

    public List<CategoryDto> GetCategories()
    {
        var categories = _categoryRepository.GetAll().Select(x => OptionalMapper.MapToCategoryDto(x)).ToList();
        return categories;
    }

    public List<StatusDto> GetStatuses()
    {
        var statuses = _statusRepository.GetAll().Select(x => OptionalMapper.MapToStatusDto(x)).ToList();
        return statuses;
    }
}
