using WinForms.Demos.Demo1_MasterDetail.ProductTypes;

namespace WinForms.Demos.Demo1_MasterDetail.DetailPanels;

public class ElectronicsDetailPanel : DetailPanel
{
    private readonly Label lblNameValue;
    private readonly Label lblPriceValue;
    private readonly Label lblDescriptionValue;
    private readonly Label lblBrandValue;
    private readonly Label lblModelNumberValue;
    private readonly Label lblWarrantyValue;
    private readonly Label lblPowerConsumptionValue;

    public override bool AutoScroll => true;

    public ElectronicsDetailPanel()
    {
        Padding = new Padding(20);

        int yPos = 0;

        CreateLabel("Electronics Details", ref yPos, fontStyle: FontStyle.Bold, isTitle: true);
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

        CreateLabel("Brand:", ref yPos, fontStyle: FontStyle.Bold);
        lblBrandValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Model Number:", ref yPos, fontStyle: FontStyle.Bold);
        lblModelNumberValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Warranty:", ref yPos, fontStyle: FontStyle.Bold);
        lblWarrantyValue = CreateLabel("", ref yPos);
        yPos += 10;

        CreateLabel("Power Consumption:", ref yPos, fontStyle: FontStyle.Bold);
        lblPowerConsumptionValue = CreateLabel("", ref yPos);
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
