using WinForms.Demos.Demo1.ProductTypes;

namespace WinForms.Demos.Demo1.DetailPanels;

/// <summary>
/// Panel that displays detailed information for an Electronics product.
/// Manually creates and positions labels for each property.
/// </summary>
public class ElectronicsDetailPanel : Panel
{
    private readonly Label lblTitle;
    private readonly Label lblName;
    private readonly Label lblPrice;
    private readonly Label lblDescription;
    private readonly Label lblBrand;
    private readonly Label lblModelNumber;
    private readonly Label lblWarranty;
    private readonly Label lblPowerConsumption;

    private readonly Label lblNameValue;
    private readonly Label lblPriceValue;
    private readonly Label lblDescriptionValue;
    private readonly Label lblBrandValue;
    private readonly Label lblModelNumberValue;
    private readonly Label lblWarrantyValue;
    private readonly Label lblPowerConsumptionValue;

    public ElectronicsDetailPanel()
    {
        AutoScroll = true;
        Padding = new Padding(20);

        int yPos = 0;

        // Title
        lblTitle = CreateLabel("Electronics Details", new Font("Segoe UI", 16F, FontStyle.Bold), ref yPos);
        yPos += 20;

        // Name
        lblName = CreateLabel("Name:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblNameValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Price
        lblPrice = CreateLabel("Price:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblPriceValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Description
        lblDescription = CreateLabel("Description:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblDescriptionValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos, maxWidth: 350);
        yPos += 20;

        // Separator line
        var separator = new Panel
        {
            Height = 1,
            Width = 400,
            BackColor = Color.LightGray,
            Location = new Point(0, yPos)
        };
        Controls.Add(separator);
        yPos += 20;

        // Brand
        lblBrand = CreateLabel("Brand:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblBrandValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Model Number
        lblModelNumber = CreateLabel("Model Number:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblModelNumberValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Warranty
        lblWarranty = CreateLabel("Warranty:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblWarrantyValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Power Consumption
        lblPowerConsumption = CreateLabel("Power Consumption:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblPowerConsumptionValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
    }

    private Label CreateLabel(string text, Font font, ref int yPos, int maxWidth = 400)
    {
        var label = new Label
        {
            Text = text,
            Font = font,
            Location = new Point(0, yPos),
            AutoSize = true,
            MaximumSize = new Size(maxWidth, 0)
        };
        Controls.Add(label);
        yPos += label.PreferredHeight;
        return label;
    }

    public void LoadElectronics(Electronics electronics)
    {
        lblNameValue.Text = electronics.Name;
        lblPriceValue.Text = $"${electronics.Price:F2}";
        lblDescriptionValue.Text = electronics.Description;
        lblBrandValue.Text = electronics.Brand;
        lblModelNumberValue.Text = electronics.ModelNumber;
        lblWarrantyValue.Text = $"{electronics.WarrantyMonths} months";
        lblPowerConsumptionValue.Text = electronics.PowerConsumption;
    }
}
