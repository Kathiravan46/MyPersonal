using Microsoft.Playwright;
using NUnit.Framework;

public class List
{
private readonly IPage page;
    public List(IPage page)
    {
        this.page = page;
    }
    public async Task Lists()
    {
        await page.GotoAsync("https://rahulshettyacademy.com/AutomationPractice/");
        var allCells = page.Locator(".tableFixHead td:nth-of-type(3)");
        var cities = await allCells.AllInnerTextsAsync();
        //int city = cities.Count;
        foreach (var cells in cities)
        {

            Console.WriteLine("The cities are :" + cells);
        }
        int counts = cities.Count(c => c.Equals("Chennai", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine("The count of Chennai is :" + counts);
        Assert.That(counts, Is.GreaterThan(50), "Chennai should appear at least once in the table.");
        

    } 
}