using Budgetting.Domain.Models;
using Budgetting.Repository;
using Budgetting.Services;
using BudgettingPersistence;

namespace TestProject
{
    [TestClass]
    public class ProductTest
    {
        private IProductService _productService;
        private IBudgettingContext ctx = new BudgettingContext();
        public ProductTest()
        {
            var ctx = new BudgettingContext();
            _productService = new ProductService(ctx);
        }
        [TestMethod]
        public async Task GetItem_ShouldReturnItemAsync()
        {

            //_productService = new ProductService(ctx);
            var item = new Product
            {
                Id = "5708324c-fdca-47d6-a799-90640eecc7e0",
                Name = "Matte Lip stick"
            };
            var existing = await _productService.GetItem(item);
            Assert.AreEqual(item.Id, existing.Id);
        }

        [TestMethod]
        public async Task GetItems_ShouldNotBeNull()
        {
            var query = await _productService.GetItems();
            Assert.IsNotNull(query);
        }

    }
}