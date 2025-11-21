using Microsoft.Playwright;
using NUnit.Framework;

public class ErrorValidation
{
    private readonly IPage page;
    public ErrorValidation(IPage page)
    {
        this.page = page;
    }
    public async Task Cities()
    {
        await page.GotoAsync("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");
        await page.GetByPlaceholder("Username").FillAsync("Admin");
        await page.GetByPlaceholder("Password").FillAsync("admin");
        await page.Locator("//button[@type='submit']").ClickAsync();
        var errormessage = page.Locator("//p[text()='Invalid credentials']");
        await Assertions.Expect(errormessage).ToHaveTextAsync("Invalid credentials");
        
    }
}