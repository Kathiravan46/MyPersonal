using Microsoft.Playwright;

public class LoginSession
{
    public readonly IPage page;
    public LoginSession(IPage page)
    {
        this.page = page;
    }
    public async Task LoginStorage()
    {
        await page.GotoAsync("https://practicetestautomation.com/practice-test-login/?utm_source=chatgpt.com");
        await page.GetByTestId("username").FillAsync("student");
        await page.GetByTestId("password").FillAsync("Password123");
        await page.GetByTestId("submit").ClickAsync();
        await page.Context.StorageStateAsync(new BrowserContextStorageStateOptions
        {
            Path = "C:/Users/suba/OneDrive/Documents/Kathir/Handson-20251014T045653Z-1-001.json"
        });
        await page.GetByText("Log out").ClickAsync();
    }
}