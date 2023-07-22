`define N 5		/* для хранения количества роутеров и эмуряции пакета */
`define N2 9   /* это размер входящего и выходящего пакетов - 1 бит для эмуляции и K*2 бит для передачи двух чисел (шагов по первой и по второй образующим)*/
`define N_COUNT 8  /* это количество роутеров с отсчетом с нулевого, поэтому это значение всегда будет на один меньше от счетного количества*/

module toplevel_apo_9_nodes(
	clk,
	
	out_data,
	sw_on,
	sw_sel_data,
	sw_sel_router,
	key_inc,
	key_dec,
	
	hex_data,
	hex_router
);
	input clk;
	input sw_on;
	input sw_sel_data;
	input sw_sel_router;
	input key_inc;
	input key_dec;
	
	output wire[127:0] out_data;
	output wire[6:0] hex_data;
	output wire[6:0] hex_router;
	
	
	wire[`N2-1:0] out_router1;
	wire[`N2-1:0] out_router2;
	wire[`N2-1:0] out_router3;
	wire[`N2-1:0] out_router4;
	wire[`N2-1:0] out_router5;
	wire[`N2-1:0] out_router6;
	wire[`N2-1:0] out_router7;
	wire[`N2-1:0] out_router8;
	wire[`N2-1:0] out_router9;

	
	wire[`N2-1:0] r_minR[0:`N_COUNT];// размерности элементов из массива количеством
	wire[`N2-1:0] r_maxR[0:`N_COUNT];
	wire[`N2-1:0] r_minL[0:`N_COUNT];
	wire[`N2-1:0] r_maxL[0:`N_COUNT];

	select_data_9 sel (.clk(clk), .sw_on(sw_on), .sw_sel_data(sw_sel_data), .sw_sel_router(sw_sel_router), .key_inc(key_inc), .key_dec(key_dec),
							.out_router1(out_router1), .out_router2(out_router2), .out_router3(out_router3), .out_router4(out_router4), .out_router5(out_router5), 
							.out_router6(out_router6), .out_router7(out_router7), .out_router8(out_router8), .out_router9(out_router9), 	
							.hex_data(hex_data), .hex_router(hex_router));
	
	
	apo_router_9_nodes r1  ( .clk(clk), .router_name(4'b0000), .in_free(out_router1), .in_r1R(r_minL[2]), .in_r2R(r_maxL[3]), .in_r1L(r_minR[7]), .in_r2L(r_maxR[6]), .out_r1R(r_minR[0]), .out_r2R(r_maxR[0]), .out_r1L(r_minL[0]), .out_r2L(r_maxL[0]), .out_data(out_data[0]) );
	apo_router_9_nodes r2  ( .clk(clk), .router_name(4'b0001), .in_free(out_router2), .in_r1R(r_minL[3]), .in_r2R(r_maxL[4]), .in_r1L(r_minR[8]), .in_r2L(r_maxR[7]), .out_r1R(r_minR[1]), .out_r2R(r_maxR[1]), .out_r1L(r_minL[1]), .out_r2L(r_maxL[1]), .out_data(out_data[1]) );
	apo_router_9_nodes r3  ( .clk(clk), .router_name(4'b0010), .in_free(out_router3), .in_r1R(r_minL[4]), .in_r2R(r_maxL[5]), .in_r1L(r_minR[0]), .in_r2L(r_maxR[8]), .out_r1R(r_minR[2]), .out_r2R(r_maxR[2]), .out_r1L(r_minL[2]), .out_r2L(r_maxL[2]), .out_data(out_data[2]) );
	apo_router_9_nodes r4  ( .clk(clk), .router_name(4'b0011), .in_free(out_router4), .in_r1R(r_minL[5]), .in_r2R(r_maxL[6]), .in_r1L(r_minR[1]), .in_r2L(r_maxR[0]), .out_r1R(r_minR[3]), .out_r2R(r_maxR[3]), .out_r1L(r_minL[3]), .out_r2L(r_maxL[3]), .out_data(out_data[3]) );
	apo_router_9_nodes r5  ( .clk(clk), .router_name(4'b0100), .in_free(out_router5), .in_r1R(r_minL[6]), .in_r2R(r_maxL[7]), .in_r1L(r_minR[2]), .in_r2L(r_maxR[1]), .out_r1R(r_minR[4]), .out_r2R(r_maxR[4]), .out_r1L(r_minL[4]), .out_r2L(r_maxL[4]), .out_data(out_data[4]) );
	apo_router_9_nodes r6  ( .clk(clk), .router_name(4'b0101), .in_free(out_router6), .in_r1R(r_minL[7]), .in_r2R(r_maxL[8]), .in_r1L(r_minR[3]), .in_r2L(r_maxR[2]), .out_r1R(r_minR[5]), .out_r2R(r_maxR[5]), .out_r1L(r_minL[5]), .out_r2L(r_maxL[5]), .out_data(out_data[5]) );
	apo_router_9_nodes r7  ( .clk(clk), .router_name(4'b0110), .in_free(out_router7), .in_r1R(r_minL[8]), .in_r2R(r_maxL[0]), .in_r1L(r_minR[4]), .in_r2L(r_maxR[3]), .out_r1R(r_minR[6]), .out_r2R(r_maxR[6]), .out_r1L(r_minL[6]), .out_r2L(r_maxL[6]), .out_data(out_data[6]) );
	apo_router_9_nodes r8  ( .clk(clk), .router_name(4'b0111), .in_free(out_router8), .in_r1R(r_minL[0]), .in_r2R(r_maxL[1]), .in_r1L(r_minR[5]), .in_r2L(r_maxR[4]), .out_r1R(r_minR[7]), .out_r2R(r_maxR[7]), .out_r1L(r_minL[7]), .out_r2L(r_maxL[7]), .out_data(out_data[7]) );
	apo_router_9_nodes r9  ( .clk(clk), .router_name(4'b1000), .in_free(out_router9), .in_r1R(r_minL[1]), .in_r2R(r_maxL[2]), .in_r1L(r_minR[6]), .in_r2L(r_maxR[5]), .out_r1R(r_minR[8]), .out_r2R(r_maxR[8]), .out_r1L(r_minL[8]), .out_r2L(r_maxL[8]), .out_data(out_data[8]) );
	
endmodule
