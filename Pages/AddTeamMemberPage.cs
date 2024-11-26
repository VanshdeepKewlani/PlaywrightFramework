using Microsoft.Playwright;
using Bogus;

namespace PlaywrightFramework.Pages
{
    public class AddTeamMemberPage
    {
        private readonly IPage _page;

        public AddTeamMemberPage(IPage page) => _page = page;
        private ILocator _firstName => _page.Locator("#firstName");
        private ILocator _lastName => _page.Locator("#lastName");
        private ILocator _email => _page.Locator("#email");
        private ILocator _cellPhone => _page.Locator("#phone");
        private ILocator _userName => _page.Locator("#username");
        private ILocator _password => _page.Locator("#password");
        private ILocator _confirmPassword => _page.Locator("#confirmPassword");

        public async Task Add_Team_Member(string fname)
        {
           // Generate fake data
            var faker = new Faker();
            var firstName = fname;
            var lastName = faker.Name.LastName();
            var email = faker.Internet.Email();
            var cellPhone = faker.Phone.PhoneNumber();
            var username = faker.Internet.UserName();
            var password = "Test!ng123456";
            var confirmPassword = password; // Confirm password should match the password
                                        
            // Write the data to the CSV file
            var users = new List<User>
            {
            new User{FirstName = firstName, LastName = lastName, Email = email, Phone = cellPhone, Username = username, Password = password}
            };
         
            await _firstName.FillAsync(firstName);
            await _lastName.FillAsync(lastName);
            await _email.FillAsync(email);
            await _cellPhone.FillAsync(cellPhone);
            await _userName.FillAsync(username);
            await _password.FillAsync(password);
            await _confirmPassword.FillAsync(confirmPassword);
      
            // Locate the button by its text
            var savebtn = _page.Locator("button").GetByText(" Save and Close ");
            // Wait for the button to be visible
            await savebtn.WaitForAsync();
            // Click the button
            await savebtn.ClickAsync();

            // Define the CSV file path
            var csvFilePath = "users.csv";

            // Write to CSV
            CsvHelperExample.WriteToCSV(csvFilePath, users);

            // Read from CSV
            var readUsers = CsvHelperExample.ReadFromCSV(csvFilePath);

            // Print read users
            foreach (var user in readUsers)
            {
                System.Console.WriteLine($"FirstName: {user.FirstName}, LastName: {user.LastName}, Email: {user.Email}, Phone: {user.Phone}, Username: {user.Username}, Password: {user.Password}");
            }

        }

       
    }
}