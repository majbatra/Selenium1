using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Net;
using static System.Collections.Specialized.BitVector32;

internal class Program
{
    private static void Main(string[] args)
    {
        //Create the reference for our browser.
        IWebDriver driver = new ChromeDriver();

        //Maximize the window
        driver.Manage().Window.Maximize();

        //Navigate to google page.

        driver.Navigate().GoToUrl("https://testautomationpractice.blogspot.com/");

        //ImplicitWait
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        
        driver.SwitchTo().Frame(0);

        //Find the First Name element
        IWebElement First_element = driver.FindElement(By.Id("RESULT_TextField-1"));
        //Input First Name
        First_element.SendKeys("Rahul");

        //Find the Last Name element
        IWebElement Last_element = driver.FindElement(By.Id("RESULT_TextField-2"));
        //Input Last Name
        Last_element.SendKeys("Tiwari");

        //Find the Phone Number element
        IWebElement Phone_element = driver.FindElement(By.Id("RESULT_TextField-3"));
        //Input Phone Number
        Phone_element.SendKeys("+91 7905975082");

        //Find the Country element
        IWebElement Country_element = driver.FindElement(By.Id("RESULT_TextField-4"));
        //Input Phone Number
        Country_element.SendKeys("India");

        //Find the City element
        IWebElement City_element = driver.FindElement(By.Id("RESULT_TextField-5"));
        //Input Phone Number
        City_element.SendKeys("Varanasi");

        //Find the Email element
        IWebElement Email_element = driver.FindElement(By.Id("RESULT_TextField-6"));
        //Input Phone Number
        Email_element.SendKeys("rti@leapwork.com");

        //Find the Gender element
        IWebElement Gender_element = driver.FindElement(By.XPath("//*[@id=\"q26\"]/table/tbody/tr[1]/td/label"));
        //Input Phone Number
        Gender_element.Click();

        //Find the week element
        IWebElement Week_element = driver.FindElement(By.XPath("//*[@id=\"q15\"]/table/tbody/tr[2]/td/label"));
        //Click Week Element by id
        Week_element.Click();

        //Find the dropdown element
        SelectElement dropDown = new SelectElement(driver.FindElement(By.Id("RESULT_RadioButton-9")));
        //Selecting the dropdown by value
        dropDown.SelectByValue("Radio-1");

        //Find the upload element
        IWebElement Upload_element = driver.FindElement(By.Id("RESULT_FileUpload-10"));
        //Uploading the file
        Upload_element.SendKeys("C:\\Users\\rahul\\Downloads\\4.png");

        //Find the Submit button
        //IWebElement btn = driver.FindElement(By.Id("FSsubmit"));
        //Input Phone Number
        // btn.Click();

        //Getting out of iframe
        driver.SwitchTo().DefaultContent();

        //Left Pane scraping and fill Up
        //Search and pick the first search
        driver.FindElement(By.ClassName("wikipedia-search-input")).SendKeys("Car");
        driver.FindElement(By.ClassName("wikipedia-search-button")).Click();
        Thread.Sleep(3000);
        driver.FindElement(By.XPath("//div[@id=\"wikipedia-search-result-link\"][1]/a")).Click();

        //Switching back to parent window
        driver.SwitchTo().Window(driver.WindowHandles[0]);

        //Handling Alert
        Thread.Sleep(3000);
        IWebElement Alert_element = driver.FindElement(By.XPath("//*[@id=\"HTML9\"]/div[1]/button"));
        //clicking on the button
        Alert_element.Click();
        // Switch the control of 'driver' to the Alert from main Window
        IAlert simpleAlert = driver.SwitchTo().Alert();
        // '.Text' is used to get the text from the Alert
        String alertText = simpleAlert.Text;
        Console.WriteLine("Alert text is " + alertText);
        // '.Accept()' is used to accept the alert '(click on the Ok button)'
        simpleAlert.Accept();
        //To fetch text displayed after clicking the alert
        IWebElement AText_element = driver.FindElement(By.Id("demo"));
        string AlText = AText_element.Text;
        Console.WriteLine(AlText);


        /****************************************Date Picker************************************/

        //1st Method :Interacting with Date Picker for a particluar date of this month 
        //driver.FindElement(By.XPath("//*[@id=\"datepicker\"]")).Click(); // find the calendar input field and click on it.
        //IWebElement Date_element = driver.FindElement(By.XPath("//*[@id=\"ui-datepicker-div\"]/table/tbody/tr[1]/td[4]/a"));
        // Date_element.Click();

        //*[@id="ui-datepicker-div"]/table/tbody/tr[4]/td[6]/a

        //2nd Method: 
        //Year is 2023
         String month = "February";
         String date = "24";
         driver.FindElement(By.CssSelector("input#datepicker")).Click();

         //Selecting Month
         while (!driver.FindElement(By.CssSelector("span.ui-datepicker-month")).Text.Contains(month))
         {
             driver.FindElement(By.CssSelector("span.ui-icon.ui-icon-circle-triangle-e")).Click();
             Thread.Sleep(1000);
         }

         //Selecting Date
         List<IWebElement> dates_available = new List<IWebElement>(driver.FindElements(By.CssSelector("a.ui-state-default")));
         foreach (IWebElement ele in dates_available) // use foreach iterate each cell.
         {
             string datez = ele.Text; // get the text of the element.

             if (datez.Equals(date)) // check if the date is 20
             {
                 ele.Click(); // if date is 20, select it.
                 break;
             }
         }

         //Scroll by 300 pixels
         ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,300)");

