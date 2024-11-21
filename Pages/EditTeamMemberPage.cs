using Microsoft.Playwright;
using NUnit.Framework;
using Bogus;

namespace PlaywrightFramework.Pages
{
    public class EditTeamMemberPage
    {
        private readonly IPage _page;
        private string firstName = "";

        public EditTeamMemberPage(IPage page) => _page = page;
        private ILocator _header => _page.Locator("h1");
        private ILocator _selectLocator_AssignRole => _page.Locator("select#memberRoleSelection");
        private ILocator _selectLocator_TeacherType => _page.Locator("select#memberEduTypeSelection");
        private ILocator _firstName => _page.Locator("#firstName");
        private ILocator _email => _page.Locator("#email");
        private ILocator _phone => _page.Locator("#phone");
        private ILocator _userName => _page.Locator("#username");
        private ILocator _saveBtn => _page.Locator("button.btn.btn-primary.btn-icon-left");
        private ILocator _deleteButton => _page.Locator("button.btn.btn-danger");
        private ILocator _confirmDeletionButton => _page.Locator("div.text-center button.btn.btn-danger");


        public async Task VerifyTeamMemberHeading()
        {
            // Wait for navigation to the new page on invoking manage team members
            await _page.WaitForURLAsync("https://rta-edu-stg-web-03.azurewebsites.net/core/setup/team-members/edit/*");

            try
            {

                string heading = await _header.InnerTextAsync();

                if (heading.Contains("Edit Team Member"))
                {
                    Assert.Pass("The page contains 'Edit Team Member' as heading.");
                }
                else
                {
                    Assert.Fail("The page does not contain 'Edit Team Member' as heading.");
                }
            }
            catch (NUnit.Framework.SuccessException excep)
            {
                Console.WriteLine("The page contains 'Edit Team Member' as heading.");
            }
        }

        public async Task Edit_Team_Member()
        {
            // Generate fake data
            var faker = new Faker();
            firstName = faker.Name.FirstName();
            var email = faker.Internet.Email();
            var cellPhone = faker.Phone.PhoneNumber();
            var username = faker.Internet.UserName();

            // Write the data to the CSV file
            var users = new List<User>
            {
            new() {FirstName = firstName, Email = email, Phone = cellPhone, Username = username}
            };

            //await EditAssignRole();
            await EditFirstName(firstName);
            await EditEmail(email);
            await EditPhone(cellPhone);
            await EditUserName(username);

        }


        public async Task EditAssignRole()
        {
            // Locate the select element
            // var selectLocator_AssignRole = _page.Locator("select#memberRoleSelection");

            // Wait for options to be present
            var optionsLocator = _selectLocator_AssignRole.Locator("Teacher");
            await optionsLocator.WaitForAsync();

            // Select an option by value
            await _selectLocator_AssignRole.SelectOptionAsync(" Teacher ");

            // Select an option by value for teacher option
            await _selectLocator_TeacherType.SelectOptionAsync(" Special Education ");

        }

        public async Task EditFirstName(string fName)
        {
            await _firstName.FillAsync(fName);
        }

        public async Task EditEmail(string email)
        {
            await _email.FillAsync(email);
        }

        public async Task EditPhone(string phone)
        {
            await _phone.FillAsync(phone);
        }

        public async Task EditUserName(string username)
        {
            await _userName.FillAsync(username);
        }

        public async Task SubmitEditedDetails()
        {
            await _saveBtn.ClickAsync();

            // Wait for navigation to the new page on updating team member
            await _page.WaitForURLAsync("https://rta-edu-stg-web-03.azurewebsites.net/core/setup/team-members", new PageWaitForURLOptions { Timeout = 60000 });
        }

        public string GetFirstName() => firstName;

        public async Task DeleteMember()
        {
            await _deleteButton.ClickAsync();

            await _confirmDeletionButton.ClickAsync();

            await _saveBtn.ClickAsync();

        }
    }
}