using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Playwright;
using NUnit.Framework;

public class Price
{
private readonly IPage page;
    public Price(IPage page)
    {
        this.page = page;
    }
    public async Task PrintBooksAndLinks()
    {
        // 1. Open browser and maximize (already handled in Setup)

        // 2. Enter URl
            await page!.GotoAsync("https://practice.automationtesting.in/");

        // 3. Print name and price of books displayed
            var bookElements = await page.QuerySelectorAllAsync("ul.products li");

        foreach (var book in bookElements)
        {
            var name = await book.QuerySelectorAsync("h3");
            var price = await book.QuerySelectorAsync("span.price");

            string bookName = name != null ? await name.InnerTextAsync() : "N/A";
            string bookPrice = price != null ? await price.InnerTextAsync() : "N/A";

            Console.WriteLine($"Book: {bookName} | Price: {bookPrice}");
        }

        // 4. Print number of hyperlinks in the webpage
        var links = await page.QuerySelectorAllAsync("a");
        Console.WriteLine($"Total number of hyperlinks: {links.Count}");
        }
}