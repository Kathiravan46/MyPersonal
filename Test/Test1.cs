using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Playwright;
using NUnit.Framework;

[Parallelizable(ParallelScope.None)]

[TestFixture]
class MainTest : BasePage
{
    // [Test]
    // public async Task DryRun()
    // {
    //     var login = new Test(page!);
    //     await login.practice();
    //     Assert.Pass("Completed");
    // }
    // [Test]
    // public async Task Table()
    // {
    //     var list = new List(page!);
    //     await list.Lists();
    // }

    // [Test]
    // public async Task PriceAndName()
    // {
    //     var price = new Price(page!);
    //     await price.PrintBooksAndLinks();
    // }
    // [Test]
    // public async Task DropDown()
    // {
    //     var drop = new DropDown(page!);
    //     await drop.DropDowns();
    // }

    // [Test]
    // public async Task Fetch()
    // {
    //     var fetch = new Rahul(page!);
    //     await fetch.Cities();
    // }
    // [Test]
    // public async Task authentication()
    // {
    //     var auth = new Auth(page!);
    //     await auth.Authentication();
    // }
    // [Test]
    // public async Task NewPage()
    // {
    //     var newpage = new NewTab(page!, context!);
    //     await newpage.NewTabs();
    // }
    // [Test]
    // public async Task ReUse()
    // {
    //     var reuse = new Reuse(page!);
    //     await reuse.ReuseLogin();
    // }
    [Test]
    public async Task MultipleLoginTest()
    {
        var multipleLogin = new MultipleLogin(page!);
        await multipleLogin.Login();
    }
    }

    
