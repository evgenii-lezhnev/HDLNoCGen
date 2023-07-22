`define N 6
`define N2 11
`define N_COUNT 15

module toplevel_apo_16_nodes(
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
	wire[`N2-1:0] out_router10;
	wire[`N2-1:0] out_router11;
	wire[`N2-1:0] out_router12;
	wire[`N2-1:0] out_router13;
	wire[`N2-1:0] out_router14;
	wire[`N2-1:0] out_router15;
	wire[`N2-1:0] out_router16;

	wire[`N2-1:0] r_minR[0:`N_COUNT];	
	wire[`N2-1:0] r_maxR[0:`N_COUNT];	
	wire[`N2-1:0] r_minL[0:`N_COUNT];	
	wire[`N2-1:0] r_maxL[0:`N_COUNT];	

	select_data_16 sel (.clk(clk), .sw_on(sw_on), .sw_sel_data(sw_sel_data), .sw_sel_router(sw_sel_router), .key_inc(key_inc), .key_dec(key_dec), 
.out_router1(out_router1), 
.out_router2(out_router2), 
.out_router3(out_router3), 
.out_router4(out_router4), 
.out_router5(out_router5), 
.out_router6(out_router6), 
.out_router7(out_router7), 
.out_router8(out_router8), 
.out_router9(out_router9), 
.out_router10(out_router10), 
.out_router11(out_router11), 
.out_router12(out_router12), 
.out_router13(out_router13), 
.out_router14(out_router14), 
.out_router15(out_router15), 
.out_router16(out_router16),
.hex_data(hex_data), .hex_router(hex_router));

	apo_router_16_nodes r1 (.clk(clk), .router_name(4'd0), .in_free(out_router1), .in_r1R(r_minL[2]), .in_r2R(r_maxL[3]), .in_r1L(r_minR[14]), .in_r2L(r_maxR[13]), .out_r1R(r_minR[0]), .out_r2R(r_maxR[0]), .out_r1L(r_minL[0]), .out_r2L(r_maxL[0]), .out_data(out_data[0]));
	apo_router_16_nodes r2 (.clk(clk), .router_name(4'd1), .in_free(out_router2), .in_r1R(r_minL[3]), .in_r2R(r_maxL[4]), .in_r1L(r_minR[15]), .in_r2L(r_maxR[14]), .out_r1R(r_minR[1]), .out_r2R(r_maxR[1]), .out_r1L(r_minL[1]), .out_r2L(r_maxL[1]), .out_data(out_data[1]));
	apo_router_16_nodes r3 (.clk(clk), .router_name(4'd2), .in_free(out_router3), .in_r1R(r_minL[4]), .in_r2R(r_maxL[5]), .in_r1L(r_minR[0]), .in_r2L(r_maxR[15]), .out_r1R(r_minR[2]), .out_r2R(r_maxR[2]), .out_r1L(r_minL[2]), .out_r2L(r_maxL[2]), .out_data(out_data[2]));
	apo_router_16_nodes r4 (.clk(clk), .router_name(4'd3), .in_free(out_router4), .in_r1R(r_minL[5]), .in_r2R(r_maxL[6]), .in_r1L(r_minR[1]), .in_r2L(r_maxR[0]), .out_r1R(r_minR[3]), .out_r2R(r_maxR[3]), .out_r1L(r_minL[3]), .out_r2L(r_maxL[3]), .out_data(out_data[3]));
	apo_router_16_nodes r5 (.clk(clk), .router_name(4'd4), .in_free(out_router5), .in_r1R(r_minL[6]), .in_r2R(r_maxL[7]), .in_r1L(r_minR[2]), .in_r2L(r_maxR[1]), .out_r1R(r_minR[4]), .out_r2R(r_maxR[4]), .out_r1L(r_minL[4]), .out_r2L(r_maxL[4]), .out_data(out_data[4]));
	apo_router_16_nodes r6 (.clk(clk), .router_name(4'd5), .in_free(out_router6), .in_r1R(r_minL[7]), .in_r2R(r_maxL[8]), .in_r1L(r_minR[3]), .in_r2L(r_maxR[2]), .out_r1R(r_minR[5]), .out_r2R(r_maxR[5]), .out_r1L(r_minL[5]), .out_r2L(r_maxL[5]), .out_data(out_data[5]));
	apo_router_16_nodes r7 (.clk(clk), .router_name(4'd6), .in_free(out_router7), .in_r1R(r_minL[8]), .in_r2R(r_maxL[9]), .in_r1L(r_minR[4]), .in_r2L(r_maxR[3]), .out_r1R(r_minR[6]), .out_r2R(r_maxR[6]), .out_r1L(r_minL[6]), .out_r2L(r_maxL[6]), .out_data(out_data[6]));
	apo_router_16_nodes r8 (.clk(clk), .router_name(4'd7), .in_free(out_router8), .in_r1R(r_minL[9]), .in_r2R(r_maxL[10]), .in_r1L(r_minR[5]), .in_r2L(r_maxR[4]), .out_r1R(r_minR[7]), .out_r2R(r_maxR[7]), .out_r1L(r_minL[7]), .out_r2L(r_maxL[7]), .out_data(out_data[7]));
	apo_router_16_nodes r9 (.clk(clk), .router_name(4'd8), .in_free(out_router9), .in_r1R(r_minL[10]), .in_r2R(r_maxL[11]), .in_r1L(r_minR[6]), .in_r2L(r_maxR[5]), .out_r1R(r_minR[8]), .out_r2R(r_maxR[8]), .out_r1L(r_minL[8]), .out_r2L(r_maxL[8]), .out_data(out_data[8]));
	apo_router_16_nodes r10 (.clk(clk), .router_name(4'd9), .in_free(out_router10), .in_r1R(r_minL[11]), .in_r2R(r_maxL[12]), .in_r1L(r_minR[7]), .in_r2L(r_maxR[6]), .out_r1R(r_minR[9]), .out_r2R(r_maxR[9]), .out_r1L(r_minL[9]), .out_r2L(r_maxL[9]), .out_data(out_data[9]));
	apo_router_16_nodes r11 (.clk(clk), .router_name(4'd10), .in_free(out_router11), .in_r1R(r_minL[12]), .in_r2R(r_maxL[13]), .in_r1L(r_minR[8]), .in_r2L(r_maxR[7]), .out_r1R(r_minR[10]), .out_r2R(r_maxR[10]), .out_r1L(r_minL[10]), .out_r2L(r_maxL[10]), .out_data(out_data[10]));
	apo_router_16_nodes r12 (.clk(clk), .router_name(4'd11), .in_free(out_router12), .in_r1R(r_minL[13]), .in_r2R(r_maxL[14]), .in_r1L(r_minR[9]), .in_r2L(r_maxR[8]), .out_r1R(r_minR[11]), .out_r2R(r_maxR[11]), .out_r1L(r_minL[11]), .out_r2L(r_maxL[11]), .out_data(out_data[11]));
	apo_router_16_nodes r13 (.clk(clk), .router_name(4'd12), .in_free(out_router13), .in_r1R(r_minL[14]), .in_r2R(r_maxL[15]), .in_r1L(r_minR[10]), .in_r2L(r_maxR[9]), .out_r1R(r_minR[12]), .out_r2R(r_maxR[12]), .out_r1L(r_minL[12]), .out_r2L(r_maxL[12]), .out_data(out_data[12]));
	apo_router_16_nodes r14 (.clk(clk), .router_name(4'd13), .in_free(out_router14), .in_r1R(r_minL[15]), .in_r2R(r_maxL[0]), .in_r1L(r_minR[11]), .in_r2L(r_maxR[10]), .out_r1R(r_minR[13]), .out_r2R(r_maxR[13]), .out_r1L(r_minL[13]), .out_r2L(r_maxL[13]), .out_data(out_data[13]));
	apo_router_16_nodes r15 (.clk(clk), .router_name(4'd14), .in_free(out_router15), .in_r1R(r_minL[0]), .in_r2R(r_maxL[1]), .in_r1L(r_minR[12]), .in_r2L(r_maxR[11]), .out_r1R(r_minR[14]), .out_r2R(r_maxR[14]), .out_r1L(r_minL[14]), .out_r2L(r_maxL[14]), .out_data(out_data[14]));
	apo_router_16_nodes r16 (.clk(clk), .router_name(4'd15), .in_free(out_router16), .in_r1R(r_minL[1]), .in_r2R(r_maxL[2]), .in_r1L(r_minR[13]), .in_r2L(r_maxR[12]), .out_r1R(r_minR[15]), .out_r2R(r_maxR[15]), .out_r1L(r_minL[15]), .out_r2L(r_maxL[15]), .out_data(out_data[15]));

endmodule

