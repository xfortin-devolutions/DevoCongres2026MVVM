namespace WinForms.Demos.Demo2.ViewPanels;

public class CardViewPanel : Panel
{
    private readonly FlowLayoutPanel flowLayoutPanel;

    public CardViewPanel()
    {
        AutoScroll = true;
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

        foreach (var product in products)
        {
            var cardPanel = CreateCardPanel(product);
            flowLayoutPanel.Controls.Add(cardPanel);
        }
    }

    private Panel CreateCardPanel(Product product)
    {
        var panel = new Panel
        {
            Width = 750,
            Height = 140,
            Margin = new Padding(10),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = SystemColors.Window,
            Padding = new Padding(20)
        };

        var typeLabel = new Label
        {
            Text = product.ProductType,
            Location = new Point(0, 0),
            Size = new Size(100, 24),
            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.FromArgb(0, 120, 215),
            ForeColor = Color.White,
            Padding = new Padding(4, 2, 4, 2)
        };
        panel.Controls.Add(typeLabel);

        var priceLabel = new Label
        {
            Text = $"${product.Price:F2}",
            Location = new Point(0, 30),
            Size = new Size(100, 30),
            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter,
            ForeColor = Color.FromArgb(0, 120, 215)
        };
        panel.Controls.Add(priceLabel);

        var nameLabel = new Label
        {
            Text = product.Name,
            Location = new Point(120, 0),
            Width = 610,
            Height = 30,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            AutoEllipsis = true
        };
        panel.Controls.Add(nameLabel);

        var descLabel = new Label
        {
            Text = product.Description,
            Location = new Point(120, 35),
            Width = 610,
            Height = 50,
            Font = new Font("Segoe UI", 9F),
            AutoEllipsis = true
        };
        panel.Controls.Add(descLabel);

        var separatorPanel = new Panel
        {
            Location = new Point(120, 90),
            Size = new Size(610, 1),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = SystemColors.ControlLight
        };
        panel.Controls.Add(separatorPanel);

        var idLabel = new Label
        {
            Text = $"ID: {product.Id}",
            Location = new Point(120, 95),
            Width = 610,
            Height = 20,
            Font = new Font("Segoe UI", 8F),
            ForeColor = SystemColors.GrayText
        };
        panel.Controls.Add(idLabel);

        return panel;
    }
}
