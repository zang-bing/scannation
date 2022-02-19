using System;
using System.Drawing;
using System.Windows.Forms;

namespace Scanation
{
    public class FrameSelection : IDisposable
    {
        private PictureBox _pictureBox;
        public Rectangle Rect;
        public bool allowDeformingDuringMovement = false;
        private bool _isClick = false;
        private bool _move = false;
        private int _oldX;
        private int _oldY;
        private int _rectNodeSize = 5;
        private Bitmap _bmp = null;
        private Bitmap _selectedBmp = null;
        private PosSizableRect nodeSelected = PosSizableRect.None;
        public bool Selected { get; set; } = false;

        private enum PosSizableRect
        {
            UpMiddle,
            LeftMiddle,
            LeftBottom,
            LeftUp,
            RightUp,
            RightMiddle,
            RightBottom,
            BottomMiddle,
            None
        };

        public FrameSelection(Rectangle r)
        {
            Rect = r;
            _isClick = false;
        }

        public void Draw(Graphics g)
        {
            if (Rect.Width <= 0 || Rect.Height <= 0)
            {
                return;
            }
            int penWidth = Selected ? 2 : 1;
            g.DrawRectangle(new Pen(Color.Red, penWidth), Rect);

            foreach (PosSizableRect pos in Enum.GetValues(typeof(PosSizableRect)))
            {
                g.DrawRectangle(new Pen(Color.Red), GetRect(pos));
            }
        }

        public void SetBitmapFile(string filename)
        {
            this._bmp = new Bitmap(filename);
        }

        public void SetBitmap(Bitmap bmp)
        {
            this._bmp = bmp;
        }

        public Bitmap SelectedBitmap => this._selectedBmp;

        public void SetPictureBox(PictureBox p)
        {
            _pictureBox = p;
            _pictureBox.MouseDown += PictureBox_MouseDown;
            _pictureBox.MouseUp += PictureBox_MouseUp;
            _pictureBox.MouseMove += PictureBox_MouseMove;
            _pictureBox.Paint += PictureBox_Paint;

            var bmp = new Bitmap(_pictureBox.Image);
            _selectedBmp = bmp.Clone(Rect, bmp.PixelFormat);
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Draw(e.Graphics);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }

        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _isClick = true;

            nodeSelected = PosSizableRect.None;
            nodeSelected = GetNodeSelectable(e.Location);

            if (Rect.Contains(new Point(e.X, e.Y)))
            {
                _move = true;
                Selected = true;
            }
            else
            {
                Selected = false;
            }
            _oldX = e.X;
            _oldY = e.Y;
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _isClick = false;
            _move = false;
            if (_pictureBox != null)
            {
                var bmp = new Bitmap(_pictureBox.Image);

                try
                {
                    _selectedBmp = bmp.Clone(Rect, bmp.PixelFormat);
                }
                catch (Exception) { }
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            ChangeCursor(e.Location);
            if (_isClick == false)
            {
                return;
            }

            Rectangle backupRect = Rect;

            switch (nodeSelected)
            {
                case PosSizableRect.LeftUp:
                    Rect.X += e.X - _oldX;
                    Rect.Width -= e.X - _oldX;
                    Rect.Y += e.Y - _oldY;
                    Rect.Height -= e.Y - _oldY;
                    break;
                case PosSizableRect.LeftMiddle:
                    Rect.X += e.X - _oldX;
                    Rect.Width -= e.X - _oldX;
                    break;
                case PosSizableRect.LeftBottom:
                    Rect.Width -= e.X - _oldX;
                    Rect.X += e.X - _oldX;
                    Rect.Height += e.Y - _oldY;
                    break;
                case PosSizableRect.BottomMiddle:
                    Rect.Height += e.Y - _oldY;
                    break;
                case PosSizableRect.RightUp:
                    Rect.Width += e.X - _oldX;
                    Rect.Y += e.Y - _oldY;
                    Rect.Height -= e.Y - _oldY;
                    break;
                case PosSizableRect.RightBottom:
                    Rect.Width += e.X - _oldX;
                    Rect.Height += e.Y - _oldY;
                    break;
                case PosSizableRect.RightMiddle:
                    Rect.Width += e.X - _oldX;
                    break;

                case PosSizableRect.UpMiddle:
                    Rect.Y += e.Y - _oldY;
                    Rect.Height -= e.Y - _oldY;
                    break;

                default:
                    if (_move)
                    {
                        Rect.X = Rect.X + e.X - _oldX;
                        Rect.Y = Rect.Y + e.Y - _oldY;
                        Console.WriteLine($"{Rect.X} {Rect.Y} {Rect.Width} {Rect.Height}");
                    }
                    break;
            }
            _oldX = e.X;
            _oldY = e.Y;

            if (Rect.Width < 5 || Rect.Height < 5)
            {
                Rect = backupRect;
            }

            TestIfRectInsideArea();

            _pictureBox.Invalidate();
        }

