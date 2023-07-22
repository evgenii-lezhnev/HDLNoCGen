`define N 4		/* для хранения количества роутеров и эмуряции пакета */
`define N2 7   /* это размер входящего и выходящего пакетов - 1 бит для эмуляции и K*2 бит для передачи двух чисел (шагов по первой и по второй образующим)*/
`define K 3		// на 1 меньше чем N
`define BIT 4	// сколько нужно бит для хранения количества роутеров в сети, для 5 роутеров равно 3

module select_data_5(
	clk,
	sw_on,			// вкл или выкл подачи значения в сеть
	sw_sel_data,	// установка подаваемого значения
	sw_sel_router,	// установка номера роутера на кот подается значение
	key_inc,			// увеличение устанавливаемого значения
	key_dec,			// уменьшение устанавливаемого значения
	
	out_router1,	// значения которые передаются на роутеры.
	out_router2,	// только в одном из них будет входное значение
	out_router3,
	out_router4,
	out_router5,
	
	hex_data,
	hex_router
	
);
	input clk;
	input sw_on;
	input sw_sel_data;
	input sw_sel_router;
	input key_inc;
	input key_dec;
	
	output reg[`N2-1:0] out_router1;
	output reg[`N2-1:0] out_router2;
	output reg[`N2-1:0] out_router3;
	output reg[`N2-1:0] out_router4;
	output reg[`N2-1:0] out_router5;
	
	output reg[6:0] hex_data;
	output reg[6:0] hex_router;
	
	reg[`N2-2:0] data = `K'b00000;
	reg[`N2-2:0] router = `BIT'b00000;
	reg flag_key_inc = 1'b0;
	reg flag_key_dec = 1'b0;
	
	reg[34:0] out_to_router;  // размерность определяется как N*колво узлов сети
	
	always@(posedge clk)
	begin
		if(sw_on == 1'b1)
		begin
			out_to_router = (35'b0 + {1'b1, data}) << router*`N2;
			
			out_router1  = out_to_router[6:0];
			out_router2  = out_to_router[13:7];
			out_router3  = out_to_router[20:14];
			out_router4  = out_to_router[27:21];
			out_router5  = out_to_router[34:28];
		end
		else
		begin
			out_to_router = 35'b0;
		end
		
		if(sw_sel_data == 1'b1)
		begin
			if(key_inc == 1'b1 && flag_key_inc == 1'b0)
			begin
				data = data + 1'b1;
				flag_key_inc = 1'b1;
			end
			if(key_inc == 1'b0)
			begin
				flag_key_inc = 1'b0;
			end
			if(key_dec == 1'b1 && flag_key_dec == 1'b0)
			begin
				data = data - 1'b1;
				flag_key_dec = 1'b1;
			end
			if(key_dec == 1'b0)
			begin
				flag_key_dec = 1'b0;
			end
		end
		
		if(sw_sel_router == 1'b1)
		begin
			if(key_inc == 1'b1 && flag_key_inc == 1'b0)
			begin
				router = router + 1'b1;
				flag_key_inc = 1'b1;
			end
			if(key_inc == 1'b0)
			begin
				flag_key_inc = 1'b0;
			end
			if(key_dec == 1'b1 && flag_key_dec == 1'b0)
			begin
				router = router - 1'b1;
				flag_key_dec = 1'b1;
			end
			if(key_dec == 1'b0)
			begin
				flag_key_dec = 1'b0;
			end
		end

//================================================================================
//================================================================================
		case(data)
			5'b00000:
				hex_data = ~7'b1111110;		//0
			5'b00001:
				hex_data = ~7'b0110000;		//1
			5'b00010:
				hex_data = ~7'b1101101;		//2
			5'b00011:
				hex_data = ~7'b1111001;		//3
			5'b00100:
				hex_data = ~7'b0110011;		//4
			5'b00101:
				hex_data = ~7'b1011011;		//5
			5'b00110:
				hex_data = ~7'b1011111;		//6
			5'b00111:
				hex_data = ~7'b1110000;		//7
			5'b01000:
				hex_data = ~7'b1111111;		//8
			5'b01001:
				hex_data = ~7'b1111011;		//9
		endcase
		
		case(router)
			5'b00000:
				hex_router = ~7'b1111110;	//0
			5'b00001:
				hex_router = ~7'b0110000;	//1
			5'b00010:
				hex_router = ~7'b1101101;	//2
			5'b00011:
				hex_router = ~7'b1111001;	//3
			5'b00100:
				hex_router = ~7'b0110011;	//4
			5'b00101:
				hex_router = ~7'b1011011;	//5
			5'b00110:
				hex_router = ~7'b1011111;	//6
			5'b00111:
				hex_router = ~7'b1110000;	//7
			5'b01000:
				hex_router = ~7'b1111111;	//8
			5'b01001:
				hex_router = ~7'b1111011;	//9
		endcase
	end
	
endmodule
	