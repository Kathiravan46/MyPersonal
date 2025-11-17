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
        try
        {
            var file = await File.ReadAllLinesAsync(@"C:\Kathir Automation\Kathir\Handson-20251014T045653Z-1-001\Handson\Utilities\credentials.csv");
            foreach (var line in file.Skip(1))
            {
                var parts = line.Split(',');
                var username = parts[0].Trim();
                var password = parts[1].Trim();

                // Perform login with username and password
                Console.WriteLine($"Logging in with Username: {username} and Password: {password}");
                // Add your login logic here
                await page.GotoAsync("https://www.saucedemo.com/");
                await page.GetByPlaceholder("Username").FillAsync(username);
                await page.GetByPlaceholder("Password").FillAsync(password);
                await page.Locator("#login-button").ClickAsync();
                
            }
        }
        catch (PlaywrightException ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        var text = page.Locator("//div[text()='Swag Labs']");
        await Assertions.Expect(text).ToHaveTextAsync("Swag Labs");
    }   
}