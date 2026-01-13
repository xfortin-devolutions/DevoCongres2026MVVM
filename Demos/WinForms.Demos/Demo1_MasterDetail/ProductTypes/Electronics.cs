namespace WinForms.Demos.Demo1_MasterDetail.ProductTypes;

public class Electronics : Product
{
    public string Brand { get; init; } = string.Empty;
    public int WarrantyMonths { get; init; }
    public string PowerConsumption { get; init; } = string.Empty;
    public string ModelNumber { get; init; } = string.Empty;

    public override string ProductType => "Electronics";
}
