using ElevenNote.Data;
using ElevenNote.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    public class CategoryService
    {
        public bool CreateCategory(CategoryCreate model)
        {
            Category entity =
                new Category()
                {
                    Id = model.CategoryId,
                    Name = model.Name
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryListItem> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Categories
                    .Select(
                        e =>
                        new CategoryListItem
                        {
                            CategoryId = e.Id,
                            Name = e.Name
                        }
                        );
                return query.ToArray();//ToArray for one prop?(just Name)

            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Category entity =
                    ctx
                    .Categories
                    .Single(e => e.Id == model.CategoryId);

                entity.Name = model.Name;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int categoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Category entity =
                    ctx
                    .Categories
                    .Single(e => e.Id == categoryId);

                ctx.Categories.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
