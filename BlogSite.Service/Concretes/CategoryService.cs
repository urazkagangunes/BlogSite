using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Category.Request;
using BlogSite.Models.Dtos.Category.Response;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CategoryService : ICategoryService
{

    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    ReturnModel<CategoryResponseDto> ICategoryService.Add(CreateCategoryRequest createCategoryRequest)
    {
        try
        {
            Category createdCategory = _mapper.Map<Category>(createCategoryRequest);

            _categoryRepository.Add(createdCategory);

            CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(createdCategory);

            return new ReturnModel<CategoryResponseDto>
            {
                Data = categoryResponseDto,
                Message = "New Category Added.",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception e)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Data = null,
                Message = e.Message,
                StatusCode = 500,
                Success = false
            };
        }
        
    }

    ReturnModel<List<CategoryResponseDto>> ICategoryService.GetAll()
    {
        try
        {
            List<Category> categories = _categoryRepository.GetAll().ToList();

            List<CategoryResponseDto> categoryResponseDtos = _mapper.Map<List<CategoryResponseDto>>(categories);

            return new ReturnModel<List<CategoryResponseDto>>
            {
                Data = categoryResponseDtos,
                Message = "All categories listed successfully.",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ReturnModel<List<CategoryResponseDto>>
            {
                Data = null,
                Message = $"An error occurred while retrieving categories: {ex.Message}",
                StatusCode = 500, 
                Success = false
            };
        }
    }

    ReturnModel<CategoryResponseDto> ICategoryService.GetById(int id)
    {
        try
        {
            Category? category = _categoryRepository.GetById(id);

            if (category == null)
            {
                return new ReturnModel<CategoryResponseDto>
                {
                    Data = null,
                    Message = "Category not found.",
                    StatusCode = 404,
                    Success = false
                };
            }

            CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(category);

            return new ReturnModel<CategoryResponseDto>
            {
                Data = categoryResponseDto,
                Message = "Category retrieved successfully by ID.",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Data = null,
                Message = $"An error occurred: {ex.Message}",
                StatusCode = 500, 
                Success = false
            };
        }
    }

    ReturnModel<CategoryResponseDto> ICategoryService.Remove(int id)
    {
        try
        {
            Category? category = _categoryRepository.GetById(id);

            if (category == null)
            {
                return new ReturnModel<CategoryResponseDto>
                {
                    Data = null,
                    Message = "Category not found.",
                    StatusCode = 404,
                    Success = false
                };
            }

            Category? deletedCategory = _categoryRepository.Remove(category);

            CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(deletedCategory);

            return new ReturnModel<CategoryResponseDto>
            {
                Data = categoryResponseDto,
                Message = "Category deleted successfully.",
                StatusCode = 200,
                Success = true
            };
        }
        catch (Exception ex)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Data = null,
                Message = $"An error occurred while deleting the category: {ex.Message}",
                StatusCode = 500, 
                Success = false
            };
        }
    }

    ReturnModel<CategoryResponseDto> ICategoryService.Update(UpdateCategoryRequest updateCategoryRequest)
    {
        try
        {
            Category? category = _categoryRepository.GetById(updateCategoryRequest.Id);

            if (category == null)
            {
                return new ReturnModel<CategoryResponseDto>
                {
                    Data = null,
                    Message = "Category not found",
                    StatusCode = 404,
                    Success = false
                };
            }

            Category updateCategory = new Category
            {
                Name = updateCategoryRequest.Name,
            };

            Category updatedCategory = _categoryRepository.Update(updateCategory);

            CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(updatedCategory);

            return new ReturnModel<CategoryResponseDto>
            {
                Data = categoryResponseDto,
                Message = "Category updated successfully",
                StatusCode = 200,
                Success = true
            };
        }
        catch(Exception ex)
        {
            return new ReturnModel<CategoryResponseDto>
            {
                Data = null,
                Message = ex.Message,
                StatusCode = 500,
                Success = false
            };
        }
        
    }

}
