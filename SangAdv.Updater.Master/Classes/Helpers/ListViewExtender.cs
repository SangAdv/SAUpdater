using SangAdv.Updater.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SangAdv.Updater.Master
{
    public class ListViewExtender : IDisposable
    {
        private readonly Dictionary<int, ListViewColumn> _columns = new Dictionary<int, ListViewColumn>();

        public ListViewExtender(ListView listView)
        {
            if (listView == null)
                throw new ArgumentNullException(nameof(listView));

            if (listView.View != View.Details)
                throw new ArgumentException(null, nameof(listView));

            ListView = listView;
            ListView.OwnerDraw = true;
            ListView.DrawItem += OnDrawItem;
            ListView.DrawSubItem += OnDrawSubItem;
            ListView.DrawColumnHeader += OnDrawColumnHeader;
            ListView.MouseMove += OnMouseMove;
            ListView.MouseClick += OnMouseClick;

            Font = new Font(ListView.Font.FontFamily, ListView.Font.Size - 2);
        }

        public virtual Font Font { get; private set; }
        public ListView ListView { get; private set; }

        protected virtual void OnMouseClick(object sender, MouseEventArgs e)
        {
            var column = GetColumnAt(e.X, e.Y, out var item, out var sub);
            column?.MouseClick(e, item, sub);
        }

        public ListViewColumn GetColumnAt(int x, int y, out ListViewItem item, out ListViewItem.ListViewSubItem subItem)
        {
            subItem = null;
            item = ListView.GetItemAt(x, y);
            if (item == null)
                return null;

            subItem = item.GetSubItemAt(x, y);
            if (subItem == null)
                return null;

            for (int i = 0; i < item.SubItems.Count; i++)
            {
                if (item.SubItems[i] == subItem)
                    return GetColumn(i);
            }
            return null;
        }

        protected virtual void OnMouseMove(object sender, MouseEventArgs e)
        {
            var column = GetColumnAt(e.X, e.Y, out var item, out var sub);
            if (column != null)
            {
                column.Invalidate(item, sub);
                return;
            }
            if (item != null)
            {
                ListView.Invalidate(item.Bounds);
            }
        }

        protected virtual void OnDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        protected virtual void OnDrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var column = GetColumn(e.ColumnIndex);
            if (column == null)
            {
                e.DrawDefault = true;
                return;
            }

            column.Draw(e);
        }

        protected virtual void OnDrawItem(object sender, DrawListViewItemEventArgs e)
        {
            // do nothing
        }

        public void AddColumn(ListViewColumn column)
        {
            if (column == null) throw new ArgumentNullException(nameof(column));

            column.Extender = this;
            _columns[column.ColumnIndex] = column;
        }

        public ListViewColumn GetColumn(int index)
        {
            return _columns.TryGetValue(index, out var column) ? column : null;
        }

        public IEnumerable<ListViewColumn> Columns => _columns.Values;

        public virtual void Dispose()
        {
            if (Font == null) return;
            Font.Dispose();
            Font = null;
        }
    }

    public abstract class ListViewColumn
    {
        public event EventHandler<ListViewColumnMouseEventArgs> Click;

        protected ListViewColumn(int columnIndex)
        {
            if (columnIndex < 0)
                throw new ArgumentException(null, nameof(columnIndex));

            ColumnIndex = columnIndex;
        }

        public virtual ListViewExtender Extender { get; protected internal set; }
        public int ColumnIndex { get; private set; }

        public virtual Font Font => Extender?.Font;

        public ListView ListView => Extender?.ListView;

        public abstract void Draw(DrawListViewSubItemEventArgs e);

        public virtual void MouseClick(MouseEventArgs e, ListViewItem item, ListViewItem.ListViewSubItem subItem)
        {
            Click?.Invoke(this, new ListViewColumnMouseEventArgs(e, item, subItem));
        }

        public virtual void Invalidate(ListViewItem item, ListViewItem.ListViewSubItem subItem)
        {
            Extender?.ListView.Invalidate(subItem.Bounds);
        }
    }

    public class ListViewColumnMouseEventArgs : MouseEventArgs
    {
        public ListViewColumnMouseEventArgs(MouseEventArgs e, ListViewItem item, ListViewItem.ListViewSubItem subItem)
            : base(e.Button, e.Clicks, e.X, e.Y, e.Delta)
        {
            Item = item;
            SubItem = subItem;
        }

        public ListViewItem Item { get; private set; }
        public ListViewItem.ListViewSubItem SubItem { get; private set; }
    }

    public class ListViewButtonColumn : ListViewColumn
    {
        private Rectangle _hot = Rectangle.Empty;

        public ListViewButtonColumn(int columnIndex) : base(columnIndex)
        {
        }

        public bool FixedWidth { get; set; }
        public bool DrawIfEmpty { get; set; }

        public override ListViewExtender Extender
        {
            get => base.Extender;
            protected internal set
            {
                base.Extender = value;
                if (FixedWidth)
                {
                    base.Extender.ListView.ColumnWidthChanging += OnColumnWidthChanging;
                }
            }
        }

        protected virtual void OnColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex != ColumnIndex) return;
            e.Cancel = true;
            e.NewWidth = ListView.Columns[e.ColumnIndex].Width;
        }

        public override void Draw(DrawListViewSubItemEventArgs e)
        {
            if (_hot != Rectangle.Empty)
            {
                if (_hot != e.Bounds)
                {
                    ListView.Invalidate(_hot);
                    _hot = Rectangle.Empty;
                }
            }

            if ((!DrawIfEmpty) && (string.IsNullOrEmpty(e.SubItem.Text)))
                return;

            var mouse = e.Item.ListView.PointToClient(Control.MousePosition);
            if ((ListView.GetItemAt(mouse.X, mouse.Y) == e.Item) && (e.Item.GetSubItemAt(mouse.X, mouse.Y) == e.SubItem))
            {
                ButtonRenderer.DrawButton(e.Graphics, e.Bounds, e.SubItem.Text, Font, true, PushButtonState.Hot);
                _hot = e.Bounds;
            }
            else
            {
                ButtonRenderer.DrawButton(e.Graphics, e.Bounds, e.SubItem.Text, Font, false, PushButtonState.Default);
            }
        }
    }

    public class ListViewImageColumn : ListViewColumn
    {
        private Rectangle _hot = Rectangle.Empty;

        public ListViewImageColumn(int columnIndex) : base(columnIndex)
        {
        }

        public bool DrawIfEmpty { get; set; }

        public override ListViewExtender Extender
        {
            get => base.Extender;
            protected internal set
            {
                base.Extender = value;

                base.Extender.ListView.ColumnWidthChanging += OnColumnWidthChanging;
            }
        }

        protected virtual void OnColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            if (e.ColumnIndex != ColumnIndex) return;
            e.Cancel = true;
            e.NewWidth = ListView.Columns[e.ColumnIndex].Width;
        }

        private Image GetSmallListImage(int imageIndex)
        {
            return base.Extender.ListView.SmallImageList.Images[imageIndex];
        }

        public override void Draw(DrawListViewSubItemEventArgs e)
        {
            if (_hot != Rectangle.Empty)
            {
                if (_hot != e.Bounds)
                {
                    ListView.Invalidate(_hot);
                    _hot = Rectangle.Empty;
                }
            }

            if ((!DrawIfEmpty) && (string.IsNullOrEmpty(e.SubItem.Text)))
                return;

            var image = GetSmallListImage(e.SubItem.Text.Value<int>());
            var imageWidth = image.Width;

            var rectangle = new Rectangle();
            rectangle.Width = imageWidth;
            rectangle.Height = imageWidth;
            rectangle.X = e.Bounds.X;
            rectangle.Y = e.Bounds.Y;

            rectangle.X = e.Bounds.X + (e.Bounds.Width - 24) / 2;

            e.Graphics.DrawImage(GetSmallListImage(e.SubItem.Text.Value<int>()), rectangle);
        }
    }
}