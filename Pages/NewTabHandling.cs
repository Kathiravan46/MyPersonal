using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Playwright;
using NUnit.Framework;

public class NewTab
{
    private readonly IPage page;
    private readonly IBrowserContext context;
    public NewTab(IPage page, IBrowserContext context)
    {
        this.page = page;
        this.context = context;
    }
    public async Task NewTabs()
    {
        // var playwright = await Playwright.CreateAsync();
        // var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        // var context = await browser.NewContextAsync();
        // var page = await context.NewPageAsync();
        await page.GotoAsync("https://rahulshettyacademy.com/AutomationPractice/");
        var newTab = context.WaitForPageAsync();
        await page.Locator("#openwindow").ClickAsync();
        var newTabs = await newTab;
        await newTabs.WaitForLoadStateAsync();
        await page.BringToFrontAsync();
            
    }
}