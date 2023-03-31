using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnitDemonstration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TriangleSolver;




namespace SystemTesting
{
    public class TriangleTest
    {

        private IWebDriver driver;

   
        [SetUp]
        public void Setup()
        {

            // Set Up Chrome Driver
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            driver = new ChromeDriver(options);

            // Navigate to the Web URL

            driver.Navigate().GoToUrl("http://localhost:8080/prog2070a03/getQuote.html");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        public decimal CalculatePremium(int age, int experience, int accidents)
        {
            decimal insuranceValue = 0;
            if (accidents >= 3)
            {
                // If the driver has 3 or more accidents on record, refuse to provide them with insurance.
                string insuranceInvalid = "Insurance Not Provided";
            }
            else
            {
                // Calculate the base rate based on driving experience.
                decimal baseRate = 0;

                if (age == 0 || age.Equals(null))
                {
                    return insuranceValue;
                }


                if (experience < 1)
                {
                    // If the driver has no driving experience, apply a base rate of $6000 annually.
                    baseRate = 6000;
                }
                else if (experience >= 1 && experience <= 9)
                {
                    // If a driver has 1 to 9 years of experience, apply a base rate of $4500 annually.
                    baseRate = 4500;
                }
                else
                {
                    // Otherwise, apply a base rate of $3000 annually.
                    baseRate = 3000;
                }

               
                // Apply a rate reduction for drivers who are 30 years old or older and have at least two years of driving experience.
                if (age >= 30 && experience >= 2)
                {
                    decimal rateReduction = baseRate * 0.27m;
                    insuranceValue = baseRate - rateReduction;
                }
                else
                {
                    insuranceValue = baseRate;
                }
            }
            return insuranceValue;
            
        }

        // VALIDATIONS

        // Method to validate phone number formate
        public bool ValidatePhoneNumber(string phoneNumber)
        {
            // Define the regular expression pattern to match the "111-111-1111" format.
            string pattern = @"^\d{3}-\d{3}-\d{4}$";

            // Create a regular expression object using the pattern.
            Regex regex = new Regex(pattern);

            // Test if the phone number matches the pattern.
            if (regex.IsMatch(phoneNumber))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Method to validate email address format
        public bool ValidateEmailAddress(string email)
        {
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }

        // Postal code validation function
        public bool ValidatePostalCode(string postalCode)
        {
            // Canadian postal codes have the format A1A 1A1
            string pattern = @"^[A-Za-z]\d[A-Za-z]\s\d[A-Za-z]\d$";

            // Use a regular expression to match the input string with the pattern
            Match match = Regex.Match(postalCode, pattern);

            // If the input string matches the pattern, return true
            return match.Success;
        }
        
        // Validating Name
        public bool ValidateName(string name)
        {
            // Check if name is null or empty
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            // Check if name contains only letters, spaces, hyphens, or apostrophes
            foreach (char c in name)
            {
                if (!char.IsLetter(c) && c != ' ' && c != '-' && c != '\'')
                {
                    return false;
                }
            }

            return true;
        }

        //Validating City Name

        public bool ValidateCity(string city)
        {
            // Check if city name is null or empty
            if (string.IsNullOrEmpty(city))
            {
                return false;
            }

            // Check if city name contains any non-alphabetic characters or digits
            foreach (char c in city)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }

            return true;
        }


        [Test]
        public void Test1()
        {
            // TEST 1 DETAILS : Your first and last name with all remaining fields with valid data,
            // Age = 25, Driving Experience = 3,
            // Accidents = 0

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");
            

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("25");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            
            decimal expectedValue = 4500.00m;
            var InsuranceValue = CalculatePremium(25, 3, 0);
            Assert.AreEqual(expectedValue, InsuranceValue);

            
        }

        [Test]
        public void Test2()
        {
            // TEST 2 DETAILS : Your first and last name with all remaining fields with valid data,
            // Age = 25, Driving Experience = 3,
            // Accidents = 4

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("25");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("4");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            var insuranceValue = CalculatePremium(25, 3, 4);
            string expectedValue = "Insurance Not Provided";
            string insuranceInvalid = "Insurance Not Provided";
            Assert.AreEqual(expectedValue, insuranceInvalid);
        }

        [Test]
        public void Test3()
        {
            // TEST 3 DETAILS : Your first and last name with all remaining fields with valid data, Age = 35, Driving Experience = 10, Accidents = 2

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("25");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 2190m;
            var InsuranceValue = CalculatePremium(35, 10, 2);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test4()
        {
            // TEST 3 DETAILS :Invalid phone number with all remaining fields with valid data,
            // Age = 27,
            // Driving Experience = 3,
            // Accidents = 0

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("012");

            // Validate the phone number format
            bool isPhoneNumberValid = ValidatePhoneNumber(phoneNum.GetAttribute("value"));
           

            // Assert that the phone number format is valid
            Assert.IsTrue(isPhoneNumberValid);

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("25");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 4500m;
            var InsuranceValue = CalculatePremium(27, 3, 0);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test5()
        {
            // TEST 3 DETAILS : Your first and last name with all remaining fields with valid data,
            // Age = 28
            // Driving Experience = 3
            // Accidents = 0

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@@@hotmail.com");

            // Validate the email address format
            bool isEmailValid = ValidateEmailAddress(email.GetAttribute("value"));

            // Assert that the email address format is valid
            Assert.IsTrue(isEmailValid);

           

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("25");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 4500m;
            var InsuranceValue = CalculatePremium(28, 3, 0);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test6()
        {
            // TEST 3 DETAILS : Your first and last name with all remaining fields with valid data,
            // Age = 35
            // Driving Experience = 17
            // Accidents = 1

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H3R6");

            //Validating Postal Code
            bool isPostalCodeValid = ValidatePostalCode(postalCode.GetAttribute("value"));

            Assert.IsTrue(isPostalCodeValid);

           


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("25");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 2190m;
            var InsuranceValue = CalculatePremium(35, 17, 1);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test7()
        {
            // TEST 3 DETAILS : Your first and last name with all remaining fields with valid data,
            // Age = Omitted
            // Driving Experience = 5
            // Accidents = 0

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("0");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 0m;
            var InsuranceValue = CalculatePremium(0, 17, 1);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test8()
        {
            // TEST 3 DETAILS : Your first and last name with all remaining fields with valid data,
            // Age = 37
            // Driving Experience = 8
            // Accidents = 0

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("25");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 3285m;
            var InsuranceValue = CalculatePremium(37, 8, 0);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test9()
        {
            // TEST 3 DETAILS : Your first and last name with all remaining fields with valid data,
            // Age = 45
            // Driving Experience = omitted
            // Accidents = 0

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");


            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("25");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 6000m;
            var InsuranceValue = CalculatePremium(37, 0, 1);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test10()
        {
            // TEST 3 DETAILS : Invalid first or last name with all remaining fields with valid data,
            // Age = 23
            // Driving Experience = 2
            // Accidents = 1

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad12");

            bool isFirstNameValid = ValidateName(firstName.GetAttribute("value"));
            Assert.IsTrue(isFirstNameValid);

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            bool isLastNameValid = ValidateName(lastName.GetAttribute("value"));
            Assert.IsTrue(isLastNameValid);

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("25");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 6000m;
            var InsuranceValue = CalculatePremium(23, 2, 1);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test11()
        {
            // TEST 3 DETAILS : Invalid City Name with all remaining fields with valid data,
            // Age = 23
            // Driving Experience = 2
            // Accidents = 1

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad12");

            bool isFirstNameValid = ValidateName(firstName.GetAttribute("value"));
            Assert.IsTrue(isFirstNameValid);

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            bool isLastNameValid = ValidateName(lastName.GetAttribute("value"));
            Assert.IsTrue(isLastNameValid);

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");

            bool isCityValid = ValidateCity(city.GetAttribute("value"));
            Assert.IsTrue(isCityValid);

            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("25");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 6000m;
            var InsuranceValue = CalculatePremium(23, 2, 1);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test12()
        {
            // TEST 3 DETAILS : Invalid City Name with all remaining fields with valid data,
            // Age = 29
            // Driving Experience = 3
            // Accidents = 2

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");

          

            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");

            

            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");


            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("29");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("3");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("2");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 4500m;
            var InsuranceValue = CalculatePremium(29, 3, 2);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test13()
        {
            // TEST 3 DETAILS : Invalid City Name with all remaining fields with valid data,
            // Age = 30
            // Driving Experience = 2
            // Accidents = 0

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");



            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");



            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");


            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("30");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("2");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 3285m;
            var InsuranceValue = CalculatePremium(30, 2, 0);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test14()
        {
            // TEST 3 DETAILS : Invalid City Name with all remaining fields with valid data,
            // Age = 20
            // Driving Experience = 0
            // Accidents = 1

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");



            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");



            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");


            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("20");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("0");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("1");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 6000m;
            var InsuranceValue = CalculatePremium(20, 0, 1);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }

        [Test]
        public void Test15()
        {
            // TEST 3 DETAILS : Invalid City Name with all remaining fields with valid data,
            // Age = 45
            // Driving Experience = 5
            // Accidents = 0

            // Enter driver details
            IWebElement firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Muhammad");



            IWebElement lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Mian");



            IWebElement address = driver.FindElement(By.Id("address"));
            address.SendKeys("1633 King Street");

            IWebElement city = driver.FindElement(By.Id("city"));
            city.SendKeys("35");


            IWebElement province = driver.FindElement(By.Id("province"));
            province.SendKeys("ON");

            IWebElement postalCode = driver.FindElement(By.Id("postalCode"));
            postalCode.SendKeys("N3H 3R6");


            IWebElement phoneNum = driver.FindElement(By.Id("phone"));
            phoneNum.SendKeys("437-255-1821");

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("talha4321@hotmail.com");

            IWebElement age = driver.FindElement(By.Id("age"));
            age.SendKeys("45");

            IWebElement experince = driver.FindElement(By.Id("experience"));
            experince.SendKeys("5");

            IWebElement accidents = driver.FindElement(By.Id("accidents"));
            accidents.SendKeys("0");



            // Click on Calculate button
            IWebElement btnSubmit = driver.FindElement(By.Id("btnSubmit"));
            btnSubmit.Click();

            // Verify the calculated premium is correct
            IWebElement finalQuote = driver.FindElement(By.Id("finalQuote"));
            decimal expectedValue = 3285m;
            var InsuranceValue = CalculatePremium(45, 5, 0);
            Assert.AreEqual(expectedValue, InsuranceValue);
        }













    }

}
