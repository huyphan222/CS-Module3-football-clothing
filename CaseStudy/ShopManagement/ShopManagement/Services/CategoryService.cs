using Microsoft.EntityFrameworkCore;
using ShopManagement.AppDbContexts;
using ShopManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext context;

        public CategoryService(AppDbContext context)
        {
            this.context = context;
        }

        public Category Add(Category category)
        {
            context.Add(category);
            context.SaveChanges();
            return category;

        }

        public Category Delete(int id)
        {
            var categoryNeedDelete = context.categories.Find(id);
            if(categoryNeedDelete != null)
            {
                context.Remove(categoryNeedDelete);
                context.SaveChanges();
            }
            return categoryNeedDelete;

        }

        public IEnumerable<Category> GetAllCategory()
        {
            return context.categories.Include(c => c.products);
                                    
        }

        public Category GetCategory(int id)
        {
            return context.categories.Find(id);
        }

        public Category Update(Category categoryChange)
        {
            throw new NotImplementedException();
        }
    }
}
