namespace WinForms.Demos.Demo2_MultipleViews.ViewPanels;

public class GridViewPanel : Panel
{
    private readonly DataGridView dataGridView;

    public GridViewPanel()
    {
        Padding = new Padding(10);

        dataGridView = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            ReadOnly = true,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            MultiSelect = false,
            RowHeadersVisible = false,
            BackgroundColor = SystemColors.Window,
            BorderStyle = BorderStyle.None
        };

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "Id",
            HeaderText = "ID",
            DataPropertyName = "Id",
            FillWeight = 10
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "Name",
            HeaderText = "Name",
            DataPropertyName = "Name",
            FillWeight = 25
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "ProductType",
            HeaderText = "Type",
            DataPropertyName = "ProductType",
            FillWeight = 15
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "Price",
            HeaderText = "Price",
            DataPropertyName = "Price",
            FillWeight = 15,
            DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
        });

        dataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "Description",
            HeaderText = "Description",
            DataPropertyName = "Description",
            FillWeight = 35
        });

        Controls.Add(dataGridView);
    }

    public void LoadProducts(List<Product> products)
    {
        dataGridView.DataSource = null;
        dataGridView.DataSource = products;
    }
}
