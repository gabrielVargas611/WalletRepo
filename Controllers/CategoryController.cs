using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletAPI.Contract;
using WalletAPI.Models;

namespace WalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category/All
        [HttpGet]
        [Route("All")]
        public ActionResult<List<Category>> Get() => _categoryService.Get();

        // GET: api/Category/GetOne/5
        [HttpGet("{id}")]
        [Route("Category/GetOne")]
        public ActionResult<Category> Get(int id)
        {
            var category = _categoryService.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        // POST: api/Category
        [HttpPost]
        public ActionResult<Category> Create([FromBody] Category category)
        {
            _categoryService.Create(category);

            return CreatedAtRoute("GetMovement", new { id = category.id.ToString() }, category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Category categoryp)
        {
            var category = _categoryService.Get(id);
            if (category == null)
                return NotFound();

            _categoryService.Update(id, categoryp);

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryService.Get(id);
            if (category == null)
                return NotFound();

            _categoryService.Remove(category.id);

            return NoContent();
        }
    }
}
