# HDLNoCGen
**Verilog Code Generator for Network-on-Chip Communication Subsystem (including circulant topology)**
    
This is the Generator of Communication Subsystem for Network-on-Chip.        
The program includes options to visualize circulant graphs as possible topology for communication subsystem. The search for the shortest routes based on Dijkstra's algorithm, as well as specialized algorithms for circulant graphs also included.
Information about circulant graphs:    
[Development of routing algorithms in networks-on-chip based on two-dimensional optimal circulant topologies](https://www.sciencedirect.com/science/article/pii/S2405844020300281), https://doi.org/10.1016/j.heliyon.2020.e03183.
    
# Contact persons    
a.romanov@hse.ru (Aleksandr Romanov, PhD)     
https://www.hse.ru/en/staff/a.romanov#sci   
https://www.researchgate.net/profile/Aleksandr-Romanov

elezhnev@hse.ru (Evgenii Lezhnev, PhD)     
https://www.hse.ru/en/org/persons/207913081#sci     
https://orcid.org/0000-0001-9990-6467

# How to use   
After starting the program, you need to enter the signature of the graph you want to work with in the "Circulant" field. At the moment, the program can only work with circulant graphs.
The graph signature is entered in the following format: __N s1 s2 ... sn__
```
N - nodes count
s1 s2 ... sn - generatrices, write with spaces
```
After the signature of the graph is set, you need to call the command __Graph->Create topology__. At this stage, the graph is drawn.
To generate routes, select the command __Graph->Generate all routes__. By default, routes are generated only based on the Deixtra algorithm. To enable generation of routes based on other algorithms, select them in the __Graph->Routing Algorithms__ tab. For all algorithms selected for generation, a tab is created on the right side of the program.
After successful generation of routes, the list of routes from the first node to all the others will be displayed in the tabs of the algorithms. By double-clicking the right mouse button on the route of interest, it is drawn on the graph.
You can also enter an arbitrary route for rendering in the __Custom route__ field. The input format is the same as that in which the generated routes are displayed.
To save the graph image, select the command __Graph->Save topology image__.
The display of the graph and routes can be configured by calling the command __File->Settings__. For most settings, the ability to preview the rendering is implemented.

The main parameters that affect the view ot the graph:
1. Line thickness of the graph – changes the line thickness used to draw the graph (node and edge);
2. Node marker size – changes the diameter of the drawn node marker;
3. Font signature nodes;
4. Node label offset – sets how close labels will be placed to the graph;
5. Alternative rendering of generators - when checked, draws generators in the form of an arc. If the checkbox is not set, then all generators are drawn as straight lines. __Note:__ Alternative rendering of generators works correctly only for circulants of the form C(N; s1, s2, s3) with more than 30 nodes.

After entering all the necessary parameters and generating routes, you can generate files for low-level modeling by selecting the appropriate algorithm in the __Generate__ tab.        

# Usage
The results of this project was successfully used in:
1. E. A. Monakhova, O. G. Monakhov and A. Y. Romanov, "Routing Algorithms in Optimal Degree Four Circulant Networks Based on Relative Addressing: Comparative Analysis for Networks-on-Chip," in IEEE Transactions on Network Science and Engineering, vol. 10, no. 1, pp. 413-425, 1 Jan.-Feb. 2023, doi: 10.1109/TNSE.2022.3211985.        
2. O. G. Monakhov, E. A. Monakhova, A. Y. Romanov, A. M. Sukhov and E. V. Lezhnev, "Adaptive Dynamic Shortest Path Search Algorithm in Networks-on-Chip Based on Circulant Topologies," in IEEE Access, vol. 9, pp. 160836-160846, 2021, doi: 10.1109/ACCESS.2021.3131635.        
3. E. A. Monakhova, A. Y. Romanov and E. V. Lezhnev, "Shortest Path Search Algorithm in Optimal Two-Dimensional Circulant Networks: Implementation for Networks-on-Chip," in IEEE Access, vol. 8, pp. 215010-215019, 2020, doi: 10.1109/ACCESS.2020.3040323.        
4. E. Monakhova, O. Monakhov, E. Lezhnev and A. Romanov, "Optimal Routing Algorithm in Dense Gaussian Networks-on-Chip," 2022 International Conference on Electrical, Computer, Communications and Mechatronics Engineering (ICECCME), Maldives, Maldives, 2022, pp. 1-6, doi: 10.1109/ICECCME55909.2022.9988159.
5. etc.

# RUS
**Генератор Verilog кода подсистемы связи для сетей на кристалле**
    
Программа позволяет видуализировать циркулянтные графы, производить поиск кратчайших маршрутов на основе алгоритма Дейкстры, а также специализированных алгоритмов для циркулянтных графов.  
Информация о циркулянтных графах в публикации:    
[Development of routing algorithms in networks-on-chip based on two-dimensional optimal circulant topologies](https://www.sciencedirect.com/science/article/pii/S2405844020300281).
    
# Контакты    
elezhnev@hse.ru (Evgenii Lezhnev)     
https://www.hse.ru/en/org/persons/207913081#sci     
https://orcid.org/0000-0001-9990-6467

a.romanov@hse.ru (Aleksandr Romanov, PhD)     
https://www.hse.ru/en/staff/a.romanov#sci   
https://www.researchgate.net/profile/Aleksandr-Romanov

# Работа с программой   
После запуска программы необходимо в поле "Циркулянт" ввести сигнатуру графа, с которым нужно работать. На данный момент программа умеет работать только с циркулянтными графами.  
Сигнатура графа вводится в следующем формате: __N s1 s2 ... sn__
```
N - количество узлов в сети
s1 s2 ... sn - список образующих графа через пробел
```
После того как сигнатура графа задана нужно вызвать команду __Граф->Создать топологию__. На этом этапе происходит отрисовка графа.  
Для генерации маршрутов необходимо выбрать команду __Граф->Сгенерировать все маршруты__.  По Умолчанию генерируются маршруты только на основе алгоритма Декстры. Для включения генерации маршрутов на оснвое других алгоритмов необходимо их выбрать во вкладке __Граф->Алгоритмы маршрутизации__. Для всехвыбранных к генерации алгоритмов создается вкладка в правой части программы.  
После удачной генерации маршрутов во вкладках алгоритмов будет отображен их список от первого узла ко всем остальным. Двойным нажатием правой кнопкой мыши на интересующий маршрут производится его отрисовка на графе.  
Также в поле __Собственный маршрут__ можно ввести для отрисовки произвольный маршрут. Формат ввода совпадает с тем, в котором отображаются сгенерированный маршруты.  
Для сохранения изображения графа необходимо выбрать команду __Граф->Сохранить изображение топологии__.  
Отображение графа и маршрутов можно настраивать через вызов команды __Файл->Настройки__. Для большинства настроек реализована возможность предварительного просмотра отрисовки.  

Основные параметры, которые влияют на красоту отображения:
1. Толщина линии графа – именяет толщину линии, которой рисуется граф (узел и ребро);
2. Размер маркера узла – изменяет диаметр рисуемого маркера узла;
3. Шрифт подписи узлов;
4. Смещение подписи узлов – устанавливает на сколько близко к графу будут размещены подписи;
5. Альтернативная отрисовка образующих – при установленной галочке рисует образующие в виде дуги. Если галочка не установлена – то все образующие рисуются в виде прямых линий. __Примечание:__ Альтернативная отрисовка образующих корректно работает только для циркулянтов вида C(N; s1, s2, s3) с количеством узлов более 30.  

После ввода всех необходимых параметров и генерации маршрутов можно производить генерацию файллов для низкоуровневого моделирования, путем выбора сообветствующего алгоритма во вкладке __Сгенерировать__.  
