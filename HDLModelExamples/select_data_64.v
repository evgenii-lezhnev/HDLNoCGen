`define N 8		/* для хранения количества роутеров и эмуряции пакета */
`define N2 15   /* это размер входящего и выходящего пакетов - 1 бит для эмуляции и K*2 бит для передачи двух чисел (шагов по первой и по второй образующим)*/
`define K 7		// на 1 меньше чем N
`define BIT 7	// сколько нужно бит для хранения количества роутеров в сети, для 25 роутеров равно 5

module select_data_64(
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
	out_router37,
	out_router38,
	out_router39,
	out_router40,
	out_router41,
	out_router42,
	out_router43,
	out_router44,
	out_router45,
	out_router46,
	out_router47,
	out_router48,
	out_router49,
	out_router50,
	out_router51,
	out_router52,
	out_router53,
	out_router54,
	out_router55,
	out_router56,
	out_router57,
	out_router58,
	out_router59,
	out_router60,
	out_router61,
	out_router62,
	out_router63,
	out_router64,
	
	
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
	output reg[`N2-1:0] out_router37;
	output reg[`N2-1:0] out_router38;
	output reg[`N2-1:0] out_router39;
	output reg[`N2-1:0] out_router40;
	output reg[`N2-1:0] out_router41;
	output reg[`N2-1:0] out_router42;
	output reg[`N2-1:0] out_router43;
	output reg[`N2-1:0] out_router44;
	output reg[`N2-1:0] out_router45;
	output reg[`N2-1:0] out_router46;
	output reg[`N2-1:0] out_router47;
	output reg[`N2-1:0] out_router48;
	output reg[`N2-1:0] out_router49;
	output reg[`N2-1:0] out_router50;
	output reg[`N2-1:0] out_router51;
	output reg[`N2-1:0] out_router52;
	output reg[`N2-1:0] out_router53;
	output reg[`N2-1:0] out_router54;
	output reg[`N2-1:0] out_router55;
	output reg[`N2-1:0] out_router56;
	output reg[`N2-1:0] out_router57;
	output reg[`N2-1:0] out_router58;
	output reg[`N2-1:0] out_router59;
	output reg[`N2-1:0] out_router60;
	output reg[`N2-1:0] out_router61;
	output reg[`N2-1:0] out_router62;
	output reg[`N2-1:0] out_router63;
	output reg[`N2-1:0] out_router64;
	
	output reg[6:0] hex_data;
	output reg[6:0] hex_router;
	
	reg[`N2-2:0] data = `K'b00000;
	reg[`N2-2:0] router = `BIT'b00000;
	reg flag_key_inc = 1'b0;
	reg flag_key_dec = 1'b0;
	
	reg[959:0] out_to_router;  // размерность определяется как N*колво узлов сети
	
	always@(posedge clk)
	begin
		if(sw_on == 1'b1)
		begin
			out_to_router = (960'b0 + {1'b1, data}) << router*`N2;
			
			out_router1 = out_to_router[14:0];
out_router2 = out_to_router[29:15];
out_router3 = out_to_router[44:30];
out_router4 = out_to_router[59:45];
out_router5 = out_to_router[74:60];
out_router6 = out_to_router[89:75];
out_router7 = out_to_router[104:90];
out_router8 = out_to_router[119:105];
out_router9 = out_to_router[134:120];
out_router10 = out_to_router[149:135];
out_router11 = out_to_router[164:150];
out_router12 = out_to_router[179:165];
out_router13 = out_to_router[194:180];
out_router14 = out_to_router[209:195];
out_router15 = out_to_router[224:210];
out_router16 = out_to_router[239:225];
out_router17 = out_to_router[254:240];
out_router18 = out_to_router[269:255];
out_router19 = out_to_router[284:270];
out_router20 = out_to_router[299:285];
out_router21 = out_to_router[314:300];
out_router22 = out_to_router[329:315];
out_router23 = out_to_router[344:330];
out_router24 = out_to_router[359:345];
out_router25 = out_to_router[374:360];
out_router26 = out_to_router[389:375];
out_router27 = out_to_router[404:390];
out_router28 = out_to_router[419:405];
out_router29 = out_to_router[434:420];
out_router30 = out_to_router[449:435];
out_router31 = out_to_router[464:450];
out_router32 = out_to_router[479:465];
out_router33 = out_to_router[494:480];
out_router34 = out_to_router[509:495];
out_router35 = out_to_router[524:510];
out_router36 = out_to_router[539:525];
out_router37 = out_to_router[554:540];
out_router38 = out_to_router[569:555];
out_router39 = out_to_router[584:570];
out_router40 = out_to_router[599:585];
out_router41 = out_to_router[614:600];
out_router42 = out_to_router[629:615];
out_router43 = out_to_router[644:630];
out_router44 = out_to_router[659:645];
out_router45 = out_to_router[674:660];
out_router46 = out_to_router[689:675];
out_router47 = out_to_router[704:690];
out_router48 = out_to_router[719:705];
out_router49 = out_to_router[734:720];
out_router50 = out_to_router[749:735];
out_router51 = out_to_router[764:750];
out_router52 = out_to_router[779:765];
out_router53 = out_to_router[794:780];
out_router54 = out_to_router[809:795];
out_router55 = out_to_router[824:810];
out_router56 = out_to_router[839:825];
out_router57 = out_to_router[854:840];
out_router58 = out_to_router[869:855];
out_router59 = out_to_router[884:870];
out_router60 = out_to_router[899:885];
out_router61 = out_to_router[914:900];
out_router62 = out_to_router[929:915];
out_router63 = out_to_router[944:930];
out_router64 = out_to_router[959:945];




		end
		else
		begin
			out_to_router = 960'b0;
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
	