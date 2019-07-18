using BidirectionalList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLTest
{
    public partial class Form1 : Form
    {
        ListRandom list = null;
        const int rectSize = 40;

        Font f = new Font("Tahoma", 12, FontStyle.Bold);
        Font f2 = new Font("Tahoma", 8);

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.Black, graphics.ClipBounds);

            if (list == null)
                return;

            ListNode n = list.Head;

            for (int i = 0; i < list.Count; i++)
            {
                Rectangle r = new Rectangle(2 + (2 * rectSize + 2) * i, 2, 2 * rectSize, rectSize);
                Size textSize = graphics.MeasureString(n.Data, f).ToSize();
                int textOffsetX = (r.Width - textSize.Width) / 2;
                int textOffsetY = (r.Height - textSize.Height) / 2;

                string prevText = n.Previous != null ? n.Previous.Data : "Head";
                string nextText = n.Next != null ? n.Next.Data : "Tail";
                string rndText = n.Random != null ? n.Random.Data : "";

                graphics.FillRectangle(Brushes.White, r);
                
                graphics.DrawString(prevText, f2, Brushes.Gray, r.Left + 2, n.Previous == null ? r.Top + 2 : r.Height - 12);
                graphics.DrawString(nextText, f2, Brushes.Gray, r.Right - graphics.MeasureString(nextText, f2).ToSize().Width - 2, n.Next == null ? r.Top + 2 : r.Height - 12);
                graphics.DrawString(n.Data, f, Brushes.Black, r.Left + textOffsetX, r.Top + textOffsetY);
                graphics.DrawString(rndText, f2, Brushes.Red, r.Left + (r.Width - graphics.MeasureString(rndText, f2).ToSize().Width) / 2, r.Height - 12);

                n = n.Next;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list = ListRandom.GenerateRandomList();
            pictureBox1.Invalidate();
        }

        private void bDeserialize_Click(object sender, EventArgs e)
        {
            try
            {
                list = new ListRandom();
                var fs = new FileStream("list.blf", FileMode.Open);
                list.Deserialize(fs);
                pictureBox1.Invalidate();
                MessageBox.Show("list deserialization complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bSerialize_Click(object sender, EventArgs e)
        {
            if (list == null)
            {
                MessageBox.Show("list is null", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var fs = new FileStream("list.blf", FileMode.Create);
                list?.Serialize(fs);
                MessageBox.Show("list serialization complete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
