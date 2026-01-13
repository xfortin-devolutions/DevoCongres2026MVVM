namespace WinForms.Demos.Demo1_MasterDetail.DetailPanels;

public abstract class DetailPanel : Panel
{
    protected Label CreateLabel(string text, ref int yPos, FontStyle fontStyle = FontStyle.Regular, bool isTitle = false)
    {
        float fontSize = isTitle ? 16F : 9F;
        Label label = new()
        {
            Text = text,
            Font = new Font("Segoe UI", fontSize, fontStyle),
            Location = new Point(0, yPos),
            AutoSize = true
        };
        Controls.Add(label);
        yPos += label.PreferredHeight;
        return label;
    }
}
