using System.Collections.ObjectModel;
using OpenQA.Selenium.Interactions;

namespace AutomationHackathon23.Helpers
{
    public static class BrowserExtensions
    {
        public static IWebElement WaitForAndReturn(this IWebDriver driver, By selector, int timeout = 30, Func<IWebElement?>? parentElementFunc = null)
        {
            var defaultTimeout = driver.Manage().Timeouts().ImplicitWait;
            try
            {
                Exception? exception = null;
                IWebElement? element = null;

                var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(timeout)).Token;
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;

                Wait.WaitFor(
                    () =>
                    {
                        try
                        {
                            exception = null;
                            var parentElement = parentElementFunc?.Invoke();
                            element = parentElement == null
                                ? driver.FindElement(selector)
                                : parentElement.FindElement(selector);

                            if (element == null)
                            {
                                return false;
                            }

                            ScrollIntoView(driver, element);
                            return true;
                        }
                        catch (Exception e)
                        {
                            exception = e;
                            return false;
                        }
                    }, cancellationToken);

                if (element != null)
                {
                    return element;
                }

                throw new NoSuchElementException($"Element was not found by selector: {selector.Criteria}", exception);
            }
            catch (OperationCanceledException e)
            {
                throw new OperationCanceledException($"Element was not found by selector: {selector.Criteria}", e);
            }
            finally
            {
                driver.Manage().Timeouts().ImplicitWait = defaultTimeout;
            }
        }

        public static ReadOnlyCollection<IWebElement> WaitForAndReturnElements(this IWebDriver driver, By selector, Func<IWebElement>? parentElementFunc = null, int timeout = 30)
        {
            ReadOnlyCollection<IWebElement>? elements = null;
            Exception? exception = null;

            var cancellationToken = new CancellationTokenSource(TimeSpan.FromSeconds(timeout)).Token;
            var defaultTimeout = driver.Manage().Timeouts().ImplicitWait;
            try
            {
                Wait.WaitFor(
                    () =>
                    {
                        try
                        {
                            exception = null;
                            var parentElement = parentElementFunc?.Invoke();

                            driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
                            elements = parentElement == null
                                ? driver.FindElements(selector)
                                : parentElement.FindElements(selector);

                            return true;
                        }
                        catch (Exception e)
                        {
                            exception = e;
                            return false;
                        }
                        finally
                        {
                            driver.Manage().Timeouts().ImplicitWait = defaultTimeout;
                        }
                    }, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                throw new OperationCanceledException($"Elements were not found by selector: {selector.Criteria}", exception);
            }

            return elements ?? throw new NoSuchElementException($"Elements were not found by selector: {selector.Criteria}", exception);
        }
        
        public static void ScrollIntoView(this IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoViewIfNeeded();", element);        
        }

        public static void ScrollToBottom(this IWebDriver driver)
        {
            var action = new Actions(driver);
            action.SendKeys(Keys.End).Perform();
        }
        
        public static void ScrollToTop(this IWebDriver driver)
        {
            var action = new Actions(driver);
            action.SendKeys(Keys.Home).Perform();
        }

        public static void HitKeyboardEnter(this IWebDriver driver)
        {
            var action = new Actions(driver);
            action.SendKeys(Keys.Enter).Perform();
        }
        
        public static void HoverOn(this IWebDriver driver, IWebElement element, int x = 0, int y = 0)
        {
            var action = new Actions(driver);
            action.MoveToElement(element, x, y).Perform();
        }        
        
        public static void meu(this IWebDriver driver, IWebElement element, int x = 0, int y = 0)
        {
            var action = new Actions(driver);
            var xx = element.Size;
            var yy = element.Location;
            action.MoveToElement(element, -xx.Width/2, 0)
                .MoveByOffset(x, y)
                .ClickAndHold()
                // .Pause(TimeSpan.FromMilliseconds(500))
                .Release()
                .Build()
                .Perform();
        }
    }
}