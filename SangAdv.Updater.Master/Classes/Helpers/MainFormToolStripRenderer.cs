using System.Drawing;
using System.Windows.Forms;

namespace SangAdv.Updater.Master
{
    public class MainFormToolStripRenderer : ToolStripProfessionalRenderer
    {
        public MainFormToolStripRenderer()
        {
            RoundedEdges = false;
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Pressed) e.Graphics.Clear(Color.FromArgb(65, 65, 65));
            else if (e.Item.Selected) SetItemHightlightColor(e);
            else base.OnRenderDropDownButtonBackground(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (!e.Item.Selected) base.OnRenderButtonBackground(e);
            else SetItemHightlightColor(e);
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            e.ArrowColor = Color.White;
            base.OnRenderArrow(e);
        }

        private void SetItemHightlightColor(ToolStripItemRenderEventArgs e)
        {
            Rectangle rectangle = new Rectangle(0, 0, e.Item.Size.Width - 1, e.Item.Size.Height - 1);
            if (e.Item.Name == "tsbExit") e.Graphics.FillRectangle(Brushes.Red, rectangle);
            else e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(97, 97, 97)), rectangle);
        }
    }
}