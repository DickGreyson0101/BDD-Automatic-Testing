using BRCtest.BRCWebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumUITest.BasePage;
using SeleniumUITest.Pages;

namespace SpecFlowTestNet4_8.StepDefinitions
{
    [Binding]
    public class LogInSteps
    {
        private readonly LogInPage logInPage = new LogInPage();

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            // Code to navigate to the login page
        }

        [When(@"I enter ""(.*)"" and ""(.*)""")]
        public void WhenIEnterAnd(string email, string password)
        {
            logInPage.Login(email, password);
        }

        [Then(@"the login result should be ""(.*)""")]
        public void ThenTheLoginResultShouldBe(string expectedResult)
        {
            // Extract the expected result as a boolean
            bool expectedBoolResult = bool.Parse(expectedResult);

            // Code to verify the URL and the success message
            string currentUrl = BRCWebDriver.GetInstance().Url;
            bool urlCheck = currentUrl.Contains("https://brc-uat.azurewebsites.net/Home.aspx");

            bool messageDisplayed = false;
            if (urlCheck)
            {
                try
                {
                    IWebElement successMessage = BRCWebDriver.GetInstance().FindElement(logInPage.SuccessfulMessage);
                    messageDisplayed = successMessage.Displayed;
                }
                catch (NoSuchElementException)
                {
                    messageDisplayed = false;
                }
            }

            // Combine the checks for final result
            bool result = urlCheck && messageDisplayed;

            // Assert the result
            Assert.AreEqual(expectedBoolResult, result);
        }


        // Additional steps for other scenarios
        [AfterTestRun]
        public static void CleanupAfterAllTests()
        {
            SetUp.Cleanup();
        }
    }



}