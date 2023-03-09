using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoLibreTests
{
    public sealed class ChromeDriverManager
    {
        private static ChromeDriver driverInstance;

        private ChromeDriverManager() { }

        public static ChromeDriver GetDriver()
        {
            if (driverInstance == null)
            {
                ChromeOptions options = new ChromeOptions();

                // Add any desired options to the options object here
                driverInstance = new ChromeDriver(options);
            }
            return driverInstance;
        }
    }

}