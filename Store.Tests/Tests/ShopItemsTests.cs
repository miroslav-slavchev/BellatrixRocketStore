using NUnit.Framework;
using Store.Tests.Hooks;
using Store.Library.PageComponents.PageObjects.ShopItems;
using Store.Library.Pages;

namespace Store.Tests.Tests
{
    internal class ShopItemsTests : BaseTests
    {
        protected Shop ShopPage { get; private set; }

        [SetUp]
        public void InitialisePage()
        {
            ShopPage = new Shop(Driver);
        }

        [Test]
        public void AddItem()
        {
            InStockShopItem protonRocket = ShopPage.GetInStockShopItem("Proton Rocket");
            Assert.IsTrue(protonRocket.HasSaleLabel);
            protonRocket.AddToCart();
            protonRocket.ViewCart();
        }
    }
}
