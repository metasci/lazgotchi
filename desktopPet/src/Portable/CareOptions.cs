﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopPet
{
        /// <summary>
        /// Application options. Need a redesign, so it is not documented.
        /// </summary>
        /// <preliminary/>
    public partial class CareOptions : Form
    {
            /// <summary>
            /// Constructor
            /// </summary>
        public CareOptions()
        {
            InitializeComponent();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;
            
            // Get the item from the collection.
            TabPage _tabPage = tabControl1.TabPages[e.Index];

            // Use our own font.
            Font _tabFont;


            if (e.State == DrawItemState.Selected)
            {
                // Draw a different background colour, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.White, e.Bounds);
                _tabFont = new Font(tabControl1.TabPages[e.Index].Font.FontFamily.ToString(), (float)11.0, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            else
            {
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.LightGray, e.Bounds);
                _tabFont = new Font(tabControl1.TabPages[e.Index].Font.FontFamily.ToString(), (float)10.0, FontStyle.Regular, GraphicsUnit.Pixel);
            }
            
            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, tabControl1.GetTabRect(e.Index), _stringFlags);
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {
            int totalWaterDrank = Program.WaterController.GetTotalWaterDrank();
            totalWaterLabel.Text = "Total Water Drank: " + totalWaterDrank + " oz";

            string lastWaterDrank = Program.WaterController.GetMostRecentWater();
            lastWaterDrankLabel.Text = "Last Water Drank: " + lastWaterDrank;
        }

        private void walkStartClick(object sender, EventArgs e)
        {
            walkStartTime.Text = "Start Time: " + System.DateTime.Now;
        }

        private void walkEndClick(object sender, EventArgs e)
        {
            walkEndTime.Text = "End Time: " + System.DateTime.Now;
        }

        private void waterValueAdded(object sender, EventArgs e)
        {
            int waterValue = int.Parse(waterValueInput.Text);
            Program.WaterController.AddWater(waterValue);

            int totalWaterDrank = Program.WaterController.GetTotalWaterDrank();
            totalWaterLabel.Text = "Total Water Drank: " + totalWaterDrank + " oz";

            string lastWaterDrank = Program.WaterController.GetMostRecentWater();
            lastWaterDrankLabel.Text = "Last Water Drank: " + lastWaterDrank;
        }
    }
}
