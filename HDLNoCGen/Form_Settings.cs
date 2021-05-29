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

namespace HDL_NoC_CodeGen
{
    public partial class Form_Settings : Form
    {
        //string minusPath = Application.StartupPath + Path.DirectorySeparatorChar + "minus.png";
        //string plusPath = Application.StartupPath + Path.DirectorySeparatorChar + "plus.png";
        //string nodePath = Application.StartupPath + Path.DirectorySeparatorChar + "directory.png";
        //string nonePath = Application.StartupPath + Path.DirectorySeparatorChar + "none.png";

        private Settings settings;

        private int back_color_graph;
        private bool black_graph_color;
        private bool alternative_draw_graph;
        private int pen_node_color;

        private int pen_node_width;
        private int vertex_size;
        private string node_naming_font_name;
        private int node_naming_font_size;
        private int node_naming_brush_color;
        private bool node_naming;
        private int node_naming_start_index;
        private int node_naming_string_offset;
        private int node_naming_interval;

        private int route_color;
        private int route_width;


        public Form_Settings()
        {
            InitializeComponent();
            //this.treeView1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            //this.treeView1.DrawNode += new DrawTreeNodeEventHandler(treeView1_DrawNode);

            settings = Settings.GetInstance();

            tabControl1.ItemSize = new Size(1, 1);
            tabControl1.SelectTab(0);


            /*
            back_color_graph = -1;
            black_graph_color = false;
            alternative_draw_graph = false;
            pen_node_color = -16777216;
            pen_node_width = 5;
            vertex_size = 30;
            node_naming_font_name = "Arial";
            node_naming_font_size = 7;
            node_naming_brush_color = -16777216;
            node_naming = true;
            node_naming_start_index = 0;
            node_naming_string_offset = 50;
            route_color = -10496;
            route_width = 5;
            */
            try
            {
                this.back_color_graph = settings.Get_back_color_graph();
                this.black_graph_color = settings.Get_black_graph_color();
                this.alternative_draw_graph = settings.Get_alternative_draw_graph();
                this.pen_node_color = settings.Get_pen_node_color();
                this.pen_node_width = settings.Get_pen_node_width();
                this.vertex_size = settings.Get_vertex_size();
                this.node_naming_font_name = settings.Get_node_naming_font_name();
                this.node_naming_font_size = settings.Get_node_naming_font_size();
                this.node_naming_brush_color = settings.Get_node_naming_brush_color();
                this.node_naming = settings.Get_node_naming();
                this.node_naming_start_index = settings.Get_node_naming_start_index();
                this.node_naming_string_offset = settings.Get_node_naming_string_offset();
                this.node_naming_interval = settings.Get_node_naming_interval();
                this.route_color = settings.Get_route_color();
                this.route_width = settings.Get_route_width();
            }
            catch (Exception ex)
            {
                this.back_color_graph = -1;
                this.black_graph_color = false;
                this.alternative_draw_graph = false;
                this.pen_node_color = -16777216;
                this.pen_node_width = 5;
                this.vertex_size = 30;
                this.node_naming_font_name = "Arial";
                this.node_naming_font_size = 7;
                this.node_naming_brush_color = -16777216;
                this.node_naming = true;
                this.node_naming_start_index = 0;
                this.node_naming_string_offset = 50;
                this.node_naming_interval = 1;
                this.route_color = -10496;
                this.route_width = 5;
            }


            panel_backcolor.BackColor = Color.FromArgb(this.back_color_graph);
            checkBox_graph_color.Checked = this.black_graph_color;
            checkBox_alternative_draw_graph.Checked = this.alternative_draw_graph;
            numericUpDown_edge_thickness.Value = this.pen_node_width;
            numericUpDown_vertex_size.Value = this.vertex_size;
            checkBox_node_naming.Checked = this.node_naming;
            textBox_vertex_font.Text = this.node_naming_font_name + "; " + this.node_naming_font_size.ToString();
            comboBox_node_naming_start_index.SelectedItem = comboBox_node_naming_start_index.Items[this.node_naming_start_index];
            numericUpDown_strinhg_offset.Value = this.node_naming_string_offset;
            panel_route_color.BackColor = Color.FromArgb(this.route_color);
            numericUpDown_route_size.Value = this.route_width;
            numericUpDownnode_naming_interval.Value = this.node_naming_interval;

            Draw_preview_graph();
        }

