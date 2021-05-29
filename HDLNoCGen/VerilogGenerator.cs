using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDL_NoC_CodeGen
{
    static class VerilogGenerator
    {
        // табличная маршрутизация

        public static void Generate_table_route_map(int node_count, int diameter, List<int> generators, List<List<int>> min_ways_routing_deikstra)
        {
            string FileName;
            string Base_FolderName;
            string graph_name;
            string FilePath;

            FileStream fs;
            StreamWriter sw;

            // файл таблицы маршрутов от одного узла к остальным, который генерирует алгоритм дейкстры
            #region файл таблицы маршрутов от первого узла к остальным

            graph_name = "C(" + node_count.ToString() + "; " + generators[0].ToString() + ", " + generators[1].ToString() + ")";
            Base_FolderName = graph_name + " table routing files";
            Directory.CreateDirectory(Base_FolderName);

            FileName = graph_name + ".txt";
            FilePath = Directory.GetCurrentDirectory() + @"\" + Base_FolderName + @"\" + FileName;

            fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);

            sw.WriteLine("Циркулянт " + graph_name + "    Диаметр = " + diameter);
            sw.WriteLine();

            for (int i = 0; i < min_ways_routing_deikstra.Count; i++)
            {
                string buffer = "";
                List<int> buff_list = new List<int>();
                buff_list = min_ways_routing_deikstra[i];

                for (int j = 0; j < min_ways_routing_deikstra[i].Count; j++)
                {
                    buffer += min_ways_routing_deikstra[i][j].ToString() + "-";
                    buffer.Trim();
                }
                buffer = buffer.Remove(buffer.Length - 1);

                sw.WriteLine(buffer);
            }
            sw.Close();
            fs.Close();
            #endregion
        }

        public static void Generate_table_memory_file(int node_count, List<int> generators, List<List<int>> min_ways_routing_deikstra)
        {
            string FileName;
            string Base_FolderName;
            string FolderName;
            string graph_name;
            string FilePath;

            FileStream fs;
            StreamWriter sw;

            // файлы для инициализации памяти роутеров в quartus
            #region файлы для инициализации памяти роутеров в quartus

            graph_name = "C(" + node_count.ToString() + "; " + generators[0].ToString() + ", " + generators[1].ToString() + ")";
            Base_FolderName = graph_name + " table routing files";
            FolderName = graph_name + " routers table";
            Directory.CreateDirectory(Base_FolderName + @"\" + FolderName);

            string[] data_to_table = new string[node_count];
            int find_generators = 0;
            for (int i = 0; i < min_ways_routing_deikstra.Count; i++)
            {
                if (min_ways_routing_deikstra[i].Count > 1)
                {
                    find_generators = min_ways_routing_deikstra[i][1] - min_ways_routing_deikstra[i][0];
                }
                else
                {
                    data_to_table[i] = "100";
                }

                if (find_generators == generators[0]) // по часовой стрелке по малой образующей
                {
                    data_to_table[i] = "000";
                }
                else if (find_generators == generators[1]) // по часовой стрелке по большой образующей
                {
                    data_to_table[i] = "001";
                }
                else if ((node_count - find_generators) == generators[0]) // против часовой стрелке по малой образующей
                {
                    data_to_table[i] = "011";
                }
                else if ((node_count - find_generators) == generators[1]) // против часовой стрелке по большой образующей
                {
                    data_to_table[i] = "010";
                }
            }

            int router_index = 0;
            for (router_index = 0; router_index < node_count; router_index++)
            {
                FileName = "C_" + node_count.ToString() + "_" + generators[0] + "_" + generators[1] + "_RouterTable" + (router_index + 1).ToString();                                           // должно меняться в зависимости от номера роутера
                FilePath = Directory.GetCurrentDirectory() + @"\" + Base_FolderName + @"\" + FolderName + @"\" + FileName + ".dat";

                fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
                sw = new StreamWriter(fs);

                for (int i = 0; i < node_count; i++)
                {
                    sw.WriteLine(data_to_table[(i + node_count - router_index) % node_count]);
                }

                sw.Close();
                fs.Close();

            }
            #endregion
        }

        public static void Generate_table_load_memory_block_file(int node_count, List<int> generators)
        {
            string FileName;
            string Base_FolderName;
            string graph_name;
            string FilePath;

            FileStream fs;
            StreamWriter sw;

            //файлы описания модуля памяти в quartus  (table_memory_X_nodes)
            #region файл описания модуля памяти в quartus

            graph_name = "C(" + node_count.ToString() + "; " + generators[0].ToString() + ", " + generators[1].ToString() + ")";
            Base_FolderName = graph_name + " table routing files";
            Directory.CreateDirectory(Base_FolderName);

            FileName = "table_memory_" + (node_count).ToString() + "_nodes.v"; // генерация имени файла       table_memory_9_nodes
            FilePath = Directory.GetCurrentDirectory() + @"\" + Base_FolderName + @"\" + FileName;

            fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);          // открытие файла

            sw.WriteLine("module table_memory_" + (node_count).ToString() + "_nodes (");

            for (int i = 0; i < (node_count - 1); i++)
            {
                sw.WriteLine("\toutdatatbl" + (i + 1).ToString() + ",");
            }
            sw.WriteLine("\toutdatatbl" + (node_count).ToString());
            sw.WriteLine(");");
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.WriteLine("\toutput[" + (node_count * 3 - 1).ToString() + ":0] outdatatbl" + (i + 1).ToString() + ";");
            }
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.WriteLine("\treg[2:0] tbl" + (i + 1).ToString() + " [7:0];");
            }
            sw.WriteLine();

            sw.WriteLine("initial begin");
            for (int i = 0; i < node_count; i++)
            {
                sw.WriteLine("\t$readmemb(\"C_" + node_count.ToString() + "_" + generators[0].ToString() + "_" + generators[1].ToString() + "_RouterTable" + (i + 1).ToString() + ".dat\", tbl" + (i + 1).ToString() + ");");
            }
            sw.WriteLine("end");
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                string datad = "";

                for (int j = 0; j < (node_count - 1); j++)
                {
                    datad = datad + "tbl" + (i + 1).ToString() + "[" + j.ToString() + "], ";
                }
                datad = datad + "tbl" + (i + 1).ToString() + "[" + (node_count - 1).ToString() + "]";

                sw.WriteLine("\tassign outdatatbl" + (i + 1).ToString() + " = {" + datad + "};");
            }
            sw.WriteLine();
            sw.WriteLine("endmodule");
            sw.WriteLine();

            sw.Close();
            fs.Close();
            #endregion
        }

        public static void Generate_table_net_connection_file(int node_count, List<int> generators)
        {
            string FileName;
            string Base_FolderName;
            string graph_name;
            string FilePath;

            FileStream fs;
            StreamWriter sw;

            #region
            //toplevel_table_9_nodes

            graph_name = "C(" + node_count.ToString() + "; " + generators[0].ToString() + ", " + generators[1].ToString() + ")";
            Base_FolderName = graph_name + " table routing files";
            Directory.CreateDirectory(Base_FolderName);

            FileName = "toplevel_table_" + node_count.ToString() + "_nodes.v";
            FilePath = Directory.GetCurrentDirectory() + @"\" + Base_FolderName + @"\" + FileName;

            fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);          // открытие файла

            sw.WriteLine("`define N " + (Math.Ceiling(Math.Log(node_count, 2)) + 1).ToString());
            sw.WriteLine("`define N_COUNT " + (node_count - 1).ToString());
            sw.WriteLine();

            sw.WriteLine("module toplevel_table_" + node_count.ToString() + "_nodes(");
            sw.Write("\t"); sw.WriteLine("clk,");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("sw_on,");
            sw.Write("\t"); sw.WriteLine("sw_sel_data,");
            sw.Write("\t"); sw.WriteLine("sw_sel_router,");
            sw.Write("\t"); sw.WriteLine("key_inc,");
            sw.Write("\t"); sw.WriteLine("key_dec,");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("out_data,");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("hex_data,");
            sw.Write("\t"); sw.WriteLine("hex_router");
            sw.WriteLine(");");

            sw.Write("\t"); sw.WriteLine("input clk;");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("input sw_on;");
            sw.Write("\t"); sw.WriteLine("input sw_sel_data;");
            sw.Write("\t"); sw.WriteLine("input sw_sel_router;");
            sw.Write("\t"); sw.WriteLine("input key_inc;");
            sw.Write("\t"); sw.WriteLine("input key_dec;");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("output wire[127:0] out_data;");
            sw.Write("\t"); sw.WriteLine("output wire[6:0] hex_data;");
            sw.Write("\t"); sw.WriteLine("output wire[6:0] hex_router");
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t"); sw.WriteLine("wire[" + (node_count * 3 - 1).ToString() + ":0] r_mem" + (i + 1).ToString() + ";");
            }
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t"); sw.WriteLine("wire[`N-1:0] out_router" + (i + 1).ToString() + ";");
            }
            sw.WriteLine();

            sw.Write("\t"); sw.Write("wire[`N-1:0] r_min[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в право по малой   образующей    данные от out_r1R");
            sw.Write("\t"); sw.Write("wire[`N-1:0] r_max[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в право по большей образующей    данные от out_r2R");
            sw.Write("\t"); sw.Write("wire[`N-1:0] l_min[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в лево  по малой   образующей    данные от out_r1L");
            sw.Write("\t"); sw.Write("wire[`N-1:0] l_max[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в лево  по большей образующей    данные от out_r2L");
            sw.WriteLine();

            sw.Write("\t"); sw.Write("select_data sel (");
            sw.Write(".clk(clk), ");
            sw.Write(".sw_on(sw_on), ");
            sw.Write(".sw_sel_data(sw_sel_data), ");
            sw.Write(".sw_sel_router(sw_sel_router), ");
            sw.Write(".key_inc(key_inc), ");
            sw.Write(".key_dec(key_dec), ");

            for (int i = 0; i < node_count - 1; i++)
            {
                sw.Write(".out_router" + (i + 1).ToString() + "(out_router" + (i + 1).ToString() + "), ");
            }
            sw.Write(".out_router" + node_count.ToString() + "(out_router" + node_count.ToString() + ")");
            sw.Write(".hex_data(hex_data), ");
            sw.WriteLine(".hex_router(hex_router));");
            sw.WriteLine();

            sw.Write("\t"); sw.Write("table_memory_" + node_count.ToString() + "_nodes mem1 (");
            for (int i = 0; i < node_count - 1; i++)
            {
                sw.Write(".outdatatbl" + (i + 1).ToString() + "(r_mem" + (i + 1).ToString() + "), ");
            }
            sw.WriteLine(".outdatatbl" + node_count.ToString() + "(r_mem" + node_count.ToString() + "));");
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t");
                sw.Write("table_router_" + node_count.ToString() + "_nodes r" + (i + 1).ToString() + " (");
                sw.Write(".clk(clk), "); sw.Write(".in_free(out_router" + (i + 1).ToString() + "), "); sw.Write(".r_table(r_mem" + (i + 1).ToString() + "), ");
                sw.Write(".in_r1R(l_min[" + ((i + generators[0]) % node_count).ToString() + "]), ");
                sw.Write(".in_r2R(l_max[" + ((i + generators[1]) % node_count).ToString() + "]), ");
                sw.Write(".in_r1L(r_min[" + ((node_count - generators[0] + i) % node_count).ToString() + "]), ");
                sw.Write(".in_r2L(r_max[" + ((node_count - generators[1] + i) % node_count).ToString() + "]), ");
                sw.Write(".out_r1R(r_min[" + i.ToString() + "]), ");
                sw.Write(".out_r2R(r_max[" + i.ToString() + "]), ");
                sw.Write(".out_r1L(l_min[" + i.ToString() + "]), ");
                sw.Write(".out_r2L(l_max[" + i.ToString() + "]), ");
                sw.Write(".out_data(out_data[" + i.ToString() + "]));");
                sw.WriteLine();
            }
            sw.WriteLine();

            sw.WriteLine("endmodule");
            sw.WriteLine();

            sw.Close();
            fs.Close();

            #endregion
        }

        public static void Generate_table_dop_part_module(int node_count, List<int> generators)
        {
            string FileName;
            string Base_FolderName;
            string graph_name;
            string FilePath;

            FileStream fs;
            StreamWriter sw;

            graph_name = "C(" + node_count.ToString() + "; " + generators[0].ToString() + ", " + generators[1].ToString() + ")";
            Base_FolderName = graph_name + " table routing files";
            Directory.CreateDirectory(Base_FolderName);


            FileName = "Дополнительные части модулей для " + graph_name + ".txt";
            FilePath = Directory.GetCurrentDirectory() + @"\" + Base_FolderName + @"\" + FileName;

            fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);

            sw.WriteLine("Дополнительные части модулей для C(" + node_count.ToString() + "; " + generators[0].ToString() + ", " + generators[1].ToString() + "):");
            sw.WriteLine();

            sw.WriteLine("Для модуля table_router_" + node_count.ToString() + "_nodes.v");
            sw.WriteLine("описывается разделение вектора от модуля памяти на массив");
            sw.WriteLine();
            for (int i = 0; i < node_count; i++)
            {
                sw.WriteLine("routing_table[" + (node_count - 1 - i).ToString() + "][2:0] = r_table[" + ((i + 1) * 3 - 1).ToString() + ":" + (i * 3).ToString() + "];");
            }
            sw.WriteLine(); sw.WriteLine(); sw.WriteLine(); sw.WriteLine(); sw.WriteLine();


            sw.WriteLine("Для модуля select_data.v");
            sw.WriteLine("объявляются выходные вектора, в которые передается значение на роутер на in_free");
            sw.WriteLine();
            for (int i = 0; i < node_count; i++)
            {
                sw.WriteLine("out_router" + (i + 1).ToString() + ",");
            }
            sw.WriteLine(); sw.WriteLine(); sw.WriteLine(); sw.WriteLine(); sw.WriteLine();


            sw.WriteLine("Для модуля select_data.v");
            sw.WriteLine("инициализируются выходные вектора, в которые передается значение на роутер на in_free");
            sw.WriteLine();
            for (int i = 0; i < node_count; i++)
            {
                sw.WriteLine("output reg[`N-1:0] out_router" + (i + 1).ToString() + ";");
            }
            sw.WriteLine(); sw.WriteLine(); sw.WriteLine(); sw.WriteLine(); sw.WriteLine();


            sw.WriteLine("Для модуля select_data.v");
            sw.WriteLine("присвоение значений для выходных векторов, в которые передается значение на роутер на in_free");
            sw.WriteLine();
            for (int i = 0; i < node_count; i++)
            {
                sw.WriteLine("out_router" + (i + 1).ToString() + " = out_to_router[" + ((i + 1) * (Math.Ceiling(Math.Log(node_count, 2)) + 1) - 1).ToString() + ":" + (i * (Math.Ceiling(Math.Log(node_count, 2)) + 1)).ToString() + "];");
            }
            sw.WriteLine();

            sw.Close();
            fs.Close();
        }

        public static void Generate_simple_net_connection_file(int node_count, List<int> generators)
        {
            string FileName;
            string Base_FolderName;
            string graph_name;
            string FilePath;

            FileStream fs;
            StreamWriter sw;

            #region
            //toplevel_table_9_nodes

            graph_name = "C(" + node_count.ToString() + "; " + generators[0].ToString() + ", " + generators[1].ToString() + ")";
            Base_FolderName = graph_name + " simple routing files";
            Directory.CreateDirectory(Base_FolderName);

            FileName = "toplevel_simple_" + node_count.ToString() + "_nodes.v";
            FilePath = Directory.GetCurrentDirectory() + @"\" + Base_FolderName + @"\" + FileName;

            fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);          // открытие файла


            sw.WriteLine("`define N_COUNT " + (node_count - 1).ToString());
            sw.WriteLine("`define N " + (Math.Ceiling(Math.Log(node_count, 2)) + 1).ToString());
            sw.WriteLine("`define NC " + (Math.Ceiling(Math.Log(node_count, 2))).ToString());
            sw.WriteLine();

            sw.WriteLine("module toplevel_simple_" + node_count.ToString() + "_nodes(");
            sw.Write("\t"); sw.WriteLine("clk,");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("sw_on,");
            sw.Write("\t"); sw.WriteLine("sw_sel_data,");
            sw.Write("\t"); sw.WriteLine("sw_sel_router,");
            sw.Write("\t"); sw.WriteLine("key_inc,");
            sw.Write("\t"); sw.WriteLine("key_dec,");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("out_data,");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("hex_data,");
            sw.Write("\t"); sw.WriteLine("hex_router");
            sw.WriteLine(");");

            sw.Write("\t"); sw.WriteLine("input clk;");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("input sw_on;");
            sw.Write("\t"); sw.WriteLine("input sw_sel_data;");
            sw.Write("\t"); sw.WriteLine("input sw_sel_router;");
            sw.Write("\t"); sw.WriteLine("input key_inc;");
            sw.Write("\t"); sw.WriteLine("input key_dec;");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("output wire[127:0] out_data;");
            sw.Write("\t"); sw.WriteLine("output wire[6:0] hex_data;");
            sw.Write("\t"); sw.WriteLine("output wire[6:0] hex_router");
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t"); sw.WriteLine("wire[`N-1:0] out_router" + (i + 1).ToString() + ";");
            }
            sw.WriteLine();

            sw.Write("\t"); sw.Write("wire[`N-1:0] r_min[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в право по малой   образующей    данные от out_r1R");
            sw.Write("\t"); sw.Write("wire[`N-1:0] r_max[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в право по большей образующей    данные от out_r2R");
            sw.Write("\t"); sw.Write("wire[`N-1:0] l_min[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в лево  по малой   образующей    данные от out_r1L");
            sw.Write("\t"); sw.Write("wire[`N-1:0] l_max[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в лево  по большей образующей    данные от out_r2L");
            sw.WriteLine();

            sw.Write("\t"); sw.Write("select_data sel (");
            sw.Write(".clk(clk), ");
            sw.Write(".sw_on(sw_on), ");
            sw.Write(".sw_sel_data(sw_sel_data), ");
            sw.Write(".sw_sel_router(sw_sel_router), ");
            sw.Write(".key_inc(key_inc), ");
            sw.Write(".key_dec(key_dec), ");

            for (int i = 0; i < node_count - 1; i++)
            {
                sw.Write(".out_router" + (i + 1).ToString() + "(out_router" + (i + 1).ToString() + "), ");
            }
            sw.Write(".out_router" + node_count.ToString() + "(out_router" + node_count.ToString() + ")");
            sw.Write(".hex_data(hex_data), ");
            sw.WriteLine(".hex_router(hex_router));");
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t");
                sw.Write("simple_router_" + node_count.ToString() + "_nodes r" + (i + 1).ToString() + " (");
                sw.Write(".clk(clk), ");
                sw.Write(".r_num(`NC'd" + i.ToString() + "), ");
                sw.Write(".in_free(out_router" + (i + 1).ToString() + "), ");
                sw.Write(".in_r1R(l_min[" + ((i + generators[0]) % node_count).ToString() + "]), ");
                sw.Write(".in_r2R(l_max[" + ((i + generators[1]) % node_count).ToString() + "]), ");
                sw.Write(".in_r1L(r_min[" + ((node_count - generators[0] + i) % node_count).ToString() + "]), ");
                sw.Write(".in_r2L(r_max[" + ((node_count - generators[1] + i) % node_count).ToString() + "]), ");
                sw.Write(".out_r1R(r_min[" + i.ToString() + "]), ");
                sw.Write(".out_r2R(r_max[" + i.ToString() + "]), ");
                sw.Write(".out_r1L(l_min[" + i.ToString() + "]), ");
                sw.Write(".out_r2L(l_max[" + i.ToString() + "]), ");
                sw.Write(".out_data(out_data[" + i.ToString() + "]));");
                sw.WriteLine();
            }
            sw.WriteLine();

            sw.WriteLine("endmodule");
            sw.WriteLine();

            sw.Close();
            fs.Close();

            #endregion
        }

        public static void Generate_adaptive_net_connection_file(int node_count, List<int> generators)
        {
            string FileName;
            string Base_FolderName;
            string graph_name;
            string FilePath;

            FileStream fs;
            StreamWriter sw;

            #region
            //toplevel_table_9_nodes

            graph_name = "C(" + node_count.ToString() + "; " + generators[0].ToString() + ", " + generators[1].ToString() + ")";
            Base_FolderName = graph_name + " smart routing files";
            Directory.CreateDirectory(Base_FolderName);

            FileName = "toplevel_smart_" + node_count.ToString() + "_nodes.v";
            FilePath = Directory.GetCurrentDirectory() + @"\" + Base_FolderName + @"\" + FileName;

            fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);          // открытие файла

            sw.WriteLine("`define N_COUNT " + (node_count - 1).ToString());
            sw.WriteLine("`define N " + (Math.Ceiling(Math.Log(node_count, 2)) + 1).ToString());
            sw.WriteLine("`define NC " + (Math.Ceiling(Math.Log(node_count, 2))).ToString());
            sw.WriteLine();

            sw.WriteLine("module toplevel_smart_" + node_count.ToString() + "_nodes(");
            sw.Write("\t"); sw.WriteLine("clk,");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("sw_on,");
            sw.Write("\t"); sw.WriteLine("sw_sel_data,");
            sw.Write("\t"); sw.WriteLine("sw_sel_router,");
            sw.Write("\t"); sw.WriteLine("key_inc,");
            sw.Write("\t"); sw.WriteLine("key_dec,");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("out_data,");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("hex_data,");
            sw.Write("\t"); sw.WriteLine("hex_router");
            sw.WriteLine(");");

            sw.Write("\t"); sw.WriteLine("input clk;");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("input sw_on;");
            sw.Write("\t"); sw.WriteLine("input sw_sel_data;");
            sw.Write("\t"); sw.WriteLine("input sw_sel_router;");
            sw.Write("\t"); sw.WriteLine("input key_inc;");
            sw.Write("\t"); sw.WriteLine("input key_dec;");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("output wire[127:0] out_data;");
            sw.Write("\t"); sw.WriteLine("output wire[6:0] hex_data;");
            sw.Write("\t"); sw.WriteLine("output wire[6:0] hex_router");
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t"); sw.WriteLine("wire[`N-1:0] out_router" + (i + 1).ToString() + ";");
            }
            sw.WriteLine();

            sw.Write("\t"); sw.Write("wire[`N-1:0] r_min[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в право по малой   образующей    данные от out_r1R");
            sw.Write("\t"); sw.Write("wire[`N-1:0] r_max[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в право по большей образующей    данные от out_r2R");
            sw.Write("\t"); sw.Write("wire[`N-1:0] l_min[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в лево  по малой   образующей    данные от out_r1L");
            sw.Write("\t"); sw.Write("wire[`N-1:0] l_max[0:`N_count];"); sw.Write("\t"); sw.WriteLine("// в лево  по большей образующей    данные от out_r2L");
            sw.WriteLine();

            sw.Write("\t"); sw.Write("select_data sel (");
            sw.Write(".clk(clk), ");
            sw.Write(".sw_on(sw_on), ");
            sw.Write(".sw_sel_data(sw_sel_data), ");
            sw.Write(".sw_sel_router(sw_sel_router), ");
            sw.Write(".key_inc(key_inc), ");
            sw.Write(".key_dec(key_dec), ");

            for (int i = 0; i < node_count - 1; i++)
            {
                sw.Write(".out_router" + (i + 1).ToString() + "(out_router" + (i + 1).ToString() + "), ");
            }
            sw.Write(".out_router" + node_count.ToString() + "(out_router" + node_count.ToString() + ")");
            sw.Write(".hex_data(hex_data), ");
            sw.WriteLine(".hex_router(hex_router));");
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t");
                sw.Write("smart_router_" + node_count.ToString() + "_nodes r" + (i + 1).ToString() + " (");
                sw.Write(".clk(clk), ");
                sw.Write(".r_num(`NC'd" + i.ToString() + "), ");
                sw.Write(".in_free(out_router" + (i + 1).ToString() + "), ");
                sw.Write(".in_r1R(l_min[" + ((i + generators[0]) % node_count).ToString() + "]), ");
                sw.Write(".in_r2R(l_max[" + ((i + generators[1]) % node_count).ToString() + "]), ");
                sw.Write(".in_r1L(r_min[" + ((node_count - generators[0] + i) % node_count).ToString() + "]), ");
                sw.Write(".in_r2L(r_max[" + ((node_count - generators[1] + i) % node_count).ToString() + "]), ");
                sw.Write(".out_r1R(r_min[" + i.ToString() + "]), ");
                sw.Write(".out_r2R(r_max[" + i.ToString() + "]), ");
                sw.Write(".out_r1L(l_min[" + i.ToString() + "]), ");
                sw.Write(".out_r2L(l_max[" + i.ToString() + "]), ");
                sw.Write(".out_data(out_data[" + i.ToString() + "]));");
                sw.WriteLine();
            }
            sw.WriteLine();

            sw.WriteLine("endmodule");
            sw.WriteLine();

            sw.Close();
            fs.Close();

            #endregion
        }

        public static void Generate_pair_net_connection_file(int node_count, List<int> generators)
        {
            string FileName;
            string Base_FolderName;
            string graph_name;
            string FilePath;

            FileStream fs;
            StreamWriter sw;

            #region
            //toplevel_table_9_nodes

            graph_name = "C(" + node_count.ToString() + "; " + generators[0].ToString() + ", " + generators[1].ToString() + ", " + generators[2].ToString() + ")";
            Base_FolderName = graph_name + " apm routing files";
            Directory.CreateDirectory(Base_FolderName);

            FileName = "toplevel_apm_" + node_count.ToString() + "_nodes.v";
            FilePath = Directory.GetCurrentDirectory() + @"\" + Base_FolderName + @"\" + FileName;

            fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);          // открытие файла

            sw.WriteLine("`define N " + (Math.Ceiling(Math.Log(node_count, 2)) + 1).ToString());
            sw.WriteLine("`define K " + (Math.Ceiling(Math.Log(node_count, 2))).ToString());
            sw.WriteLine("`define N_COUNT " + node_count.ToString());
            sw.WriteLine();

            sw.WriteLine("module toplevel_apm_" + node_count.ToString() + "_nodes(");
            sw.Write("\t"); sw.WriteLine("clk,");
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("out_data,");
            sw.WriteLine();

            sw.Write("\t"); sw.WriteLine("sw_on,");
            sw.Write("\t"); sw.WriteLine("sw_sel_data,");
            sw.Write("\t"); sw.WriteLine("sw_sel_router,");
            sw.Write("\t"); sw.WriteLine("key_inc,");
            sw.Write("\t"); sw.WriteLine("key_dec,");

            
            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("hex_data,");
            sw.Write("\t"); sw.WriteLine("hex_router");
            sw.WriteLine(");");

            sw.Write("\t"); sw.WriteLine("input clk;");
            sw.Write("\t"); sw.WriteLine("input sw_on;");
            sw.Write("\t"); sw.WriteLine("input sw_sel_data;");
            sw.Write("\t"); sw.WriteLine("input sw_sel_router;");
            sw.Write("\t"); sw.WriteLine("input key_inc;");
            sw.Write("\t"); sw.WriteLine("input key_dec;");

            sw.WriteLine();
            sw.Write("\t"); sw.WriteLine("output wire[127:0] out_data;");
            sw.Write("\t"); sw.WriteLine("output wire[6:0] hex_data;");
            sw.Write("\t"); sw.WriteLine("output wire[6:0] hex_router;");
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t"); sw.WriteLine("wire[`N-1:0] out_router" + (i + 1).ToString() + ";");
            }
            sw.WriteLine();

            sw.Write("\t"); sw.Write("wire[`N-1:0] r_minR[0:`N_COUNT];"); sw.Write("\t"); sw.WriteLine("// в право по малой   образующей    данные от out_r1R");
            sw.Write("\t"); sw.Write("wire[`N-1:0] r_midR[0:`N_COUNT];"); sw.Write("\t"); sw.WriteLine("// в право по средней образующей    данные от out_r2R");
            sw.Write("\t"); sw.Write("wire[`N-1:0] r_maxR[0:`N_COUNT];"); sw.Write("\t"); sw.WriteLine("// в право по большей образующей    данные от out_r2R");
            sw.Write("\t"); sw.Write("wire[`N-1:0] r_minL[0:`N_COUNT];"); sw.Write("\t"); sw.WriteLine("// в лево  по малой   образующей    данные от out_r1L");
            sw.Write("\t"); sw.Write("wire[`N-1:0] r_midL[0:`N_COUNT];"); sw.Write("\t"); sw.WriteLine("// в лево  по большей образующей    данные от out_r2L");
            sw.Write("\t"); sw.Write("wire[`N-1:0] r_maxL[0:`N_COUNT];"); sw.Write("\t"); sw.WriteLine("// в лево  по большей образующей    данные от out_r2L");
            sw.WriteLine();

            sw.Write("\t"); sw.Write("select_data_" + node_count + " sel (");
            sw.Write(".clk(clk), ");
            sw.Write(".sw_on(sw_on), ");
            sw.Write(".sw_sel_data(sw_sel_data), ");
            sw.Write(".sw_sel_router(sw_sel_router), ");
            sw.Write(".key_inc(key_inc), ");
            sw.Write(".key_dec(key_dec), ");
            sw.WriteLine();
            sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t");
            int perenos = 0;
            for (int i = 0; i < node_count - 1; i++)
            {
                sw.Write(".out_router" + (i + 1).ToString() + "(out_router" + (i + 1).ToString() + "), ");
                if (perenos == 4)
                {
                    perenos = 0;
                    sw.WriteLine(); sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t");
                }
                else
                {
                    perenos++;
                }
            }

            sw.Write(".out_router" + node_count.ToString() + "(out_router" + node_count.ToString() + "), ");
            sw.WriteLine();
            sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t"); sw.Write("\t");
            sw.Write(".hex_data(hex_data), ");
            sw.WriteLine(".hex_router(hex_router));");
            sw.WriteLine();

            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t");
                sw.Write("apm_router_" + node_count.ToString() + "_nodes r" + (i + 1).ToString() + " (");
                sw.Write(".clk(clk), ");
                sw.Write(".router_name(`K'd" + i.ToString() + "), ");
                sw.Write(".in_free(out_router" + (i + 1).ToString() + "), ");

                sw.Write(".in_r1R(r_minL[" + ((i + generators[0]) % node_count).ToString() + "]), ");
                sw.Write(".in_r2R(r_midL[" + ((i + generators[1]) % node_count).ToString() + "]), ");
                if (generators[2] < node_count / 2)
                {
                    sw.Write(".in_r3R(r_maxL[" + ((i + generators[2]) % node_count).ToString() + "]), ");
                }
                else
                {
                    sw.Write(".in_r3R(r_maxL[" + ((i + (node_count - generators[2])) % node_count).ToString() + "]), ");
                }

                sw.Write(".in_r1L(r_minR[" + ((node_count - generators[0] + i) % node_count).ToString() + "]), ");
                sw.Write(".in_r2L(r_midR[" + ((node_count - generators[1] + i) % node_count).ToString() + "]), ");
                if (generators[2] < node_count / 2)
                {
                    sw.Write(".in_r3L(r_maxR[" + ((node_count - generators[2] + i) % node_count).ToString() + "]), ");
                }
                else
                {
                    sw.Write(".in_r3L(r_maxR[" + ((node_count - (node_count - generators[2]) + i) % node_count).ToString() + "]), ");
                }

                sw.Write(".out_r1R(r_minR[" + i.ToString() + "]), ");
                sw.Write(".out_r2R(r_midR[" + i.ToString() + "]), ");
                sw.Write(".out_r3R(r_maxR[" + i.ToString() + "]), ");

                sw.Write(".out_r1L(r_minL[" + i.ToString() + "]), ");
                sw.Write(".out_r2L(r_midL[" + i.ToString() + "]), ");
                sw.Write(".out_r3L(r_maxL[" + i.ToString() + "]), ");

                sw.Write(".out_data(out_data[" + i.ToString() + "]));");
                sw.WriteLine();
            }
            sw.WriteLine();

            sw.WriteLine("endmodule");
            sw.WriteLine();

            sw.Close();
            fs.Close();

            #endregion
        }

        public static void Generate_pair_select_data_file(int node_count, List<int> generators)
        {
            string FileName;
            string Base_FolderName;
            string graph_name;
            string FilePath;

            FileStream fs;
            StreamWriter sw;

            #region
            //toplevel_table_9_nodes

            graph_name = "C(" + node_count.ToString() + "; " + generators[0].ToString() + ", " + generators[1].ToString() + ", " + generators[2].ToString() + ")";
            Base_FolderName = graph_name + " apm routing files";
            Directory.CreateDirectory(Base_FolderName);

            FileName = "select_data_" + node_count.ToString() + ".txt";
            FilePath = Directory.GetCurrentDirectory() + @"\" + Base_FolderName + @"\" + FileName;

            fs = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite);
            sw = new StreamWriter(fs);          // открытие файла

            int perenos = 0;
            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t"); sw.Write("out_router" + (i + 1).ToString() + ", ");
                if (perenos == 4)
                {
                    perenos = 0;
                    sw.WriteLine();
                }
                else
                {
                    perenos++;
                }
            }
            sw.WriteLine(); sw.WriteLine(); sw.WriteLine();

            perenos = 0;
            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t"); sw.Write("output reg[`N-1:0] out_router" + (i + 1).ToString() + "; ");
                if (perenos == 4)
                {
                    perenos = 0;
                    sw.WriteLine();
                }
                else
                {
                    perenos++;
                }
            }
            sw.WriteLine(); sw.WriteLine(); sw.WriteLine();

            perenos = 0;
            for (int i = 0; i < node_count; i++)
            {
                sw.Write("\t"); sw.Write("out_router" + (i + 1).ToString() + " =  out_to_router[" + ((Math.Ceiling(Math.Log(node_count, 2)) + 1) * (i + 1) - 1) + ":" + ((Math.Ceiling(Math.Log(node_count, 2)) + 1) * (i)) + "]; ");
                if (perenos == 2)
                {
                    perenos = 0;
                    sw.WriteLine();
                }
                else
                {
                    perenos++;
                }
            }
            sw.WriteLine();

            sw.Close();
            fs.Close();

            #endregion
        }
    }
}
