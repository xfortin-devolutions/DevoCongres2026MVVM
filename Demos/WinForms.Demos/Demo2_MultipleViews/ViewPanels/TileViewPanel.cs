namespace WinForms.Demos.Demo2_MultipleViews.ViewPanels;

public class TileViewPanel : Panel
{
    private readonly FlowLayoutPanel flowLayoutPanel;

    public TileViewPanel()
    {
        Padding = new Padding(10);

        flowLayoutPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            WrapContents = true,
            FlowDirection = FlowDirection.LeftToRight,
            Padding = new Padding(5)
        };

        Controls.Add(flowLayoutPanel);
    }

    public void LoadProducts(List<Product> products)
    {
        flowLayoutPanel.Controls.Clear();

        foreach (Product product in products)
        {
            Panel tilePanel = CreateTilePanel(product);
            flowLayoutPanel.Controls.Add(tilePanel);
        }
    }

    private Panel CreateTilePanel(Product product)
    {
        Panel panel = new()
        {
            Width = 400,
            Height = 300,
            Margin = new Padding(20),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = SystemColors.Window
        };

        const int MARGIN = 20;
        int yPos = MARGIN;
        const int CONTENT_WIDTH = 360;

        Label nameLabel = new()
        {
            Text = product.Name,
            Location = new Point(MARGIN, yPos),
            Width = CONTENT_WIDTH,
            Height = 80,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            AutoEllipsis = true
        };
        panel.Controls.Add(nameLabel);
        yPos += 80;

        Label typeLabel = new()
        {
            Text = product.ProductType,
            Location = new Point(MARGIN, yPos),
            Width = CONTENT_WIDTH,
            Height = 40,
            Font = new Font("Segoe UI", 9F),
            ForeColor = SystemColors.GrayText
        };
        panel.Controls.Add(typeLabel);
        yPos += 44;

        Label priceLabel = new()
        {
            Text = $"${product.Price:F2}",
            Location = new Point(MARGIN, yPos),
            Width = CONTENT_WIDTH,
            Height = 50,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 120, 215)
        };
        panel.Controls.Add(priceLabel);
        yPos += 54;

        Label descLabel = new()
        {
            Text = product.Description,
            Location = new Point(MARGIN, yPos),
            Width = CONTENT_WIDTH,
            Height = 60,
            Font = new Font("Segoe UI", 8F),
            AutoEllipsis = true
        };
        panel.Controls.Add(descLabel);

        return panel;
    }
}
