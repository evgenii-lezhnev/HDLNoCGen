using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HDL_NoC_CodeGen
{
    class Graph
    {
        private Settings settings;
        private string error_message;

        private bool is_created;
        private int node_count;
        private List<int> generators;
        private int diameter;
        private int p; // для алгоритма парной маршрутизации
        private int[,] matr_smej;
        private List<List<int>> min_ways_routing_deikstra; //минимальные пути по алгоритму Дейкстры
        private List<List<int>> min_ways_routing_simple; // минимальные пути по простому алгоритму маршрутизации
        private List<List<int>> min_ways_routing_ROU; // минимальные пути по адаптивному алгоритму маршрутизации
        private List<List<int>> min_ways_routing_APM; // минимальные пути по алгоритму парной маршрутизации
        private List<List<int>> min_ways_routing_APO; // минимальные пути по алгоритму парного обмена

        private double efficiency_deikstra;
        private double efficiency_simple;
        private double efficiency_ROU;
        private double efficiency_APM;
        private double efficiency_APO;

        public bool Is_created()
        {
            return this.is_created;
        }

        public string Get_error_message()
        {
            return this.error_message;
        }

        public int Get_node_count()
        {
            return this.node_count;
        }

        public List<int> Get_generators()
        {
            return this.generators;
        }

        public int Get_diameter()
        {
            return this.diameter;
        }

        public int Get_p()
        {
            return this.p;
        }

        public int[,] Get_matr_smej()
        {
            return this.matr_smej;
        }

        public List<List<int>> Get_min_ways_routing_deikstra()
        {
            return this.min_ways_routing_deikstra;
        }

        public List<List<int>> Get_min_ways_routing_simple()
        {
            return this.min_ways_routing_simple;
        }

        public List<List<int>> Get_min_ways_routing_ROU()
        {
            return this.min_ways_routing_ROU;
        }

        public List<List<int>> Get_min_ways_routing_APM()
        {
            return this.min_ways_routing_APM;
        }

        public List<List<int>> Get_min_ways_routing_APO()
        {
            return this.min_ways_routing_APO;
        }

        public double Get_efficiency_deikstra()
        {
            return this.efficiency_deikstra;
        }

        public double Get_efficiency_simple()
        {
            return this.efficiency_simple;
        }

        public double Get_efficiency_ROU()
        {
            return this.efficiency_ROU;
        }

        public double Get_efficiency_APM()
        {
            return this.efficiency_APM;
        }

        public double Get_efficiency_APO()
        {
            return this.efficiency_APO;
        }

        public Graph()
        {
            settings = Settings.GetInstance();
            this.error_message = "";

            this.is_created = false;
            this.node_count = 0;
            this.generators = null;
            this.diameter = 0;
            this.p = 0;
            this.matr_smej = null;
            this.min_ways_routing_deikstra = null;
            this.min_ways_routing_simple = null;
            this.min_ways_routing_ROU = null;
            this.min_ways_routing_APM = null;
            this.min_ways_routing_APO = null;
        }

        public Graph(string paraneters)
        {
            settings = Settings.GetInstance();

            string[] buffer = paraneters.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            string[] buffer_topology = buffer[0].Trim().Split(new string[] { "С(", "C(", ";", ":", ", ", ")", " " }, StringSplitOptions.RemoveEmptyEntries);
            this.node_count = Convert.ToInt32(buffer_topology[0]);
            generators = new List<int>();
            for (int i = 1; i < buffer_topology.Length; i++)
            {
                generators.Add(Convert.ToInt32(buffer_topology[i]));
            }
            generators.Sort();

            string[] buffer_parameters;
            if (buffer.Length > 1)
            {
                buffer_parameters = buffer[1].Trim().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                buffer_parameters[0].Trim();
                string[] sub_buffer_parameters = buffer_parameters[0].Trim().Split(new string[] {"="}, StringSplitOptions.RemoveEmptyEntries);
                this.p = Convert.ToInt32(sub_buffer_parameters[1]);
            }

            //string[] buffer = paraneters.Split(new string[] { "С(", "C(", ";", ":",  ", ", ")", " " }, StringSplitOptions.RemoveEmptyEntries);
            //this.node_count = Convert.ToInt32(buffer[0]);
            //this.p = Convert.ToInt32(param_2);

            

            this.is_created = true;
        }

        private void Create_matr_smej()
        {
            this.matr_smej = new int[this.node_count, this.node_count];

            for (int i = 0; i < this.generators.Count; i++)
            {
                for (int j = 1; j < (this.node_count + 1); j++)
                {
                    int k = this.generators[i] + j;
                    if (k > this.node_count)
                    {
                        k = k - this.node_count;
                    }
                    this.matr_smej[j - 1, k - 1] = 1;
                    this.matr_smej[k - 1, j - 1] = 1;
                }
            }

        }

        public List<List<int>> Generate_deikstra_routing()
        {
            Create_matr_smej();

            int[] d = new int[node_count]; // минимальное расстояние
            int[] v = new int[node_count]; // посещенные вершины
            int minindex;
            int min;
            int temp;
            List<int[]> ways;

            min_ways_routing_deikstra = new List<List<int>>();

            for (int i = 0; i < node_count; i++)
            {
                d[i] = 10000;
                v[i] = 1;
            }
            d[0] = 0;

            // Шаг алгоритма
            do
            {
                minindex = 10000;
                min = 10000;
                for (int i = 0; i < node_count; i++)
                { // Если вершину ещё не обошли и вес меньше min
                    if ((v[i] == 1) && (d[i] < min))
                    { // Переприсваиваем значения
                        min = d[i];
                        minindex = i;
                    }
                }

                // Добавляем найденный минимальный вес к текущему весу вершины
                // и сравниваем с текущим минимальным весом вершины
                if (minindex != 10000)
                {
                    for (int i = 0; i < node_count; i++)
                    {
                        if (matr_smej[minindex, i] > 0)
                        {
                            temp = min + matr_smej[minindex, i];
                            if (temp < d[i])
                            {
                                d[i] = temp;
                            }
                        }
                    }
                    v[minindex] = 0;
                }
            } while (minindex < 10000);
            //конец алгоритма Дейкстра

            //Востановление пути
            ways = new List<int[]>();
            for (int i = 0; i < node_count; i++)
            {
                int[] ver;
                ver = new int[node_count];// массив посещенных вершин
                int end = node_count - i - 1; // индекс конечной вершины = 5 - 1
                ver[0] = end; // начальный элемент - конечная вершина
                int k = 0; // индекс предыдущей вершины
                int weight = d[end]; // вес конечной вершины

                while (end > 0) // пока не дошли до начальной вершины
                {
                    for (int j = 0; j < node_count; j++) // просматриваем все вершины
                        if (matr_smej[end, j] != 0)   // если связь есть
                        {
                            temp = weight - matr_smej[end, j]; // определяем вес пути из предыдущей вершины
                            if (temp == d[j]) // если вес совпал с рассчитанным
                            {                 // значит из этой вершины и был переход
                                weight = temp; // сохраняем новый вес
                                end = j;       // сохраняем предыдущую вершину
                                ver[k] = j + 1; // и записываем ее в массив
                                k++;
                            }
                        }
                }
                ways.Add(ver);
            }

            for (int i = ways.Count - 1; i > -1; i--)
            {
                List<int> buff = new List<int>();
                for (int j = node_count - 1; j > -1; j--)
                {
                    if (ways[i][j] != 0)
                    {
                        buff.Add((ways[i][j] - 1 + settings.Get_node_naming_start_index()));
                    }
                }
                buff.Add(min_ways_routing_deikstra.Count + settings.Get_node_naming_start_index());
                min_ways_routing_deikstra.Add(buff);
            }

            return this.min_ways_routing_deikstra;
        }

        public int Calculate_diameter()
        {
            this.diameter = 0;
            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                if (this.min_ways_routing_deikstra[i].Count > this.diameter)
                {
                    this.diameter = this.min_ways_routing_deikstra[i].Count;
                }
            }
            this.diameter = this.diameter - 1;

            return this.diameter;
        }

        public List<List<int>> Generate_Simple_routing()
        {
            int iterations_count; // для того чтобы программа не зависала, если не может посчитать маршрут

            int start_node;
            int end_node;
            List<int> route;

            this.min_ways_routing_simple = new List<List<int>>();

            try
            {
                if (!this.is_created)
                {
                    throw new Exception("Описание топологии не было задано или задано не полностью");
                }

                for (int i = 0; i < this.node_count; i++)
                {
                    iterations_count = 0;

                    start_node = 1;
                    end_node = i + 1;
                    route = new List<int>();
                    route.Add(start_node - 1 + settings.Get_node_naming_start_index());
                    while (end_node != start_node)
                    {
                        iterations_count++;

                        start_node = Simple_routing(start_node, end_node);
                        route.Add(start_node - 1 + settings.Get_node_naming_start_index());

                        if (iterations_count > settings.Get_error_iterations_count())
                        {
                            throw new Exception("Превышено количество итераций моделирования маршрута для алгоритма Simple");
                        }
                    }
                    this.min_ways_routing_simple.Add(route);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.min_ways_routing_simple;
        } // проверка на ошибки добавлена

        private int Simple_routing(int start_node, int end_node)
        {
            int S = end_node - start_node;
            if (S == 0)
            {
                return (start_node);
            }
            if (S < 0)
            {
                S = S + this.node_count;
            }
            if (S <= (this.node_count / 2))
            {
                if (S >= this.generators[1])
                    start_node = (this.generators[1] + start_node) % this.node_count;
                else
                    start_node = (this.generators[0] + start_node) % this.node_count;
            }
            else
            {
                S = this.node_count - S;
                if (S >= this.generators[1])
                    start_node = (this.node_count - this.generators[1] + start_node) % this.node_count;
                else
                    start_node = (this.node_count - this.generators[0] + start_node) % this.node_count;
            }
            if (start_node == 0) start_node = this.node_count;
            return (start_node);
        }

        public List<List<int>> Generate_ROU_routing()
        {
            int iterations_count; // для того чтобы программа не зависала, если не может посчитать маршрут

            int start_node;
            int end_node;
            List<int> route;

            this.min_ways_routing_ROU = new List<List<int>>();

            try
            {
                if (!this.is_created)
                {
                    throw new Exception("Описание топологии не было задано или задано не полностью");
                }

                for (int i = 0; i < this.node_count; i++)
                {
                    iterations_count = 0;

                    start_node = 1;
                    end_node = i + 1;
                    route = new List<int>();
                    route.Add(start_node - 1 + settings.Get_node_naming_start_index());
                    while (end_node != start_node)
                    {
                        iterations_count++;
                        start_node = ROU_routing(start_node, end_node, this.node_count, this.generators[0], this.generators[1]);
                        route.Add(start_node - 1 + settings.Get_node_naming_start_index());

                        if (iterations_count > settings.Get_error_iterations_count())
                        { 
                            throw new Exception("Превышено количество итераций моделирования маршрута для алгоритма ROU");
                        }
                    }
                    this.min_ways_routing_ROU.Add(route);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.min_ways_routing_ROU;
        } // проверка на ошибки добавлена

        private int ROU_routing(int start_node, int end_node, int node_count, int s1 = 1, int s2 = 2)
        {
            //чтобы начальный всегда был меньше конечного  
            //117 1 43  - надо устранение 2 циклов по большой образующей
            //500 1 276 - надо устранение 2+ циклов по большой образующей
            if (start_node > end_node)
            {
                start_node = start_node - Step_cicles(end_node, start_node, node_count, s1, s2);
                //start_node = start_node - Step(end_node, start_node, N, s1, s2);
            }
            else
            {
                start_node = start_node + Step_cicles(start_node, end_node, node_count, s1, s2);
                //start_node = start_node + Step(start_node, end_node, N, s1, s2);
            }

            // ! работает тоже 
            //  чтобы начальный всегда был меньше конечного
            //if(start_node > end_node)
            //{
            //    end_node = end_node + N;
            //}
            //start_node = start_node + Step(start_node, end_node, N, s1, s2);

            // нормализация 
            if (start_node > node_count)
            {
                start_node = start_node - node_count;
            }
            else if (start_node <= 0)
            {
                start_node = start_node + node_count;
            }
            return start_node;
        }

        /*
         * Поиск шага, когда 2 образующие, s1=1. Устраняются циклы.
         */
        private int Step_cicles(int start_node, int end_node, int node_count, int s1, int s2)
        {
            int best_way_R = 0, step_R = 0, best_way_L = 0, step_L = 0;
            int s = end_node - start_node;

            // лучший путь вправо и шаг
            int R1 = s / s2 + s % s2;
            int R2 = s / s2 - s % s2 + s2 + 1;
            if (s % s2 == 0)
            {
                best_way_R = R1;
                step_R = s2;
            }
            else
            {
                if (R1 < R2)
                {
                    best_way_R = R1;
                    step_R = s1;
                }
                else
                {
                    best_way_R = R2;
                    step_R = s2;
                }
            }

            //1 цикл
            int R5 = (s + node_count) / s2 + (s + node_count) % s2;
            int R6 = (s + node_count) / s2 - (s + node_count) % s2 + s2 + 1;
            if (R5 < best_way_R)
            {
                best_way_R = R5;
                step_R = s2;
            }
            if (R6 < best_way_R)
            {
                best_way_R = R6;
                step_R = s2;
            }

            //2 цикл
            int R9 = (s + node_count + node_count) / s2 + (s + node_count + node_count) % s2;
            int R10 = (s + node_count + node_count) / s2 - (s + node_count + node_count) % s2 + s2 + 1;
            if (R9 < best_way_R)
            {
                best_way_R = R9;
                step_R = s2;
            }
            if (R10 < best_way_R)
            {
                best_way_R = R10;
                step_R = s2;
            }
            //3 цикл
            //..

            // лучший путь влево и шаг
            s = start_node - end_node + node_count;
            int L1 = s / s2 + s % s2;
            int L2 = s / s2 - s % s2 + s2 + 1;
            if (s % s2 == 0)
            {
                best_way_L = L1;
                step_L = -s2;
            }
            else
            {
                if (L1 < L2)
                {
                    best_way_L = L1;
                    step_L = -s1;
                }
                else
                {
                    best_way_L = L2;
                    step_L = -s2;
                }
            }

            //1 цикл
            int R7 = (s + node_count) / s2 + (s + node_count) % s2;
            int R8 = (s + node_count) / s2 - (s + node_count) % s2 + s2 + 1;
            if (R7 < best_way_L)
            {
                best_way_L = R7;
                step_L = -s2;
            }
            if (R8 < best_way_L)
            {
                best_way_L = R8;
                step_L = -s2;
            }

            //2 цикл
            int R11 = (s + node_count + node_count) / s2 + (s + node_count + node_count) % s2;
            int R12 = (s + node_count + node_count) / s2 - (s + node_count + node_count) % s2 + s2 + 1;
            if (R11 < best_way_L)
            {
                best_way_L = R11;
                step_L = -s2;
            }
            if (R12 < best_way_L)
            {
                best_way_L = R12;
                step_L = -s2;
            }

            // решаем куда шагнуть, и шагаем
            if (best_way_R < best_way_L)
            {
                return step_R;
            }
            else
            {
                return step_L;
            }
        }

        /*
         * Поиск шага, когда 2 образующие, s1=1. Циклы не проверяются.
         */
        private int Step(int start_node, int end_node, int node_count, int s1 = 1, int s2 = 2)
        {
            int best_way_R = 0, step_R = 0, best_way_L = 0, step_L = 0;
            int s = end_node - start_node;

            // лучший путь вправо и шаг
            int R1 = s / s2 + s % s2;
            int R2 = s / s2 - s % s2 + s2 + 1;
            if (s % s2 == 0)
            {
                best_way_R = R1;
                step_R = s2;
            }
            else
            {
                if (R1 < R2)
                {
                    best_way_R = R1;
                    step_R = s1;
                }
                else
                {
                    best_way_R = R2;
                    step_R = s2;
                }
            }

            // лучший путь влево и шаг
            s = start_node - end_node + node_count;
            int L1 = s / s2 + s % s2;
            int L2 = s / s2 - s % s2 + s2 + 1;
            if (s % s2 == 0)
            {
                best_way_L = L1;
                step_L = -s2;
            }
            else
            {
                if (L1 < L2)
                {
                    best_way_L = L1;
                    step_L = -s1;
                }
                else
                {
                    best_way_L = L2;
                    step_L = -s2;
                }
            }

            // решаем куда шагнуть, и шагаем
            if (best_way_R < best_way_L)
            {
                return step_R;
            }
            else
            {
                return step_L;
            }
        }

        public List<List<int>> Generate_APM_routing()
        {
            int iterations_count; // для того чтобы программа не зависала, если не может посчитать маршрут

            this.min_ways_routing_APM = new List<List<int>>();
            int start_node;
            int end_node;
            List<int> route; // то что будет записываться в итоговый лист
            List<int> buff_route;

            try
            {
                if (!this.is_created || this.p == 0)
                {
                    throw new Exception("Описание топологии не было задано или не было произведено создание топологии");
                }
                for (int i = 0; i < this.node_count; i++)
                {
                    iterations_count = 0;
                    
                    start_node = 1;
                    end_node = i + 1;
                    route = new List<int>();
                    buff_route = new List<int>();
                    buff_route = APM_routing(start_node, end_node, diameter, this.p);

                    route.Add(start_node - 1 + settings.Get_node_naming_start_index());
                    for (int j = 0; j < 3; j++)
                    {
                        for (int k = 0; k < Math.Abs(buff_route[j]); k++)
                        {
                            if (buff_route[j] > 0)
                            {
                                start_node = start_node + generators[j];
                                start_node = start_node % node_count;
                                if (start_node == 0)
                                {
                                    start_node = node_count;
                                }
                                route.Add(start_node - 1 + settings.Get_node_naming_start_index());
                            }
                            else
                            {
                                start_node = start_node - generators[j];
                                if (start_node < 0)
                                {
                                    start_node = node_count + start_node;
                                }
                                if (start_node == 0)
                                {
                                    start_node = node_count;
                                }
                                route.Add(start_node - 1 + settings.Get_node_naming_start_index());
                            }
                        }
                    }

                    this.min_ways_routing_APM.Add(route);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.min_ways_routing_APM;
        }

        private List<int> APM_routing(int start_node, int end_node, int d, int p)
        {
            bool flag_dir = false; // вычисояем как обычно
            List<int> result = new List<int>();
            int V = end_node - start_node;
            if (V >= node_count / 2)
            {
                V = node_count - V;
                flag_dir = true; // инвертируем знаки в итоговом векторе
            }
            int gamma = 2 * (d + 1 - p);
            int i =  V / generators[2];
            int j, k, k1;
            bool step;

            if (V < (i + 1) * generators[1])
            {
                j = (V - i * generators[2]) / (generators[2] - generators[1]);
                k = V - i * generators[2] - j * (generators[2] - generators[1]) - gamma;
                k1 = i + 2 * j + gamma - d - 1;
                step = false;
            }
            else
            {
                j = (V - (i+1) * generators[1]) / (generators[2] - generators[1]);
                k = V - (i+1) * generators[1] - j * (generators[2] - generators[1]) - gamma +1;
                k1 = i + gamma - d - 1;
                step = true;
            }

            if (!step) // шаг 2
            {
                if (((i + 2 * j) >= 0 && (i + 2 * j) <= (d - gamma) && (k >= -gamma) && (k <= 0)) ||
                    (((i + 2 * j) > (d - gamma)) && (i + 2 * j) <= d && k >= -gamma && k < -k1))
                {
                    result.Add(k + gamma);
                    result.Add(-j);
                    result.Add(i + j);
                }
                else if (((i + 2 * j) >= 0 && (i + 2 * j) <= (d - gamma) && k >= 0 && k <= (gamma - 3)) ||
                        ((i + 2 * j) > (d - gamma) && (i + 2 * j) <= d && k > k1 && k <= (gamma - 3)))
                {
                    result.Add(-(gamma - k - 2));
                    result.Add(-(j + 1));
                    result.Add(i + j + 1);
                }
                else 
                {
                    result.Add(k);
                    result.Add(d + 1 - gamma/2 -j);
                    result.Add(-(d - gamma / 2 - i - j));
                }
            }
            else // шаг 3
            {
                if ((i >= 0 && i <= (d - gamma) && k > -gamma && k <= 0) ||
                    (i > (d - gamma) && i <= (d - gamma / 2) && k > -gamma && k < -k1))
                {
                    result.Add(gamma - 1 - Math.Abs(k));
                    result.Add(i+1-j);
                    result.Add(j);
                }
                else if ((i > (d - gamma) && i <= (d - gamma / 2) && Math.Abs(k) <= k1))
                {
                    result.Add(k);
                    result.Add(-(d - gamma / 2 - i + j));
                    result.Add(-(d + 1 - gamma / 2 - j));
                }
                else
                {
                    result.Add(-(gamma - 1 - k));
                    result.Add(i - j);
                    result.Add(j + 1);
                }
            }

            if (flag_dir)
            {
                result[0] = -result[0];
                result[1] = -result[1];
                result[2] = -result[2];
            }

            return result;
        }

        public List<List<int>> Generate_APO_routing()
        {
            this.min_ways_routing_APO = new List<List<int>>();
            int start_node;
            int end_node;
            List<int> route; // то что будет записываться в итоговый лист
            List<int> buff_route;

            try
            {
                if (!this.is_created)
                {
                    throw new Exception("Описание топологии не было задано или задано не полностью");
                }

                for (int i = 0; i < this.node_count; i++)
                {
                    start_node = 1;
                    end_node = i + 1;
                    route = new List<int>();
                    buff_route = new List<int>(); // получаем сколько нужно пройти по первой и по второй образующим
                    buff_route = APO_routing(start_node, end_node, generators[0]);

                    route.Add(start_node - 1 + settings.Get_node_naming_start_index());// сначала записываем узел из которого идем
                    for (int j = 0; j < 2; j++)
                    {
                        for (int k = 0; k < Math.Abs(buff_route[j]); k++)
                        {
                            if (buff_route[j] > 0)
                            {
                                start_node = start_node + generators[j];
                                start_node = start_node % node_count;
                                if (start_node == 0)
                                {
                                    start_node = node_count;
                                }
                                route.Add(start_node - 1 + settings.Get_node_naming_start_index());

                            }
                            else
                            {
                                start_node = start_node - generators[j];
                                if (start_node < 0)
                                {
                                    start_node = node_count + start_node;
                                }
                                if (start_node == 0)
                                {
                                    start_node = node_count;
                                }
                                route.Add(start_node - 1 + settings.Get_node_naming_start_index());
                            }
                        }
                    }

                    this.min_ways_routing_APO.Add(route);
                }
            }
            catch (Exception ex)
            {
                this.error_message = ex.Message;
                return null;
            }

            return this.min_ways_routing_APO;
        }

        private List<int> APO_routing(int start_node, int end_node, int s1)
        {
            List<int> result = new List<int>();  //хранит 2 числа сколько нужно шагов по по первой образующей и сколько по второй
            int sgn = 0;
            int alpha = 0;
            int betta = 0;
            int k = 0;

            k = Math.Abs(start_node - end_node);
            if (end_node <= start_node)
            {
                sgn = -1;
            }
            else
            {
                sgn = 1;
            }

            if (k > (node_count / 2))
            {
                sgn = -sgn;
                k = node_count - k;
            }

            betta = k % s1;
            alpha = k / s1 - betta;

            if ((alpha >= (betta - s1)) && (alpha <=s1))
            {
                result.Add(alpha * sgn);
                result.Add(betta * sgn);
            }
            else if (alpha < (betta - s1))
            {
                result.Add((alpha + s1 + 1) * sgn);
                result.Add((betta - s1) * sgn);
            }
            else
            {
                result.Add((alpha - (s1 + 1)) * sgn);
                result.Add((betta + s1) * sgn);
            }

            return result;
        }
   
        public double Calculate_efficiency_deikstra()
        {
            this.efficiency_deikstra = 1.0;

            return this.efficiency_deikstra;
        }

        public double Calculate_efficiency_simple()
        {
            double deikstra_algorithm_L = 0;
            double simple_algorithm_L = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_algorithm_L += this.min_ways_routing_deikstra[i].Count - 1;
                simple_algorithm_L += this.min_ways_routing_simple[i].Count - 1;
            }

            efficiency_simple = Math.Round((deikstra_algorithm_L / simple_algorithm_L), 3);
            return this.efficiency_simple;
        }

        public double Calculate_efficiency_ROU()
        {
            double deikstra_algorithm_L = 0;
            double ROU_algorithm_L = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_algorithm_L += this.min_ways_routing_deikstra[i].Count - 1;
                ROU_algorithm_L += this.min_ways_routing_ROU[i].Count - 1;
            }

            efficiency_ROU = Math.Round((deikstra_algorithm_L / ROU_algorithm_L), 3);
            return this.efficiency_ROU;
        }

        public double Calculate_efficiency_APM()
        {
            double deikstra_algorithm_L = 0;
            double APM_algorithm_L = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_algorithm_L += this.min_ways_routing_deikstra[i].Count - 1;
                APM_algorithm_L += this.min_ways_routing_APM[i].Count - 1;
            }

            efficiency_APM = Math.Round((deikstra_algorithm_L / APM_algorithm_L), 3);
            return this.efficiency_APM;
        }

        public double Calculate_efficiency_APO()
        {
            double deikstra_algorithm_L = 0;
            double APO_algorithm_L = 0;

            for (int i = 0; i < this.min_ways_routing_deikstra.Count; i++)
            {
                deikstra_algorithm_L += this.min_ways_routing_deikstra[i].Count - 1;
                APO_algorithm_L += this.min_ways_routing_APO[i].Count - 1;
            }

            efficiency_APO = Math.Round((deikstra_algorithm_L / APO_algorithm_L), 3);
            return this.efficiency_APO;
        }

    }
}
