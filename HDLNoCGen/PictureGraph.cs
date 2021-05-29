using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace HDL_NoC_CodeGen
{
    class PictureGraph
    {
        private Settings settings;

        public Size bmp_size;
        private Bitmap bmp;                 // поле для отрисовки
        private bool is_draw;               // была ли отрисовка рисунка

        private Color back_color_graph;     // фон поля для отрисовки
        private bool black_graph_color;     // черно-белая отрисовка графа
        private bool alternative_draw_graph;// отрисовка образующих эллипсом
        private List<Color> colors;         // список цветов для отрисовки образующих
        private int pen_node_width;         // ширина линий для рисования узлов и образующих
        private Pen pen_node;               // перо для рисования узлов графа
        private Pen pen_graph;              // перо для рисования образующих графа
        private int vertex_size;            // размер узла

        private int route_width;            // щирина линии, которой отрисовывается маршрут

        private Pen pen_route;              // перо для рисования маршрута

        private SolidBrush brush;           // кисть для отсования подписей узлов
        private Font font;                  // шрифт для рисования подписей узлов
        private int string_offset;          // смещение подписи узлв от центра узла
        private bool node_naming;           // указывает нужно ли подписывать узлы
        private int node_naming_start_index;// начало нумерации узлов
        private int node_naming_interval;

        public PictureGraph() 
        {
            settings = Settings.GetInstance();

            this.is_draw = false;

            this.black_graph_color = settings.Get_black_graph_color();
            this.alternative_draw_graph = settings.Get_alternative_draw_graph();

            this.back_color_graph = Color.FromArgb(settings.Get_back_color_graph());
            this.black_graph_color = settings.Get_black_graph_color();
            this.alternative_draw_graph = settings.Get_alternative_draw_graph();
            this.colors = new List<Color> // перевести в настройки
            {
                Color.Black,
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Pink,
                Color.Yellow
            };
            this.pen_node_width = this.settings.Get_pen_node_width();
            this.pen_node = new Pen(Color.FromArgb(settings.Get_pen_node_color()));
            this.pen_node.Width = this.pen_node_width;
            this.pen_graph = new Pen(Color.FromArgb(settings.Get_pen_node_color()));
            this.pen_graph.Width = this.pen_node_width;
            this.vertex_size = this.settings.Get_vertex_size();

            this.pen_route = new Pen(Color.FromArgb(settings.Get_route_color()));
            this.route_width = settings.Get_route_width();
            this.pen_route.Width = this.route_width;

            this.brush = new SolidBrush(Color.FromArgb(settings.Get_node_naming_brush_color()));
            this.font = new Font(settings.Get_node_naming_font_name(), settings.Get_node_naming_font_size());
            this.string_offset = settings.Get_node_naming_string_offset();
            this.node_naming_interval = settings.Get_node_naming_interval();
            this.node_naming = this.settings.Get_node_naming();
            this.node_naming_start_index = this.settings.Get_node_naming_start_index();
        }

        public void Set_bmp_size(Size bmp_size)
        {
            this.bmp_size = bmp_size;
        }

        public void Update_Draw_settings()
        {
            settings = Settings.LoadSettings();

            this.black_graph_color = settings.Get_black_graph_color();
            this.alternative_draw_graph = settings.Get_alternative_draw_graph();

            this.back_color_graph = Color.FromArgb(settings.Get_back_color_graph());
            this.black_graph_color = settings.Get_black_graph_color();
            this.alternative_draw_graph = settings.Get_alternative_draw_graph();
            this.colors = new List<Color> // перевести в настройки
            {
                Color.Black,
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Pink,
                Color.Yellow
            };
            this.pen_node_width = this.settings.Get_pen_node_width();
            this.pen_node = new Pen(Color.FromArgb(settings.Get_pen_node_color()));
            this.pen_node.Width = this.pen_node_width;
            this.pen_graph = new Pen(Color.FromArgb(settings.Get_pen_node_color()));
            this.pen_graph.Width = this.pen_node_width;
            this.vertex_size = this.settings.Get_vertex_size();

            this.pen_route = new Pen(Color.FromArgb(settings.Get_route_color()));
            this.route_width = settings.Get_route_width();
            this.pen_route.Width = this.route_width;

            this.brush = new SolidBrush(Color.FromArgb(settings.Get_node_naming_brush_color()));
            this.font = new Font(settings.Get_node_naming_font_name(), settings.Get_node_naming_font_size());
            this.string_offset = settings.Get_node_naming_string_offset();
            this.node_naming_interval = settings.Get_node_naming_interval();
            this.node_naming = this.settings.Get_node_naming();
            this.node_naming_start_index = this.settings.Get_node_naming_start_index();
        }

        public bool Is_Draw()
        {
            return this.is_draw;
        }
        /*
        public Bitmap Get_bmp()
        {
            return this.bmp;
        }
        */
        private int Calculate_Diametr() 
        {
            return Math.Min(this.bmp_size.Height, this.bmp_size.Width) - 300;
        }

        private Point Calculate_Center_Graph() 
        {
            return new Point(this.bmp_size.Width / 2, this.bmp_size.Height / 2);
        }

        private List<Point> Calculate_Node_Points(int node_count, int draw_diametr, Point draw_center) 
        {
            double curr_angel;
            double x;
            double y;
            List<Point> node_points = new List<Point>();

            for (int i = 0; i < node_count; i++)
            {
                curr_angel = 180 - 360 / (double)node_count * i;
                x = draw_center.X + draw_diametr / 2 * Math.Sin(Math.PI * curr_angel / 180);
                y = draw_center.Y + draw_diametr / 2 * Math.Cos(Math.PI * curr_angel / 180);
                node_points.Add(new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
            }

            return node_points;
        }

        private List<Point> Calculate_Node_Name_Points(int node_count, int draw_diametr, Point draw_center) 
        {
            double curr_angel;
            double x;
            double y;
            List<Point> string_points = new List<Point>();

            for (int i = 0; i < node_count; i++)
            {
                curr_angel = 180 - 360 / (double)node_count * i;
                x = draw_center.X + (draw_diametr / 2 + this.string_offset) * Math.Sin(Math.PI * curr_angel / 180);
                y = draw_center.Y + (draw_diametr / 2 + this.string_offset) * Math.Cos(Math.PI * curr_angel / 180);
                string_points.Add(new Point(Convert.ToInt32(x), Convert.ToInt32(y)));
            }

            return string_points;
        }

        public Bitmap Draw_Graph(int node_count, List<int> generators) 
        {
            int error = 0;
            this.bmp = new Bitmap(bmp_size.Width, bmp_size.Height);
            this.bmp.SetResolution(500, 500);
            Graphics graph = Graphics.FromImage(this.bmp);
            graph.Clear(this.back_color_graph);

            Point draw_center = Calculate_Center_Graph();
            int draw_diametr = Calculate_Diametr();
            List<Point> node_points = Calculate_Node_Points(node_count, draw_diametr, draw_center);
            List<Point> string_points = Calculate_Node_Name_Points(node_count, draw_diametr, draw_center);
            if (this.node_naming)
            {
                Calculate_Node_Name_Points(node_count, draw_diametr, draw_center);
            }

            // для проверки центрирования отрисовки
            //this.graph.DrawEllipse(this.pen_node, new Rectangle(this.draw_center.X - 15, this.draw_center.Y - 15, 30, 30));
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
            for (int i = 0; i < node_count; i++)
            {
                // первые два числа - координаты угла описанного квадрата, вторые два числа - его размеры
                graph.DrawEllipse(this.pen_node, new Rectangle(node_points[i].X - this.vertex_size / 2, node_points[i].Y - this.vertex_size / 2, this.vertex_size, this.vertex_size));
                // для проверки расположения подписей ущлов
                //this.graph.DrawRectangle(this.pen_node, new Rectangle(this.string_points[i].X - 60, this.string_points[i].Y - 60, 120, 120));
                // смещение в координате Y на 4 нужно для точного позиционирования относительно узла
                if (this.node_naming)
                {
                    if (i % node_naming_interval == 0 || i == (node_count-1))
                    {
                        graph.DrawString((i + this.node_naming_start_index).ToString(), this.font, this.brush, new Rectangle(string_points[i].X - 60, string_points[i].Y - 60 + 4, 120, 120), sf);
                    }
                }
            }

            for (int i = 0; i < generators.Count; i++)
            {
                try
                {
                    if (this.black_graph_color)
                    {
                        pen_graph.Color = Color.Black;
                    }
                    else
                    {
                        pen_graph.Color = colors[i];
                    }
                    
                }
                catch
                {
                    error++;
                }
                for (int j = 0; j < node_count; j++)
                {

                    // рисование простых линий
                    if (this.alternative_draw_graph)
                    {
                        if (i == 0) //если постаить условие i < 10   то все будет рисоваться прямыми линиями. сейчас прямой линией рисуется только первая образующая
                        {
                            graph.DrawLine(this.pen_graph, node_points[j % node_count], node_points[(j + generators[i]) % node_count]);
                        }
                        else
                        {
                            // рисование по окружностям
                            Point middle_point = new Point();
                            Point mp = new Point();
                            double buffer1 = node_points[(j + generators[i]) % node_count].Y - node_points[j % node_count].Y;
                            double buffer2 = node_points[(j + generators[i]) % node_count].X - node_points[j % node_count].X;
                            double data2 = buffer1 / buffer2;
                            double angel_m_p = Math.Atan(data2);
                            mp.X = Math.Min(node_points[j % node_count].X, node_points[(j + generators[i]) % node_count].X) + Math.Abs((node_points[(j + generators[i]) % node_count].X - node_points[j % node_count].X) / 2);
                            mp.Y = Math.Min(node_points[j % node_count].Y, node_points[(j + generators[i]) % node_count].Y) + Math.Abs((node_points[(j + generators[i]) % node_count].Y - node_points[j % node_count].Y) / 2);

                            int sign_param = 1;
                            if (i % 2 == 1)
                            {
                                sign_param = -1;
                            }
                            if (node_points[j % node_count].X > node_points[(j + generators[i]) % node_count].X)
                            {
                                middle_point.X = Convert.ToInt32(mp.X + (100 * 1) * Math.Cos(1.57 * sign_param + angel_m_p));
                                middle_point.Y = Convert.ToInt32(mp.Y + (100 * 1) * Math.Sin(1.57 * sign_param + angel_m_p));
                            }
                            else
                            {
                                middle_point.X = Convert.ToInt32(mp.X + (100 * 1) * Math.Cos(-1.57 * sign_param + angel_m_p));
                                middle_point.Y = Convert.ToInt32(mp.Y + (100 * 1) * Math.Sin(-1.57 * sign_param + angel_m_p));
                            }


                            //для теста расположения точек
                            //this.graph.DrawEllipse(this.pen_node, new Rectangle(mp.X - this.vertex_size / 2, mp.Y - this.vertex_size / 2, this.vertex_size, this.vertex_size));
                            //this.graph.DrawEllipse(this.pen_node, new Rectangle(middle_point.X - this.vertex_size / 2, middle_point.Y - this.vertex_size / 2, this.vertex_size, this.vertex_size));

                            graph.DrawCurve(this.pen_graph, new Point[] { node_points[j % node_count], middle_point, node_points[(j + generators[i]) % node_count] });
                        }
                    }
                    else
                    {
                        graph.DrawLine(this.pen_graph, node_points[j % node_count], node_points[(j + generators[i]) % node_count]);
                    }
                }   
            }

            if (error > 0)
            {
                System.Windows.Forms.MessageBox.Show("Несколько образующих (" + error + ") были нарисованы одним цветом", "Проблемы отрисовки", System.Windows.Forms.MessageBoxButtons.OK);
            }

            this.is_draw = true;
            graph.Dispose();
            return bmp;
        }

        public Bitmap Draw_Route(string route, int node_count, List<int> generators) 
        {
            Graphics graph = Graphics.FromImage(this.bmp);
            Point draw_center = Calculate_Center_Graph();
            int draw_diametr = Calculate_Diametr();
            List<Point> node_points = Calculate_Node_Points(node_count, draw_diametr, draw_center);
            string[] buffer = route.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < buffer.Length - 1; i++)
            {
                int node_index_1 = Convert.ToInt32(buffer[i]) - settings.Get_node_naming_start_index();
                int node_index_2 = Convert.ToInt32(buffer[i + 1]) - settings.Get_node_naming_start_index();


                if (this.alternative_draw_graph)
                {

                    if (Math.Abs(node_index_2 - node_index_1) == generators[0])
                    {
                        graph.DrawLine(this.pen_route, node_points[node_index_1], node_points[node_index_2]);
                    }
                    else if (Math.Abs(node_index_2 - node_index_1) == generators[1])
                    {
                        Point middle_point = new Point();
                        Point mp = new Point();
                        double buffer1 = node_points[node_index_2].Y - node_points[node_index_1].Y;
                        double buffer2 = node_points[node_index_2].X - node_points[node_index_1].X;
                        double data2 = buffer1 / buffer2;
                        double angel_m_p = Math.Atan(data2);
                        mp.X = Math.Min(node_points[node_index_1].X, node_points[node_index_2].X) + Math.Abs((node_points[node_index_2].X - node_points[node_index_1].X) / 2);
                        mp.Y = Math.Min(node_points[node_index_1].Y, node_points[node_index_2].Y) + Math.Abs((node_points[node_index_2].Y - node_points[node_index_1].Y) / 2);

                        bool type = true;
                        if ((node_index_2 - node_index_1 > 0) && (node_points[node_index_1].X > node_points[node_index_2].X))
                        {
                            type = true;
                        }
                        else if ((node_index_2 - node_index_1 < 0) && (node_points[node_index_1].X > node_points[node_index_2].X))
                        {
                            type = false;
                        }
                        else if ((node_index_2 - node_index_1 > 0) && (node_points[node_index_1].X < node_points[node_index_2].X))
                        {
                            type = false;
                        }
                        else if ((node_index_2 - node_index_1 < 0) && (node_points[node_index_1].X < node_points[node_index_2].X))
                        {
                            type = true;
                        }


                        if (type)
                        {
                            middle_point.X = Convert.ToInt32(mp.X + (100 * 1) * Math.Cos(1.57 * (-1) + angel_m_p));
                            middle_point.Y = Convert.ToInt32(mp.Y + (100 * 1) * Math.Sin(1.57 * (-1) + angel_m_p));
                        }
                        else
                        {
                            middle_point.X = Convert.ToInt32(mp.X + (100 * 1) * Math.Cos(-1.57 * (-1) + angel_m_p));
                            middle_point.Y = Convert.ToInt32(mp.Y + (100 * 1) * Math.Sin(-1.57 * (-1) + angel_m_p));
                        }

                        graph.DrawCurve(this.pen_route, new Point[] { node_points[node_index_1], middle_point, node_points[node_index_2] });
                    }
                    else if (Math.Abs(node_index_2 - node_index_1) == generators[2])
                    {
                        Point middle_point = new Point();
                        Point mp = new Point();
                        double buffer1 = node_points[node_index_2].Y - node_points[node_index_1].Y;
                        double buffer2 = node_points[node_index_2].X - node_points[node_index_1].X;
                        double data2 = buffer1 / buffer2;
                        double angel_m_p = Math.Atan(data2);
                        mp.X = Math.Min(node_points[node_index_1].X, node_points[node_index_2].X) + Math.Abs((node_points[node_index_2].X - node_points[node_index_1].X) / 2);
                        mp.Y = Math.Min(node_points[node_index_1].Y, node_points[node_index_2].Y) + Math.Abs((node_points[node_index_2].Y - node_points[node_index_1].Y) / 2);

                        bool type = true;
                        if ((node_index_2 - node_index_1 > 0) && (node_points[node_index_1].X > node_points[node_index_2].X))
                        {
                            type = true;
                        }
                        else if ((node_index_2 - node_index_1 < 0) && (node_points[node_index_1].X > node_points[node_index_2].X))
                        {
                            type = false;
                        }
                        else if ((node_index_2 - node_index_1 > 0) && (node_points[node_index_1].X < node_points[node_index_2].X))
                        {
                            type = false;
                        }
                        else if ((node_index_2 - node_index_1 < 0) && (node_points[node_index_1].X < node_points[node_index_2].X))
                        {
                            type = true;
                        }



                        if (type)
                        {
                            middle_point.X = Convert.ToInt32(mp.X + (100 * 1) * Math.Cos(1.57 + angel_m_p));
                            middle_point.Y = Convert.ToInt32(mp.Y + (100 * 1) * Math.Sin(1.57 + angel_m_p));
                        }
                        else
                        {
                            middle_point.X = Convert.ToInt32(mp.X + (100 * 1) * Math.Cos(-1.57 + angel_m_p));
                            middle_point.Y = Convert.ToInt32(mp.Y + (100 * 1) * Math.Sin(-1.57 + angel_m_p));
                        }

                        graph.DrawCurve(this.pen_route, new Point[] { node_points[node_index_1], middle_point, node_points[node_index_2] });
                    }
                }
                else
                {
                    graph.DrawLine(this.pen_route, node_points[node_index_1], node_points[node_index_2]);
                }

            }
            graph.Dispose();
            return this.bmp;
        }

        public Bitmap Draw_Selected_Node(Size bmp_size, Point mouse_location, int node_count, List<int> generators) 
        {
            Graphics graph = Graphics.FromImage(this.bmp);
            Point draw_center = Calculate_Center_Graph();
            int draw_diametr = Calculate_Diametr();
            List<Point> node_points = Calculate_Node_Points(node_count, draw_diametr, draw_center);
            int node_near_mouse_click = -1;
            for (int i = 0; i < node_points.Count; i++)
            {
                if (mouse_location.X >= node_points[i].X - 10 && mouse_location.X <= node_points[i].X + 10)
                {
                    if (mouse_location.Y >= node_points[i].Y - 10 && mouse_location.Y <= node_points[i].Y + 10)
                    {
                        node_near_mouse_click = i;
                    }
                }
            }

            if (node_near_mouse_click != -1)
            {
                for (int j = 0; j < generators.Count; j++)
                {
                    Pen pen = new Pen(Color.Gold);
                    graph.DrawEllipse(pen, new Rectangle(node_points[node_near_mouse_click].X - 5, node_points[node_near_mouse_click].Y - 5, 10, 10));

                    pen.Color = Color.White;
                    graph.DrawLine(pen, node_points[node_near_mouse_click % node_count], node_points[(node_near_mouse_click + generators[j]) % node_count]);
                    pen.Color = Color.LightGray;
                    graph.DrawLine(pen, node_points[node_near_mouse_click % node_count], node_points[(node_near_mouse_click - generators[j] + node_count) % node_count]);
                }
            }

            graph.Dispose();
            return this.bmp;
        }
    }
}
