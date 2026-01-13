namespace WinForms.Demos.Demo3;

public class DynamicFormControl : UserControl
{
    public DynamicFormControl()
    {
        InitializeComponent();
        InitializeUI();
    }

    private void InitializeComponent()
    {
        SuspendLayout();

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Name = "DynamicFormControl";
        Size = new Size(800, 450);

        ResumeLayout(false);
    }

    private void InitializeUI()
    {
        var label = new Label
        {
            Text = "Demo 3: Dynamic Form Composition - À implémenter",
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter
        };

        Controls.Add(label);
    }
}
