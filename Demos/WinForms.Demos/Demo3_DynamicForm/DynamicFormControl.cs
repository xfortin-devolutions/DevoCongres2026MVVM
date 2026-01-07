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
        // TODO: Implémenter la démo Dynamic Form Composition
        var label = new Label
        {
            Text = "Demo 3: Dynamic Form Composition - À implémenter",
            Location = new Point(20, 20),
            AutoSize = true,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold)
        };

        Controls.Add(label);
    }
}
