using ExpenseTrackerConsoleApplication;
using System.Globalization;

namespace ExpenseTrackerTests
{
    public class ExpenseTrackerApplicationTests
    {
        Category categoryInstance;
        FileManager fileManagerInstance;
        Services serviceInstance;
        UserAuthentication userAuthenticationInstance;
        User userInstance;
        public ExpenseTrackerApplicationTests()
        {
            Category categoryInstance= new Category();
            serviceInstance = new Services(categoryInstance);
            fileManagerInstance = new FileManager(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            userAuthenticationInstance = new UserAuthentication(fileManagerInstance, serviceInstance, categoryInstance);
        }


        [Theory]
        [InlineData("LapTop")]
        public void CategoryValueToBeAdded_CategoriesList_IsAddedInCategoriesList(string input)
        {
            //Arrange
            Category category = new Category();

            //Act
            category.Categories.Add(input);

            //Assert
            Assert.Contains(input, category.Categories);
        }

        [Theory]
        [InlineData("Sru", "U3J1")]
        public void PasswordAndEncodedPassword_EncodingPassword_IsActualPasswordAndEncodePasswordSame(string input, string actualOutput)
        {
            //Arrange
            Password password = new Password(input);

            //Assert
            Assert.Equal(password.EncodedPassword, actualOutput);
        }


        [Theory]
        [InlineData("Sru")]
        public void Password_EncodingPassword_IsEncoded(string input)
        {
            //Arrange
            Password password = new Password(input);

            //Act
            var expectedOutput = password.PasswordChecker(input);

            //Assert
            Assert.True(expectedOutput);
        }


        [Theory]
        [InlineData("Lipika", "Lipi")]
        public async void UserNameAndPassword_LoggingOut_IsLoggedOut(string userName, string userPassword)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            ActiveUsers.ActiveUser = user.UserName;

            //Act
            await userAuthenticationInstance.LogOut(user);

            //Assert
            Assert.True(ActiveUsers.ActiveUser == null);
        }

        [Theory]
        [InlineData("Lipika", "Lipi")]
        public void UserNameAndPassword_SigningIn_IsSignedIn(string userName, string password)
        {
            //Act
            var user = userAuthenticationInstance.UserSignIn(userName, password, fileManagerInstance);

            //Assert
            Assert.Equal(userName, user.UserName);
        }

        [Theory]
        [InlineData("Lipika", "Lipi")]
        public void UserNameAndPassword_AddingIncome_IsIncomeAdded(string userName, string password)
        {
            //Arrange
            User user = new User(userName, password, categoryInstance, serviceInstance);
            Income income = new Income(DateOnly.Parse("2023/10/10"), "Food",555, ModesOfCash.Cash, "From Testing!", 5.0);

            //Act
            user.AddIncome(income);

            //Assert
            Assert.Contains(income, user.Incomes);
        }

        [Theory]
        [InlineData("Lipika", "Lipi")]
        public void UserNameAndPassword_AddingExpense_IsExpenseAdded(string userName, string password)
        {
            //Arrange
            User user = new User(userName, password, categoryInstance, serviceInstance);
            Expense expense = new Expense(DateOnly.Parse("2023/10/10"), "Food", 555, ModesOfCash.Cash, "From Testing!", 5.0);

            //Act
            user.AddExpense(expense);

            //Assert
            Assert.Contains(expense, user.Expenses);
        }

