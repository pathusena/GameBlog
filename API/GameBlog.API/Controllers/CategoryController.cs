using GameBlog.API.Data;
using GameBlog.API.Models.Domains;
using GameBlog.API.Models.DTOs;
using GameBlog.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameBlog.API.Controllers
{
    // https://localhost:xxxx/api/category
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            var category = new Category //TODO: User AutoMapper here later
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };

            await _categoryRepository.CreateAsync(category);

            var response = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };
            return Ok(response);
        }

        //GET: https://localhost:7074/api/category
        [HttpGet]
        public async Task<ActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllAsync();

            var response = categories?.Select(category => new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            }).ToList();

            return Ok(response);
        }
    }
}
