using ShopManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopManagement.Services
{
    public interface ICategoryService
    {
        public Category GetCategory(int id);
        public IEnumerable<Category> GetAllCategory();
        public Category Add(Category category);
        public Category Update(Category categoryChange);
        public Category Delete(int id);



    }
}