        private void TestIfRectInsideArea()
        {
            // Test if rectangle still inside the area.
            if (Rect.X < 0) Rect.X = 0;
            if (Rect.Y < 0) Rect.Y = 0;
            if (Rect.Width <= 0) Rect.Width = 1;
            if (Rect.Height <= 0) Rect.Height = 1;

            if (Rect.X + Rect.Width > _pictureBox.Width)
            {
                Rect.Width = _pictureBox.Width - Rect.X - 1; // -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                    _isClick = false;
                }
            }
            if (Rect.Y + Rect.Height > _pictureBox.Height)
            {
                Rect.Height = _pictureBox.Height - Rect.Y - 1;// -1 to be still show 
                if (allowDeformingDuringMovement == false)
                {
                    _isClick = false;
                }
            }
        }

        private Rectangle CreateRectSizableNode(int x, int y)
        {
            return new Rectangle(x - _rectNodeSize / 2, y - _rectNodeSize / 2, _rectNodeSize, _rectNodeSize);
        }

        private Rectangle GetRect(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return CreateRectSizableNode(Rect.X, Rect.Y);

                case PosSizableRect.LeftMiddle:
                    return CreateRectSizableNode(Rect.X, Rect.Y + +Rect.Height / 2);

                case PosSizableRect.LeftBottom:
                    return CreateRectSizableNode(Rect.X, Rect.Y + Rect.Height);

                case PosSizableRect.BottomMiddle:
                    return CreateRectSizableNode(Rect.X + Rect.Width / 2, Rect.Y + Rect.Height);

                case PosSizableRect.RightUp:
                    return CreateRectSizableNode(Rect.X + Rect.Width, Rect.Y);

                case PosSizableRect.RightBottom:
                    return CreateRectSizableNode(Rect.X + Rect.Width, Rect.Y + Rect.Height);

                case PosSizableRect.RightMiddle:
                    return CreateRectSizableNode(Rect.X + Rect.Width, Rect.Y + Rect.Height / 2);

                case PosSizableRect.UpMiddle:
                    return CreateRectSizableNode(Rect.X + Rect.Width / 2, Rect.Y);
                default:
                    return new Rectangle();
            }
        }

        private PosSizableRect GetNodeSelectable(Point p)
        {
            foreach (PosSizableRect r in Enum.GetValues(typeof(PosSizableRect)))
            {
                if (GetRect(r).Contains(p))
                {
                    return r;
                }
            }
            return PosSizableRect.None;
        }

        private void ChangeCursor(Point p)
        {
            _pictureBox.Cursor = GetCursor(GetNodeSelectable(p));
        }

        private Cursor GetCursor(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return Cursors.SizeNWSE;

                case PosSizableRect.LeftMiddle:
                    return Cursors.SizeWE;

                case PosSizableRect.LeftBottom:
                    return Cursors.SizeNESW;

                case PosSizableRect.BottomMiddle:
                    return Cursors.SizeNS;

                case PosSizableRect.RightUp:
                    return Cursors.SizeNESW;

                case PosSizableRect.RightBottom:
                    return Cursors.SizeNWSE;

                case PosSizableRect.RightMiddle:
                    return Cursors.SizeWE;

                case PosSizableRect.UpMiddle:
                    return Cursors.SizeNS;
                default:
                    return Cursors.Default;
            }
        }

        public void Dispose()
        {
            if (_pictureBox != null)
            {
                _pictureBox.MouseDown -= PictureBox_MouseDown;
                _pictureBox.MouseUp -= PictureBox_MouseUp;
                _pictureBox.MouseMove -= PictureBox_MouseMove;
                _pictureBox.Paint -= PictureBox_Paint;
                _pictureBox = null;
            }

            if (_selectedBmp != null)
            {
                _selectedBmp.Dispose();
            }
        }
    }
}
