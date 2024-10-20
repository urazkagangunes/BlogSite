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

    ReturnModel<List<CategoryResponseDto>> ICategoryService.GetAll()
    {
        List<Category> categories = _categoryRepository.GetAll().ToList();
        List<CategoryResponseDto> categoryResponseDtos = _mapper.Map<List<CategoryResponseDto>>(categories);

        return new ReturnModel<List<CategoryResponseDto>>
        {
            Data = categoryResponseDtos,
            Message = "Whole Category Listed.",
            StatusCode = 200,
            Success = true
        };
    }

    ReturnModel<CategoryResponseDto> ICategoryService.GetById(int id)
    {
        Category? category = _categoryRepository.GetById(id);
        CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(category);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = categoryResponseDto,
            Message = "Id'ye göre categori getirildi.",
            StatusCode = 200,
            Success = true
        };
    }

    ReturnModel<CategoryResponseDto> ICategoryService.Remove(int id)
    {
        Category category = _categoryRepository.GetById(id);
        Category deletedCategory = _categoryRepository.Remove(category);
        CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(deletedCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = categoryResponseDto,
            Message = "Category deleted.",
            StatusCode = 200,
            Success = true
        };
    }

    ReturnModel<CategoryResponseDto> ICategoryService.Update(UpdateCategoryRequest updateCategoryRequest)
    {
        Category category = _categoryRepository.GetById(updateCategoryRequest.Id);
        
        Category updateCategory = new Category
        {
            Name = updateCategoryRequest.Name,
        };
        
        Category updatedCategory = _categoryRepository.Update(updateCategory);
        CategoryResponseDto categoryResponseDto = _mapper.Map<CategoryResponseDto>(updatedCategory);

        return new ReturnModel<CategoryResponseDto>
        {
            Data = categoryResponseDto,
            Message = "Choosen Id updated",
            StatusCode = 200,
            Success = true
        };
    }
}
