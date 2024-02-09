using GameBlog.API.Data;
using GameBlog.API.Models.Domains;
using GameBlog.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GameBlog.API.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}
