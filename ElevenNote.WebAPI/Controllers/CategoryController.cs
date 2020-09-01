using ElevenNote.Data;
using ElevenNote.Models;
using ElevenNote.Services;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        //POST
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CategoryService service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }

        //GET all
        public IHttpActionResult Get()
        {
            CategoryService service = CreateCategoryService();
            var categories = service.GetCategories();
            return Ok(categories);
        }

        //GET by id
        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Category entity =
                    ctx
                    .Categories
                    .Single(e => e.Id == id);
                return
                    new CategoryDetail
                    {
                        Name = entity.Name
                    };
            }
        }

        //PUT
        public IHttpActionResult Put(CategoryEdit category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCategoryService();

            if (!service.UpdateCategory(category))
                return InternalServerError();

            return Ok();
        }

        //DELETE
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();
            if (!service.DeleteCategory(id))
                return InternalServerError();

            return Ok();
        }

        private CategoryService CreateCategoryService()
        {
            CategoryService categoryService = new CategoryService();
            return categoryService;
        }
    }
}
