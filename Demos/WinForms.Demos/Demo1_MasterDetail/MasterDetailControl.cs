using WinForms.Demos.Demo1.ProductTypes;
using WinForms.Demos.Demo1.DetailPanels;

namespace WinForms.Demos.Demo1;

public class MasterDetailControl : UserControl
{
    private readonly ListBox productListBox;
    private readonly Panel detailPanel;
    private readonly Label titleLabel;

    private BookDetailPanel? bookDetailPanel;
    private ElectronicsDetailPanel? electronicsDetailPanel;
    private ClothingDetailPanel? clothingDetailPanel;

    private readonly List<Product> products;

    public MasterDetailControl()
    {
        products = new List<Product>
        {
            new Book
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
            new Electronics
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
            new Book
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
            new Clothing
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
            new Electronics
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
            new Clothing
            {
                Id = 6,
                Name = "Winter Jacket",
                Price = 129.99m,
                Description = "Warm winter jacket with water-resistant outer shell",
                Size = "Large",
                Color = "Black",
                Material = "Polyester with down filling",
                CareInstructions = "Dry clean only"
            }
        };

        titleLabel = new Label
        {
            Text = "Demo 1: Master-Detail Pattern",
            Location = new Point(20, 20),
            Size = new Size(760, 30),
            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter
        };

        productListBox = new ListBox
        {
            Location = new Point(20, 60),
            Size = new Size(200, 370),
            DisplayMember = "Name"
        };

        detailPanel = new Panel
        {
            Location = new Point(230, 60),
            Size = new Size(550, 370),
            BorderStyle = BorderStyle.FixedSingle,
            AutoScroll = true
        };

        InitializeComponent();
        InitializeUI();
    }

    private void InitializeComponent()
    {
        SuspendLayout();

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Name = "MasterDetailControl";
        Size = new Size(800, 450);

        ResumeLayout(false);
    }

    private void InitializeUI()
    {
        Controls.Add(titleLabel);
        Controls.Add(productListBox);
        Controls.Add(detailPanel);

        foreach (var product in products)
        {
            productListBox.Items.Add(product);
        }

        productListBox.SelectedIndexChanged += ProductListBox_SelectedIndexChanged;
    }

    private void ProductListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (productListBox.SelectedItem == null)
        {
            detailPanel.Controls.Clear();
            return;
        }

        var selectedProduct = (Product)productListBox.SelectedItem;

        detailPanel.Controls.Clear();

        switch (selectedProduct)
        {
            case Book book:
                ShowBookDetails(book);
                break;

            case Electronics electronics:
                ShowElectronicsDetails(electronics);
                break;

            case Clothing clothing:
                ShowClothingDetails(clothing);
                break;
        }
    }

    private void ShowBookDetails(Book book)
    {
        if (bookDetailPanel == null)
        {
            bookDetailPanel = new BookDetailPanel
            {
                Dock = DockStyle.Fill
            };
        }

        bookDetailPanel.LoadBook(book);

        detailPanel.Controls.Add(bookDetailPanel);
    }

    private void ShowElectronicsDetails(Electronics electronics)
    {
        if (electronicsDetailPanel == null)
        {
            electronicsDetailPanel = new ElectronicsDetailPanel
            {
                Dock = DockStyle.Fill
            };
        }

        electronicsDetailPanel.LoadElectronics(electronics);

        detailPanel.Controls.Add(electronicsDetailPanel);
    }

    private void ShowClothingDetails(Clothing clothing)
    {
        if (clothingDetailPanel == null)
        {
            clothingDetailPanel = new ClothingDetailPanel
            {
                Dock = DockStyle.Fill
            };
        }

        clothingDetailPanel.LoadClothing(clothing);

        detailPanel.Controls.Add(clothingDetailPanel);
    }
}
