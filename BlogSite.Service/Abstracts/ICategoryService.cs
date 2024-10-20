using BlogSite.Models.Dtos.Category.Request;
using BlogSite.Models.Dtos.Category.Response;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICategoryService
{
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto> GetById(int id);
    ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest createCategoryRequest);
    ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategoryRequest);
    ReturnModel<CategoryResponseDto> Remove(int id);
}