        [Theory]
        [InlineData("Lipika", "Lipi", 10.0)]
        public void UserNamePasswordAndTotalExpense_TotalExpense_ExpectedOutput(string userName, string password, double expectedOutput)
        {
            //Arrange
            User user = new User(userName, password, categoryInstance, serviceInstance);

            Expense expense1 = new Expense(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            user.AddExpense(expense1);

            Expense expense2 = new Expense(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            user.AddExpense(expense2);

            //Act
            double actualOutput = user.ViewTotalExpense(user);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("Lipika", "Lipi", 10.0)]
        public void UserNamePasswordAndTotalIncome_TotalIncome_ExpectedOutput(string userName, string password, double expectedOutput)
        {
            //Arrange
            User user = new User(userName, password, categoryInstance, serviceInstance);

            Income income1 = new Income(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            user.AddIncome(income1);

            Income income2 = new Income(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            user.AddIncome(income2);

            //Act
            double actualOutput = user.ViewTotalIncome(user);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", 1, "11/10/2023")]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateDateForExpense_IsUpdated(string userName, string userPassword, int indexToUpdate, string expectedOutput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);

            Expense expenseData = new Expense(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            user.AddExpense(expenseData);

            //Act
            user.UpdateDateForExpense(indexToUpdate, DateOnly.Parse(expectedOutput));

            //Arrange
            Assert.Equal(DateOnly.Parse(expectedOutput),user.Expenses[indexToUpdate - 1].DateOnly);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", 1, 10.0)]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateAmountForExpense_IsUpdated(string userName, string userPassword, int indexToUpdate, double expectedOutput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);

            Expense expenseData = new Expense(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);

            //Act
            user.AddExpense(expenseData);
            user.UpdateAmountForExpense(indexToUpdate, expectedOutput);

            //Assert
            Assert.Equal(expectedOutput,user.Expenses[indexToUpdate - 1].Amount);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", 1, ModesOfCash.ECash)]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateModeOfCashForExpense_IsUpdated(string userName, string userPassword, int indexToUpdate, ModesOfCash mode)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Expense expenseData = new Expense(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            
            //Act
            user.AddExpense(expenseData);
            user.UpdateModeOfCashForExpense(indexToUpdate, mode);

            //Assert
            Assert.Equal(mode, user.Expenses[indexToUpdate - 1].AmountMode);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", 1, 555)]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateAccountNumberForExpense_IsUpdated(string userName, string userPassword, int indexToUpdate, int expectedOuput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Expense expenseData = new Expense(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            
            //Act
            user.AddExpense(expenseData);
            user.UpdateAccountNumberForExpense(indexToUpdate, expectedOuput);

            //Assert
            Assert.Equal(expectedOuput, user.Expenses[indexToUpdate - 1].Account);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", 1, "Food")]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateCategoryForExpense_IsUpdated(string userName, string userPassword, int indexToUpdate, string expectedOuput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Expense expenseData = new Expense(DateOnly.Parse("2023/10/10"), "Groceries", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            
            //Act
            user.AddExpense(expenseData);
            user.UpdateCategoryForExpense(indexToUpdate, expectedOuput);

            //Assert
            Assert.Equal(expectedOuput, user.Expenses[indexToUpdate - 1].Category);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", 1, "NotesForExpense")]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateNotesForExpense_IsUpdated(string userName, string userPassword, int indexToUpdate, string expectedOuput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Expense expenseData = new Expense(DateOnly.Parse("2023/10/10"), "Groceries", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            
            //Act
            user.AddExpense(expenseData);
            user.UpdateNotesForExpense(indexToUpdate, expectedOuput);

            //Assert
            Assert.Equal(expectedOuput, user.Expenses[indexToUpdate - 1].Note);
        }

        [Theory]
        [InlineData("Test", "TestPassword", 1, "11/10/11")]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateDateForIncome_IsUpdated(string userName, string userPassword, int indexToUpdate, string expectedOuput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Income income = new Income(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            
            //Act
            user.AddIncome(income);
            user.UpdateDateForIncome(indexToUpdate, DateOnly.Parse(expectedOuput));

            //Assert
            Assert.Equal(DateOnly.Parse(expectedOuput), user.Incomes[indexToUpdate - 1].DateOnly);

        }

        [Theory]
        [InlineData("TestName", "TestPassword", 1, 10.0)]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateAmountForIncome_IsUpdated(string userName, string userPassword, int indexToUpdate, double expectedOutput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Income income = new Income(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            
            //Act
            user.AddIncome(income);
            user.UpdateAmountForIncome(indexToUpdate, expectedOutput);

            //Assert
            Assert.Equal(expectedOutput, user.Incomes[indexToUpdate - 1].Amount);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", 1, ModesOfCash.ECash)]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateModeOfCashForIncome_IsUpdated(string userName, string userPassword, int indexToUpdate, ModesOfCash mode)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Income income = new Income(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.ECash, "From Testing!", 5.0);
            
            //Act
            user.AddIncome(income);
            user.UpdateModeOfCashForIncome(indexToUpdate, mode);

            //Assert
            Assert.Equal(mode, user.Incomes[indexToUpdate - 1].AmountMode);

        }


        [Theory]
        [InlineData("TestName", "TestPassword", 1, 555)]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateAccountNumberForIncome_IsUpdated(string userName, string userPassword, int indexToUpdate, int expectedOuput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Income income = new Income(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            
            //Act
            user.AddIncome(income);
            user.UpdateAccountNumberForIncome(indexToUpdate, expectedOuput);

            //Assert
            Assert.Equal(expectedOuput, user.Incomes[indexToUpdate - 1].Account);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", 1, "Food")]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateCategoryForIncome_IsUpdated(string userName, string userPassword, int indexToUpdate, string expectedOuput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Income income = new Income(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);

            //Act
            user.AddIncome(income);
            user.UpdateCategoryForIncome(indexToUpdate, expectedOuput);

            //Assert
            Assert.Equal(expectedOuput, user.Incomes[indexToUpdate - 1].Category);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", 1, "NotesForIncome")]
        public void UserNamePasswordAndIndexAndValueToUpdate_UpdateNotesForIncome_IsUpdated(string userName, string userPassword, int indexToUpdate, string expectedOuput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Income income = new Income(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);

            //Act
            user.AddIncome(income);
            user.UpdateNotesForIncome(indexToUpdate, expectedOuput);

            //Assert
            Assert.Equal(expectedOuput, user.Incomes[indexToUpdate - 1].Note);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", 2, "NotesForIncome")]
        public void UserNamePasswordAndIndexAndValueToDelete_DeleteIncome_IsDeleted(string userName, string userPassword, int indexToUpdate, string expectedOutput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Income income1 = new Income(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            Income income2 = new Income(DateOnly.Parse("2023/10/10"), "Food", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            
            //Act
            user.AddIncome(income1);
            user.AddIncome(income2);

            user.DeleteIncome(indexToUpdate, user);

            //Assert
            Assert.Equal(indexToUpdate - 1 , user.Incomes.Count);

        }

        [Theory]
        [InlineData("TestName", "TestPassword", 2, "NotesForIncome")]
        public void UserNamePasswordAndIndexAndValueToDelete_DeleteExpense_IsDeleted(string userName, string userPassword, int indexToUpdate, string expectedOutput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);
            Expense expenseData1 = new Expense(DateOnly.Parse("2023/10/10"), "Groceries", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            Expense expenseData2 = new Expense(DateOnly.Parse("2023/10/10"), "Groceries", 5, ModesOfCash.Cash, "From Testing!", 5.0);
            
            //Act
            user.AddExpense(expenseData1);
            user.AddExpense(expenseData2);

            user.DeleteExpense(indexToUpdate, user);

            //Assert
            Assert.Equal(indexToUpdate - 1, user.Expenses.Count);
        }

        [Theory]
        [InlineData("TestName", "TestPassword", "TestName.json")]
        public void UserNamePassword_CreatingFileNamedAsUserName_IsFileCreated(string userName, string userPassword, string expectedOutput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);

            //Act
            var actualOutput = fileManagerInstance.fileName(user);

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Theory]
        [InlineData("Lipika", "Lipi", "Lipika.json")]
        public void UserNamePassword_LogInDetailsToFile_IsLogin(string userName, string userPassword, string expectedOutput)
        {
            //Arrange
            User user = new User(userName, userPassword, categoryInstance, serviceInstance);

            //Act
            var actualOutput = fileManagerInstance.LogInDetailsToFile(userName, userPassword, user);

            //Assert
            Assert.True(actualOutput);
        }

    }

}