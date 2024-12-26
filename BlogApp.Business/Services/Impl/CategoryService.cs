using AutoMapper;
using BlogApp.Business.DTOs.Category;
using BlogApp.Business.Helpers.Exceptions.Category;
using BlogApp.Business.Helpers.Exceptions.Common;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using BlogApp.DAL.Repositories.Interfaces;

namespace BlogApp.Business.Services.Impl;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<GetCategoryDto> GetByIdAsync(int id)
    {
        if (id <= 0)
        {
            throw new NegativeIdException();
        }

        var category = await _categoryRepository.GetByIdAsync(id);
        return category != null ? _mapper.Map<GetCategoryDto>(category) : throw new CategoryNullException();
    }

    public GetAllCategoryDto GetAllAsync()
    {
        var categories = _categoryRepository.GetAllAsync();
        var mappedCategories = categories
            .Select(category => _mapper.Map<GetCategoryDto>(category))
            .AsQueryable();

        return new GetAllCategoryDto { Categories = mappedCategories };
    }

    public async Task AddAsync(AddCategoryDto addCategoryDto)
    {
        if (_categoryRepository.Table.Any(c => c.Name == addCategoryDto.Name))
        {
            throw new CategoryAlreadyExistsException();
        }

        var category = _mapper.Map<Category>(addCategoryDto);
        await _categoryRepository.AddAsync(category);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, UpdateCategoryDto updateCategoryDto)
    {
        if (id <= 0)
        {
            throw new NegativeIdException();
        }

        if (_categoryRepository.Table.Any(c => c.Name == updateCategoryDto.Name))
        {
            throw new CategoryAlreadyExistsException();
        }

        var existingCategory = await _categoryRepository.GetByIdAsync(id);
        if (existingCategory == null)
        {
            throw new CategoryNullException();
        }

        _mapper.Map(updateCategoryDto, existingCategory);
        await _categoryRepository.UpdateAsync(existingCategory);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        if (id <= 0)
        {
            throw new NegativeIdException();
        }

        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new CategoryNullException();
        }

        await _categoryRepository.DeleteAsync(category);
        await _categoryRepository.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(int id)
    {
        if (id <= 0)
        {
            throw new NegativeIdException();
        }

        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null)
        {
            throw new CategoryNullException();
        }

        await _categoryRepository.SoftDeleteAsync(category);
        await _categoryRepository.SaveChangesAsync();
    }
}