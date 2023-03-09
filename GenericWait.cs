using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoLibreTests
{
    public class GenericWait
    {
        public static bool Wait(Func<bool> waitForTrue, TimeSpan retrytime, TimeSpan timeout, bool throwException)
        {
            DateTime now = DateTime.Now;
            Exception ex = null;
            do
            {
                try
                {
                    ex = null;
                    if (waitForTrue())
                    {
                        return true;
                    }
                }
                catch (Exception ex2)
                {
                    if (throwException)
                    {
                        ex = ex2;
                    }
                }
                Thread.Sleep(retrytime);
            }
            while (DateTime.Now - now < timeout);
            if (throwException && ex != null)
            {
                throw ex;
            }
            return false;
        }

    }
}
    //GenericWait.Wait(() =>
    //{
    //    if(driver.FindElement(By.XPath("//h2[contains(text(), 'iPhone')]")).Displayed)
    //    {
    //        return true;
    //    }
    //    return true;
    //}, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(60), false);

