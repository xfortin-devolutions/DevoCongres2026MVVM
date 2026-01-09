namespace WinForms.Demos.Demo2.ViewPanels;

public class TileViewPanel : Panel
{
    private readonly FlowLayoutPanel flowLayoutPanel;

    public TileViewPanel()
    {
        AutoScroll = true;
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

        foreach (var product in products)
        {
            var tilePanel = CreateTilePanel(product);
            flowLayoutPanel.Controls.Add(tilePanel);
        }
    }

    private Panel CreateTilePanel(Product product)
    {
        var panel = new Panel
        {
            Width = 200,
            Height = 150,
            Margin = new Padding(10),
            BorderStyle = BorderStyle.FixedSingle,
            BackColor = SystemColors.Window,
            Padding = new Padding(15)
        };

        int yPos = 0;

        var nameLabel = new Label
        {
            Text = product.Name,
            Location = new Point(0, yPos),
            Width = 170,
            Height = 40,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            AutoEllipsis = true
        };
        panel.Controls.Add(nameLabel);
        yPos += 45;

        var typeLabel = new Label
        {
            Text = product.ProductType,
            Location = new Point(0, yPos),
            Width = 170,
            Font = new Font("Segoe UI", 9F),
            ForeColor = SystemColors.GrayText
        };
        panel.Controls.Add(typeLabel);
        yPos += 25;

        var priceLabel = new Label
        {
            Text = $"${product.Price:F2}",
            Location = new Point(0, yPos),
            Width = 170,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold),
            ForeColor = Color.FromArgb(0, 120, 215)
        };
        panel.Controls.Add(priceLabel);
        yPos += 30;

        var descLabel = new Label
        {
            Text = product.Description,
            Location = new Point(0, yPos),
            Width = 170,
            Height = 40,
            Font = new Font("Segoe UI", 8F),
            AutoEllipsis = true
        };
        panel.Controls.Add(descLabel);

        return panel;
    }
}
