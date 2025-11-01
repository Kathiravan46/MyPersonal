using Microsoft.Playwright;
using NUnit.Framework;

public class Rahul
{
    private readonly IPage page;
    public Rahul(IPage page)
    {
        this.page = page;
    }
    public async Task Cities()
    {
        await page.GotoAsync("https://rahulshettyacademy.com/AutomationPractice/");
        var cities = page.Locator(".tableFixHead td:nth-of-type(3)").AllInnerTextsAsync();
        foreach (var city in await cities)
        {
            Console.WriteLine("The cities are :" + city);
        }
        List<string> cityList = new List<string>(await cities);
        cityList.Sort();
        Console.WriteLine("The sorted cities are:" + string.Join(", ", cityList));
    }
}