using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System.Security.Cryptography.X509Certificates;

namespace MercadoLibreTests
{
    public class PageObjectModel
    {
        private readonly IWebDriver driver;
        private readonly Actions action;
        public PageObjectModel()
        {
            driver = ChromeDriverManager.GetDriver();
            action = ChromeDriverManager.GetActions();
        }

        public IWebElement TextBox => driver.FindElement(By.Id("cb1-edit"));
        private IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        private IWebElement CategoriasButton => driver.FindElement(By.XPath("//a[text()='Categorías']"));
        public IWebElement CuidadoDelCabello => driver.FindElement(By.XPath("//*[text()='Cuidado del Cabello']"));
        public IWebElement CoockiesEntendidoButton => driver.FindElement(By.XPath("//*[text()='Entendido']"));
        public IWebElement IsVisibleArticleAfterSearch(string article) => driver.FindElement(By.XPath($"//h2[contains(text(), '{article}')]"));
        public IWebElement AddToCartButton => driver.FindElement(By.XPath($"//*[text()='Agregar al carrito']//parent::button"));
        public IWebElement PantalonLevisButton => driver.FindElement(By.XPath("//*[text()='Levi´s Pantalón Hombre 502 Taper Mex Dark 29 29507-0788']"));
        private IWebElement MessageAfterAddToCart => driver.FindElement(By.XPath("//div//*[text()='¡Hola! Para agregar al carrito, ingresa a tu cuenta']"));
        public IReadOnlyList<IWebElement> HeadersCategorias => driver.FindElements(By.XPath($"//ul[@class='nav-menu-list']//li//a")).ToList();
        public IReadOnlyList<IWebElement> DropDownCategoriasOptions => driver.FindElements(By.XPath($"//ul//li[@class='nav-menu-item']//div//ul//li//a")).ToList();






        //--------------------------------------------------------------------  METHODS ----------------------------------------------------------------------------------------------

        public void SearchMethod(string search)
        {
            TextBox.SendKeys($"{search}");
            SubmitButton.Click();
        }

        public void ClickOnAddCart() => AddToCartButton.Click();

        public void ClickOnCategoriasButton() => CategoriasButton.Click();
        public void ClickOnLevisPantalon() => PantalonLevisButton.Click();
        public bool IsMessageAfterAddToCartArticleVisible() => ElementIsPresent(driver, MessageAfterAddToCart, 10);


        /// <summary>
        /// Verify if the element is visible on the page with a timeout 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="locator"></param>
        /// <returns></returns>
        public static bool ElementIsPresent(IWebDriver driver, IWebElement locator, double timeout)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
                wait.Until(drv => locator); 
                return true;
            }

            catch { }
            return false;
        }

        /// <summary>
        ///  Hace una iteracion de una tabla en las feature para convertirla en una lista y poder hacer Aserciones y comparar
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public List<string> ConvertirAListaFromFeature(Table table)
        {
            List<string> listOfValues = new List<string>();



            foreach (var item in table.Rows)
            {
                var val = item[0];
                if (val != null)
                {
                    listOfValues.Add(item[0]);
                }
            }
            return listOfValues;
        }


        /// <summary>
        /// Parecido al metodo TextoDeListasParaAsserts pero este es leyendo los datos desde la ui pasandole un selector que contenga varios textos y convertirlos en una lista de textos
        /// </summary>
        /// <param name="Elements"></param>
        /// <returns></returns>
        public List<string> TextoDeUnaListaFromUI(IReadOnlyList<IWebElement> Elements)
        {
            List<string> headersOfTable = new List<string>();
            { 
            foreach (var element in Elements)
            
                if(element.Text != "")
                {
                    headersOfTable.Add(element.Text);
                }
            }
            return headersOfTable;
        }

        public void CompareTwoLists(Table table, IReadOnlyList<IWebElement> selectorWithListOfElements)
        {
            var lista = ConvertirAListaFromFeature(table);
            var listaFromUI = TextoDeUnaListaFromUI(selectorWithListOfElements);

            foreach (var element in lista)
            {
                var header = listaFromUI.SingleOrDefault(x => x.Equals(element));
                Assert.AreEqual(element, header);
            }

        }

        public bool IsElementPresentOnUI(Table table)
        {
            bool IsCategoriesMenuVisible = GenericWait.Wait(() =>
            {
                CategoriasButton.Click();
                var element = driver.FindElement(By.XPath("//*[text()='Hogar y Muebles ']"));
                action.MoveToElement(element).Perform();
                var elementMarket = driver.FindElement(By.XPath("//*[text()='Supermercado']"));
                action.MoveToElement(elementMarket).Perform();
                CategoriasButton.Click();
                CompareTwoLists(table, driver.FindElements(By.XPath($"(//ul//li[@class='nav-menu-item'])//div//ul//li//a")).ToList());
                return true;
            }, TimeSpan.Zero, TimeSpan.FromSeconds(60), false);
            return IsCategoriesMenuVisible;
        }
    }
}
