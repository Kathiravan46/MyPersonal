using System.ComponentModel;
using Microsoft.Playwright;

public class Auth
{
    private readonly IPage page;
    public Auth(IPage page)
    {
        this.page = page;
    }
    public async Task Authentication()
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        var context = await browser.NewContextAsync(new BrowserNewContextOptions
        {
            HttpCredentials = new HttpCredentials
            {
                Username = "postman",
                Password = "password"
            }
        });
        var page = await context.NewPageAsync();
        await page.GotoAsync("https://postman-echo.com/basic-auth");
    }
}