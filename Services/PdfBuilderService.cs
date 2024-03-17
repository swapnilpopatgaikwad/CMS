using CMS.Model;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace CMS.Services
{
    public static class PdfBuilderService
    {
        public static IFileSaver FileSaver => HandlerService.GetService<IFileSaver>();

        public static async Task<bool> BuildPdfAsync(TreatementModel treatementModel)
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(QuestPDF.Helpers.Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(20));

                    page.Header()
                        .Text("Developing PDF...")
                        .SemiBold().FontSize(36).FontColor(QuestPDF.Helpers.Colors.Blue.Medium);

                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x =>
                        {
                            x.Spacing(20);

                            x.Item().Text(Placeholders.LoremIpsum());
                            x.Item().Image(Placeholders.Image(200, 100));
                        });

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            });
            //document.GeneratePdf(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "hello.pdf"));
            //document.ShowInPreviewer();

            var pdfBytes = document.GeneratePdf();

            using var stream = new MemoryStream(pdfBytes);
            var fileName = "CMS" + treatementModel.patientName ?? "" + DateTime.Now.ToString() + ".pdf";

            //var fileName = "CMS_Sample.pdf";
            var fileLocationResult = await FileSaver.SaveAsync(fileName, stream);
            fileLocationResult.EnsureSuccess();

            await Launcher.Default.OpenAsync(new OpenFileRequest("CMS pdf View", new ReadOnlyFile(fileLocationResult.FilePath)));
            await Toast.Make($"File is saved : {fileLocationResult.FilePath}").Show();

            return true;
        }
    }
}
