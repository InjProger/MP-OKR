using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MissionPlanner.Controls
{
    public class CmbItem : IDisposable
    {
        public string Text { get; set; }

        public Image Image { get; set; }

        public CmbItem(string text, Image img)
        {
            Text = text;
            Image = img;
        }

        public CmbItem(string text)
            : this(text, null)
        {

            // TODO
        }

        public override string ToString()
        {
            return Text;
        }

        public void Dispose()
        {
            if (Image != null)
            {
                Image.Dispose();
                Image = null;
            }
        }
    }

    public class PictureComboBox : ComboBox
    {
        public PictureComboBox()
                : base()
        {

            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= this.Items.Count)
            {
                base.OnDrawItem(e);
                return;
            }

            if (!(this.Items[e.Index] is CmbItem))
            {
                base.OnDrawItem(e);
                return;
            }

            var item = this.Items[e.Index] as CmbItem;

            var g = e.Graphics;

            e.DrawBackground();

            if (item.Image != null)
            {
                g.DrawImage(item.Image, e.Bounds.X, e.Bounds.Y, item.Image.Width, e.Bounds.Height);
                g.DrawString(item.Text, e.Font, Brushes.Black, new RectangleF(
                        item.Image.Width + 5,
                        e.Bounds.Y,
                        e.Bounds.Width - item.Image.Width - 5,
                        e.Bounds.Height
                    )
                );
            }
            else
            {
                g.DrawString(item.Text, e.Font, Brushes.Black,
                    new RectangleF(
                        5,
                        e.Bounds.Y,
                        e.Bounds.Width - 5,
                        e.Bounds.Height
                    )
                );
            }

            if (e.Index == this.SelectedIndex)
                e.DrawFocusRectangle();

            base.OnDrawItem(e);
        }
    }
}
