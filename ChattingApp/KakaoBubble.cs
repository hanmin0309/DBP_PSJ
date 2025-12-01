using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

public class KakaoBubble : Control
{
    private readonly string text;
    private readonly bool isMine;

    public KakaoBubble(string msg, bool mine)
    {
        text = msg;
        isMine = mine;
        AutoSize = true;
        Padding = new Padding(14);
        Font = new Font("맑은 고딕", 10);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // 말풍선 배경
        Color bubbleColor = isMine ? Color.FromArgb(255, 235, 0) : Color.WhiteSmoke;
        using (SolidBrush brush = new SolidBrush(bubbleColor))
        using (GraphicsPath path = RoundedBubblePath(ClientRectangle, 14))
        {
            e.Graphics.FillPath(brush, path);
        }

        // 꼬리
        Point[] tail = isMine ?
            new Point[] {
                new Point(Width - 12, Height - 18),
                new Point(Width - 1, Height - 14),
                new Point(Width - 12, Height - 8) }
            :
            new Point[] {
                new Point(12, Height - 18),
                new Point(1, Height - 14),
                new Point(12, Height - 8) };

        using (SolidBrush brush = new SolidBrush(bubbleColor))
            e.Graphics.FillPolygon(brush, tail);

        // 텍스트 출력
        Rectangle textRect = new Rectangle(10, 8, Width - 20, Height - 20);
        TextRenderer.DrawText(e.Graphics, text, Font, textRect, Color.Black,
            TextFormatFlags.WordBreak);
    }

    private GraphicsPath RoundedBubblePath(Rectangle r, int radius)
    {
        GraphicsPath path = new GraphicsPath();
        int d = radius * 2;

        path.AddArc(r.X, r.Y, d, d, 180, 90);
        path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
        path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
        path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
        path.CloseFigure();
        return path;
    }

    public override Size GetPreferredSize(Size proposedSize)
    {
        Size textSize = TextRenderer.MeasureText(text, Font, new Size(240, 999),
            TextFormatFlags.WordBreak);

        return new Size(textSize.Width + Padding.Left + Padding.Right,
                        textSize.Height + Padding.Top + Padding.Bottom);
    }
}
