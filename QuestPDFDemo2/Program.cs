using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

Document.Create(container =>
    {
        container.Page(page =>
        {
            page.Margin(50);

            page.Header().Column(column =>
            {
                column.Item().ShowOnce().Element(ComposeHeader);
                column.Item().SkipOnce().Background(Colors.Grey.Darken1).Element(ComposeOtherHeader);
            });
            page.Content().Element(ComposeContent);

            page.Footer().Column(column =>
            {
                column.Item().ShowOnce().Element(ComposeFirstPageFooter);
                column.Item().SkipOnce().Element(ComposeOtherPageFooter);
            });
        });
    })
    .ShowInPreviewer();

void ComposeHeader(IContainer container)
{
    container.Row(row =>
    {
        row.ConstantItem(100).Image("Resources/image15.png");
        row.ConstantItem(290);
        row.ConstantItem(100).Height(50).Image("Resources/DigDrilProg.png");
    });
}

void ComposeFirstPageFooter(IContainer container)
{
    container.Row(row =>
    {
        row.AutoItem().AlignRight().AlignMiddle().PaddingRight(140).Text("Partners").Style(TextStyle.Default.FontSize(10).FontColor(Colors.Black));
        row.AutoItem().AlignRight().AlignMiddle().PaddingHorizontal(10).Text("Var Energ").Style(TextStyle.Default.FontSize(12).FontColor(Colors.Black));
        row.AutoItem().AlignRight().AlignMiddle().PaddingHorizontal(10).Text("Var Energ").Style(TextStyle.Default.FontSize(12).FontColor(Colors.Black));
        row.AutoItem().AlignRight().AlignMiddle().PaddingHorizontal(10).Text("Var Energ").Style(TextStyle.Default.FontSize(12).FontColor(Colors.Black));
        row.AutoItem().AlignRight().AlignMiddle().PaddingHorizontal(10).Text("Var Energ").Style(TextStyle.Default.FontSize(12).FontColor(Colors.Black));
    });
}

void ComposeOtherPageFooter(IContainer container)
{
    container.AlignMiddle().AlignCenter().Row(row =>
    {
        row.AutoItem().Text(x =>
        {
            x.CurrentPageNumber();
            x.Span(" / ");
            x.TotalPages();
        });
    });
}

void ComposeOtherHeader(IContainer container)
{
    container.Column(column =>
    {
        column.Item().Height(40).Row(row =>
        {
            row.RelativeItem().AlignCenter().AlignMiddle().Image("Resources/image 12.png").FitHeight();
            row.RelativeItem().AlignMiddle().Image("Resources/image 11.png").FitArea();
            row.AutoItem().AlignRight().AlignMiddle().PaddingHorizontal(10).Text("Asset Name").Style(TextStyle.Default.FontSize(12).Bold().FontColor(Colors.White));
            row.AutoItem().AlignRight().AlignMiddle().PaddingHorizontal(10).Text("25/7-A-2 B").Style(TextStyle.Default.FontSize(12).Bold().FontColor(Colors.White));
            row.RelativeItem().PaddingLeft(40).AlignMiddle().Column(c =>
            {
                c.Item().AlignCenter().Text("Doc No").Style(TextStyle.Default.FontSize(10).Bold().FontColor(Colors.White));
                c.Item().AlignCenter().Text("1").Style(TextStyle.Default.FontSize(8).Bold().FontColor(Colors.White));
            });

            row.RelativeItem().PaddingLeft(20).AlignMiddle().Column(cc =>
            {
                cc.Item().AlignCenter().Text("Revision").Style(TextStyle.Default.FontSize(10).Bold().FontColor(Colors.White));
                cc.Item().AlignCenter().Text("1").Style(TextStyle.Default.FontSize(8).Bold().FontColor(Colors.White));
            });
        });
    });
}

void ComposeContent(IContainer container)
{
    Model model = new Model { Items = new List<Item>() };
    for (int i = 1; i <= 5; i++)
    {
        model.Items.Add(new Item { Name = $"Item{i}", Price = i * 10 });
    }

    var titleStyle = TextStyle.Default.FontSize(10).SemiBold().FontColor(Colors.Grey.Medium);
    var headerStyle = TextStyle.Default.FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
    var contentStyle = TextStyle.Default.FontSize(15).FontColor(Colors.Grey.Medium);

    container.Column(column =>
    {
        column.Item().PaddingVertical(80);
        column.Item().AlignCenter().Text("DRILLING PROGRAMME").Style(titleStyle);
        column.Item().AlignCenter().PaddingVertical(5).Text("25/7-A-2 B & 25/7-A-2 B").Style(headerStyle);
        column.Item().PaddingVertical(10).Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\r\n").Style(contentStyle);
        column.Item().PageBreak();
        column.Item().PaddingVertical(2);
        column.Item().Text("General").FontSize(14).Bold();
        column.Item().PaddingVertical(3);
        column.Item().Text("1.1 Purpose").FontSize(12).Bold();
        column.Item().PaddingVertical(3);
        column.Item().Background("#F8F9FC").Row(row =>
        {
            row.AutoItem().Text("");
            row.AutoItem().PaddingHorizontal(10).LineVertical(1).LineColor("#2374B6");
            row.AutoItem().MaxWidth(475).Text("Lorem ipsum dolor sit amet consectetur. Aliquam pretium ipsum cursus vulputate amet pharetra a. Non eget diam sagittis nisl egestas at ut fermentum. Et amet lorem aenean in nam venenatis. Vitae at nibh commodo sit nullam elit. Et amet lorem aenean in nam venenatis. Vitae at nibh commodo sit nullam elit.Et amet lorem aenean in nam Et amet lorem aenean in nam venenatis. Vitae at nibh commodo sit nullam elit.Et amet orem aenean in nam venenatis. Vitae at nibh commodo sit nullam elit. Et amet lorem aenean in nam ven").FontSize(8);
        });

        column.Item().PaddingVertical(10);
        column.Item().Text("1.2 Basic Well Data").FontSize(12).Bold();
        column.Item().Text("Basic data associated with the planned well is listed in the table below. The well has been planned in accordance with NORSOK D-010 rev. 5 and requirements as outlined in the Aker BP Well Construction Process (51-01 - Well Construction).").FontSize(10);
        column.Item().Row(row =>
        {
            row.RelativeItem(8).Background("#F8F9FC").Table(table =>
            {
                // step 1
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                });

                // step 2
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("Product");
                    header.Cell().Element(CellStyle).AlignRight().Text("Unit price");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                // step 3
                foreach (var item in model.Items)
                {
                    table.Cell().Element(CellStyle).Text(item.Name);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price}$");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
            row.RelativeItem().PaddingVertical(0);
            row.RelativeItem(8).Background("#F8F9FC").Table(table =>
            {
                // step 1
                table.ColumnsDefinition(columns =>
                {
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                });

                // step 2
                table.Header(header =>
                {
                    header.Cell().Element(CellStyle).Text("#");
                    header.Cell().Element(CellStyle).AlignRight().Text("Total");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                    }
                });

                // step 3
                foreach (var item in model.Items)
                {
                    table.Cell().Element(CellStyle).Text(item.Name);
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price}$");

                    static IContainer CellStyle(IContainer container)
                    {
                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                }
            });
        });
        column.Item().Text("Table 1: Basic well data").FontSize(6).FontColor(Colors.Blue.Lighten1).Bold();
    });
}

public class Item
{
    public string? Name { get; set; }
    public decimal Price { get; set; }
}

public class Model
{
    public List<Item>? Items { get; set; }
}