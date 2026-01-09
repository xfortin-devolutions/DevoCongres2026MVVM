namespace WinForms.Demos.Demo1.ProductTypes;

/// <summary>
/// Base class for all product types in the Master-Detail demo.
/// Contains common properties shared by all products.
/// </summary>
public abstract class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Returns the type name of the product (e.g., "Book", "Electronics", "Clothing").
    /// Used for display purposes in the UI.
    /// </summary>
    public abstract string ProductType { get; }

    public override string ToString() => Name;
}
