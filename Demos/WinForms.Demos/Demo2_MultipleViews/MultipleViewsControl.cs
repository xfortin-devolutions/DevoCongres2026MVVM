namespace WinForms.Demos.Demo2;

public class MultipleViewsControl : UserControl
{
    public MultipleViewsControl()
    {
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
        // TODO: Implémenter la démo Multiple Views
        var label = new Label
        {
            Text = "Demo 2: Multiple Views - À implémenter",
            Location = new Point(20, 20),
            AutoSize = true,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold)
        };

        Controls.Add(label);
    }
}
