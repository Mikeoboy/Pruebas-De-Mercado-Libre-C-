using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace MercadoLibreTests
{
    [Binding]
    public sealed class Hooks1
    {
        private readonly IWebDriver driver;
        public Hooks1()
        {
            driver = ChromeDriverManager.GetDriver();
        }



        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            driver.Url = "https://www.mercadolibre.com.mx/";
            driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void AfterScenario()
        {
           driver.Quit();
        }
    }
}