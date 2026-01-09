namespace WinForms.Demos.Demo1.ProductTypes;

public class Clothing : Product
{
    public string Size { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public string Material { get; set; } = string.Empty;
    public string CareInstructions { get; set; } = string.Empty;

    public override string ProductType => "Clothing";
}
