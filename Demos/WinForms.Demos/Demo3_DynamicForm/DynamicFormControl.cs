using WinForms.Demos.Demo3_DynamicForm.FormItems;
using WinForms.Demos.Demo3_DynamicForm.FormItemPanels;

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

    private static List<FormItem> CreateFormItems()
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
                TextItem textItem => new TextItemPanel(textItem),
                NumberItem numberItem => new NumberItemPanel(numberItem),
                BooleanItem booleanItem => new BooleanItemPanel(booleanItem),
                ChoiceItem choiceItem => new ChoiceItemPanel(choiceItem),
                _ => throw new NotSupportedException($"Form item type {item.GetType().Name} is not supported")
            };

            formPanel.Controls.Add(itemPanel);
        }
    }
}
