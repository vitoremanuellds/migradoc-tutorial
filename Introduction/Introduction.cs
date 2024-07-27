using MigraDoc.DocumentObjectModel;
using PdfSharp.Pdf;

public class Introduction {

    public static void GenerateIntroductionDocument() {
        var document = new Document();

        document.Info.Title = "Hello, World!";
        document.Info.Author = "Vitor Dos Santos";
        document.Info.Subject = "This document is a demostration of what MigraDoc can produce.";
        document.Info.Keywords = "MigraDoc Demo Generation PDF";

        var section = document.AddSection();

        var heading = section.AddParagraph("Heading 1");
        heading.Style = StyleNames.Heading1;
        var p = section.AddParagraph("Hello, World!");

        p.AddLineBreak();
        var formattedText = p.AddFormattedText("Red bold text", TextFormat.Bold);
        formattedText.Color = Colors.Red;

        var path = $"{Environment.CurrentDirectory}/Introduction/notebook.jpeg";
        section.AddImage(path);

        var renderer = new MigraDoc.Rendering.PdfDocumentRenderer
        {
            Document = document // This is the document we've been builing
        };
        renderer.PdfDocument.PageLayout = PdfPageLayout.SinglePage;
        renderer.PdfDocument.ViewerPreferences.FitWindow = true;

        // Rendering the document
        renderer.RenderDocument();

        // Saving in a file
        renderer.PdfDocument.Save($"{Environment.CurrentDirectory}/Introduction/output.pdf");
    }

}