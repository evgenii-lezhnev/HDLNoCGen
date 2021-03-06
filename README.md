# HDLNoCGen
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