        // возможно стоит перенести в класс отрисовки
        private void Draw_preview_graph()
        {
            Bitmap bmp = new Bitmap(pictureBox_preview.Width, pictureBox_preview.Height);
            bmp.SetResolution(500, 500);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.FromArgb(back_color_graph));

            Pen pen_node = new Pen(Color.FromArgb(pen_node_color));
            pen_node.Width = pen_node_width;

            Pen pen_route = new Pen(Color.FromArgb(route_color));
            pen_route.Width = route_width;

            Point node_point = new Point(pictureBox_preview.Size.Width / 2, pictureBox_preview.Size.Height / 2 + 50);
            graphics.DrawEllipse(pen_node, new Rectangle(node_point.X - vertex_size / 2, node_point.Y - vertex_size / 2, vertex_size, vertex_size));
            graphics.DrawLine(pen_node, node_point, new Point(pictureBox_preview.Size.Width / 2 - 70, pictureBox_preview.Size.Height / 2 + 65));
            graphics.DrawLine(pen_route, node_point, new Point(pictureBox_preview.Size.Width / 2 + 70, pictureBox_preview.Size.Height / 2 + 65));

            Point str_point = new Point(node_point.X, node_point.Y - 70);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            Rectangle rect = new Rectangle(node_point.X - 40, node_point.Y - 40, 80, 80);

            // для текста
            //graphics.DrawRectangle(pen_node, rect);
            //graphics.DrawLine(pen_node, new Point(node_point.X - 40, node_point.Y - 40), new Point(node_point.X + 40, node_point.Y + 40));
            //graphics.DrawLine(pen_node, new Point(node_point.X + 40, node_point.Y - 40), new Point(node_point.X - 40, node_point.Y + 40));

            if (node_naming == true)
            {
                graphics.DrawString(node_naming_start_index.ToString(), new Font(node_naming_font_name, node_naming_font_size), new SolidBrush(Color.FromArgb(node_naming_brush_color)), new Rectangle(node_point.X - 60, node_point.Y - 60 - 2 - node_naming_string_offset, 120, 120), sf);
            }
            pictureBox_preview.Image = bmp;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int selected_node_index = Convert.ToInt32(treeView1.SelectedNode.Tag);
            tabControl1.SelectTab(selected_node_index);
        }

        private void panel_back_color_graph_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                back_color_graph = colorDialog1.Color.ToArgb();
                panel_backcolor.BackColor = colorDialog1.Color;

