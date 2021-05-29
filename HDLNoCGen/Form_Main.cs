using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HDL_NoC_CodeGen
{
    public partial class Form_Main : Form
    {
        Settings settings;

        PictureGraph picture_graph;
        Graph graph;
        int size = 3000;

        string selected_route = "";

        public Form_Main()
        {
            InitializeComponent();

            settings = Settings.GetInstance();

            picture_graph = new PictureGraph();
            picture_graph.Set_bmp_size(pictureBox1.Size);

            saveFileDialog1.Filter = "image files (*.png)|*.png|All files (*.*)|*.*";

            //tabControl1.TabPages.Remove(tabPage1); // алгоритм дейкстры
            tabControl1.TabPages.Remove(tabPage2);
            tabControl1.TabPages.Remove(tabPage3);
            tabControl1.TabPages.Remove(tabPage4);
            tabControl1.TabPages.Remove(tabPage5);
            ToolStripMenuItem_routing_simple.Checked = settings.Get_checked_routing_algorithms(0);
            ToolStripMenuItem_routing_rou.Checked = settings.Get_checked_routing_algorithms(1);
            ToolStripMenuItem_routing_apm.Checked = settings.Get_checked_routing_algorithms(2);
            ToolStripMenuItem_routing_apo.Checked = settings.Get_checked_routing_algorithms(3);

            ToolStripMenuItem_All_routers.Enabled = false;
            ToolStripMenuItem_Save_grapg_image.Enabled = false;
            ToolStripMenuItem_Adaptive_routing_generating.Enabled = false;
            ToolStripMenuItem_pair_routing_generating.Enabled = false;
            ToolStripMenuItem_StepCircle_routing_generating.Enabled = false;
            ToolStripMenuItem_Table_routing_generating.Enabled = false;
        }

        private void Draw_graph() 
        {
            picture_graph.Set_bmp_size(pictureBox1.Size);
            pictureBox1.Image = picture_graph.Draw_Graph(graph.Get_node_count(), graph.Get_generators());

            GC.Collect();
        }

        private void Draw_route(string route) 
        {
            pictureBox1.Image = picture_graph.Draw_Route(route, graph.Get_node_count(), graph.Get_generators());

            GC.Collect();
        }

        private void Form1_Resize(object sender, EventArgs e) 
        {
            try
            {
                Draw_graph();
            }
            catch
            {

            }
            try
            {
                Draw_route(selected_route);
            }
            catch
            {
 
            }

            GC.Collect();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e) 
        {
           /* if (picture_graph.Is_Draw())
            {
                Point mouse_location = new Point(e.X, e.Y);
                pictureBox1.Image = picture_graph.Draw_Selected_Node(pictureBox1.Size, mouse_location, graph.Get_node_count(), graph.Get_generators());
            }*/
        }

        private void textBox_node_count_Click(object sender, EventArgs e) 
        {
            textBox_topology_signature.SelectAll();

            GC.Collect();
        }

        private void View_route(List<List<int>> route_list, ListView listView) 
        {
            int route_length = 0; // длина маршрута
            string route_name = "";
            string route;
            List<int> buff_list;
            ListViewItem item;

            listView.Items.Clear();

            for (int i = 0; i < route_list.Count; i++)
            {
                route = "";
                buff_list = new List<int>(route_list[i]);

                route_name = route_list[i][0].ToString() + "-";
                for (int j = 0; j < route_list[i].Count; j++)
                {
                    route += route_list[i][j].ToString() + "-";
                }
                route_name += route_list[i][route_list[i].Count - 1].ToString();
                route = route.Remove(route.Length - 1);

                item = new ListViewItem(route_name, i - 1);
                item.SubItems.Add(route);

                route_length = 0;
                for (int k = 0; k < route.Length - 1; k++)        // вычисление длины маршрутау
                {
                    if (route[k].Equals('-'))
                    {
                        route_length++;
                    }
                }
                item.SubItems.Add(route_length.ToString());
                listView.Items.Add(item);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_All_routers_Click(object sender, EventArgs e) 
        {
            if (graph.Is_created())
            {
                try
                {
                    View_route(graph.Generate_deikstra_routing(), listView_Deikstra);
                    label_diam_graph.Text = "D=" + graph.Calculate_diameter().ToString();

                    if (ToolStripMenuItem_routing_simple.Checked)
                    {
                        View_route(graph.Generate_Simple_routing(), listView_Simple);
                        for (int j = 0; j < listView_Deikstra.Items.Count - 1; j++)
                        {
                            if (Convert.ToInt32(listView_Simple.Items[j].SubItems[2].Text) > Convert.ToInt32(listView_Deikstra.Items[j].SubItems[2].Text))
                            {
                                listView_Simple.Items[j].BackColor = Color.Yellow;
                            }

                            if (Convert.ToInt32(listView_Simple.Items[j].SubItems[2].Text) > graph.Get_diameter())
                            {
                                listView_Simple.Items[j].BackColor = Color.Red;
                            }
                        }
                    }
                    if (ToolStripMenuItem_routing_rou.Checked)
                    {
                        View_route(graph.Generate_ROU_routing(), listView_ROU);
                        for (int j = 0; j < listView_Deikstra.Items.Count - 1; j++)
                        {
                            if (Convert.ToInt32(listView_ROU.Items[j].SubItems[2].Text) > Convert.ToInt32(listView_Deikstra.Items[j].SubItems[2].Text))
                            {
                                listView_ROU.Items[j].BackColor = Color.Yellow;
                            }

                            if (Convert.ToInt32(listView_ROU.Items[j].SubItems[2].Text) > graph.Get_diameter())
                            {
                                listView_ROU.Items[j].BackColor = Color.Red;
                            }
                        }
                    }
                    if (ToolStripMenuItem_routing_apo.Checked)
                    {
                        View_route(graph.Generate_APO_routing(), listView_APO);
                        for (int j = 0; j < listView_Deikstra.Items.Count - 1; j++)
                        {
                            if (Convert.ToInt32(listView_APO.Items[j].SubItems[2].Text) > Convert.ToInt32(listView_Deikstra.Items[j].SubItems[2].Text))
                            {
                                listView_APO.Items[j].BackColor = Color.Yellow;
                            }

                            if (Convert.ToInt32(listView_APO.Items[j].SubItems[2].Text) > graph.Get_diameter())
                            {
                                listView_APO.Items[j].BackColor = Color.Red;
                            }
                        }
                    }
                    if (ToolStripMenuItem_routing_apm.Checked)
                    {
                        View_route(graph.Generate_APM_routing(), listView_APM);
                        for (int j = 0; j < listView_Deikstra.Items.Count - 1; j++)
                        {
                            if (Convert.ToInt32(listView_APM.Items[j].SubItems[2].Text) > Convert.ToInt32(listView_Deikstra.Items[j].SubItems[2].Text))
                            {
                                listView_APM.Items[j].BackColor = Color.Yellow;
                            }

                            if (Convert.ToInt32(listView_APM.Items[j].SubItems[2].Text) > graph.Get_diameter())
                            {
                                listView_APM.Items[j].BackColor = Color.Red;
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show(graph.Get_error_message(), "Ошибка генерации маршрутов", System.Windows.Forms.MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации маршрутов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void listView_deikstra_ItemActivate(object sender, EventArgs e) 
        {
            ListViewItem item = listView_Deikstra.SelectedItems[0];
            selected_route = item.SubItems[1].Text;

            Draw_graph();
            Draw_route(selected_route);

            GC.Collect();

        }  // вывод выбранного маршрута дейкстра алгоритма

        private void listView_circle_ItemActivate(object sender, EventArgs e) 
        {
            ListViewItem item = listView_Simple.SelectedItems[0];
            selected_route = item.SubItems[1].Text;

            Draw_graph();
            Draw_route(selected_route);

            GC.Collect();
        } // вывод выбранного маршрута простого алгоритма

        private void listView_routes_ItemActivate(object sender, EventArgs e) 
        {
            ListViewItem item = listView_ROU.SelectedItems[0];
            selected_route = item.SubItems[1].Text;

            Draw_graph();
            Draw_route(selected_route);

            GC.Collect();
        } // вывод выбранного маршрута адаптивного алгоритма

        private void listView_APM_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView_APM.SelectedItems[0];
            selected_route = item.SubItems[1].Text;

            Draw_graph();
            Draw_route(selected_route);

            GC.Collect();
        }  // вывод выбранного маршрута алгоритма парной маршрутизации АПМ

        private void listView_APO_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = listView_APO.SelectedItems[0];
            selected_route = item.SubItems[1].Text;

            Draw_graph();
            Draw_route(selected_route);

            GC.Collect();
        }

        private void Show_efficient() 
        {
            int selected_tab = tabControl1.SelectedIndex;
            switch (selected_tab)
            {
                case 0:
                    label_efficiency_algorithm.Text = "E = " + graph.Calculate_efficiency_deikstra();
                break;
                case 1:
                    label_efficiency_algorithm.Text = "E = " + graph.Calculate_efficiency_simple();
                break;
                case 2:
                    label_efficiency_algorithm.Text = "E = " + graph.Calculate_efficiency_ROU();
                break;
                case 3:
                    label_efficiency_algorithm.Text = "E = " + graph.Calculate_efficiency_APM();
                break;

            }

            GC.Collect();
        }

        private void ToolStripMenuItem_Save_grapg_image_Click(object sender, EventArgs e) 
        {
            try
            {/*
                #region основной вариант сохранения
                saveFileDialog1.FileName = null;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    int min_size;
                    int max_size;
                    if (picture_graph.Get_bmp().Width > picture_graph.Get_bmp().Height)
                    {
                        min_size = picture_graph.Get_bmp().Height;
                        max_size = picture_graph.Get_bmp().Width;
                    }
                    else
                    {
                        min_size = picture_graph.Get_bmp().Width;
                        max_size = picture_graph.Get_bmp().Height;
                    }
                    Bitmap save_bmp = picture_graph.Get_bmp().Clone(new Rectangle(max_size / 2 - min_size / 2, 0, min_size, min_size), picture_graph.Get_bmp().PixelFormat);
                    save_bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                #endregion
                */
                saveFileDialog1.FileName = null;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    

                    Bitmap save_bmp = null;
                    Bitmap save_bmp2 = null;

                    try
                    {
                        picture_graph.Set_bmp_size(new Size(size, size));
                        save_bmp = picture_graph.Draw_Graph(graph.Get_node_count(), graph.Get_generators());
                    }
                    catch(Exception ex)
                    {

                    }
                    try
                    {
                        save_bmp = picture_graph.Draw_Route(selected_route, graph.Get_node_count(), graph.Get_generators());
                    }
                    catch (Exception ex)
                    {

                    }
                    if (save_bmp != null)
                    {
                        save_bmp2 = save_bmp.Clone(new Rectangle(0, 0, size, size), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                        save_bmp.Dispose();
                        GC.Collect();
                        save_bmp2.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        
                        save_bmp2.Dispose();
                        GC.Collect();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Описание топологии не было задано или не было произведено создание топологии.", "Ошибка сохранения изображения", System.Windows.Forms.MessageBoxButtons.OK);
            }
        }

        private void ToolStripMenuItem_Draw_graph_Click(object sender, EventArgs e) 
        {
            try
            {
                string buffer = textBox_topology_signature.Text.Trim();
                graph = new Graph(buffer);
                Draw_graph();

                if (graph.Is_created())
                {
                    ToolStripMenuItem_All_routers.Enabled = true;
                    ToolStripMenuItem_Save_grapg_image.Enabled = true;
                    ToolStripMenuItem_Adaptive_routing_generating.Enabled = true;
                    ToolStripMenuItem_pair_routing_generating.Enabled = true;
                    ToolStripMenuItem_StepCircle_routing_generating.Enabled = true;
                    ToolStripMenuItem_Table_routing_generating.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Описание топологии не было задано или задано некорректно.", "Ошибка создания топологии", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_Generate_memory_files_Click(object sender, EventArgs e) 
        {
            try
            {
                VerilogGenerator.Generate_table_memory_file(graph.Get_node_count(), graph.Get_generators(), graph.Get_min_ways_routing_deikstra());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_Generate_load_memory_block_Click(object sender, EventArgs e) 
        {
            try
            {
                VerilogGenerator.Generate_table_load_memory_block_file(graph.Get_node_count(), graph.Get_generators());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_Generate_net_connection_file_Click(object sender, EventArgs e)
        {
            try
            { 
                VerilogGenerator.Generate_table_net_connection_file(graph.Get_node_count(), graph.Get_generators());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_Generate_dop_part_module_Click(object sender, EventArgs e) 
        {
            try
            { 
                VerilogGenerator.Generate_table_dop_part_module(graph.Get_node_count(), graph.Get_generators());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_Genetare_route_map_Click(object sender, EventArgs e) 
        {
            try
            {
                VerilogGenerator.Generate_table_route_map(graph.Get_node_count(), graph.Get_diameter(), graph.Get_generators(), graph.Get_min_ways_routing_deikstra());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_Genetare_all_files_Click(object sender, EventArgs e) 
        {
            try
            {
                VerilogGenerator.Generate_table_route_map(graph.Get_node_count(), graph.Get_diameter(), graph.Get_generators(), graph.Get_min_ways_routing_deikstra());
                VerilogGenerator.Generate_table_memory_file(graph.Get_node_count(), graph.Get_generators(), graph.Get_min_ways_routing_deikstra());
                VerilogGenerator.Generate_table_load_memory_block_file(graph.Get_node_count(), graph.Get_generators());
                VerilogGenerator.Generate_table_net_connection_file(graph.Get_node_count(), graph.Get_generators());
                VerilogGenerator.Generate_table_dop_part_module(graph.Get_node_count(), graph.Get_generators());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_Generate_simple_net_connection_file_Click(object sender, EventArgs e) 
        {
            try
            {
                VerilogGenerator.Generate_simple_net_connection_file(graph.Get_node_count(), graph.Get_generators());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItemm_Generate_adaptive_net_connection_file_Click(object sender, EventArgs e) 
        {
            try
            {
                VerilogGenerator.Generate_adaptive_net_connection_file(graph.Get_node_count(), graph.Get_generators());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e) 
        {
            try
            {
                int selected_tab = tabControl1.SelectedIndex;
                switch (selected_tab)
                {
                    case 0:
                        label_efficiency_algorithm.Text = "E = " + graph.Calculate_efficiency_deikstra();
                    break;
                    case 1:
                        label_efficiency_algorithm.Text = "E = " + graph.Calculate_efficiency_simple();
                    break;
                    case 2:
                        label_efficiency_algorithm.Text = "E = " + graph.Calculate_efficiency_ROU();
                    break;
                    case 3:
                        label_efficiency_algorithm.Text = "E = " + graph.Calculate_efficiency_APM();
                    break;
                }
            }
            catch
            {

            }

            GC.Collect();
        }

        private void ToolStripMenuItemm_Generate_pair_net_connection_file_Click(object sender, EventArgs e)
        {
            try
            {
                VerilogGenerator.Generate_pair_net_connection_file(graph.Get_node_count(), graph.Get_generators());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItemm_Generate_pair_select_data_file_Click(object sender, EventArgs e)
        {
            try
            {
                VerilogGenerator.Generate_pair_select_data_file(graph.Get_node_count(), graph.Get_generators());
            }
            catch
            {
                MessageBox.Show("Не было произведено создание топологии.", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_Settings_Click(object sender, EventArgs e)
        {
            Form_Settings form_settings = new Form_Settings();
            if (form_settings.ShowDialog() == DialogResult.OK)
            {
                picture_graph.Update_Draw_settings();
                if (picture_graph.Is_Draw())
                {
                    this.Draw_graph();
                }
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_routing_simple_CheckStateChanged(object sender, EventArgs e)
        {
            settings.Set_checked_routing_algorithms(0, ToolStripMenuItem_routing_simple.Checked);
            settings.Save();
            if(ToolStripMenuItem_routing_simple.Checked)
            {
                tabControl1.TabPages.Add(tabPage2);
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage2);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_routing_rou_CheckStateChanged(object sender, EventArgs e)
        {
            settings.Set_checked_routing_algorithms(1, ToolStripMenuItem_routing_rou.Checked);
            settings.Save();
            if(ToolStripMenuItem_routing_rou.Checked)
            {
                tabControl1.TabPages.Add(tabPage3);
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage3);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_routing_apm_CheckStateChanged(object sender, EventArgs e)
        {
            settings.Set_checked_routing_algorithms(2, ToolStripMenuItem_routing_apm.Checked);
            settings.Save();
            if(ToolStripMenuItem_routing_apm.Checked)
            {
                tabControl1.TabPages.Add(tabPage4);
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage4);
            }

            GC.Collect();
        }

        private void ToolStripMenuItem_routing_apo_CheckStateChanged(object sender, EventArgs e)
        {
            settings.Set_checked_routing_algorithms(3, ToolStripMenuItem_routing_apo.Checked);
            settings.Save();
            if(ToolStripMenuItem_routing_apo.Checked)
            {
                tabControl1.TabPages.Add(tabPage5);
            }
            else
            {
                tabControl1.TabPages.Remove(tabPage5);
            }

            GC.Collect();
        }

        private bool Check_routing_algorithm()
        {
            if (!settings.Get_checked_routing_algorithms(0))
            {
                if (!settings.Get_checked_routing_algorithms(1))
                {
                    if (!settings.Get_checked_routing_algorithms(2))
                    {
                        if (!settings.Get_checked_routing_algorithms(3))
                        {
                            GC.Collect();
                            return false;
                        }
                    }
                }
            }

            GC.Collect();
            return true;
        }

        private void ToolStripMenuItem1_routing_settings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void загрузитьНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void списокМоделированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void загрузитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void нарисоватьМаршрутToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока не активно", "debug", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Draw_graph();
                Draw_route(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не было произведено создание топологии. \nОтрисовка маршрута невозможна", "Ошибка генерации файлов", System.Windows.Forms.MessageBoxButtons.OK);
            }

            GC.Collect();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }
    }
}