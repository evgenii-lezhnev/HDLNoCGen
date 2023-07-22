`define N 8
`define N2 15
`define N_COUNT 80

module toplevel_apo_81_nodes(
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
	wire[`N2-1:0] out_router37;
	wire[`N2-1:0] out_router38;
	wire[`N2-1:0] out_router39;
	wire[`N2-1:0] out_router40;
	wire[`N2-1:0] out_router41;
	wire[`N2-1:0] out_router42;
	wire[`N2-1:0] out_router43;
	wire[`N2-1:0] out_router44;
	wire[`N2-1:0] out_router45;
	wire[`N2-1:0] out_router46;
	wire[`N2-1:0] out_router47;
	wire[`N2-1:0] out_router48;
	wire[`N2-1:0] out_router49;
	wire[`N2-1:0] out_router50;
	wire[`N2-1:0] out_router51;
	wire[`N2-1:0] out_router52;
	wire[`N2-1:0] out_router53;
	wire[`N2-1:0] out_router54;
	wire[`N2-1:0] out_router55;
	wire[`N2-1:0] out_router56;
	wire[`N2-1:0] out_router57;
	wire[`N2-1:0] out_router58;
	wire[`N2-1:0] out_router59;
	wire[`N2-1:0] out_router60;
	wire[`N2-1:0] out_router61;
	wire[`N2-1:0] out_router62;
	wire[`N2-1:0] out_router63;
	wire[`N2-1:0] out_router64;
	wire[`N2-1:0] out_router65;
	wire[`N2-1:0] out_router66;
	wire[`N2-1:0] out_router67;
	wire[`N2-1:0] out_router68;
	wire[`N2-1:0] out_router69;
	wire[`N2-1:0] out_router70;
	wire[`N2-1:0] out_router71;
	wire[`N2-1:0] out_router72;
	wire[`N2-1:0] out_router73;
	wire[`N2-1:0] out_router74;
	wire[`N2-1:0] out_router75;
	wire[`N2-1:0] out_router76;
	wire[`N2-1:0] out_router77;
	wire[`N2-1:0] out_router78;
	wire[`N2-1:0] out_router79;
	wire[`N2-1:0] out_router80;
	wire[`N2-1:0] out_router81;

	wire[`N2-1:0] r_minR[0:`N_COUNT];	
	wire[`N2-1:0] r_maxR[0:`N_COUNT];	
	wire[`N2-1:0] r_minL[0:`N_COUNT];	
	wire[`N2-1:0] r_maxL[0:`N_COUNT];	

	select_data_81 sel (.clk(clk), .sw_on(sw_on), .sw_sel_data(sw_sel_data), .sw_sel_router(sw_sel_router), .key_inc(key_inc), .key_dec(key_dec), 
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
.out_router37(out_router37), 
.out_router38(out_router38), 
.out_router39(out_router39), 
.out_router40(out_router40), 
.out_router41(out_router41), 
.out_router42(out_router42), 
.out_router43(out_router43), 
.out_router44(out_router44), 
.out_router45(out_router45), 
.out_router46(out_router46), 
.out_router47(out_router47), 
.out_router48(out_router48), 
.out_router49(out_router49), 
.out_router50(out_router50), 
.out_router51(out_router51), 
.out_router52(out_router52), 
.out_router53(out_router53), 
.out_router54(out_router54), 
.out_router55(out_router55), 
.out_router56(out_router56), 
.out_router57(out_router57), 
.out_router58(out_router58), 
.out_router59(out_router59), 
.out_router60(out_router60), 
.out_router61(out_router61), 
.out_router62(out_router62), 
.out_router63(out_router63), 
.out_router64(out_router64), 
.out_router65(out_router65), 
.out_router66(out_router66), 
.out_router67(out_router67), 
.out_router68(out_router68), 
.out_router69(out_router69), 
.out_router70(out_router70), 
.out_router71(out_router71), 
.out_router72(out_router72), 
.out_router73(out_router73), 
.out_router74(out_router74), 
.out_router75(out_router75), 
.out_router76(out_router76), 
.out_router77(out_router77), 
.out_router78(out_router78), 
.out_router79(out_router79), 
.out_router80(out_router80), 
.out_router81(out_router81),
.hex_data(hex_data), .hex_router(hex_router));

	apo_router_81_nodes r1 (.clk(clk), .router_name(7'd0), .in_free(out_router1), .in_r1R(r_minL[6]), .in_r2R(r_maxL[7]), .in_r1L(r_minR[75]), .in_r2L(r_maxR[74]), .out_r1R(r_minR[0]), .out_r2R(r_maxR[0]), .out_r1L(r_minL[0]), .out_r2L(r_maxL[0]), .out_data(out_data[0]));
	apo_router_81_nodes r2 (.clk(clk), .router_name(7'd1), .in_free(out_router2), .in_r1R(r_minL[7]), .in_r2R(r_maxL[8]), .in_r1L(r_minR[76]), .in_r2L(r_maxR[75]), .out_r1R(r_minR[1]), .out_r2R(r_maxR[1]), .out_r1L(r_minL[1]), .out_r2L(r_maxL[1]), .out_data(out_data[1]));
	apo_router_81_nodes r3 (.clk(clk), .router_name(7'd2), .in_free(out_router3), .in_r1R(r_minL[8]), .in_r2R(r_maxL[9]), .in_r1L(r_minR[77]), .in_r2L(r_maxR[76]), .out_r1R(r_minR[2]), .out_r2R(r_maxR[2]), .out_r1L(r_minL[2]), .out_r2L(r_maxL[2]), .out_data(out_data[2]));
	apo_router_81_nodes r4 (.clk(clk), .router_name(7'd3), .in_free(out_router4), .in_r1R(r_minL[9]), .in_r2R(r_maxL[10]), .in_r1L(r_minR[78]), .in_r2L(r_maxR[77]), .out_r1R(r_minR[3]), .out_r2R(r_maxR[3]), .out_r1L(r_minL[3]), .out_r2L(r_maxL[3]), .out_data(out_data[3]));
	apo_router_81_nodes r5 (.clk(clk), .router_name(7'd4), .in_free(out_router5), .in_r1R(r_minL[10]), .in_r2R(r_maxL[11]), .in_r1L(r_minR[79]), .in_r2L(r_maxR[78]), .out_r1R(r_minR[4]), .out_r2R(r_maxR[4]), .out_r1L(r_minL[4]), .out_r2L(r_maxL[4]), .out_data(out_data[4]));
	apo_router_81_nodes r6 (.clk(clk), .router_name(7'd5), .in_free(out_router6), .in_r1R(r_minL[11]), .in_r2R(r_maxL[12]), .in_r1L(r_minR[80]), .in_r2L(r_maxR[79]), .out_r1R(r_minR[5]), .out_r2R(r_maxR[5]), .out_r1L(r_minL[5]), .out_r2L(r_maxL[5]), .out_data(out_data[5]));
	apo_router_81_nodes r7 (.clk(clk), .router_name(7'd6), .in_free(out_router7), .in_r1R(r_minL[12]), .in_r2R(r_maxL[13]), .in_r1L(r_minR[0]), .in_r2L(r_maxR[80]), .out_r1R(r_minR[6]), .out_r2R(r_maxR[6]), .out_r1L(r_minL[6]), .out_r2L(r_maxL[6]), .out_data(out_data[6]));
	apo_router_81_nodes r8 (.clk(clk), .router_name(7'd7), .in_free(out_router8), .in_r1R(r_minL[13]), .in_r2R(r_maxL[14]), .in_r1L(r_minR[1]), .in_r2L(r_maxR[0]), .out_r1R(r_minR[7]), .out_r2R(r_maxR[7]), .out_r1L(r_minL[7]), .out_r2L(r_maxL[7]), .out_data(out_data[7]));
	apo_router_81_nodes r9 (.clk(clk), .router_name(7'd8), .in_free(out_router9), .in_r1R(r_minL[14]), .in_r2R(r_maxL[15]), .in_r1L(r_minR[2]), .in_r2L(r_maxR[1]), .out_r1R(r_minR[8]), .out_r2R(r_maxR[8]), .out_r1L(r_minL[8]), .out_r2L(r_maxL[8]), .out_data(out_data[8]));
	apo_router_81_nodes r10 (.clk(clk), .router_name(7'd9), .in_free(out_router10), .in_r1R(r_minL[15]), .in_r2R(r_maxL[16]), .in_r1L(r_minR[3]), .in_r2L(r_maxR[2]), .out_r1R(r_minR[9]), .out_r2R(r_maxR[9]), .out_r1L(r_minL[9]), .out_r2L(r_maxL[9]), .out_data(out_data[9]));
	apo_router_81_nodes r11 (.clk(clk), .router_name(7'd10), .in_free(out_router11), .in_r1R(r_minL[16]), .in_r2R(r_maxL[17]), .in_r1L(r_minR[4]), .in_r2L(r_maxR[3]), .out_r1R(r_minR[10]), .out_r2R(r_maxR[10]), .out_r1L(r_minL[10]), .out_r2L(r_maxL[10]), .out_data(out_data[10]));
	apo_router_81_nodes r12 (.clk(clk), .router_name(7'd11), .in_free(out_router12), .in_r1R(r_minL[17]), .in_r2R(r_maxL[18]), .in_r1L(r_minR[5]), .in_r2L(r_maxR[4]), .out_r1R(r_minR[11]), .out_r2R(r_maxR[11]), .out_r1L(r_minL[11]), .out_r2L(r_maxL[11]), .out_data(out_data[11]));
	apo_router_81_nodes r13 (.clk(clk), .router_name(7'd12), .in_free(out_router13), .in_r1R(r_minL[18]), .in_r2R(r_maxL[19]), .in_r1L(r_minR[6]), .in_r2L(r_maxR[5]), .out_r1R(r_minR[12]), .out_r2R(r_maxR[12]), .out_r1L(r_minL[12]), .out_r2L(r_maxL[12]), .out_data(out_data[12]));
	apo_router_81_nodes r14 (.clk(clk), .router_name(7'd13), .in_free(out_router14), .in_r1R(r_minL[19]), .in_r2R(r_maxL[20]), .in_r1L(r_minR[7]), .in_r2L(r_maxR[6]), .out_r1R(r_minR[13]), .out_r2R(r_maxR[13]), .out_r1L(r_minL[13]), .out_r2L(r_maxL[13]), .out_data(out_data[13]));
	apo_router_81_nodes r15 (.clk(clk), .router_name(7'd14), .in_free(out_router15), .in_r1R(r_minL[20]), .in_r2R(r_maxL[21]), .in_r1L(r_minR[8]), .in_r2L(r_maxR[7]), .out_r1R(r_minR[14]), .out_r2R(r_maxR[14]), .out_r1L(r_minL[14]), .out_r2L(r_maxL[14]), .out_data(out_data[14]));
	apo_router_81_nodes r16 (.clk(clk), .router_name(7'd15), .in_free(out_router16), .in_r1R(r_minL[21]), .in_r2R(r_maxL[22]), .in_r1L(r_minR[9]), .in_r2L(r_maxR[8]), .out_r1R(r_minR[15]), .out_r2R(r_maxR[15]), .out_r1L(r_minL[15]), .out_r2L(r_maxL[15]), .out_data(out_data[15]));
	apo_router_81_nodes r17 (.clk(clk), .router_name(7'd16), .in_free(out_router17), .in_r1R(r_minL[22]), .in_r2R(r_maxL[23]), .in_r1L(r_minR[10]), .in_r2L(r_maxR[9]), .out_r1R(r_minR[16]), .out_r2R(r_maxR[16]), .out_r1L(r_minL[16]), .out_r2L(r_maxL[16]), .out_data(out_data[16]));
	apo_router_81_nodes r18 (.clk(clk), .router_name(7'd17), .in_free(out_router18), .in_r1R(r_minL[23]), .in_r2R(r_maxL[24]), .in_r1L(r_minR[11]), .in_r2L(r_maxR[10]), .out_r1R(r_minR[17]), .out_r2R(r_maxR[17]), .out_r1L(r_minL[17]), .out_r2L(r_maxL[17]), .out_data(out_data[17]));
	apo_router_81_nodes r19 (.clk(clk), .router_name(7'd18), .in_free(out_router19), .in_r1R(r_minL[24]), .in_r2R(r_maxL[25]), .in_r1L(r_minR[12]), .in_r2L(r_maxR[11]), .out_r1R(r_minR[18]), .out_r2R(r_maxR[18]), .out_r1L(r_minL[18]), .out_r2L(r_maxL[18]), .out_data(out_data[18]));
	apo_router_81_nodes r20 (.clk(clk), .router_name(7'd19), .in_free(out_router20), .in_r1R(r_minL[25]), .in_r2R(r_maxL[26]), .in_r1L(r_minR[13]), .in_r2L(r_maxR[12]), .out_r1R(r_minR[19]), .out_r2R(r_maxR[19]), .out_r1L(r_minL[19]), .out_r2L(r_maxL[19]), .out_data(out_data[19]));
	apo_router_81_nodes r21 (.clk(clk), .router_name(7'd20), .in_free(out_router21), .in_r1R(r_minL[26]), .in_r2R(r_maxL[27]), .in_r1L(r_minR[14]), .in_r2L(r_maxR[13]), .out_r1R(r_minR[20]), .out_r2R(r_maxR[20]), .out_r1L(r_minL[20]), .out_r2L(r_maxL[20]), .out_data(out_data[20]));
	apo_router_81_nodes r22 (.clk(clk), .router_name(7'd21), .in_free(out_router22), .in_r1R(r_minL[27]), .in_r2R(r_maxL[28]), .in_r1L(r_minR[15]), .in_r2L(r_maxR[14]), .out_r1R(r_minR[21]), .out_r2R(r_maxR[21]), .out_r1L(r_minL[21]), .out_r2L(r_maxL[21]), .out_data(out_data[21]));
	apo_router_81_nodes r23 (.clk(clk), .router_name(7'd22), .in_free(out_router23), .in_r1R(r_minL[28]), .in_r2R(r_maxL[29]), .in_r1L(r_minR[16]), .in_r2L(r_maxR[15]), .out_r1R(r_minR[22]), .out_r2R(r_maxR[22]), .out_r1L(r_minL[22]), .out_r2L(r_maxL[22]), .out_data(out_data[22]));
	apo_router_81_nodes r24 (.clk(clk), .router_name(7'd23), .in_free(out_router24), .in_r1R(r_minL[29]), .in_r2R(r_maxL[30]), .in_r1L(r_minR[17]), .in_r2L(r_maxR[16]), .out_r1R(r_minR[23]), .out_r2R(r_maxR[23]), .out_r1L(r_minL[23]), .out_r2L(r_maxL[23]), .out_data(out_data[23]));
	apo_router_81_nodes r25 (.clk(clk), .router_name(7'd24), .in_free(out_router25), .in_r1R(r_minL[30]), .in_r2R(r_maxL[31]), .in_r1L(r_minR[18]), .in_r2L(r_maxR[17]), .out_r1R(r_minR[24]), .out_r2R(r_maxR[24]), .out_r1L(r_minL[24]), .out_r2L(r_maxL[24]), .out_data(out_data[24]));
	apo_router_81_nodes r26 (.clk(clk), .router_name(7'd25), .in_free(out_router26), .in_r1R(r_minL[31]), .in_r2R(r_maxL[32]), .in_r1L(r_minR[19]), .in_r2L(r_maxR[18]), .out_r1R(r_minR[25]), .out_r2R(r_maxR[25]), .out_r1L(r_minL[25]), .out_r2L(r_maxL[25]), .out_data(out_data[25]));
	apo_router_81_nodes r27 (.clk(clk), .router_name(7'd26), .in_free(out_router27), .in_r1R(r_minL[32]), .in_r2R(r_maxL[33]), .in_r1L(r_minR[20]), .in_r2L(r_maxR[19]), .out_r1R(r_minR[26]), .out_r2R(r_maxR[26]), .out_r1L(r_minL[26]), .out_r2L(r_maxL[26]), .out_data(out_data[26]));
	apo_router_81_nodes r28 (.clk(clk), .router_name(7'd27), .in_free(out_router28), .in_r1R(r_minL[33]), .in_r2R(r_maxL[34]), .in_r1L(r_minR[21]), .in_r2L(r_maxR[20]), .out_r1R(r_minR[27]), .out_r2R(r_maxR[27]), .out_r1L(r_minL[27]), .out_r2L(r_maxL[27]), .out_data(out_data[27]));
	apo_router_81_nodes r29 (.clk(clk), .router_name(7'd28), .in_free(out_router29), .in_r1R(r_minL[34]), .in_r2R(r_maxL[35]), .in_r1L(r_minR[22]), .in_r2L(r_maxR[21]), .out_r1R(r_minR[28]), .out_r2R(r_maxR[28]), .out_r1L(r_minL[28]), .out_r2L(r_maxL[28]), .out_data(out_data[28]));
	apo_router_81_nodes r30 (.clk(clk), .router_name(7'd29), .in_free(out_router30), .in_r1R(r_minL[35]), .in_r2R(r_maxL[36]), .in_r1L(r_minR[23]), .in_r2L(r_maxR[22]), .out_r1R(r_minR[29]), .out_r2R(r_maxR[29]), .out_r1L(r_minL[29]), .out_r2L(r_maxL[29]), .out_data(out_data[29]));
	apo_router_81_nodes r31 (.clk(clk), .router_name(7'd30), .in_free(out_router31), .in_r1R(r_minL[36]), .in_r2R(r_maxL[37]), .in_r1L(r_minR[24]), .in_r2L(r_maxR[23]), .out_r1R(r_minR[30]), .out_r2R(r_maxR[30]), .out_r1L(r_minL[30]), .out_r2L(r_maxL[30]), .out_data(out_data[30]));
	apo_router_81_nodes r32 (.clk(clk), .router_name(7'd31), .in_free(out_router32), .in_r1R(r_minL[37]), .in_r2R(r_maxL[38]), .in_r1L(r_minR[25]), .in_r2L(r_maxR[24]), .out_r1R(r_minR[31]), .out_r2R(r_maxR[31]), .out_r1L(r_minL[31]), .out_r2L(r_maxL[31]), .out_data(out_data[31]));
	apo_router_81_nodes r33 (.clk(clk), .router_name(7'd32), .in_free(out_router33), .in_r1R(r_minL[38]), .in_r2R(r_maxL[39]), .in_r1L(r_minR[26]), .in_r2L(r_maxR[25]), .out_r1R(r_minR[32]), .out_r2R(r_maxR[32]), .out_r1L(r_minL[32]), .out_r2L(r_maxL[32]), .out_data(out_data[32]));
	apo_router_81_nodes r34 (.clk(clk), .router_name(7'd33), .in_free(out_router34), .in_r1R(r_minL[39]), .in_r2R(r_maxL[40]), .in_r1L(r_minR[27]), .in_r2L(r_maxR[26]), .out_r1R(r_minR[33]), .out_r2R(r_maxR[33]), .out_r1L(r_minL[33]), .out_r2L(r_maxL[33]), .out_data(out_data[33]));
	apo_router_81_nodes r35 (.clk(clk), .router_name(7'd34), .in_free(out_router35), .in_r1R(r_minL[40]), .in_r2R(r_maxL[41]), .in_r1L(r_minR[28]), .in_r2L(r_maxR[27]), .out_r1R(r_minR[34]), .out_r2R(r_maxR[34]), .out_r1L(r_minL[34]), .out_r2L(r_maxL[34]), .out_data(out_data[34]));
	apo_router_81_nodes r36 (.clk(clk), .router_name(7'd35), .in_free(out_router36), .in_r1R(r_minL[41]), .in_r2R(r_maxL[42]), .in_r1L(r_minR[29]), .in_r2L(r_maxR[28]), .out_r1R(r_minR[35]), .out_r2R(r_maxR[35]), .out_r1L(r_minL[35]), .out_r2L(r_maxL[35]), .out_data(out_data[35]));
	apo_router_81_nodes r37 (.clk(clk), .router_name(7'd36), .in_free(out_router37), .in_r1R(r_minL[42]), .in_r2R(r_maxL[43]), .in_r1L(r_minR[30]), .in_r2L(r_maxR[29]), .out_r1R(r_minR[36]), .out_r2R(r_maxR[36]), .out_r1L(r_minL[36]), .out_r2L(r_maxL[36]), .out_data(out_data[36]));
	apo_router_81_nodes r38 (.clk(clk), .router_name(7'd37), .in_free(out_router38), .in_r1R(r_minL[43]), .in_r2R(r_maxL[44]), .in_r1L(r_minR[31]), .in_r2L(r_maxR[30]), .out_r1R(r_minR[37]), .out_r2R(r_maxR[37]), .out_r1L(r_minL[37]), .out_r2L(r_maxL[37]), .out_data(out_data[37]));
	apo_router_81_nodes r39 (.clk(clk), .router_name(7'd38), .in_free(out_router39), .in_r1R(r_minL[44]), .in_r2R(r_maxL[45]), .in_r1L(r_minR[32]), .in_r2L(r_maxR[31]), .out_r1R(r_minR[38]), .out_r2R(r_maxR[38]), .out_r1L(r_minL[38]), .out_r2L(r_maxL[38]), .out_data(out_data[38]));
	apo_router_81_nodes r40 (.clk(clk), .router_name(7'd39), .in_free(out_router40), .in_r1R(r_minL[45]), .in_r2R(r_maxL[46]), .in_r1L(r_minR[33]), .in_r2L(r_maxR[32]), .out_r1R(r_minR[39]), .out_r2R(r_maxR[39]), .out_r1L(r_minL[39]), .out_r2L(r_maxL[39]), .out_data(out_data[39]));
	apo_router_81_nodes r41 (.clk(clk), .router_name(7'd40), .in_free(out_router41), .in_r1R(r_minL[46]), .in_r2R(r_maxL[47]), .in_r1L(r_minR[34]), .in_r2L(r_maxR[33]), .out_r1R(r_minR[40]), .out_r2R(r_maxR[40]), .out_r1L(r_minL[40]), .out_r2L(r_maxL[40]), .out_data(out_data[40]));
	apo_router_81_nodes r42 (.clk(clk), .router_name(7'd41), .in_free(out_router42), .in_r1R(r_minL[47]), .in_r2R(r_maxL[48]), .in_r1L(r_minR[35]), .in_r2L(r_maxR[34]), .out_r1R(r_minR[41]), .out_r2R(r_maxR[41]), .out_r1L(r_minL[41]), .out_r2L(r_maxL[41]), .out_data(out_data[41]));
	apo_router_81_nodes r43 (.clk(clk), .router_name(7'd42), .in_free(out_router43), .in_r1R(r_minL[48]), .in_r2R(r_maxL[49]), .in_r1L(r_minR[36]), .in_r2L(r_maxR[35]), .out_r1R(r_minR[42]), .out_r2R(r_maxR[42]), .out_r1L(r_minL[42]), .out_r2L(r_maxL[42]), .out_data(out_data[42]));
	apo_router_81_nodes r44 (.clk(clk), .router_name(7'd43), .in_free(out_router44), .in_r1R(r_minL[49]), .in_r2R(r_maxL[50]), .in_r1L(r_minR[37]), .in_r2L(r_maxR[36]), .out_r1R(r_minR[43]), .out_r2R(r_maxR[43]), .out_r1L(r_minL[43]), .out_r2L(r_maxL[43]), .out_data(out_data[43]));
	apo_router_81_nodes r45 (.clk(clk), .router_name(7'd44), .in_free(out_router45), .in_r1R(r_minL[50]), .in_r2R(r_maxL[51]), .in_r1L(r_minR[38]), .in_r2L(r_maxR[37]), .out_r1R(r_minR[44]), .out_r2R(r_maxR[44]), .out_r1L(r_minL[44]), .out_r2L(r_maxL[44]), .out_data(out_data[44]));
	apo_router_81_nodes r46 (.clk(clk), .router_name(7'd45), .in_free(out_router46), .in_r1R(r_minL[51]), .in_r2R(r_maxL[52]), .in_r1L(r_minR[39]), .in_r2L(r_maxR[38]), .out_r1R(r_minR[45]), .out_r2R(r_maxR[45]), .out_r1L(r_minL[45]), .out_r2L(r_maxL[45]), .out_data(out_data[45]));
	apo_router_81_nodes r47 (.clk(clk), .router_name(7'd46), .in_free(out_router47), .in_r1R(r_minL[52]), .in_r2R(r_maxL[53]), .in_r1L(r_minR[40]), .in_r2L(r_maxR[39]), .out_r1R(r_minR[46]), .out_r2R(r_maxR[46]), .out_r1L(r_minL[46]), .out_r2L(r_maxL[46]), .out_data(out_data[46]));
	apo_router_81_nodes r48 (.clk(clk), .router_name(7'd47), .in_free(out_router48), .in_r1R(r_minL[53]), .in_r2R(r_maxL[54]), .in_r1L(r_minR[41]), .in_r2L(r_maxR[40]), .out_r1R(r_minR[47]), .out_r2R(r_maxR[47]), .out_r1L(r_minL[47]), .out_r2L(r_maxL[47]), .out_data(out_data[47]));
	apo_router_81_nodes r49 (.clk(clk), .router_name(7'd48), .in_free(out_router49), .in_r1R(r_minL[54]), .in_r2R(r_maxL[55]), .in_r1L(r_minR[42]), .in_r2L(r_maxR[41]), .out_r1R(r_minR[48]), .out_r2R(r_maxR[48]), .out_r1L(r_minL[48]), .out_r2L(r_maxL[48]), .out_data(out_data[48]));
	apo_router_81_nodes r50 (.clk(clk), .router_name(7'd49), .in_free(out_router50), .in_r1R(r_minL[55]), .in_r2R(r_maxL[56]), .in_r1L(r_minR[43]), .in_r2L(r_maxR[42]), .out_r1R(r_minR[49]), .out_r2R(r_maxR[49]), .out_r1L(r_minL[49]), .out_r2L(r_maxL[49]), .out_data(out_data[49]));
	apo_router_81_nodes r51 (.clk(clk), .router_name(7'd50), .in_free(out_router51), .in_r1R(r_minL[56]), .in_r2R(r_maxL[57]), .in_r1L(r_minR[44]), .in_r2L(r_maxR[43]), .out_r1R(r_minR[50]), .out_r2R(r_maxR[50]), .out_r1L(r_minL[50]), .out_r2L(r_maxL[50]), .out_data(out_data[50]));
	apo_router_81_nodes r52 (.clk(clk), .router_name(7'd51), .in_free(out_router52), .in_r1R(r_minL[57]), .in_r2R(r_maxL[58]), .in_r1L(r_minR[45]), .in_r2L(r_maxR[44]), .out_r1R(r_minR[51]), .out_r2R(r_maxR[51]), .out_r1L(r_minL[51]), .out_r2L(r_maxL[51]), .out_data(out_data[51]));
	apo_router_81_nodes r53 (.clk(clk), .router_name(7'd52), .in_free(out_router53), .in_r1R(r_minL[58]), .in_r2R(r_maxL[59]), .in_r1L(r_minR[46]), .in_r2L(r_maxR[45]), .out_r1R(r_minR[52]), .out_r2R(r_maxR[52]), .out_r1L(r_minL[52]), .out_r2L(r_maxL[52]), .out_data(out_data[52]));
	apo_router_81_nodes r54 (.clk(clk), .router_name(7'd53), .in_free(out_router54), .in_r1R(r_minL[59]), .in_r2R(r_maxL[60]), .in_r1L(r_minR[47]), .in_r2L(r_maxR[46]), .out_r1R(r_minR[53]), .out_r2R(r_maxR[53]), .out_r1L(r_minL[53]), .out_r2L(r_maxL[53]), .out_data(out_data[53]));
	apo_router_81_nodes r55 (.clk(clk), .router_name(7'd54), .in_free(out_router55), .in_r1R(r_minL[60]), .in_r2R(r_maxL[61]), .in_r1L(r_minR[48]), .in_r2L(r_maxR[47]), .out_r1R(r_minR[54]), .out_r2R(r_maxR[54]), .out_r1L(r_minL[54]), .out_r2L(r_maxL[54]), .out_data(out_data[54]));
	apo_router_81_nodes r56 (.clk(clk), .router_name(7'd55), .in_free(out_router56), .in_r1R(r_minL[61]), .in_r2R(r_maxL[62]), .in_r1L(r_minR[49]), .in_r2L(r_maxR[48]), .out_r1R(r_minR[55]), .out_r2R(r_maxR[55]), .out_r1L(r_minL[55]), .out_r2L(r_maxL[55]), .out_data(out_data[55]));
	apo_router_81_nodes r57 (.clk(clk), .router_name(7'd56), .in_free(out_router57), .in_r1R(r_minL[62]), .in_r2R(r_maxL[63]), .in_r1L(r_minR[50]), .in_r2L(r_maxR[49]), .out_r1R(r_minR[56]), .out_r2R(r_maxR[56]), .out_r1L(r_minL[56]), .out_r2L(r_maxL[56]), .out_data(out_data[56]));
	apo_router_81_nodes r58 (.clk(clk), .router_name(7'd57), .in_free(out_router58), .in_r1R(r_minL[63]), .in_r2R(r_maxL[64]), .in_r1L(r_minR[51]), .in_r2L(r_maxR[50]), .out_r1R(r_minR[57]), .out_r2R(r_maxR[57]), .out_r1L(r_minL[57]), .out_r2L(r_maxL[57]), .out_data(out_data[57]));
	apo_router_81_nodes r59 (.clk(clk), .router_name(7'd58), .in_free(out_router59), .in_r1R(r_minL[64]), .in_r2R(r_maxL[65]), .in_r1L(r_minR[52]), .in_r2L(r_maxR[51]), .out_r1R(r_minR[58]), .out_r2R(r_maxR[58]), .out_r1L(r_minL[58]), .out_r2L(r_maxL[58]), .out_data(out_data[58]));
	apo_router_81_nodes r60 (.clk(clk), .router_name(7'd59), .in_free(out_router60), .in_r1R(r_minL[65]), .in_r2R(r_maxL[66]), .in_r1L(r_minR[53]), .in_r2L(r_maxR[52]), .out_r1R(r_minR[59]), .out_r2R(r_maxR[59]), .out_r1L(r_minL[59]), .out_r2L(r_maxL[59]), .out_data(out_data[59]));
	apo_router_81_nodes r61 (.clk(clk), .router_name(7'd60), .in_free(out_router61), .in_r1R(r_minL[66]), .in_r2R(r_maxL[67]), .in_r1L(r_minR[54]), .in_r2L(r_maxR[53]), .out_r1R(r_minR[60]), .out_r2R(r_maxR[60]), .out_r1L(r_minL[60]), .out_r2L(r_maxL[60]), .out_data(out_data[60]));
	apo_router_81_nodes r62 (.clk(clk), .router_name(7'd61), .in_free(out_router62), .in_r1R(r_minL[67]), .in_r2R(r_maxL[68]), .in_r1L(r_minR[55]), .in_r2L(r_maxR[54]), .out_r1R(r_minR[61]), .out_r2R(r_maxR[61]), .out_r1L(r_minL[61]), .out_r2L(r_maxL[61]), .out_data(out_data[61]));
	apo_router_81_nodes r63 (.clk(clk), .router_name(7'd62), .in_free(out_router63), .in_r1R(r_minL[68]), .in_r2R(r_maxL[69]), .in_r1L(r_minR[56]), .in_r2L(r_maxR[55]), .out_r1R(r_minR[62]), .out_r2R(r_maxR[62]), .out_r1L(r_minL[62]), .out_r2L(r_maxL[62]), .out_data(out_data[62]));
	apo_router_81_nodes r64 (.clk(clk), .router_name(7'd63), .in_free(out_router64), .in_r1R(r_minL[69]), .in_r2R(r_maxL[70]), .in_r1L(r_minR[57]), .in_r2L(r_maxR[56]), .out_r1R(r_minR[63]), .out_r2R(r_maxR[63]), .out_r1L(r_minL[63]), .out_r2L(r_maxL[63]), .out_data(out_data[63]));
	apo_router_81_nodes r65 (.clk(clk), .router_name(7'd64), .in_free(out_router65), .in_r1R(r_minL[70]), .in_r2R(r_maxL[71]), .in_r1L(r_minR[58]), .in_r2L(r_maxR[57]), .out_r1R(r_minR[64]), .out_r2R(r_maxR[64]), .out_r1L(r_minL[64]), .out_r2L(r_maxL[64]), .out_data(out_data[64]));
	apo_router_81_nodes r66 (.clk(clk), .router_name(7'd65), .in_free(out_router66), .in_r1R(r_minL[71]), .in_r2R(r_maxL[72]), .in_r1L(r_minR[59]), .in_r2L(r_maxR[58]), .out_r1R(r_minR[65]), .out_r2R(r_maxR[65]), .out_r1L(r_minL[65]), .out_r2L(r_maxL[65]), .out_data(out_data[65]));
	apo_router_81_nodes r67 (.clk(clk), .router_name(7'd66), .in_free(out_router67), .in_r1R(r_minL[72]), .in_r2R(r_maxL[73]), .in_r1L(r_minR[60]), .in_r2L(r_maxR[59]), .out_r1R(r_minR[66]), .out_r2R(r_maxR[66]), .out_r1L(r_minL[66]), .out_r2L(r_maxL[66]), .out_data(out_data[66]));
	apo_router_81_nodes r68 (.clk(clk), .router_name(7'd67), .in_free(out_router68), .in_r1R(r_minL[73]), .in_r2R(r_maxL[74]), .in_r1L(r_minR[61]), .in_r2L(r_maxR[60]), .out_r1R(r_minR[67]), .out_r2R(r_maxR[67]), .out_r1L(r_minL[67]), .out_r2L(r_maxL[67]), .out_data(out_data[67]));
	apo_router_81_nodes r69 (.clk(clk), .router_name(7'd68), .in_free(out_router69), .in_r1R(r_minL[74]), .in_r2R(r_maxL[75]), .in_r1L(r_minR[62]), .in_r2L(r_maxR[61]), .out_r1R(r_minR[68]), .out_r2R(r_maxR[68]), .out_r1L(r_minL[68]), .out_r2L(r_maxL[68]), .out_data(out_data[68]));
	apo_router_81_nodes r70 (.clk(clk), .router_name(7'd69), .in_free(out_router70), .in_r1R(r_minL[75]), .in_r2R(r_maxL[76]), .in_r1L(r_minR[63]), .in_r2L(r_maxR[62]), .out_r1R(r_minR[69]), .out_r2R(r_maxR[69]), .out_r1L(r_minL[69]), .out_r2L(r_maxL[69]), .out_data(out_data[69]));
	apo_router_81_nodes r71 (.clk(clk), .router_name(7'd70), .in_free(out_router71), .in_r1R(r_minL[76]), .in_r2R(r_maxL[77]), .in_r1L(r_minR[64]), .in_r2L(r_maxR[63]), .out_r1R(r_minR[70]), .out_r2R(r_maxR[70]), .out_r1L(r_minL[70]), .out_r2L(r_maxL[70]), .out_data(out_data[70]));
	apo_router_81_nodes r72 (.clk(clk), .router_name(7'd71), .in_free(out_router72), .in_r1R(r_minL[77]), .in_r2R(r_maxL[78]), .in_r1L(r_minR[65]), .in_r2L(r_maxR[64]), .out_r1R(r_minR[71]), .out_r2R(r_maxR[71]), .out_r1L(r_minL[71]), .out_r2L(r_maxL[71]), .out_data(out_data[71]));
	apo_router_81_nodes r73 (.clk(clk), .router_name(7'd72), .in_free(out_router73), .in_r1R(r_minL[78]), .in_r2R(r_maxL[79]), .in_r1L(r_minR[66]), .in_r2L(r_maxR[65]), .out_r1R(r_minR[72]), .out_r2R(r_maxR[72]), .out_r1L(r_minL[72]), .out_r2L(r_maxL[72]), .out_data(out_data[72]));
	apo_router_81_nodes r74 (.clk(clk), .router_name(7'd73), .in_free(out_router74), .in_r1R(r_minL[79]), .in_r2R(r_maxL[80]), .in_r1L(r_minR[67]), .in_r2L(r_maxR[66]), .out_r1R(r_minR[73]), .out_r2R(r_maxR[73]), .out_r1L(r_minL[73]), .out_r2L(r_maxL[73]), .out_data(out_data[73]));
	apo_router_81_nodes r75 (.clk(clk), .router_name(7'd74), .in_free(out_router75), .in_r1R(r_minL[80]), .in_r2R(r_maxL[0]), .in_r1L(r_minR[68]), .in_r2L(r_maxR[67]), .out_r1R(r_minR[74]), .out_r2R(r_maxR[74]), .out_r1L(r_minL[74]), .out_r2L(r_maxL[74]), .out_data(out_data[74]));
	apo_router_81_nodes r76 (.clk(clk), .router_name(7'd75), .in_free(out_router76), .in_r1R(r_minL[0]), .in_r2R(r_maxL[1]), .in_r1L(r_minR[69]), .in_r2L(r_maxR[68]), .out_r1R(r_minR[75]), .out_r2R(r_maxR[75]), .out_r1L(r_minL[75]), .out_r2L(r_maxL[75]), .out_data(out_data[75]));
	apo_router_81_nodes r77 (.clk(clk), .router_name(7'd76), .in_free(out_router77), .in_r1R(r_minL[1]), .in_r2R(r_maxL[2]), .in_r1L(r_minR[70]), .in_r2L(r_maxR[69]), .out_r1R(r_minR[76]), .out_r2R(r_maxR[76]), .out_r1L(r_minL[76]), .out_r2L(r_maxL[76]), .out_data(out_data[76]));
	apo_router_81_nodes r78 (.clk(clk), .router_name(7'd77), .in_free(out_router78), .in_r1R(r_minL[2]), .in_r2R(r_maxL[3]), .in_r1L(r_minR[71]), .in_r2L(r_maxR[70]), .out_r1R(r_minR[77]), .out_r2R(r_maxR[77]), .out_r1L(r_minL[77]), .out_r2L(r_maxL[77]), .out_data(out_data[77]));
	apo_router_81_nodes r79 (.clk(clk), .router_name(7'd78), .in_free(out_router79), .in_r1R(r_minL[3]), .in_r2R(r_maxL[4]), .in_r1L(r_minR[72]), .in_r2L(r_maxR[71]), .out_r1R(r_minR[78]), .out_r2R(r_maxR[78]), .out_r1L(r_minL[78]), .out_r2L(r_maxL[78]), .out_data(out_data[78]));
	apo_router_81_nodes r80 (.clk(clk), .router_name(7'd79), .in_free(out_router80), .in_r1R(r_minL[4]), .in_r2R(r_maxL[5]), .in_r1L(r_minR[73]), .in_r2L(r_maxR[72]), .out_r1R(r_minR[79]), .out_r2R(r_maxR[79]), .out_r1L(r_minL[79]), .out_r2L(r_maxL[79]), .out_data(out_data[79]));
	apo_router_81_nodes r81 (.clk(clk), .router_name(7'd80), .in_free(out_router81), .in_r1R(r_minL[5]), .in_r2R(r_maxL[6]), .in_r1L(r_minR[74]), .in_r2L(r_maxR[73]), .out_r1R(r_minR[80]), .out_r2R(r_maxR[80]), .out_r1L(r_minL[80]), .out_r2L(r_maxL[80]), .out_data(out_data[80]));

endmodule