                Draw_preview_graph();
            }
        }

        private void numericUpDown_edge_thickness_ValueChanged(object sender, EventArgs e)
        {
            pen_node_width = Convert.ToInt32(numericUpDown_edge_thickness.Value);

            Draw_preview_graph();
        }

        private void numericUpDown_vertex_size_ValueChanged(object sender, EventArgs e)
        {
            vertex_size = Convert.ToInt32(numericUpDown_vertex_size.Value);

            Draw_preview_graph();
        }

        private void button_node_naming_font_select_Click(object sender, EventArgs e)
        {
            bool error_select_font = false;
            DialogResult dialogresult;
            do
            {
                try
                {
                    fontDialog1.Font = new Font(node_naming_font_name, node_naming_font_size);
                    dialogresult = fontDialog1.ShowDialog();
                    if (dialogresult == DialogResult.OK)
                    {
                        error_select_font = false;
                        node_naming_font_name = fontDialog1.Font.Name;
                        node_naming_font_size = Convert.ToInt32(fontDialog1.Font.Size);

                        textBox_vertex_font.Text = node_naming_font_name;
                        textBox_vertex_font.Text += "; ";
                        textBox_vertex_font.Text += node_naming_font_size + " пт";

                    }
                    else if (dialogresult == DialogResult.Cancel)
                    {
                        error_select_font = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка выбора шрифта", MessageBoxButtons.OKCancel);
                    error_select_font = true;
                }
            }
            while (error_select_font);

            Draw_preview_graph();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            settings.Set_back_color_graph(this.back_color_graph);
            settings.Set_black_graph_color(this.black_graph_color);
            settings.Set_alternative_draw_graph(this.alternative_draw_graph);
            settings.Set_pen_node_color(this.pen_node_color);
            settings.Set_pen_node_width(this.pen_node_width);
            settings.Set_vertex_size(this.vertex_size);
            settings.Set_node_naming_font_name(this.node_naming_font_name);
            settings.Set_node_naming_font_size(this.node_naming_font_size);
            settings.Set_node_naming_brush_color(this.node_naming_brush_color);
            settings.Set_node_naming(this.node_naming);
            settings.Set_node_naming_start_index(this.node_naming_start_index);
            settings.Set_node_naming_string_offset(this.node_naming_string_offset);
            settings.Set_node_naming_interval(this.node_naming_interval);
            settings.Set_route_color(this.route_color);
            settings.Set_route_width(this.route_width);

            settings.Save();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBox_node_naming_CheckedChanged(object sender, EventArgs e)
        {
            node_naming = checkBox_node_naming.Checked;

            Draw_preview_graph();
        }

        private void comboBox_node_naming_start_index_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.node_naming_start_index = comboBox_node_naming_start_index.SelectedIndex;

            Draw_preview_graph();
        }

        private void numericUpDown_strinhg_offset_ValueChanged(object sender, EventArgs e)
        {
            node_naming_string_offset = Convert.ToInt32(numericUpDown_strinhg_offset.Value);

            Draw_preview_graph();
        }

        private void panel_route_color_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                route_color = colorDialog1.Color.ToArgb();
                panel_route_color.BackColor = colorDialog1.Color;

                Draw_preview_graph();
                // поумать, нужно ли визуализировать цвет маршрута или нет?
            }
        }

        private void numericUpDown_route_size_ValueChanged(object sender, EventArgs e)
        {
            this.route_width = Convert.ToInt32(numericUpDown_route_size.Value);

            Draw_preview_graph();
        }

        private void checkBox_graph_color_CheckedChanged(object sender, EventArgs e)
        {
            black_graph_color = checkBox_graph_color.Checked;
        }

        private void checkBox_alternative_draw_graph_CheckedChanged(object sender, EventArgs e)
        {
            alternative_draw_graph = checkBox_alternative_draw_graph.Checked;
        }

        private void numericUpDown_number_interval_ValueChanged(object sender, EventArgs e)
        {
            this.node_naming_interval = Convert.ToInt32(numericUpDownnode_naming_interval.Value);
        }




        /* новая отрисовка treenode1. пока что она не доделана
        void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Rectangle nodeRect = e.Node.Bounds;


            //--------- 1. draw expand/collapse icon ---------

            Point ptExpand = new Point(nodeRect.Location.X - 20, nodeRect.Location.Y + 2);
            Image expandImg = null;
            if (e.Node.IsExpanded)// || e.Node.Nodes.Count < 1)
                expandImg = Image.FromFile(plusPath);
            else if(e.Node.Nodes.Count < 1)
                expandImg = Image.FromFile(minusPath);
            else
                expandImg = Image.FromFile(minusPath);
            Graphics g = Graphics.FromImage(expandImg);
            IntPtr imgPtr = g.GetHdc();
            g.ReleaseHdc();
            e.Graphics.DrawImage(expandImg, ptExpand);
            
            //--------- 2. draw node icon ---------
            Point ptNodeIcon = new Point(nodeRect.Location.X - 4, nodeRect.Location.Y + 2);
            Image nodeImg = Image.FromFile(nodePath);
            g = Graphics.FromImage(nodeImg);
            imgPtr = g.GetHdc();
            g.ReleaseHdc();
            e.Graphics.DrawImage(nodeImg, ptNodeIcon);
            
            //--------- 3. draw node text ---------
            Font nodeFont = e.Node.NodeFont;
            if (nodeFont == null)
                nodeFont = ((TreeView)sender).Font;
            Brush textBrush = SystemBrushes.WindowText;
            //to highlight the text when selected
            if ((e.State & TreeNodeStates.Focused) != 0)
                textBrush = SystemBrushes.HotTrack;
            //Inflate to not be cut
            Rectangle textRect = nodeRect;
            //need to extend node rect
            textRect.Width += 40;
            e.Graphics.DrawString(e.Node.Text, nodeFont, textBrush,
                Rectangle.Inflate(textRect, -12, 0));

        }
        */
    }
}
