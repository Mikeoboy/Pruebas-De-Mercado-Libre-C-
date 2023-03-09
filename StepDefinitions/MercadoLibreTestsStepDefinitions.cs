using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MercadoLibreTests.StepDefinitions
{
    [Binding]
    public class MercadoLibreTestsStepDefinitions
    {
        private PageObjectModel pageObjectModel;
        private readonly IWebDriver driver;

        public MercadoLibreTestsStepDefinitions()
        {
            driver = ChromeDriverManager.GetDriver();
            pageObjectModel = new PageObjectModel();
        }


        [Given(@"Navegar a Mecado Libre")]
        public void GivenAbrirBrowser()
        {
        }

        [When(@"Buscar Iphone")]
        public void BuscarIphone()
        {
            pageObjectModel.SearchMethod("iPhone");
        }

        [When(@"Click en categoria")]
        public void ClickEnCategoria()
        {

        }


        [Then(@"Deberia aparecer una lista de iPhones")]
        public void DeberiaAparecerUnaListaDeIPhones()
        {
            Assert.IsTrue(pageObjectModel.IsVisibleArticleAfterSearch("iPhone").Displayed);
        }

        [Then(@"Añadir articulo al carrito y verificar que este ahi")]
        public void AnadirArticuloAlCarritoYVerificarQueEsteAhi()
        {
            pageObjectModel.IsVisibleArticleAfterSearch("Apple iPhone 14").Click();
            pageObjectModel.ClickOnAddCart();
            Assert.IsTrue(pageObjectModel.IsMessageAfterAddToCartArticleVisible());
        }

        [Then(@"Verificar los headers Menu Categories")]
        public void VerificarLosHeadersMenuCategories(Table table)
        {
            pageObjectModel.CompareTwoLists(table, pageObjectModel.HeadersCategorias);
        }

        [Then(@"Verificar valores del dropdown categories")]
        public void ThenVerificarValoresDelDropdownCategories(Table table)
        {
            pageObjectModel.ClickOnCategoriasButton();
            pageObjectModel.CompareTwoLists(table, pageObjectModel.DropDownCategoriasOptions);
        }



    }
}

