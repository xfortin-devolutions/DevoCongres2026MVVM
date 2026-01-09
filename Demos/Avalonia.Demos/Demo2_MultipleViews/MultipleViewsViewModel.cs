using Avalonia.Collections;
using Avalonia.Demos.Demo1_MasterDetail.ProductTypes;
using Avalonia.Demos.Demo2_MultipleViews.ViewModes;
using Avalonia.Demos.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Avalonia.Demos.Demo2_MultipleViews;

public partial class MultipleViewsViewModel() : DemoItemViewModel("Demo 2: Multiple Views")
{
    [ObservableProperty]
    private ViewMode currentViewMode = ViewMode.Grid;

    public AvaloniaList<ProductViewModel> Products { get; } =
    [
        new BookViewModel
        {
            Id = 1,
            Name = "The Hobbit",
            Price = 12.99m,
            Description = "A fantasy novel about Bilbo Baggins' adventure to win a share of the treasure guarded by Smaug the dragon.",
            Author = "J.R.R. Tolkien",
            Isbn = "978-0547928227",
            PageCount = 300,
            Genre = "Fantasy"
        },
        new ElectronicsViewModel
        {
            Id = 2,
            Name = "Laptop Pro 15",
            Price = 1299.99m,
            Description = "High-performance laptop with latest processor and 16GB RAM",
            Brand = "TechBrand",
            ModelNumber = "LP-15-2024",
            WarrantyMonths = 24,
            PowerConsumption = "65W"
        },
        new BookViewModel
        {
            Id = 3,
            Name = "Clean Code",
            Price = 42.50m,
            Description = "A handbook of agile software craftsmanship",
            Author = "Robert C. Martin",
            Isbn = "978-0132350884",
            PageCount = 464,
            Genre = "Programming"
        },
        new ClothingViewModel
        {
            Id = 4,
            Name = "Cotton T-Shirt",
            Price = 29.99m,
            Description = "Comfortable everyday t-shirt made from premium cotton",
            Size = "Medium",
            Color = "Navy Blue",
            Material = "100% Cotton",
            CareInstructions = "Machine wash cold, tumble dry low"
        },
        new ElectronicsViewModel
        {
            Id = 5,
            Name = "Wireless Mouse",
            Price = 49.99m,
            Description = "Ergonomic wireless mouse with precision tracking",
            Brand = "TechBrand",
            ModelNumber = "WM-2024",
            WarrantyMonths = 12,
            PowerConsumption = "2W"
        },
        new ClothingViewModel
        {
            Id = 6,
            Name = "Winter Jacket",
            Price = 129.99m,
            Description = "Warm winter jacket with water-resistant outer shell",
            Size = "Large",
            Color = "Black",
            Material = "Polyester with down filling",
            CareInstructions = "Dry clean only"
        },
        new BookViewModel
        {
            Id = 7,
            Name = "Design Patterns",
            Price = 54.99m,
            Description = "Elements of reusable object-oriented software",
            Author = "Gang of Four",
            Isbn = "978-0201633610",
            PageCount = 395,
            Genre = "Programming"
        },
        new ElectronicsViewModel
        {
            Id = 8,
            Name = "Mechanical Keyboard",
            Price = 149.99m,
            Description = "RGB mechanical keyboard with customizable switches",
            Brand = "TechBrand",
            ModelNumber = "MK-RGB-2024",
            WarrantyMonths = 24,
            PowerConsumption = "5W"
        }
    ];
}
