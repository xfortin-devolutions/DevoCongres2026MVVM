using WinForms.Demos.Demo1.ProductTypes;

namespace WinForms.Demos.Demo1.DetailPanels;

/// <summary>
/// Panel that displays detailed information for a Clothing product.
/// Manually creates and positions labels for each property.
/// </summary>
public class ClothingDetailPanel : Panel
{
    private readonly Label lblTitle;
    private readonly Label lblName;
    private readonly Label lblPrice;
    private readonly Label lblDescription;
    private readonly Label lblSize;
    private readonly Label lblColor;
    private readonly Label lblMaterial;
    private readonly Label lblCareInstructions;

    private readonly Label lblNameValue;
    private readonly Label lblPriceValue;
    private readonly Label lblDescriptionValue;
    private readonly Label lblSizeValue;
    private readonly Label lblColorValue;
    private readonly Label lblMaterialValue;
    private readonly Label lblCareInstructionsValue;

    public ClothingDetailPanel()
    {
        AutoScroll = true;
        Padding = new Padding(20);

        int yPos = 0;

        // Title
        lblTitle = CreateLabel("Clothing Details", new Font("Segoe UI", 16F, FontStyle.Bold), ref yPos);
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

        // Size
        lblSize = CreateLabel("Size:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblSizeValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Color
        lblColor = CreateLabel("Color:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblColorValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Material
        lblMaterial = CreateLabel("Material:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblMaterialValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos);
        yPos += 10;

        // Care Instructions
        lblCareInstructions = CreateLabel("Care Instructions:", new Font("Segoe UI", 9F, FontStyle.Bold), ref yPos);
        lblCareInstructionsValue = CreateLabel("", new Font("Segoe UI", 9F), ref yPos, maxWidth: 350);
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

    public void LoadClothing(Clothing clothing)
    {
        lblNameValue.Text = clothing.Name;
        lblPriceValue.Text = $"${clothing.Price:F2}";
        lblDescriptionValue.Text = clothing.Description;
        lblSizeValue.Text = clothing.Size;
        lblColorValue.Text = clothing.Color;
        lblMaterialValue.Text = clothing.Material;
        lblCareInstructionsValue.Text = clothing.CareInstructions;
    }
}
