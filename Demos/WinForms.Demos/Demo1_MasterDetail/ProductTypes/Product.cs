namespace WinForms.Demos.Demo1.ProductTypes;

public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;

    public abstract string ProductType { get; }

    public override string ToString() => Name;
}
