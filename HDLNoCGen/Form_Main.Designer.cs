namespace HDL_NoC_CodeGen
{
    partial class Form_Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_node_count = new System.Windows.Forms.Label();
            this.textBox_topology_signature = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.listView_ROU = new System.Windows.Forms.ListView();
            this.column_destination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_route = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_l = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_diam_graph = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView_Deikstra = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView_Simple = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.listView_APM = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.listView_APO = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label_efficiency_algorithm = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.списокМоделированияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьНастройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Graph = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Draw_graph = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритмыМаршрутизацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_routing_deikstra = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_routing_simple = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_routing_rou = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_routing_apm = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_routing_apo = new System.Windows.Forms.ToolStripMenuItem();
            this.настроитьToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem1_routing_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_All_routers = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Save_grapg_image = new System.Windows.Forms.ToolStripMenuItem();
            this.нарисоватьМаршрутToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьИзФайлаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Generate = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Table_routing_generating = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Genetare_route_map = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Generate_memory_files = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Generate_load_memory_block = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Generate_net_connection_file = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Generate_dop_part_module = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_Genetare_all_files = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_StepCircle_routing_generating = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Generate_simple_net_connection_file = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Adaptive_routing_generating = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemm_Generate_adaptive_net_connection_file = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_pair_routing_generating = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemm_Generate_pair_net_connection_file = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemm_Generate_pair_select_data_file = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(798, 448);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(798, 448);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // label_node_count
            // 
            this.label_node_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_node_count.AutoSize = true;
            this.label_node_count.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_node_count.Location = new System.Drawing.Point(818, 7);
            this.label_node_count.Name = "label_node_count";
            this.label_node_count.Size = new System.Drawing.Size(61, 13);
            this.label_node_count.TabIndex = 2;
            this.label_node_count.Text = "Циркулянт";
            // 
            // textBox_topology_signature
            // 
            this.textBox_topology_signature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_topology_signature.Location = new System.Drawing.Point(885, 4);
            this.textBox_topology_signature.Name = "textBox_topology_signature";
            this.textBox_topology_signature.Size = new System.Drawing.Size(141, 20);
            this.textBox_topology_signature.TabIndex = 4;
            this.textBox_topology_signature.Click += new System.EventHandler(this.textBox_node_count_Click);
            // 
            // listView_ROU
            // 
            this.listView_ROU.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_ROU.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_destination,
            this.column_route,
            this.column_l});
            this.listView_ROU.FullRowSelect = true;
            this.listView_ROU.GridLines = true;
            this.listView_ROU.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_ROU.HideSelection = false;
            this.listView_ROU.Location = new System.Drawing.Point(1, 3);
            this.listView_ROU.MultiSelect = false;
            this.listView_ROU.Name = "listView_ROU";
            this.listView_ROU.Size = new System.Drawing.Size(324, 416);
            this.listView_ROU.TabIndex = 16;
            this.listView_ROU.UseCompatibleStateImageBehavior = false;
            this.listView_ROU.View = System.Windows.Forms.View.Details;
            this.listView_ROU.ItemActivate += new System.EventHandler(this.listView_routes_ItemActivate);
            // 
            // column_destination
            // 
            this.column_destination.Text = "A-B";
            this.column_destination.Width = 40;
            // 
            // column_route
            // 
            this.column_route.Text = "Маршрут";
            this.column_route.Width = 233;
            // 
            // column_l
            // 
            this.column_l.Text = "L";
            this.column_l.Width = 30;
            // 
            // label_diam_graph
            // 
            this.label_diam_graph.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_diam_graph.AutoSize = true;
            this.label_diam_graph.Location = new System.Drawing.Point(1031, 7);
            this.label_diam_graph.Name = "label_diam_graph";
            this.label_diam_graph.Size = new System.Drawing.Size(21, 13);
            this.label_diam_graph.TabIndex = 17;
            this.label_diam_graph.Text = "D=";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(816, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(335, 448);
            this.tabControl1.TabIndex = 20;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView_Deikstra);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(327, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Дейкстра";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // listView_Deikstra
            // 
            this.listView_Deikstra.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Deikstra.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView_Deikstra.FullRowSelect = true;
            this.listView_Deikstra.GridLines = true;
            this.listView_Deikstra.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Deikstra.HideSelection = false;
            this.listView_Deikstra.Location = new System.Drawing.Point(1, 3);
            this.listView_Deikstra.MultiSelect = false;
            this.listView_Deikstra.Name = "listView_Deikstra";
            this.listView_Deikstra.Size = new System.Drawing.Size(324, 416);
            this.listView_Deikstra.TabIndex = 17;
            this.listView_Deikstra.UseCompatibleStateImageBehavior = false;
            this.listView_Deikstra.View = System.Windows.Forms.View.Details;
            this.listView_Deikstra.ItemActivate += new System.EventHandler(this.listView_deikstra_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "A-B";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Маршрут";
            this.columnHeader2.Width = 233;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "L";
            this.columnHeader3.Width = 30;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView_Simple);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(327, 422);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Почасовой";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView_Simple
            // 
            this.listView_Simple.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_Simple.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView_Simple.FullRowSelect = true;
            this.listView_Simple.GridLines = true;
            this.listView_Simple.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_Simple.HideSelection = false;
            this.listView_Simple.Location = new System.Drawing.Point(1, 3);
            this.listView_Simple.MultiSelect = false;
            this.listView_Simple.Name = "listView_Simple";
            this.listView_Simple.Size = new System.Drawing.Size(324, 416);
            this.listView_Simple.TabIndex = 17;
            this.listView_Simple.UseCompatibleStateImageBehavior = false;
            this.listView_Simple.View = System.Windows.Forms.View.Details;
            this.listView_Simple.ItemActivate += new System.EventHandler(this.listView_circle_ItemActivate);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "A-B";
            this.columnHeader4.Width = 40;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Маршрут";
            this.columnHeader5.Width = 233;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "L";
            this.columnHeader6.Width = 30;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView_ROU);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(327, 422);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "ROU";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.listView_APM);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(327, 422);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "АПМ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // listView_APM
            // 
            this.listView_APM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_APM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView_APM.FullRowSelect = true;
            this.listView_APM.GridLines = true;
            this.listView_APM.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_APM.HideSelection = false;
            this.listView_APM.Location = new System.Drawing.Point(1, 3);
            this.listView_APM.MultiSelect = false;
            this.listView_APM.Name = "listView_APM";
            this.listView_APM.Size = new System.Drawing.Size(324, 416);
            this.listView_APM.TabIndex = 17;
            this.listView_APM.UseCompatibleStateImageBehavior = false;
            this.listView_APM.View = System.Windows.Forms.View.Details;
            this.listView_APM.ItemActivate += new System.EventHandler(this.listView_APM_ItemActivate);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "A-B";
            this.columnHeader7.Width = 40;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Маршрут";
            this.columnHeader8.Width = 233;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "L";
            this.columnHeader9.Width = 30;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.listView_APO);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(327, 422);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "АПО";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // listView_APO
            // 
            this.listView_APO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView_APO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12});
            this.listView_APO.FullRowSelect = true;
            this.listView_APO.GridLines = true;
            this.listView_APO.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView_APO.HideSelection = false;
            this.listView_APO.Location = new System.Drawing.Point(1, 3);
            this.listView_APO.MultiSelect = false;
            this.listView_APO.Name = "listView_APO";
            this.listView_APO.Size = new System.Drawing.Size(324, 416);
            this.listView_APO.TabIndex = 18;
            this.listView_APO.UseCompatibleStateImageBehavior = false;
            this.listView_APO.View = System.Windows.Forms.View.Details;
            this.listView_APO.ItemActivate += new System.EventHandler(this.listView_APO_ItemActivate);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "A-B";
            this.columnHeader10.Width = 40;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Маршрут";
            this.columnHeader11.Width = 233;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "L";
            this.columnHeader12.Width = 30;
            // 
            // label_efficiency_algorithm
            // 
            this.label_efficiency_algorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_efficiency_algorithm.AutoSize = true;
            this.label_efficiency_algorithm.Location = new System.Drawing.Point(1091, 7);
            this.label_efficiency_algorithm.Name = "label_efficiency_algorithm";
            this.label_efficiency_algorithm.Size = new System.Drawing.Size(20, 13);
            this.label_efficiency_algorithm.TabIndex = 21;
            this.label_efficiency_algorithm.Text = "E=";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File,
            this.ToolStripMenuItem_Graph,
            this.ToolStripMenuItem_Generate});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1152, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_File
            // 
            this.ToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокМоделированияToolStripMenuItem,
            this.ToolStripMenuItem_Settings,
            this.справкаToolStripMenuItem,
            this.загрузитьНастройкиToolStripMenuItem});
            this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
            this.ToolStripMenuItem_File.Size = new System.Drawing.Size(48, 20);
            this.ToolStripMenuItem_File.Text = "Файл";
            // 
            // списокМоделированияToolStripMenuItem
            // 
            this.списокМоделированияToolStripMenuItem.Name = "списокМоделированияToolStripMenuItem";
            this.списокМоделированияToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.списокМоделированияToolStripMenuItem.Text = "Список моделирования";
            this.списокМоделированияToolStripMenuItem.Click += new System.EventHandler(this.списокМоделированияToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Settings
            // 
            this.ToolStripMenuItem_Settings.Name = "ToolStripMenuItem_Settings";
            this.ToolStripMenuItem_Settings.Size = new System.Drawing.Size(206, 22);
            this.ToolStripMenuItem_Settings.Text = "Настройки";
            this.ToolStripMenuItem_Settings.Click += new System.EventHandler(this.ToolStripMenuItem_Settings_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.справкаToolStripMenuItem.Text = "Справка";
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // загрузитьНастройкиToolStripMenuItem
            // 
            this.загрузитьНастройкиToolStripMenuItem.Name = "загрузитьНастройкиToolStripMenuItem";
            this.загрузитьНастройкиToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.загрузитьНастройкиToolStripMenuItem.Text = "Загрузить настройки";
            this.загрузитьНастройкиToolStripMenuItem.Click += new System.EventHandler(this.загрузитьНастройкиToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Graph
            // 
            this.ToolStripMenuItem_Graph.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Draw_graph,
            this.алгоритмыМаршрутизацииToolStripMenuItem,
            this.ToolStripMenuItem_All_routers,
            this.ToolStripMenuItem_Save_grapg_image,
            this.нарисоватьМаршрутToolStripMenuItem,
            this.загрузитьИзФайлаToolStripMenuItem});
            this.ToolStripMenuItem_Graph.Name = "ToolStripMenuItem_Graph";
            this.ToolStripMenuItem_Graph.Size = new System.Drawing.Size(47, 20);
            this.ToolStripMenuItem_Graph.Text = "Граф";
            // 
            // ToolStripMenuItem_Draw_graph
            // 
            this.ToolStripMenuItem_Draw_graph.Name = "ToolStripMenuItem_Draw_graph";
            this.ToolStripMenuItem_Draw_graph.Size = new System.Drawing.Size(271, 22);
            this.ToolStripMenuItem_Draw_graph.Text = "Создать топологию";
            this.ToolStripMenuItem_Draw_graph.Click += new System.EventHandler(this.ToolStripMenuItem_Draw_graph_Click);
            // 
            // алгоритмыМаршрутизацииToolStripMenuItem
            // 
            this.алгоритмыМаршрутизацииToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_routing_deikstra,
            this.ToolStripMenuItem_routing_simple,
            this.ToolStripMenuItem_routing_rou,
            this.ToolStripMenuItem_routing_apm,
            this.ToolStripMenuItem_routing_apo,
            this.настроитьToolStripMenuItem,
            this.ToolStripMenuItem1_routing_settings});
            this.алгоритмыМаршрутизацииToolStripMenuItem.Name = "алгоритмыМаршрутизацииToolStripMenuItem";
            this.алгоритмыМаршрутизацииToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.алгоритмыМаршрутизацииToolStripMenuItem.Text = "Алгоритмы маршрутизации";
            // 
            // ToolStripMenuItem_routing_deikstra
            // 
            this.ToolStripMenuItem_routing_deikstra.Checked = true;
            this.ToolStripMenuItem_routing_deikstra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToolStripMenuItem_routing_deikstra.Name = "ToolStripMenuItem_routing_deikstra";
            this.ToolStripMenuItem_routing_deikstra.Size = new System.Drawing.Size(303, 22);
            this.ToolStripMenuItem_routing_deikstra.Text = "Алгоритм дейкстры";
            // 
            // ToolStripMenuItem_routing_simple
            // 
            this.ToolStripMenuItem_routing_simple.CheckOnClick = true;
            this.ToolStripMenuItem_routing_simple.Name = "ToolStripMenuItem_routing_simple";
            this.ToolStripMenuItem_routing_simple.Size = new System.Drawing.Size(303, 22);
            this.ToolStripMenuItem_routing_simple.Text = "Простой алгоритм (Simple)";
            this.ToolStripMenuItem_routing_simple.CheckStateChanged += new System.EventHandler(this.ToolStripMenuItem_routing_simple_CheckStateChanged);
            // 
            // ToolStripMenuItem_routing_rou
            // 
            this.ToolStripMenuItem_routing_rou.CheckOnClick = true;
            this.ToolStripMenuItem_routing_rou.Name = "ToolStripMenuItem_routing_rou";
            this.ToolStripMenuItem_routing_rou.Size = new System.Drawing.Size(303, 22);
            this.ToolStripMenuItem_routing_rou.Text = "Адаптивны алгоритм (ROU)";
            this.ToolStripMenuItem_routing_rou.CheckStateChanged += new System.EventHandler(this.ToolStripMenuItem_routing_rou_CheckStateChanged);
            // 
            // ToolStripMenuItem_routing_apm
            // 
            this.ToolStripMenuItem_routing_apm.CheckOnClick = true;
            this.ToolStripMenuItem_routing_apm.Name = "ToolStripMenuItem_routing_apm";
            this.ToolStripMenuItem_routing_apm.Size = new System.Drawing.Size(303, 22);
            this.ToolStripMenuItem_routing_apm.Text = "Алгоритм парной маршрутизации (APM)";
            this.ToolStripMenuItem_routing_apm.CheckStateChanged += new System.EventHandler(this.ToolStripMenuItem_routing_apm_CheckStateChanged);
            // 
            // ToolStripMenuItem_routing_apo
            // 
            this.ToolStripMenuItem_routing_apo.CheckOnClick = true;
            this.ToolStripMenuItem_routing_apo.Name = "ToolStripMenuItem_routing_apo";
            this.ToolStripMenuItem_routing_apo.Size = new System.Drawing.Size(303, 22);
            this.ToolStripMenuItem_routing_apo.Text = "Алгоритм парного обмена (APO)";
            this.ToolStripMenuItem_routing_apo.CheckStateChanged += new System.EventHandler(this.ToolStripMenuItem_routing_apo_CheckStateChanged);
            // 
            // настроитьToolStripMenuItem
            // 
            this.настроитьToolStripMenuItem.Name = "настроитьToolStripMenuItem";
            this.настроитьToolStripMenuItem.Size = new System.Drawing.Size(300, 6);
            // 
            // ToolStripMenuItem1_routing_settings
            // 
            this.ToolStripMenuItem1_routing_settings.Name = "ToolStripMenuItem1_routing_settings";
            this.ToolStripMenuItem1_routing_settings.Size = new System.Drawing.Size(303, 22);
            this.ToolStripMenuItem1_routing_settings.Text = "Настроить";
            this.ToolStripMenuItem1_routing_settings.Click += new System.EventHandler(this.ToolStripMenuItem1_routing_settings_Click);
            // 
            // ToolStripMenuItem_All_routers
            // 
            this.ToolStripMenuItem_All_routers.Name = "ToolStripMenuItem_All_routers";
            this.ToolStripMenuItem_All_routers.Size = new System.Drawing.Size(271, 22);
            this.ToolStripMenuItem_All_routers.Text = "Сгенерировать все маршруты";
            this.ToolStripMenuItem_All_routers.Click += new System.EventHandler(this.ToolStripMenuItem_All_routers_Click);
            // 
            // ToolStripMenuItem_Save_grapg_image
            // 
            this.ToolStripMenuItem_Save_grapg_image.Name = "ToolStripMenuItem_Save_grapg_image";
            this.ToolStripMenuItem_Save_grapg_image.Size = new System.Drawing.Size(271, 22);
            this.ToolStripMenuItem_Save_grapg_image.Text = "Сохранить изображение топологии";
            this.ToolStripMenuItem_Save_grapg_image.Click += new System.EventHandler(this.ToolStripMenuItem_Save_grapg_image_Click);
            // 
            // нарисоватьМаршрутToolStripMenuItem
            // 
            this.нарисоватьМаршрутToolStripMenuItem.Name = "нарисоватьМаршрутToolStripMenuItem";
            this.нарисоватьМаршрутToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.нарисоватьМаршрутToolStripMenuItem.Text = "Нарисовать маршрут";
            this.нарисоватьМаршрутToolStripMenuItem.Visible = false;
            this.нарисоватьМаршрутToolStripMenuItem.Click += new System.EventHandler(this.нарисоватьМаршрутToolStripMenuItem_Click);
            // 
            // загрузитьИзФайлаToolStripMenuItem
            // 
            this.загрузитьИзФайлаToolStripMenuItem.Name = "загрузитьИзФайлаToolStripMenuItem";
            this.загрузитьИзФайлаToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.загрузитьИзФайлаToolStripMenuItem.Text = "Загрузить из файла";
            this.загрузитьИзФайлаToolStripMenuItem.Click += new System.EventHandler(this.загрузитьИзФайлаToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Generate
            // 
            this.ToolStripMenuItem_Generate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Table_routing_generating,
            this.ToolStripMenuItem_StepCircle_routing_generating,
            this.ToolStripMenuItem_Adaptive_routing_generating,
            this.ToolStripMenuItem_pair_routing_generating});
            this.ToolStripMenuItem_Generate.Name = "ToolStripMenuItem_Generate";
            this.ToolStripMenuItem_Generate.Size = new System.Drawing.Size(102, 20);
            this.ToolStripMenuItem_Generate.Text = "Сгенерировать";
            // 
            // ToolStripMenuItem_Table_routing_generating
            // 
            this.ToolStripMenuItem_Table_routing_generating.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Genetare_route_map,
            this.ToolStripMenuItem_Generate_memory_files,
            this.ToolStripMenuItem_Generate_load_memory_block,
            this.ToolStripMenuItem_Generate_net_connection_file,
            this.ToolStripMenuItem_Generate_dop_part_module,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_Genetare_all_files});
            this.ToolStripMenuItem_Table_routing_generating.Name = "ToolStripMenuItem_Table_routing_generating";
            this.ToolStripMenuItem_Table_routing_generating.Size = new System.Drawing.Size(266, 22);
            this.ToolStripMenuItem_Table_routing_generating.Text = "Табличная маршрутизация";
            // 
            // ToolStripMenuItem_Genetare_route_map
            // 
            this.ToolStripMenuItem_Genetare_route_map.Name = "ToolStripMenuItem_Genetare_route_map";
            this.ToolStripMenuItem_Genetare_route_map.Size = new System.Drawing.Size(284, 22);
            this.ToolStripMenuItem_Genetare_route_map.Text = "Таблица маршрутов";
            this.ToolStripMenuItem_Genetare_route_map.Click += new System.EventHandler(this.ToolStripMenuItem_Genetare_route_map_Click);
            // 
            // ToolStripMenuItem_Generate_memory_files
            // 
            this.ToolStripMenuItem_Generate_memory_files.Name = "ToolStripMenuItem_Generate_memory_files";
            this.ToolStripMenuItem_Generate_memory_files.Size = new System.Drawing.Size(284, 22);
            this.ToolStripMenuItem_Generate_memory_files.Text = "Файлы памяти";
            this.ToolStripMenuItem_Generate_memory_files.Click += new System.EventHandler(this.ToolStripMenuItem_Generate_memory_files_Click);
            // 
            // ToolStripMenuItem_Generate_load_memory_block
            // 
            this.ToolStripMenuItem_Generate_load_memory_block.Name = "ToolStripMenuItem_Generate_load_memory_block";
            this.ToolStripMenuItem_Generate_load_memory_block.Size = new System.Drawing.Size(284, 22);
            this.ToolStripMenuItem_Generate_load_memory_block.Text = "Блок загрузки памяти для роутера";
            this.ToolStripMenuItem_Generate_load_memory_block.Click += new System.EventHandler(this.ToolStripMenuItem_Generate_load_memory_block_Click);
            // 
            // ToolStripMenuItem_Generate_net_connection_file
            // 
            this.ToolStripMenuItem_Generate_net_connection_file.Name = "ToolStripMenuItem_Generate_net_connection_file";
            this.ToolStripMenuItem_Generate_net_connection_file.Size = new System.Drawing.Size(284, 22);
            this.ToolStripMenuItem_Generate_net_connection_file.Text = "Файл описания сети";
            this.ToolStripMenuItem_Generate_net_connection_file.Click += new System.EventHandler(this.ToolStripMenuItem_Generate_net_connection_file_Click);
            // 
            // ToolStripMenuItem_Generate_dop_part_module
            // 
            this.ToolStripMenuItem_Generate_dop_part_module.Name = "ToolStripMenuItem_Generate_dop_part_module";
            this.ToolStripMenuItem_Generate_dop_part_module.Size = new System.Drawing.Size(284, 22);
            this.ToolStripMenuItem_Generate_dop_part_module.Text = "Дополнительные данныедля модулей";
            this.ToolStripMenuItem_Generate_dop_part_module.Click += new System.EventHandler(this.ToolStripMenuItem_Generate_dop_part_module_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(281, 6);
            // 
            // ToolStripMenuItem_Genetare_all_files
            // 
            this.ToolStripMenuItem_Genetare_all_files.Name = "ToolStripMenuItem_Genetare_all_files";
            this.ToolStripMenuItem_Genetare_all_files.Size = new System.Drawing.Size(284, 22);
            this.ToolStripMenuItem_Genetare_all_files.Text = "Сгенерировать все файлы";
            this.ToolStripMenuItem_Genetare_all_files.Click += new System.EventHandler(this.ToolStripMenuItem_Genetare_all_files_Click);
            // 
            // ToolStripMenuItem_StepCircle_routing_generating
            // 
            this.ToolStripMenuItem_StepCircle_routing_generating.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Generate_simple_net_connection_file});
            this.ToolStripMenuItem_StepCircle_routing_generating.Name = "ToolStripMenuItem_StepCircle_routing_generating";
            this.ToolStripMenuItem_StepCircle_routing_generating.Size = new System.Drawing.Size(266, 22);
            this.ToolStripMenuItem_StepCircle_routing_generating.Text = "Почасовой обход";
            // 
            // ToolStripMenuItem_Generate_simple_net_connection_file
            // 
            this.ToolStripMenuItem_Generate_simple_net_connection_file.Name = "ToolStripMenuItem_Generate_simple_net_connection_file";
            this.ToolStripMenuItem_Generate_simple_net_connection_file.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItem_Generate_simple_net_connection_file.Text = "Файл описания сети";
            this.ToolStripMenuItem_Generate_simple_net_connection_file.Click += new System.EventHandler(this.ToolStripMenuItem_Generate_simple_net_connection_file_Click);
            // 
            // ToolStripMenuItem_Adaptive_routing_generating
            // 
            this.ToolStripMenuItem_Adaptive_routing_generating.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemm_Generate_adaptive_net_connection_file});
            this.ToolStripMenuItem_Adaptive_routing_generating.Name = "ToolStripMenuItem_Adaptive_routing_generating";
            this.ToolStripMenuItem_Adaptive_routing_generating.Size = new System.Drawing.Size(266, 22);
            this.ToolStripMenuItem_Adaptive_routing_generating.Text = "Адаптивный алгоритм";
            // 
            // ToolStripMenuItemm_Generate_adaptive_net_connection_file
            // 
            this.ToolStripMenuItemm_Generate_adaptive_net_connection_file.Name = "ToolStripMenuItemm_Generate_adaptive_net_connection_file";
            this.ToolStripMenuItemm_Generate_adaptive_net_connection_file.Size = new System.Drawing.Size(186, 22);
            this.ToolStripMenuItemm_Generate_adaptive_net_connection_file.Text = "Файл описания сети";
            this.ToolStripMenuItemm_Generate_adaptive_net_connection_file.Click += new System.EventHandler(this.ToolStripMenuItemm_Generate_adaptive_net_connection_file_Click);
            // 
            // ToolStripMenuItem_pair_routing_generating
            // 
            this.ToolStripMenuItem_pair_routing_generating.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemm_Generate_pair_net_connection_file,
            this.ToolStripMenuItemm_Generate_pair_select_data_file});
            this.ToolStripMenuItem_pair_routing_generating.Name = "ToolStripMenuItem_pair_routing_generating";
            this.ToolStripMenuItem_pair_routing_generating.Size = new System.Drawing.Size(266, 22);
            this.ToolStripMenuItem_pair_routing_generating.Text = "Алгоритм парной маршрутизации";
            // 
            // ToolStripMenuItemm_Generate_pair_net_connection_file
            // 
            this.ToolStripMenuItemm_Generate_pair_net_connection_file.Name = "ToolStripMenuItemm_Generate_pair_net_connection_file";
            this.ToolStripMenuItemm_Generate_pair_net_connection_file.Size = new System.Drawing.Size(205, 22);
            this.ToolStripMenuItemm_Generate_pair_net_connection_file.Text = "Файл описания сети";
            this.ToolStripMenuItemm_Generate_pair_net_connection_file.Click += new System.EventHandler(this.ToolStripMenuItemm_Generate_pair_net_connection_file_Click);
            // 
            // ToolStripMenuItemm_Generate_pair_select_data_file
            // 
            this.ToolStripMenuItemm_Generate_pair_select_data_file.Name = "ToolStripMenuItemm_Generate_pair_select_data_file";
            this.ToolStripMenuItemm_Generate_pair_select_data_file.Size = new System.Drawing.Size(205, 22);
            this.ToolStripMenuItemm_Generate_pair_select_data_file.Text = "Модуль выбора данных";
            this.ToolStripMenuItemm_Generate_pair_select_data_file.Click += new System.EventHandler(this.ToolStripMenuItemm_Generate_pair_select_data_file_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(495, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(206, 20);
            this.textBox1.TabIndex = 24;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(707, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Отрисовать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Собственный маршрут";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 487);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_efficiency_algorithm);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label_diam_graph);
            this.Controls.Add(this.textBox_topology_signature);
            this.Controls.Add(this.label_node_count);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.Text = "Визуализация циркулянтных топологий";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_node_count;
        private System.Windows.Forms.TextBox textBox_topology_signature;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ListView listView_ROU;
        private System.Windows.Forms.ColumnHeader column_destination;
        private System.Windows.Forms.ColumnHeader column_route;
        private System.Windows.Forms.ColumnHeader column_l;
        private System.Windows.Forms.Label label_diam_graph;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView listView_Deikstra;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label_efficiency_algorithm;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView listView_Simple;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Generate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Table_routing_generating;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Generate_memory_files;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Generate_load_memory_block;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_StepCircle_routing_generating;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Adaptive_routing_generating;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Generate_net_connection_file;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Generate_dop_part_module;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Graph;
        private System.Windows.Forms.ToolStripMenuItem нарисоватьМаршрутToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Save_grapg_image;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Generate_simple_net_connection_file;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemm_Generate_adaptive_net_connection_file;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_All_routers;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Draw_graph;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Genetare_route_map;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Genetare_all_files;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ListView listView_APM;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_pair_routing_generating;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemm_Generate_pair_net_connection_file;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemm_Generate_pair_select_data_file;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ListView listView_APO;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem списокМоделированияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Settings;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьИзФайлаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьНастройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритмыМаршрутизацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_routing_deikstra;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_routing_simple;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_routing_rou;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_routing_apm;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_routing_apo;
        private System.Windows.Forms.ToolStripSeparator настроитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1_routing_settings;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

