`define N 7		/* для хранения количества роутеров и эмуряции пакета */
`define N2 13   /* это размер входящего и выходящего пакетов - 1 бит для эмуляции и K*2 бит для передачи двух чисел (шагов по первой и по второй образующим)*/
`define K 6		// на 1 меньше чем N
`define BIT 6	// сколько нужно бит для хранения количества роутеров в сети, для 25 роутеров равно 5

module select_data_36(
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
	out_router6,
	out_router7,
	out_router8,
	out_router9,
	out_router10,
	out_router11,
	out_router12,
	out_router13,
	out_router14,
	out_router15,
	out_router16,
	out_router17,
	out_router18,
	out_router19,
	out_router20,
	out_router21,
	out_router22,
	out_router23,
	out_router24,
	out_router25,
	out_router26,
	out_router27,
	out_router28,
	out_router29,
	out_router30,
	out_router31,
	out_router32,
	out_router33,
	out_router34,
	out_router35,
	out_router36,
	
	
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
	output reg[`N2-1:0] out_router6;
	output reg[`N2-1:0] out_router7;
	output reg[`N2-1:0] out_router8;
	output reg[`N2-1:0] out_router9;
	output reg[`N2-1:0] out_router10;
	output reg[`N2-1:0] out_router11;
	output reg[`N2-1:0] out_router12;
	output reg[`N2-1:0] out_router13;
	output reg[`N2-1:0] out_router14;
	output reg[`N2-1:0] out_router15;
	output reg[`N2-1:0] out_router16;
	output reg[`N2-1:0] out_router17;
	output reg[`N2-1:0] out_router18;
	output reg[`N2-1:0] out_router19;
	output reg[`N2-1:0] out_router20;
	output reg[`N2-1:0] out_router21;
	output reg[`N2-1:0] out_router22;
	output reg[`N2-1:0] out_router23;
	output reg[`N2-1:0] out_router24;
	output reg[`N2-1:0] out_router25;
	output reg[`N2-1:0] out_router26;
	output reg[`N2-1:0] out_router27;
	output reg[`N2-1:0] out_router28;
	output reg[`N2-1:0] out_router29;
	output reg[`N2-1:0] out_router30;
	output reg[`N2-1:0] out_router31;
	output reg[`N2-1:0] out_router32;
	output reg[`N2-1:0] out_router33;
	output reg[`N2-1:0] out_router34;
	output reg[`N2-1:0] out_router35;
	output reg[`N2-1:0] out_router36;
	
	output reg[6:0] hex_data;
	output reg[6:0] hex_router;
	
	reg[`N2-2:0] data = `K'b00000;
	reg[`N2-2:0] router = `BIT'b00000;
	reg flag_key_inc = 1'b0;
	reg flag_key_dec = 1'b0;
	
	reg[467:0] out_to_router;  // размерность определяется как N*колво узлов сети
	
	always@(posedge clk)
	begin
		if(sw_on == 1'b1)
		begin
			out_to_router = (468'b0 + {1'b1, data}) << router*`N2;
			
			out_router1 = out_to_router[12:0];
			out_router2 = out_to_router[25:13];
			out_router3 = out_to_router[38:26];
			out_router4 = out_to_router[51:39];
			out_router5 = out_to_router[64:52];
			out_router6 = out_to_router[77:65];
			out_router7 = out_to_router[90:78];
			out_router8 = out_to_router[103:91];
			out_router9 = out_to_router[116:104];
			out_router10 = out_to_router[129:117];
			out_router11 = out_to_router[142:130];
			out_router12 = out_to_router[155:143];
			out_router13 = out_to_router[168:156];
			out_router14 = out_to_router[181:169];
			out_router15 = out_to_router[194:182];
			out_router16 = out_to_router[207:195];
			out_router17 = out_to_router[220:208];
			out_router18 = out_to_router[233:221];
			out_router19 = out_to_router[246:234];
			out_router20 = out_to_router[259:247];
			out_router21 = out_to_router[272:260];
			out_router22 = out_to_router[285:273];
			out_router23 = out_to_router[298:286];
			out_router24 = out_to_router[311:299];
			out_router25 = out_to_router[324:312];
			out_router26 = out_to_router[337:325];
			out_router27 = out_to_router[350:338];
			out_router28 = out_to_router[363:351];
			out_router29 = out_to_router[376:364];
			out_router30 = out_to_router[389:377];
			out_router31 = out_to_router[402:390];
			out_router32 = out_to_router[415:403];
			out_router33 = out_to_router[428:416];
			out_router34 = out_to_router[441:429];
			out_router35 = out_to_router[454:442];
			out_router36 = out_to_router[467:455];

		end
		else
		begin
			out_to_router = 468'b0;
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
	