         /******************************* Working with Menu's **********************/
        //Select a speed
         SelectElement speed = new SelectElement(driver.FindElement(By.Id("speed")));
         //Selecting the dropdown by value
         speed.SelectByIndex(3);

         //Select a file
         SelectElement file = new SelectElement(driver.FindElement(By.Id("files")));
         //Selecting the dropdown by value
         file.SelectByIndex(2);

         //Select a number
         SelectElement number = new SelectElement(driver.FindElement(By.Id("number")));
         //Selecting the dropdown by value
         number.SelectByIndex(3);

         //Select a Product
         SelectElement Product = new SelectElement(driver.FindElement(By.Id("products")));
         //Selecting the dropdown by value
         Product.SelectByIndex(2);

         //Select a Animal
         SelectElement animal = new SelectElement(driver.FindElement(By.Id("animals")));
         //Selecting the dropdown by value
         animal.SelectByIndex(2);

         //Fetching different Text Labels
         IWebElement First_Text = driver.FindElement(By.ClassName("widget-content"));
         //Input First Name
         Console.WriteLine(First_Text.Text);
         List<IWebElement> text_labels = new List<IWebElement>(driver.FindElements(By.XPath("//span[@style='font-family: Georgia, serif;']")));

         foreach(IWebElement text in text_labels)
         {
             Console.WriteLine(text.Text);
         }

         //Double Clicking on the Click button.
         driver.FindElement(By.Id("field1")).Clear();
         driver.FindElement(By.Id("field1")).SendKeys("Hello Leapwork!");
         Actions a = new Actions(driver);
         a.DoubleClick(driver.FindElement(By.XPath("//button[@ondblclick=\"myFunction1()\"]"))).Build().Perform();
         Thread.Sleep(2000);

         

        /**************Drag and Drop**************/
        //Actions class method to drag and drop 
        Actions builder = new Actions(driver);
         IWebElement from = driver.FindElement(By.Id("draggable"));
         IWebElement to = driver.FindElement(By.Id("droppable"));
         //Perform drag and drop
         builder.DragAndDrop(from, to).Perform();


         ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,300)");
         //Drag and Drop Images
         Actions builders = new Actions(driver);
         IWebElement from1 = driver.FindElement(By.XPath("//*[@id=\"gallery\"]/li[1]/img"));
         IWebElement from2 = driver.FindElement(By.XPath("//*[@id=\"gallery\"]/li[2]/img"));
         IWebElement to1 = driver.FindElement(By.XPath("//*[@id=\"trash\"]"));
         //Perform drag and drop
         builders.DragAndDrop(from1, to1).Perform();
         builders.DragAndDrop(from2, to1).Perform();

        ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0,400)");

        //Sliding code
        IWebElement slider = driver.FindElement(By.XPath("//*[@id=\"slider\"]"));
        Actions move = new Actions(driver);
        OpenQA.Selenium.Interactions.Actions sliderAction = new OpenQA.Selenium.Interactions.Actions(driver); 
        sliderAction.ClickAndHold(slider);
        sliderAction.MoveByOffset(40, 0).Build().Perform();

        //Resizeable element
        IWebElement resizeable = driver.FindElement(By.CssSelector("#resizable > div.ui-resizable-handle.ui-resizable-se.ui-icon.ui-icon-gripsmall-diagonal-se"));
        Actions resize = new Actions(driver);
        OpenQA.Selenium.Interactions.Actions resizeAction = new OpenQA.Selenium.Interactions.Actions(driver);
        resizeAction.ClickAndHold(resizeable);
        resizeAction.MoveByOffset(50, 0).Build().Perform();

        //HTML Table
        List<IWebElement> rows = new List<IWebElement>(driver.FindElements(By.XPath("//table[@name='BookTable']/tbody/tr/td")));
        foreach (IWebElement text in rows)
        {
            Console.WriteLine(text.Text);
        }
        



    }
}






