using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HDL_NoC_CodeGen
{
    [Serializable]
    class Settings
    {
        private static string settings_file_name = "settings.dat";
        private static Settings _instance;
        [NonSerialized]
        private bool error_XML_load = false;

        private int back_color_graph { get; set; }              // фон, на котором отрисовывается граф
        private bool black_graph_color { get; set; }            // черно-белая отрисовка графа
        private bool alternative_draw_graph { get; set; }       // отрисовка образующих эллипсом
        private int pen_node_color { get; set; }                // цвет, которым рисуются узлы и основная образующая
        private int pen_node_width { get; set; }                // ширина линий, которыми рисуются узлы и образующие
        private int vertex_size { get; set; }                   // размер отрисовки вершин (диаметр окружности)
        private string node_naming_font_name { get; set; }      // название шрифта, которым подписываются узлы
        private int node_naming_font_size { get; set; }         // размер шрифта, которым подписываются узлы
        private int node_naming_brush_color { get; set; }       // цвет шрифта, которым подписываются узлы
        private bool node_naming { get; set; }                  // нумерация узлов графа
        private int node_naming_start_index { get; set; }       // начало нумерации с 0 или с 1 - соответствует записанному числу
        private int node_naming_interval { get; set; }          // интервал нумерации узлов
        private int node_naming_string_offset { get; set; }     // смещение подписи узлв от центра узла

        private int route_color { get; set; }                   // цвет отрисовки маршрута

        private int route_width { get; set; }                  // щирина линии, которой отрисовывается маршрут

        private bool[] checked_routing_algorithms { get; set; } // выбор, какие алгоритмы моделировать
        private int error_iterations_count { get; set; }        // количество шагов маршрута, после которого считать, что алгоритм не может построить
                                                                // в форме настрое этого параметра пока нет 

        // добавить нужные поля и функции для их установки и получения

        private Settings()
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
            this.node_naming_interval = 1;
            this.node_naming_string_offset = 50;
            this.route_color = -10496;
            this.route_width = 5;
            this.checked_routing_algorithms = new bool[] { false, false, false, false };
            this.error_iterations_count = 30;

        }

        public static Settings GetInstance()
        {
            if (_instance == null)
            {
                _instance = Settings.LoadSettings();
            }

            return _instance;
        }

        public static Settings LoadSettings()
        {
            Settings settings = null;
            BinaryFormatter bf = new BinaryFormatter();

            if (File.Exists(settings_file_name))
            {
                using (FileStream fs = new FileStream(settings_file_name, FileMode.Open))
                {
                    try
                    {
                        settings = (Settings)bf.Deserialize(fs);
                        fs.Close();
                    }
                    catch (Exception ex)
                    {
                        settings = new Settings();
                    }
                }
            }
            else
            {
                settings = new Settings();
            }

            return settings;
        }

        public void Save()
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(settings_file_name, FileMode.Create))
            {
                bf.Serialize(fs, this);
                fs.Close();
            }
        }

        public bool Get_load_setttings_status()
        {
            return this.error_XML_load;
        }

        public int Get_back_color_graph()
        {
            return this.back_color_graph;
        }

        public bool Get_black_graph_color()
        {
            return this.black_graph_color;
        }

        public bool Get_alternative_draw_graph()
        {
            return this.alternative_draw_graph;
        }

        public int Get_pen_node_color()
        {
            return this.pen_node_color;
        }

        public int Get_pen_node_width()
        {
            return this.pen_node_width;
        }

        public int Get_vertex_size()
        {
            return this.vertex_size;
        }

        public string Get_node_naming_font_name()
        {
            return this.node_naming_font_name;
        }

        public int Get_node_naming_font_size()
        {
            return this.node_naming_font_size;
        }

        public int Get_node_naming_brush_color()
        {
            return this.node_naming_brush_color;
        }

        public bool Get_node_naming()
        {
            return this.node_naming;
        }

        public int Get_node_naming_start_index()
        {
            return this.node_naming_start_index;
        }

        public int Get_node_naming_string_offset()
        {
            return this.node_naming_string_offset;
        }

        public int Get_node_naming_interval()
        {
            return this.node_naming_interval;
        }

        public int Get_route_color()
        {
            return this.route_color;
        }

        public int Get_route_width()
        {
            return this.route_width;
        }

        public bool Get_checked_routing_algorithms(int index)
        {
            return this.checked_routing_algorithms[index];
        }

        public int Get_error_iterations_count()
        {
            return this.error_iterations_count;
        }

        public void Set_back_color_graph(int color)
        {
            this.back_color_graph = color;
        }

        public void Set_black_graph_color(bool black_graph_color)
        {
            this.black_graph_color = black_graph_color;
        }

        public void Set_alternative_draw_graph(bool alternative_draw_graph)
        {
            this.alternative_draw_graph = alternative_draw_graph;
        }

        public void Set_pen_node_color(int color)
        {
            this.pen_node_color = color;
        }

        public void Set_pen_node_width(int width)
        {
            this.pen_node_width = width;
        }

        public void Set_vertex_size(int size)
        {
            this.vertex_size = size;
        }

        public void Set_node_naming_font_name(string name)
        {
            this.node_naming_font_name = name;
        }

        public void Set_node_naming_font_size(int size)
        {
            this.node_naming_font_size = size;
        }

        public void Set_node_naming_brush_color(int color)
        {
            this.node_naming_brush_color = color;
        }

        public void Set_node_naming(bool naming)
        {
            this.node_naming = naming;
        }

        public void Set_node_naming_start_index(int index)
        {
            this.node_naming_start_index = index;
        }

        public void Set_node_naming_string_offset(int string_offset)
        {
            this.node_naming_string_offset = string_offset;
        }

        public void Set_node_naming_interval(int node_naming_interval)
        {
            this.node_naming_interval = node_naming_interval;
        }

        public void Set_route_color(int route_color)
        {
            this.route_color = route_color;
        }

        public void Set_route_width(int route_width)
        {
            this.route_width = route_width;
        }

        public void Set_checked_routing_algorithms(int index, bool state)
        {
            this.checked_routing_algorithms[index] = state;
        }

        public void Set_error_iterations_count(int iterations_count)
        {
            this.error_iterations_count = iterations_count;
        }

    }
}
