using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PuppeteerSharp;
using System.Threading.Tasks;
using PuppeteerSharp.Media;

namespace SFHTMLtoPDF
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            //Initialize HTML to PDF converter 
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);
            WebKitConverterSettings settings = new WebKitConverterSettings();
            //Set WebKit path
            settings.WebKitPath = Server.MapPath("~/bin/QtBinaries");
            settings.MediaType = Syncfusion.HtmlConverter.MediaType.Print;

            settings.Orientation = PdfPageOrientation.Landscape;

            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;
            //Convert HTML to PDF
            PdfDocument document = htmlConverter.Convert(txtURL.Text);
            //Save the PDF document 
            document.Save(Server.MapPath("~/PDF/HTMLToPDF.pdf"), Response, HttpReadType.Open);

            //Close the document
            document.Close(true);

            //This will open the PDF file so, the result will be seen in default PDF viewer
            //Process.Start("HTMLToPDF.pdf");
        }

        protected async void btnPupet_Click(object sender, EventArgs e)
        {
            var fileName = Server.MapPath("~/PDF/PuppetToPDF.pdf");

            var output = "" + fileName;
            //  await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultChromiumRevision).ConfigureAwait(false);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe"
            }).ConfigureAwait(false);
            var pdfOptions = new PdfOptions
            {
                Format = PaperFormat.A4,
                Landscape = true,
                PrintBackground = true,
                DisplayHeaderFooter = true
            };
            var page = await browser.NewPageAsync().ConfigureAwait(false);
            await page.GoToAsync(txtURL.Text).ConfigureAwait(false);
            await page.PdfAsync(output, pdfOptions).ConfigureAwait(false);
            lblmsg.Visible = true;
        }


    }
}