using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Playwright;
using NUnit.Framework;

public class DropDown
{
private readonly IPage page;
    public DropDown(IPage page)
    {
        this.page = page;
    }
    public async Task DropDowns()
    {
        await page!.GotoAsync("https://practice.expandtesting.com/dropdown?utm_source=chatgpt.com");
        var countries = await page.QuerySelectorAllAsync("//select[@id='country']//option");
        var countryNames = new List<string>();
        foreach (var country in countries)
        {
            var contry = await country.InnerTextAsync();
            countryNames.Add(contry);
            countryNames.Remove("India");
            Console.WriteLine(contry);
        }
        Console.WriteLine("After removing India");
        foreach (var name in countryNames)
        {
            Console.WriteLine(name);
        }
            
    }
}