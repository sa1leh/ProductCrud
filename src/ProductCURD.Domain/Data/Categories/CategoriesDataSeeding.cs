using ProductCURD.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace ProductCURD.Data.Categories
{
    public class CategoriesDataSeeding : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Category, int> categoryRepository;

        public CategoriesDataSeeding(IRepository<Category, int> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            if (!await categoryRepository.AnyAsync())
            {
                var categories = new List<Category>
            {
            new Category(id:1 , categoryName:"Clothing")

            };

                await this.categoryRepository.InsertManyAsync(categories);
            }
        }

    }
}
