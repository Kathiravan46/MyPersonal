using Microsoft.Playwright;

public class MultipleLogin
{
    protected IPage page;
    public MultipleLogin(IPage page)
    {
        this.page = page;
    }

    public async Task Login()
    {
        var file = await File.ReadAllLinesAsync(@"C:\Kathir Automation\Kathir\Handson-20251014T045653Z-1-001\Handson\Utilities\credentials.csv");
        foreach (var line in file.Skip(1))
        {
            var parts = line.Split(',');
            var username = parts[0];
            var password = parts[1];

            // Perform login with username and password
            Console.WriteLine($"Logging in with Username: {username} and Password: {password}");
            // Add your login logic here
            await Playwright.CreateAsync();
            using var playwright = await Playwright.CreateAsync();      
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            var page = await browser.NewPageAsync();
            await page.GotoAsync("https://practicetestautomation.com/practice-test-login/?utm_source=chatgpt.com");
            await page.FillAsync("#username", username);
            await page.FillAsync("#password", password);
            await page.ClickAsync("#login-button");
            await browser.CloseAsync();
        }
    }
}