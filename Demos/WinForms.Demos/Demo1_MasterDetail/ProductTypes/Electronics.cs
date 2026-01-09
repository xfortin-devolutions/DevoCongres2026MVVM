namespace WinForms.Demos.Demo1.ProductTypes;

/// <summary>
/// Class for an Electronics product.
/// Demonstrates specific properties unique to electronics.
/// </summary>
public class Electronics : Product
{
    public string Brand { get; set; } = string.Empty;
    public int WarrantyMonths { get; set; }
    public string PowerConsumption { get; set; } = string.Empty;
    public string ModelNumber { get; set; } = string.Empty;

    public override string ProductType => "Electronics";
}
