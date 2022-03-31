using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapper
{
    public class RestrictedPages
    {
        public RestrictedPages()
        {

        }

        public async Task<string> Main()
        {
            string fullUrl = "URL HERE";

            List<string> housesLinks = new List<string>();

            var options = new LaunchOptions()
            {
                Headless = true,
                ExecutablePath = "C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe"
            };
            var browser = await Puppeteer.LaunchAsync(options, null);
            var page = await browser.NewPageAsync();
            await page.GoToAsync(fullUrl);
            var links = @"Array.from(document.querySelectorAll('a')).map(a => a.href);";
            var urls = await page.EvaluateExpressionAsync<string[]>(links);

            if (urls != null)
            {
                foreach (var item in urls)
                {
                    if (item.StartsWith("expression"))
                    {
                        housesLinks.Add(item);
                    }
                }
            }

            return default;
        }
    }
}
