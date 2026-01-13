namespace WinForms.Demos.Demo1_MasterDetail.ProductTypes;

public abstract class Product
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public string Description { get; init; } = string.Empty;

    public abstract string ProductType { get; }

    public override string ToString() => Name;
}
