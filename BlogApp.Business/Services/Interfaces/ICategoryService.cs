using BlogApp.Business.DTOs.Category;

namespace BlogApp.Business.Services.Interfaces;

public interface ICategoryService
{
    Task<GetCategoryDto> GetByIdAsync(int id);

    GetAllCategoryDto GetAllAsync(); 

    Task AddAsync(AddCategoryDto addCategoryDto); 

    Task UpdateAsync(int id, UpdateCategoryDto updateCategoryDto); 

    Task DeleteAsync(int id); 
    
    Task SoftDeleteAsync(int id);
}