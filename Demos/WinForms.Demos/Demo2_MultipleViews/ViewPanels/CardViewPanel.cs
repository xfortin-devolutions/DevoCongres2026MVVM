namespace WinForms.Demos.Demo2_MultipleViews.ViewPanels;

public class CardViewPanel : Panel
{
    private readonly FlowLayoutPanel flowLayoutPanel;

    public CardViewPanel()
    {
        Padding = new Padding(10);

        flowLayoutPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            Padding = new Padding(5)
        };

        Controls.Add(flowLayoutPanel);
    }

    public void LoadProducts(List<Product> products)
    {
        flowLayoutPanel.Controls.Clear();

        foreach (Product product in products)
        {
            Panel cardPanel = CreateCardPanel(product);
            flowLayoutPanel.Controls.Add(cardPanel);
        }
    }

    private Panel CreateCardPanel(Product product)
    {
        Panel panel = new()
        {
            Width = 1500,
            Height = 280,
            Margin = new Padding(20),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = SystemColors.Window
        };

        const int LEFT_MARGIN = 30;
        const int TOP_MARGIN = 30;
        const int RIGHT_MARGIN = 260;

        Label typeLabel = new()
        {
            Text = product.ProductType,
            Location = new Point(LEFT_MARGIN, TOP_MARGIN),
            Size = new Size(200, 48),
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.FromArgb(0, 120, 215),
            ForeColor = Color.White
        };
        panel.Controls.Add(typeLabel);

        Label priceLabel = new()
        {
            Text = $"${product.Price:F2}",
            Location = new Point(LEFT_MARGIN, TOP_MARGIN + 70),
            Size = new Size(200, 70),
            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.FromArgb(0, 120, 215)
        };
        panel.Controls.Add(priceLabel);

        Label nameLabel = new()
        {
            Text = product.Name,
            Location = new Point(RIGHT_MARGIN, TOP_MARGIN),
            Width = 1200,
            Height = 60,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            AutoEllipsis = true
        };
        panel.Controls.Add(nameLabel);

        Label descLabel = new()
        {
            Text = product.Description,
            Location = new Point(RIGHT_MARGIN, TOP_MARGIN + 70),
            Width = 1200,
            Height = 80,
            Font = new Font("Segoe UI", 9F),
            AutoEllipsis = true
        };
        panel.Controls.Add(descLabel);

        Label separatorPanel = new()
        {
            Location = new Point(RIGHT_MARGIN, TOP_MARGIN + 160),
            Size = new Size(1200, 2),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = SystemColors.ControlLight
        };
        panel.Controls.Add(separatorPanel);

        Label idLabel = new()
        {
            Text = $"ID: {product.Id}",
            Location = new Point(RIGHT_MARGIN, TOP_MARGIN + 170),
            Width = 1200,
            Height = 40,
            Font = new Font("Segoe UI", 8F),
            ForeColor = SystemColors.GrayText
        };
        panel.Controls.Add(idLabel);

        return panel;
    }
}
