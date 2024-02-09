using GameBlog.API.Models.Domains;

namespace GameBlog.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
