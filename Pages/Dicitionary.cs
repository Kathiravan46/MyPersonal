using System.Text.RegularExpressions;
using Microsoft.Playwright;
using NUnit.Framework;

class Test
{
    private readonly IPage page;
    public Test(IPage page)
    {
        this.page = page;
    }

    public async Task practice()
    {

        Dictionary<string, string> userDetails = new Dictionary<string, string>
        {
            { "username", "student" },
            { "password", "Password123" }
        };
        for (int i = 0; i <= 1; i++)
        {
            await page.GotoAsync("https://practicetestautomation.com/practice-test-login/");
            await page.GetByRole(AriaRole.Textbox, new() { Name = "username" }).FillAsync(userDetails["username"]);
            await page.Locator("#password").FillAsync(userDetails["password"]);
            await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { NameRegex = new Regex("Log\\s*out", RegexOptions.IgnoreCase) }).ClickAsync();
            await page.WaitForSelectorAsync("#username");
            var title = page.GetByAltText("Practice Test Automation").TextContentAsync().Result;
            Console.WriteLine(title);
            //Assert.That(title, Is.EqualTo("Practice Test Automation"));
            
            
        }
    } 
}