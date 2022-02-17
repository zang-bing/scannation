using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Scanation
{
    public partial class PrescanForm : Form
    {
        private List<Bitmap> _images;
        private int _imageIndex = -1;

        public PrescanForm(List<Bitmap> images)
        {
            InitializeComponent();
            _images = images;
        }

        private void PrevBtn_Click(object sender, EventArgs e)
        {
            if (_imageIndex > 0)
            {
                pictureBox.Image = _images[--_imageIndex];
                nextBtn.Enabled = true;
            }
            if (_imageIndex <= 0)
            {
                prevBtn.Enabled = false;
            }
        }

        private void NextBtn_Click(object sender, EventArgs e)
        {
            if (_imageIndex < _images.Count - 1)
            {
                pictureBox.Image = _images[++_imageIndex];
                prevBtn.Enabled = true;
            }
            if (_imageIndex >= _images.Count - 1)
            {
                nextBtn.Enabled = false;
            }
        }

        private void PrescanForm_Load(object sender, EventArgs e)
        {
            if (_images != null && _images.Count > 1)
            {
                nextBtn.Enabled = true;
                _imageIndex = 0;
                pictureBox.Image = _images[_imageIndex];
            }
        }
    }
}
