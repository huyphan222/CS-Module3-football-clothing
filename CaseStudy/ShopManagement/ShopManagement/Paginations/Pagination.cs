
using ShopManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePage.Paginations
{
    public class Pagination<T> where T: class
    {
        public IEnumerable<Product> ListItems;
        public IEnumerable<Category> CategoriesList;
        public Pager Pager { get; set; }
    }
}
