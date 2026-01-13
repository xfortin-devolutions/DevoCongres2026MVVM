using WinForms.Demos.Demo1_MasterDetail.ProductTypes;

namespace WinForms.Demos.Demo1_MasterDetail.DetailPanels;

public class ClothingDetailPanel : DetailPanel
{
    private readonly Label lblNameValue;
    private readonly Label lblPriceValue;
    private readonly Label lblDescriptionValue;
    private readonly Label lblSizeValue;
    private readonly Label lblColorValue;
    private readonly Label lblMaterialValue;
    private readonly Label lblCareInstructionsValue;

    public override bool AutoScroll => true;

    public ClothingDetailPanel()
    {
        Padding = new Padding(20);

        int yPos = 0;

        CreateLabel("Clothing Details", ref yPos, fontStyle: FontStyle.Bold, isTitle: true);
        yPos += 20;

        CreateLabel("Name:", ref yPos, fontStyle: FontStyle.Bold);
        lblNameValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Price:", ref yPos, fontStyle: FontStyle.Bold);
        lblPriceValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Description:", ref yPos, fontStyle: FontStyle.Bold);
        lblDescriptionValue = CreateLabel("", ref yPos);
        yPos += 20;

        var separator = new Panel
        {
            Height = 1,
            Width = 900,
            BackColor = Color.LightGray,
            Location = new Point(0, yPos)
        };
        Controls.Add(separator);
        yPos += 20;

        CreateLabel("Size:", ref yPos, fontStyle: FontStyle.Bold);
        lblSizeValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Color:", ref yPos, fontStyle: FontStyle.Bold);
        lblColorValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Material:", ref yPos, fontStyle: FontStyle.Bold);
        lblMaterialValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Care Instructions:", ref yPos, fontStyle: FontStyle.Bold);
        lblCareInstructionsValue = CreateLabel("", ref yPos);
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
