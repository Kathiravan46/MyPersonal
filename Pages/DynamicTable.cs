using Microsoft.Playwright;

public class DynamicTable
{
    private readonly IPage page;
    public DynamicTable(IPage page)
    {
        this.page = page;
    }
    public async Task HandleDynamicTable()
    {
        await page.GotoAsync("https://practice.expandtesting.com/dynamic-table#google_vignette");
        var rows = page.Locator("//table[@class='table table-striped']//tbody//tr");
        int rowCount = await rows.CountAsync();
        for(int i=0; i<rowCount; i++)
        {
            var rowText =  await rows.Nth(i).InnerTextAsync();
            if(rowText.Equals("Chrome"))
            {
                var rowName =  page.Locator("//tr//td[text()='Chrome']//following-sibling::td[contains(text(),'%')]").InnerTextAsync();
                var expected =  page.Locator("//p[@id='chrome-cpu']").InnerTextAsync();
                if(rowName.Equals(expected))
                {
                    Console.WriteLine("The percentage value matches with the expected value.");
                }
                else
                {
                    Console.WriteLine("The percentage value does not match with the expected value.");
                }   
                break;              
            }
              
        }
        
    }
}