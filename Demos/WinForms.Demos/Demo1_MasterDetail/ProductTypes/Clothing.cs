namespace WinForms.Demos.Demo1_MasterDetail.ProductTypes;

public class Clothing : Product
{
    public string Size { get; init; } = string.Empty;
    public string Color { get; init; } = string.Empty;
    public string Material { get; init; } = string.Empty;
    public string CareInstructions { get; init; } = string.Empty;

    public override string ProductType => "Clothing";
}
