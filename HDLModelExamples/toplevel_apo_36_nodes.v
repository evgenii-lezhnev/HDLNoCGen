`define N 7
`define N2 13
`define N_COUNT 35

module toplevel_apo_36_nodes(
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
	wire[`N2-1:0] out_router17;
	wire[`N2-1:0] out_router18;
	wire[`N2-1:0] out_router19;
	wire[`N2-1:0] out_router20;
	wire[`N2-1:0] out_router21;
	wire[`N2-1:0] out_router22;
	wire[`N2-1:0] out_router23;
	wire[`N2-1:0] out_router24;
	wire[`N2-1:0] out_router25;
	wire[`N2-1:0] out_router26;
	wire[`N2-1:0] out_router27;
	wire[`N2-1:0] out_router28;
	wire[`N2-1:0] out_router29;
	wire[`N2-1:0] out_router30;
	wire[`N2-1:0] out_router31;
	wire[`N2-1:0] out_router32;
	wire[`N2-1:0] out_router33;
	wire[`N2-1:0] out_router34;
	wire[`N2-1:0] out_router35;
	wire[`N2-1:0] out_router36;

	wire[`N2-1:0] r_minR[0:`N_COUNT];	
	wire[`N2-1:0] r_maxR[0:`N_COUNT];	
	wire[`N2-1:0] r_minL[0:`N_COUNT];	
	wire[`N2-1:0] r_maxL[0:`N_COUNT];	

	select_data_36 sel (.clk(clk), .sw_on(sw_on), .sw_sel_data(sw_sel_data), .sw_sel_router(sw_sel_router), .key_inc(key_inc), .key_dec(key_dec), 
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
.out_router17(out_router17), 
.out_router18(out_router18), 
.out_router19(out_router19), 
.out_router20(out_router20), 
.out_router21(out_router21), 
.out_router22(out_router22), 
.out_router23(out_router23), 
.out_router24(out_router24), 
.out_router25(out_router25), 
.out_router26(out_router26), 
.out_router27(out_router27), 
.out_router28(out_router28), 
.out_router29(out_router29), 
.out_router30(out_router30), 
.out_router31(out_router31), 
.out_router32(out_router32), 
.out_router33(out_router33), 
.out_router34(out_router34), 
.out_router35(out_router35), 
.out_router36(out_router36),
.hex_data(hex_data), .hex_router(hex_router));

	apo_router_36_nodes r1 (.clk(clk), .router_name(6'd0), .in_free(out_router1), .in_r1R(r_minL[4]), .in_r2R(r_maxL[5]), .in_r1L(r_minR[32]), .in_r2L(r_maxR[31]), .out_r1R(r_minR[0]), .out_r2R(r_maxR[0]), .out_r1L(r_minL[0]), .out_r2L(r_maxL[0]), .out_data(out_data[0]));
	apo_router_36_nodes r2 (.clk(clk), .router_name(6'd1), .in_free(out_router2), .in_r1R(r_minL[5]), .in_r2R(r_maxL[6]), .in_r1L(r_minR[33]), .in_r2L(r_maxR[32]), .out_r1R(r_minR[1]), .out_r2R(r_maxR[1]), .out_r1L(r_minL[1]), .out_r2L(r_maxL[1]), .out_data(out_data[1]));
	apo_router_36_nodes r3 (.clk(clk), .router_name(6'd2), .in_free(out_router3), .in_r1R(r_minL[6]), .in_r2R(r_maxL[7]), .in_r1L(r_minR[34]), .in_r2L(r_maxR[33]), .out_r1R(r_minR[2]), .out_r2R(r_maxR[2]), .out_r1L(r_minL[2]), .out_r2L(r_maxL[2]), .out_data(out_data[2]));
	apo_router_36_nodes r4 (.clk(clk), .router_name(6'd3), .in_free(out_router4), .in_r1R(r_minL[7]), .in_r2R(r_maxL[8]), .in_r1L(r_minR[35]), .in_r2L(r_maxR[34]), .out_r1R(r_minR[3]), .out_r2R(r_maxR[3]), .out_r1L(r_minL[3]), .out_r2L(r_maxL[3]), .out_data(out_data[3]));
	apo_router_36_nodes r5 (.clk(clk), .router_name(6'd4), .in_free(out_router5), .in_r1R(r_minL[8]), .in_r2R(r_maxL[9]), .in_r1L(r_minR[0]), .in_r2L(r_maxR[35]), .out_r1R(r_minR[4]), .out_r2R(r_maxR[4]), .out_r1L(r_minL[4]), .out_r2L(r_maxL[4]), .out_data(out_data[4]));
	apo_router_36_nodes r6 (.clk(clk), .router_name(6'd5), .in_free(out_router6), .in_r1R(r_minL[9]), .in_r2R(r_maxL[10]), .in_r1L(r_minR[1]), .in_r2L(r_maxR[0]), .out_r1R(r_minR[5]), .out_r2R(r_maxR[5]), .out_r1L(r_minL[5]), .out_r2L(r_maxL[5]), .out_data(out_data[5]));
	apo_router_36_nodes r7 (.clk(clk), .router_name(6'd6), .in_free(out_router7), .in_r1R(r_minL[10]), .in_r2R(r_maxL[11]), .in_r1L(r_minR[2]), .in_r2L(r_maxR[1]), .out_r1R(r_minR[6]), .out_r2R(r_maxR[6]), .out_r1L(r_minL[6]), .out_r2L(r_maxL[6]), .out_data(out_data[6]));
	apo_router_36_nodes r8 (.clk(clk), .router_name(6'd7), .in_free(out_router8), .in_r1R(r_minL[11]), .in_r2R(r_maxL[12]), .in_r1L(r_minR[3]), .in_r2L(r_maxR[2]), .out_r1R(r_minR[7]), .out_r2R(r_maxR[7]), .out_r1L(r_minL[7]), .out_r2L(r_maxL[7]), .out_data(out_data[7]));
	apo_router_36_nodes r9 (.clk(clk), .router_name(6'd8), .in_free(out_router9), .in_r1R(r_minL[12]), .in_r2R(r_maxL[13]), .in_r1L(r_minR[4]), .in_r2L(r_maxR[3]), .out_r1R(r_minR[8]), .out_r2R(r_maxR[8]), .out_r1L(r_minL[8]), .out_r2L(r_maxL[8]), .out_data(out_data[8]));
	apo_router_36_nodes r10 (.clk(clk), .router_name(6'd9), .in_free(out_router10), .in_r1R(r_minL[13]), .in_r2R(r_maxL[14]), .in_r1L(r_minR[5]), .in_r2L(r_maxR[4]), .out_r1R(r_minR[9]), .out_r2R(r_maxR[9]), .out_r1L(r_minL[9]), .out_r2L(r_maxL[9]), .out_data(out_data[9]));
	apo_router_36_nodes r11 (.clk(clk), .router_name(6'd10), .in_free(out_router11), .in_r1R(r_minL[14]), .in_r2R(r_maxL[15]), .in_r1L(r_minR[6]), .in_r2L(r_maxR[5]), .out_r1R(r_minR[10]), .out_r2R(r_maxR[10]), .out_r1L(r_minL[10]), .out_r2L(r_maxL[10]), .out_data(out_data[10]));
	apo_router_36_nodes r12 (.clk(clk), .router_name(6'd11), .in_free(out_router12), .in_r1R(r_minL[15]), .in_r2R(r_maxL[16]), .in_r1L(r_minR[7]), .in_r2L(r_maxR[6]), .out_r1R(r_minR[11]), .out_r2R(r_maxR[11]), .out_r1L(r_minL[11]), .out_r2L(r_maxL[11]), .out_data(out_data[11]));
	apo_router_36_nodes r13 (.clk(clk), .router_name(6'd12), .in_free(out_router13), .in_r1R(r_minL[16]), .in_r2R(r_maxL[17]), .in_r1L(r_minR[8]), .in_r2L(r_maxR[7]), .out_r1R(r_minR[12]), .out_r2R(r_maxR[12]), .out_r1L(r_minL[12]), .out_r2L(r_maxL[12]), .out_data(out_data[12]));
	apo_router_36_nodes r14 (.clk(clk), .router_name(6'd13), .in_free(out_router14), .in_r1R(r_minL[17]), .in_r2R(r_maxL[18]), .in_r1L(r_minR[9]), .in_r2L(r_maxR[8]), .out_r1R(r_minR[13]), .out_r2R(r_maxR[13]), .out_r1L(r_minL[13]), .out_r2L(r_maxL[13]), .out_data(out_data[13]));
	apo_router_36_nodes r15 (.clk(clk), .router_name(6'd14), .in_free(out_router15), .in_r1R(r_minL[18]), .in_r2R(r_maxL[19]), .in_r1L(r_minR[10]), .in_r2L(r_maxR[9]), .out_r1R(r_minR[14]), .out_r2R(r_maxR[14]), .out_r1L(r_minL[14]), .out_r2L(r_maxL[14]), .out_data(out_data[14]));
	apo_router_36_nodes r16 (.clk(clk), .router_name(6'd15), .in_free(out_router16), .in_r1R(r_minL[19]), .in_r2R(r_maxL[20]), .in_r1L(r_minR[11]), .in_r2L(r_maxR[10]), .out_r1R(r_minR[15]), .out_r2R(r_maxR[15]), .out_r1L(r_minL[15]), .out_r2L(r_maxL[15]), .out_data(out_data[15]));
	apo_router_36_nodes r17 (.clk(clk), .router_name(6'd16), .in_free(out_router17), .in_r1R(r_minL[20]), .in_r2R(r_maxL[21]), .in_r1L(r_minR[12]), .in_r2L(r_maxR[11]), .out_r1R(r_minR[16]), .out_r2R(r_maxR[16]), .out_r1L(r_minL[16]), .out_r2L(r_maxL[16]), .out_data(out_data[16]));
	apo_router_36_nodes r18 (.clk(clk), .router_name(6'd17), .in_free(out_router18), .in_r1R(r_minL[21]), .in_r2R(r_maxL[22]), .in_r1L(r_minR[13]), .in_r2L(r_maxR[12]), .out_r1R(r_minR[17]), .out_r2R(r_maxR[17]), .out_r1L(r_minL[17]), .out_r2L(r_maxL[17]), .out_data(out_data[17]));
	apo_router_36_nodes r19 (.clk(clk), .router_name(6'd18), .in_free(out_router19), .in_r1R(r_minL[22]), .in_r2R(r_maxL[23]), .in_r1L(r_minR[14]), .in_r2L(r_maxR[13]), .out_r1R(r_minR[18]), .out_r2R(r_maxR[18]), .out_r1L(r_minL[18]), .out_r2L(r_maxL[18]), .out_data(out_data[18]));
	apo_router_36_nodes r20 (.clk(clk), .router_name(6'd19), .in_free(out_router20), .in_r1R(r_minL[23]), .in_r2R(r_maxL[24]), .in_r1L(r_minR[15]), .in_r2L(r_maxR[14]), .out_r1R(r_minR[19]), .out_r2R(r_maxR[19]), .out_r1L(r_minL[19]), .out_r2L(r_maxL[19]), .out_data(out_data[19]));
	apo_router_36_nodes r21 (.clk(clk), .router_name(6'd20), .in_free(out_router21), .in_r1R(r_minL[24]), .in_r2R(r_maxL[25]), .in_r1L(r_minR[16]), .in_r2L(r_maxR[15]), .out_r1R(r_minR[20]), .out_r2R(r_maxR[20]), .out_r1L(r_minL[20]), .out_r2L(r_maxL[20]), .out_data(out_data[20]));
	apo_router_36_nodes r22 (.clk(clk), .router_name(6'd21), .in_free(out_router22), .in_r1R(r_minL[25]), .in_r2R(r_maxL[26]), .in_r1L(r_minR[17]), .in_r2L(r_maxR[16]), .out_r1R(r_minR[21]), .out_r2R(r_maxR[21]), .out_r1L(r_minL[21]), .out_r2L(r_maxL[21]), .out_data(out_data[21]));
	apo_router_36_nodes r23 (.clk(clk), .router_name(6'd22), .in_free(out_router23), .in_r1R(r_minL[26]), .in_r2R(r_maxL[27]), .in_r1L(r_minR[18]), .in_r2L(r_maxR[17]), .out_r1R(r_minR[22]), .out_r2R(r_maxR[22]), .out_r1L(r_minL[22]), .out_r2L(r_maxL[22]), .out_data(out_data[22]));
	apo_router_36_nodes r24 (.clk(clk), .router_name(6'd23), .in_free(out_router24), .in_r1R(r_minL[27]), .in_r2R(r_maxL[28]), .in_r1L(r_minR[19]), .in_r2L(r_maxR[18]), .out_r1R(r_minR[23]), .out_r2R(r_maxR[23]), .out_r1L(r_minL[23]), .out_r2L(r_maxL[23]), .out_data(out_data[23]));
	apo_router_36_nodes r25 (.clk(clk), .router_name(6'd24), .in_free(out_router25), .in_r1R(r_minL[28]), .in_r2R(r_maxL[29]), .in_r1L(r_minR[20]), .in_r2L(r_maxR[19]), .out_r1R(r_minR[24]), .out_r2R(r_maxR[24]), .out_r1L(r_minL[24]), .out_r2L(r_maxL[24]), .out_data(out_data[24]));
	apo_router_36_nodes r26 (.clk(clk), .router_name(6'd25), .in_free(out_router26), .in_r1R(r_minL[29]), .in_r2R(r_maxL[30]), .in_r1L(r_minR[21]), .in_r2L(r_maxR[20]), .out_r1R(r_minR[25]), .out_r2R(r_maxR[25]), .out_r1L(r_minL[25]), .out_r2L(r_maxL[25]), .out_data(out_data[25]));
	apo_router_36_nodes r27 (.clk(clk), .router_name(6'd26), .in_free(out_router27), .in_r1R(r_minL[30]), .in_r2R(r_maxL[31]), .in_r1L(r_minR[22]), .in_r2L(r_maxR[21]), .out_r1R(r_minR[26]), .out_r2R(r_maxR[26]), .out_r1L(r_minL[26]), .out_r2L(r_maxL[26]), .out_data(out_data[26]));
	apo_router_36_nodes r28 (.clk(clk), .router_name(6'd27), .in_free(out_router28), .in_r1R(r_minL[31]), .in_r2R(r_maxL[32]), .in_r1L(r_minR[23]), .in_r2L(r_maxR[22]), .out_r1R(r_minR[27]), .out_r2R(r_maxR[27]), .out_r1L(r_minL[27]), .out_r2L(r_maxL[27]), .out_data(out_data[27]));
	apo_router_36_nodes r29 (.clk(clk), .router_name(6'd28), .in_free(out_router29), .in_r1R(r_minL[32]), .in_r2R(r_maxL[33]), .in_r1L(r_minR[24]), .in_r2L(r_maxR[23]), .out_r1R(r_minR[28]), .out_r2R(r_maxR[28]), .out_r1L(r_minL[28]), .out_r2L(r_maxL[28]), .out_data(out_data[28]));
	apo_router_36_nodes r30 (.clk(clk), .router_name(6'd29), .in_free(out_router30), .in_r1R(r_minL[33]), .in_r2R(r_maxL[34]), .in_r1L(r_minR[25]), .in_r2L(r_maxR[24]), .out_r1R(r_minR[29]), .out_r2R(r_maxR[29]), .out_r1L(r_minL[29]), .out_r2L(r_maxL[29]), .out_data(out_data[29]));
	apo_router_36_nodes r31 (.clk(clk), .router_name(6'd30), .in_free(out_router31), .in_r1R(r_minL[34]), .in_r2R(r_maxL[35]), .in_r1L(r_minR[26]), .in_r2L(r_maxR[25]), .out_r1R(r_minR[30]), .out_r2R(r_maxR[30]), .out_r1L(r_minL[30]), .out_r2L(r_maxL[30]), .out_data(out_data[30]));
	apo_router_36_nodes r32 (.clk(clk), .router_name(6'd31), .in_free(out_router32), .in_r1R(r_minL[35]), .in_r2R(r_maxL[0]), .in_r1L(r_minR[27]), .in_r2L(r_maxR[26]), .out_r1R(r_minR[31]), .out_r2R(r_maxR[31]), .out_r1L(r_minL[31]), .out_r2L(r_maxL[31]), .out_data(out_data[31]));
	apo_router_36_nodes r33 (.clk(clk), .router_name(6'd32), .in_free(out_router33), .in_r1R(r_minL[0]), .in_r2R(r_maxL[1]), .in_r1L(r_minR[28]), .in_r2L(r_maxR[27]), .out_r1R(r_minR[32]), .out_r2R(r_maxR[32]), .out_r1L(r_minL[32]), .out_r2L(r_maxL[32]), .out_data(out_data[32]));
	apo_router_36_nodes r34 (.clk(clk), .router_name(6'd33), .in_free(out_router34), .in_r1R(r_minL[1]), .in_r2R(r_maxL[2]), .in_r1L(r_minR[29]), .in_r2L(r_maxR[28]), .out_r1R(r_minR[33]), .out_r2R(r_maxR[33]), .out_r1L(r_minL[33]), .out_r2L(r_maxL[33]), .out_data(out_data[33]));
	apo_router_36_nodes r35 (.clk(clk), .router_name(6'd34), .in_free(out_router35), .in_r1R(r_minL[2]), .in_r2R(r_maxL[3]), .in_r1L(r_minR[30]), .in_r2L(r_maxR[29]), .out_r1R(r_minR[34]), .out_r2R(r_maxR[34]), .out_r1L(r_minL[34]), .out_r2L(r_maxL[34]), .out_data(out_data[34]));
	apo_router_36_nodes r36 (.clk(clk), .router_name(6'd35), .in_free(out_router36), .in_r1R(r_minL[3]), .in_r2R(r_maxL[4]), .in_r1L(r_minR[31]), .in_r2L(r_maxR[30]), .out_r1R(r_minR[35]), .out_r2R(r_maxR[35]), .out_r1L(r_minL[35]), .out_r2L(r_maxL[35]), .out_data(out_data[35]));

endmodule

