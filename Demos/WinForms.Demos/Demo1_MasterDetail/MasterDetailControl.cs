namespace WinForms.Demos.Demo1;

public class MasterDetailControl : UserControl
{
    public MasterDetailControl()
    {
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
        // TODO: Implémenter la démo Master-Detail
        var label = new Label
        {
            Text = "Demo 1: Master-Detail Pattern - À implémenter",
            Location = new Point(20, 20),
            AutoSize = true,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold)
        };

        Controls.Add(label);
    }
}
