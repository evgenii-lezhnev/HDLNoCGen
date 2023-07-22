`define N 4		/* для хранения количества роутеров и эмуряции пакета */
`define N2 7   /* это размер входящего и выходящего пакетов - 1 бит для эмуляции и K*2 бит для передачи двух чисел (шагов по первой и по второй образующим)*/
`define N_COUNT 4  /* это количество роутеров с отсчетом с нулевого, поэтому это значение всегда будет на один меньше от счетного количества*/

module toplevel_apo_5_nodes(
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

	
	wire[`N2-1:0] r_minR[0:`N_COUNT];// размерности элементов из массива количеством
	wire[`N2-1:0] r_maxR[0:`N_COUNT];
	wire[`N2-1:0] r_minL[0:`N_COUNT];
	wire[`N2-1:0] r_maxL[0:`N_COUNT];

	select_data_5 sel (.clk(clk), .sw_on(sw_on), .sw_sel_data(sw_sel_data), .sw_sel_router(sw_sel_router), .key_inc(key_inc), .key_dec(key_dec),
							.out_router1(out_router1), .out_router2(out_router2), .out_router3(out_router3), .out_router4(out_router4), .out_router5(out_router5),  	
							.hex_data(hex_data), .hex_router(hex_router));
	
	
	apo_router_5_nodes r1  ( .clk(clk), .router_name(3'b000), .in_free(out_router1), .in_r1R(r_minL[1]), .in_r2R(r_maxL[2]), .in_r1L(r_minR[4]), .in_r2L(r_maxR[3]), .out_r1R(r_minR[0]), .out_r2R(r_maxR[0]), .out_r1L(r_minL[0]), .out_r2L(r_maxL[0]), .out_data(out_data[0]) );
	apo_router_5_nodes r2  ( .clk(clk), .router_name(3'b001), .in_free(out_router2), .in_r1R(r_minL[2]), .in_r2R(r_maxL[3]), .in_r1L(r_minR[0]), .in_r2L(r_maxR[4]), .out_r1R(r_minR[1]), .out_r2R(r_maxR[1]), .out_r1L(r_minL[1]), .out_r2L(r_maxL[1]), .out_data(out_data[1]) );
	apo_router_5_nodes r3  ( .clk(clk), .router_name(3'b010), .in_free(out_router3), .in_r1R(r_minL[3]), .in_r2R(r_maxL[4]), .in_r1L(r_minR[1]), .in_r2L(r_maxR[0]), .out_r1R(r_minR[2]), .out_r2R(r_maxR[2]), .out_r1L(r_minL[2]), .out_r2L(r_maxL[2]), .out_data(out_data[2]) );
	apo_router_5_nodes r4  ( .clk(clk), .router_name(3'b011), .in_free(out_router4), .in_r1R(r_minL[4]), .in_r2R(r_maxL[0]), .in_r1L(r_minR[2]), .in_r2L(r_maxR[1]), .out_r1R(r_minR[3]), .out_r2R(r_maxR[3]), .out_r1L(r_minL[3]), .out_r2L(r_maxL[3]), .out_data(out_data[3]) );
	apo_router_5_nodes r5  ( .clk(clk), .router_name(3'b100), .in_free(out_router5), .in_r1R(r_minL[0]), .in_r2R(r_maxL[1]), .in_r1L(r_minR[3]), .in_r2L(r_maxR[2]), .out_r1R(r_minR[4]), .out_r2R(r_maxR[4]), .out_r1L(r_minL[4]), .out_r2L(r_maxL[4]), .out_data(out_data[4]) );

endmodule
