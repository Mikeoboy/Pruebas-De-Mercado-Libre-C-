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

        /* Este método Wait en C# utiliza un bucle do-while para intentar ejecutar una función waitForTrue hasta que devuelve un valor true o se alcanza 
           el tiempo de espera máximo especificado en el parámetro timeout. El método toma cuatro parámetros:

       - waitForTrue es una función que devuelve un valor booleano y representa la condición que se está esperando que sea verdadera.
       - retrytime es el tiempo que se espera antes de volver a intentar la condición.
       - timeout es el tiempo máximo que se espera antes de abandonar el bucle y regresar false.
       - throwException es un valor booleano que indica si se debe lanzar una excepción si se alcanza el tiempo de espera máximo y la condición no se cumple.
        Dentro del bucle do-while, se intenta ejecutar la función waitForTrue y se verifica si devuelve true. Si es así, el método regresa true. Si la función waitForTrue lanza una excepción, se captura en el bloque catch y se asigna a la variable ex. Si throwException es verdadero, la excepción se re-lanza una vez que se alcanza el tiempo de espera máximo y la condición no se cumple.

        Después de cada intento de ejecutar la función waitForTrue, el hilo se duerme durante el tiempo especificado en retrytime.
        Si se alcanza el tiempo de espera máximo especificado en timeout y la condición no se cumple, el método regresa false. 
        Si throwException es verdadero y una excepción fue capturada anteriormente, el método lanza esa excepción.*/
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

