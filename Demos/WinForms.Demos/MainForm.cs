using WinForms.Demos.Demo1_MasterDetail;
using WinForms.Demos.Demo2_MultipleViews;
using WinForms.Demos.Demo3_DynamicForm;

namespace WinForms.Demos;

public class MainForm : Form
{
    private Panel contentPanel = null!;

    public MainForm()
    {
        SuspendLayout();

        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1920, 1080);
        Name = "MainForm";
        Text = "WinForms Demos - MVVM Workshop";
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;

        InitializeUI();

        ResumeLayout(false);
    }

    private void InitializeUI()
    {
        
        // Menu panel (left side)
        var menuPanel = new Panel
        {
            Dock = DockStyle.Left,
            Width = 250,
            BorderStyle = BorderStyle.FixedSingle
        };

        var btnDemo1 = new Button
        {
            Text = "Demo 1: Master-Detail Pattern",
            Location = new Point(10, 20),
            Size = new Size(230, 50),
            Font = new Font("Segoe UI", 10F)
        };
        btnDemo1.Click += (s, e) => LoadDemo(new MasterDetailControl());

        var btnDemo2 = new Button
        {
            Text = "Demo 2: Multiple Views",
            Location = new Point(10, 80),
            Size = new Size(230, 50),
            Font = new Font("Segoe UI", 10F)
        };
        btnDemo2.Click += (s, e) => LoadDemo(new MultipleViewsControl());

        var btnDemo3 = new Button
        {
            Text = "Demo 3: Dynamic Form Composition",
            Location = new Point(10, 140),
            Size = new Size(230, 50),
            Font = new Font("Segoe UI", 10F)
        };
        btnDemo3.Click += (s, e) => LoadDemo(new DynamicFormControl());

        menuPanel.Controls.AddRange(new Control[] { btnDemo1, btnDemo2, btnDemo3 });

        // Content panel (right side)
        contentPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20)
        };

        Controls.Add(contentPanel);
        Controls.Add(menuPanel);
    }

    private void LoadDemo(UserControl demoControl)
    {
        contentPanel.Controls.Clear();
        demoControl.Dock = DockStyle.Fill;
        contentPanel.Controls.Add(demoControl);
    }
}
