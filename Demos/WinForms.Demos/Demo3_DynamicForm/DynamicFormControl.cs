using WinForms.Demos.Demo3_DynamicForm.FormItems;

namespace WinForms.Demos.Demo3_DynamicForm;

public class DynamicFormControl : UserControl
{
    private readonly Label titleLabel;
    private readonly FlowLayoutPanel formPanel;
    private readonly List<FormItem> formItems;

    public DynamicFormControl()
    {
        formItems = CreateFormItems();

        titleLabel = new Label
        {
            Text = "Demo 3: Dynamic Form Composition",
            Dock = DockStyle.Top,
            Height = 50,
            Font = new Font("Segoe UI", 16F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter
        };

        formPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            AutoScroll = true,
            WrapContents = false,
            Padding = new Padding(20)
        };

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        SuspendLayout();

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Name = "DynamicFormControl";
        Size = new Size(800, 450);

        Initialize();

        ResumeLayout(false);
    }

    private void Initialize()
    {
        Controls.Add(formPanel);
        Controls.Add(titleLabel);

        RenderFormItems();
    }

    private List<FormItem> CreateFormItems()
    {
        return
        [
            new TextItem
            {
                Label = "Full Name",
                Value = "John Doe"
            },
            new TextItem
            {
                Label = "Email Address",
                Value = "john.doe@example.com"
            },
            new NumberItem
            {
                Label = "Age",
                Value = 30,
                Minimum = 18,
                Maximum = 120,
                Increment = 1
            },
            new ChoiceItem
            {
                Label = "Country",
                Options = ["Canada", "United States", "United Kingdom", "France", "Germany", "Japan"],
                SelectedValue = "Canada"
            },
            new BooleanItem
            {
                Label = "Subscribe to Newsletter",
                Value = true
            },
            new NumberItem
            {
                Label = "Salary Expectation",
                Value = 75000,
                Minimum = 0,
                Maximum = 500000,
                Increment = 5000
            },
            new ChoiceItem
            {
                Label = "Experience Level",
                Options = ["Junior", "Intermediate", "Senior", "Lead", "Principal"],
                SelectedValue = "Intermediate"
            },
            new BooleanItem
            {
                Label = "Remote Work Available",
                Value = false
            },
            new TextItem
            {
                Label = "LinkedIn Profile",
                Value = "https://linkedin.com/in/johndoe"
            },
            new ChoiceItem
            {
                Label = "Preferred Language",
                Options = ["English", "French", "Spanish", "German", "Mandarin"],
                SelectedValue = "English"
            }
        ];
    }

    private void RenderFormItems()
    {
        formPanel.Controls.Clear();

        foreach (FormItem item in formItems)
        {
            Panel itemPanel = item switch
            {
                TextItem textItem => CreateTextItemPanel(textItem),
                NumberItem numberItem => CreateNumberItemPanel(numberItem),
                BooleanItem booleanItem => CreateBooleanItemPanel(booleanItem),
                ChoiceItem choiceItem => CreateChoiceItemPanel(choiceItem),
                _ => throw new NotSupportedException($"Form item type {item.GetType().Name} is not supported")
            };

            formPanel.Controls.Add(itemPanel);
        }
    }

    private static Panel CreateTextItemPanel(TextItem item)
    {
        Panel panel = new()
        {
            Width = 900,
            Height = 25,
            Margin = new Padding(0, 0, 0, 5)
        };

        Label label = new()
        {
            Text = item.Label,
            Location = new Point(0, 2),
            Width = 120
        };
        panel.Controls.Add(label);

        TextBox textBox = new()
        {
            Text = item.Value,
            Location = new Point(120, 0),
            Width = 400,
            Font = new Font("Segoe UI", 10F)
        };
        textBox.TextChanged += (_, _) => item.Value = textBox.Text;
        panel.Controls.Add(textBox);

        return panel;
    }

    private static Panel CreateNumberItemPanel(NumberItem item)
    {
        Panel panel = new()
        {
            Width = 900,
            Height = 25,
            Margin = new Padding(0, 0, 0, 5)
        };
        
        Label label = new()
        {
            Text = item.Label,
            Location = new Point(0, 2),
            Width = 120
        };
        panel.Controls.Add(label);

        NumericUpDown numericUpDown = new()
        {
            Minimum = item.Minimum,
            Maximum = item.Maximum,
            Value = item.Value,
            Increment = item.Increment,
            Location = new Point(120, 0),
            Width = 150,
            Font = new Font("Segoe UI", 10F)
        };
        numericUpDown.ValueChanged += (_, _) => item.Value = numericUpDown.Value;
        panel.Controls.Add(numericUpDown);

        return panel;
    }

    private static Panel CreateBooleanItemPanel(BooleanItem item)
    {
        Panel panel = new()
        {
            Width = 900,
            Height = 25,
            Margin = new Padding(0, 0, 0, 5)
        };

        CheckBox checkBox = new()
        {
            Text = item.Label,
            Checked = item.Value,
            Location = new Point(120, 0),
            AutoSize = true
        };
        checkBox.CheckedChanged += (_, _) => item.Value = checkBox.Checked;
        panel.Controls.Add(checkBox);

        return panel;
    }

    private static Panel CreateChoiceItemPanel(ChoiceItem item)
    {
        Panel panel = new()
        {
            Width = 900,
            Height = 25,
            Margin = new Padding(0, 0, 0, 5)
        };

        Label label = new()
        {
            Text = item.Label,
            Location = new Point(0, 2),
            Width = 120
        };
        panel.Controls.Add(label);

        ComboBox comboBox = new()
        {
            Location = new Point(120, 0),
            Width = 250,
            Font = new Font("Segoe UI", 10F),
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        comboBox.Items.AddRange(item.Options);
        comboBox.SelectedItem = item.SelectedValue;
        comboBox.SelectedIndexChanged += (_, _) => item.SelectedValue = comboBox.SelectedItem?.ToString() ?? string.Empty;
        panel.Controls.Add(comboBox);

        return panel;
    }
}
