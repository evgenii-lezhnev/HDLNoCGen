/* для циркулянта С(100; 7, 8), d=6 */
/* node_count = 9 */
`define K 8		/* для хранения количества роутеров, номеров роутеров, образующих нужно 4 бит */
`define N 9		/* для хранения количества роутеров и эмуряции пакета */
`define N2 17   /* это размер входящего и выходящего пакетов - 1 бит для эмуляции и K*2 бит для передачи двух чисел (шагов по первой и по второй образующим)*/

module apo_router_169_nodes(
// 2 образующие, следовательно должно быть 2 портов
	clk,				// тактовый сигнал
	router_name,	// номер роутера, задается для каждого роутера, поэтому и вводим снаружи
	in_free,			// порт т.н. вычислительного узла, от куда изначально подается сигнал 
	in_r1R,			// входы с правой стороны от меньшей образующей к большей
	in_r2R,
	in_r1L,			// входы с левой стороны от меньшей образующей к большей
	in_r2L,
	out_r1R,			// соответствующие входам выходы с правой и левой стороны
	out_r2R,
	out_r1L,
	out_r2L,
	out_data			// выход с роутера чтобы видеть на какой роутер пришло сообщение
);

	input 				 		clk; 							// тактовый сигнал
	input[`K-1:0]		 		router_name;				// номер роутера, задается для каждого роутера, поэтому и вводим снаружи
	input[`N2-1:0] 		 	in_free; 					// порт т.н. вычислительного узла, от куда изначально подается сигнал 
	input[`N2-1:0] 		 	in_r1R; 						// входы с правой стороны от меньшей образующей к большей
	input[`N2-1:0] 		 	in_r2R;
	input[`N2-1:0] 		 	in_r1L; 						// входы с левой стороны от меньшей образующей к большей
	input[`N2-1:0] 		 	in_r2L;
	output reg[`N2-1:0] 		out_r1R;						// соответствующие входам выходы с правой и левой стороны
	output reg[`N2-1:0] 		out_r2R;
	output reg[`N2-1:0] 		out_r1L;
	output reg[`N2-1:0] 		out_r2L;
	output reg 			 		out_data;					// выход с роутера чтобы видеть на какой роутер пришло сообщение
	
	reg signed[`K-1:0] n_count 	= `K'b10101001;		// количество узлов
	reg signed[`K-1:0] s1 			= `K'b00001001; 	// первая образующая
	reg 					 sgn 			= 1'b0; 			// флаг инвертирования направлений (=0 значения не инвертируются =1 значение инвертируется)
	reg					 flag_data 	= 1'b0; 			// флаг наличия сообщения в целом (=0 сообщения нет  =1 сообщение есть)
	reg					 flag_inph 	= 1'b0;			// флаг наличия сообщения из другого роутера (=0 сообщения нет  =1 сообщение есть)
	
	reg signed[`K-1:0] k; 								// значение из алгоритма
	reg signed[`K-1:0] alpha; 							// значение из алгоритма
	reg signed[`K-1:0] betta; 							// значение из алгоритма
	
	reg signed[`N2-2:0] end_data; 						// данные из пакета. если пакет приходит из ip ядра, то в пакете хранится номер узла назначения
																// если пакет приходит из другоро роутера, то в пакете харнятся количество шагов по малой и большой образующим
	reg signed[`K-1:0] s;
	reg signed[`K-1:0] result_1; 						// результирующие направления
	reg signed[`K-1:0] result_2;
	
	
	
	always@(posedge clk)
	begin
		// ==================================== получаем данные с входов
		begin
		if(    in_free >= `N2'b100000000000000)
		begin
			end_data = in_free;
			flag_data = 1'b1;
			flag_inph = 1'b0;
		end
		else if(in_r1R >= `N2'b10000000000000000)
		begin
			end_data = in_r1R;
			flag_data = 1'b1;
			flag_inph = 1'b1;
		end
		else if(in_r2R >= `N2'b10000000000000000)
		begin
			end_data = in_r2R;
			flag_data = 1'b1;
			flag_inph = 1'b1;
		end
		else if(in_r1L >= `N2'b10000000000000000)
		begin
			end_data = in_r1L;
			flag_data = 1'b1;
			flag_inph = 1'b1;
		end
		else if(in_r2L >= `N2'b10000000000000000)
		begin
			end_data = in_r2L;
			flag_data = 1'b1;
			flag_inph = 1'b1;
		end
		else
		begin
			flag_data = 1'b0;
			flag_inph = 1'b0;
		end
		end
		// ==================================== закончили получать данные с входов
		
		//Проверяю ест ли данные и на каких портах
		if(flag_data == 1'b1)
		begin	// данне на входе роутера есть
			if(flag_inph == 1'b1)
			begin // если я получил данные из роутера
				result_2 = end_data; 		// сколько передвигаться по малой образующей
				result_1 = end_data >> 4'b1000; 	// сколько передвигаться по большой образующей
				// и передвигаюсь передвигаюсь
			end
			else
			begin // если я получил данные из ip ядра
				s = end_data;
				if(s <= router_name)
				begin
					k = router_name - s;
					sgn = 1'b1;
				end
				else
				begin
					k = s - router_name;
					sgn = 1'b0;
				end
				if(k > (n_count>>1'b1))
				begin
					k = n_count - k;
					sgn = ~sgn;
				end
			
				betta = k % s1;
				alpha = k / s1 - betta;
				
				if((alpha >= (betta - s1)) && (alpha <= s1))
				begin
					result_1 = alpha;
					result_2 = betta;
				end
				else if(alpha < (betta - s1))
				begin
					result_1 = alpha + s1 + 1'b1;
					result_2 = betta - s1;
				end
				else
				begin
					result_1 = alpha - s1 - 1'b1;
					result_2 = betta + s1;
				end
				
				if(sgn == 1'b1)
				begin
					result_1 = `k'b0 - result_1;
					result_2 = `k'b0 - result_2;
				end
			end // получил значения для движения по образующим
		
		
			// теперь выбираю куда идти и изменяю соответственно значения result_1 и result_2
			if(result_1 != `k'b0)
			begin // если есть шаги по первой образующей
				if(result_1 > `k'b0)
				begin
					result_1 = result_1 - 1'b1;
					out_data = 1'b0;
				
					out_r1R = {1'b1, result_1, result_2};
					out_r2R = `N2'b0;
					out_r1L = `N2'b0;
					out_r2L = `N2'b0;
				end
				else
				begin
					result_1 = result_1 + 1'b1;
					out_data = 1'b0;
				
					out_r1R = `N2'b0;
					out_r2R = `N2'b0;
					out_r1L = {1'b1, result_1, result_2};
					out_r2L = `N2'b0;
				end
			end
			else if(result_2 != `k'b0)
			begin
				if(result_2 > `k'b0)
				begin
					result_2 = result_2 - 1'b1;
					out_data = 1'b0;
				
					out_r1R = `N2'b0;
					out_r2R = {1'b1, result_1, result_2};
					out_r1L = `N2'b0;
					out_r2L = `N2'b0;
				end
				else
				begin
					result_2 = result_2 + 1'b1;
					out_data = 1'b0;
				
					out_r1R = `N2'b0;
					out_r2R = `N2'b0;
					out_r1L = `N2'b0;
					out_r2L = {1'b1, result_1, result_2};
				end
			end
			else
			begin
				out_data = 1'b1;
			
				out_r1R = `N2'b0;
				out_r2R = `N2'b0;
				out_r1L = `N2'b0;
				out_r2L = `N2'b0;
			end
		end
		else // данных на входах роутера нет
		begin
			out_data = 1'b0;
			
			out_r1R = `N2'b0;
			out_r2R = `N2'b0;
			out_r1L = `N2'b0;
			out_r2L = `N2'b0;
		end
	end
endmodule
