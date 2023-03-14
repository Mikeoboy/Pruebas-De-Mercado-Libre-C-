using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace MercadoLibreTests.StepDefinitions
{
    [Binding]
    public class MercadoLibreTestsStepDefinitions
    {
        private PageObjectModel Pom;
        private readonly IWebDriver driver;
        private readonly Actions action;

        public MercadoLibreTestsStepDefinitions()
        {
            driver = ChromeDriverManager.GetDriver();
            Pom = new PageObjectModel();
            
        }

        [Given(@"Navegar a Mecado Libre")]
        public void GivenAbrirBrowser()
        {
            if(Pom.CoockiesEntendidoButton.Displayed)
            {
                Pom.CoockiesEntendidoButton.Click();
            }
        }

        [When(@"Buscar Iphone")]
        public void BuscarIphone()
        {
            Pom.SearchMethod("iPhone");
        }

        [When(@"Click en categoria")]
        public void ClickEnCategoria()
        {
            Pom.ClickOnCategoriasButton();
        }

        [When(@"Buscar Prenda y agregarla al carrito")]
        public void BuscarPrendaYAgregarlaAlCarrito()
        {
            Pom.SearchMethod("pantalon levis hombre");
            Pom.ClickOnLevisPantalon();
            Pom.ClickOnAddCart();

        }

        [Then(@"Deberia aparecer una lista de iPhones")]
        public void DeberiaAparecerUnaListaDeIPhones()
        {
            Assert.IsTrue(Pom.IsVisibleArticleAfterSearch("iPhone").Displayed);
        }

        [Then(@"Añadir articulo al carrito y verificar que este ahi")]
        public void AnadirArticuloAlCarritoYVerificarQueEsteAhi()
        {
            Pom.IsVisibleArticleAfterSearch("Apple iPhone 14").Click();
            Pom.ClickOnAddCart();
            Assert.IsTrue(Pom.IsMessageAfterAddToCartArticleVisible());
        }

        [Then(@"Verificar los headers Menu Categories")]
        public void VerificarLosHeadersMenuCategories(Table table)
        {
            Pom.CompareTwoLists(table, Pom.HeadersCategorias);
        }

        [Then(@"Verificar valores del dropdown categories")]
        public void VerificarValoresDelDropdownCategories(Table table)
        {
            Pom.IsElementPresentOnUI(table);
        }
        [Then(@"Verificar que se agrego correctamente")]
        public void VerificarQueSeaLaPrenda()
        {
            Assert.IsTrue(Pom.IsMessageAfterAddToCartArticleVisible());

        }


    }
}

