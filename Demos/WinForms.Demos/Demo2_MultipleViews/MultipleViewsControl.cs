using WinForms.Demos.Demo2.ViewPanels;

namespace WinForms.Demos.Demo2;

public class MultipleViewsControl : UserControl
{
    private readonly Label titleLabel;
    private readonly Panel toolbarPanel;
    private readonly ComboBox viewModeComboBox;
    private readonly Panel contentPanel;

    private GridViewPanel? gridViewPanel;
    private TileViewPanel? tileViewPanel;
    private CardViewPanel? cardViewPanel;

    private readonly List<Product> products;
    private ViewMode currentViewMode = ViewMode.Grid;

    public MultipleViewsControl()
    {
        products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "The Hobbit",
                ProductType = "Book",
                Price = 12.99m,
                Description = "A fantasy novel about Bilbo Baggins' adventure to win a share of the treasure guarded by Smaug the dragon."
            },
            new Product
            {
                Id = 2,
                Name = "Laptop Pro 15",
                ProductType = "Electronics",
                Price = 1299.99m,
                Description = "High-performance laptop with latest processor and 16GB RAM"
            },
            new Product
            {
                Id = 3,
                Name = "Clean Code",
                ProductType = "Book",
                Price = 42.50m,
                Description = "A handbook of agile software craftsmanship"
            },
            new Product
            {
                Id = 4,
                Name = "Cotton T-Shirt",
                ProductType = "Clothing",
                Price = 29.99m,
                Description = "Comfortable everyday t-shirt made from premium cotton"
            },
            new Product
            {
                Id = 5,
                Name = "Wireless Mouse",
                ProductType = "Electronics",
                Price = 49.99m,
                Description = "Ergonomic wireless mouse with precision tracking"
            },
            new Product
            {
                Id = 6,
                Name = "Winter Jacket",
                ProductType = "Clothing",
                Price = 129.99m,
                Description = "Warm winter jacket with water-resistant outer shell"
            },
            new Product
            {
                Id = 7,
                Name = "Design Patterns",
                ProductType = "Book",
                Price = 54.99m,
                Description = "Elements of reusable object-oriented software"
            },
            new Product
            {
                Id = 8,
                Name = "Mechanical Keyboard",
                ProductType = "Electronics",
                Price = 149.99m,
                Description = "RGB mechanical keyboard with customizable switches"
            }
        };

        titleLabel = new Label
        {
            Text = "Demo 2: Multiple Views",
            Location = new Point(20, 10),
            Size = new Size(760, 30),
            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter
        };

        toolbarPanel = new Panel
        {
            Location = new Point(0, 50),
            Size = new Size(800, 50),
            BackColor = SystemColors.ControlLight,
            BorderStyle = BorderStyle.FixedSingle
        };

        var viewModeLabel = new Label
        {
            Text = "View Mode:",
            Location = new Point(20, 15),
            Size = new Size(80, 20),
            Font = new Font("Segoe UI", 10F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleLeft
        };

        viewModeComboBox = new ComboBox
        {
            Location = new Point(110, 13),
            Width = 150,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        viewModeComboBox.Items.Add(ViewMode.Grid);
        viewModeComboBox.Items.Add(ViewMode.Tile);
        viewModeComboBox.Items.Add(ViewMode.Card);
        viewModeComboBox.SelectedIndex = 0;
        viewModeComboBox.SelectedIndexChanged += ViewModeComboBox_SelectedIndexChanged;

        toolbarPanel.Controls.Add(viewModeLabel);
        toolbarPanel.Controls.Add(viewModeComboBox);

        contentPanel = new Panel
        {
            Location = new Point(0, 100),
            Size = new Size(800, 350),
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
        Name = "MultipleViewsControl";
        Size = new Size(800, 450);

        ResumeLayout(false);
    }

    private void InitializeUI()
    {
        Controls.Add(titleLabel);
        Controls.Add(toolbarPanel);
        Controls.Add(contentPanel);

        SwitchViewMode(ViewMode.Grid);
    }

    private void ViewModeComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (viewModeComboBox.SelectedItem is ViewMode selectedMode)
        {
            SwitchViewMode(selectedMode);
        }
    }

    private void SwitchViewMode(ViewMode viewMode)
    {
        if (currentViewMode == viewMode && contentPanel.Controls.Count > 0)
            return;

        currentViewMode = viewMode;
        contentPanel.Controls.Clear();

        switch (viewMode)
        {
            case ViewMode.Grid:
                ShowGridView();
                break;
            case ViewMode.Tile:
                ShowTileView();
                break;
            case ViewMode.Card:
                ShowCardView();
                break;
        }
    }

    private void ShowGridView()
    {
        if (gridViewPanel == null)
        {
            gridViewPanel = new GridViewPanel
            {
                Dock = DockStyle.Fill
            };
        }

        gridViewPanel.LoadProducts(products);
        contentPanel.Controls.Add(gridViewPanel);
    }

    private void ShowTileView()
    {
        if (tileViewPanel == null)
        {
            tileViewPanel = new TileViewPanel
            {
                Dock = DockStyle.Fill
            };
        }

        tileViewPanel.LoadProducts(products);
        contentPanel.Controls.Add(tileViewPanel);
    }

    private void ShowCardView()
    {
        if (cardViewPanel == null)
        {
            cardViewPanel = new CardViewPanel
            {
                Dock = DockStyle.Fill
            };
        }

        cardViewPanel.LoadProducts(products);
        contentPanel.Controls.Add(cardViewPanel);
    }
}
