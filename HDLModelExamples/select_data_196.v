`define N 9		/* для хранения количества роутеров и эмуряции пакета */
`define N2 17   /* это размер входящего и выходящего пакетов - 1 бит для эмуляции и K*2 бит для передачи двух чисел (шагов по первой и по второй образующим)*/
`define K 8		// на 1 меньше чем N
`define BIT 8	// сколько нужно бит для хранения количества роутеров в сети, для 17 роутеров равно 5

module select_data_196(
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
	out_router65,
	out_router66,
	out_router67,
	out_router68,
	out_router69,
	out_router70,
	out_router71,
	out_router72,
	out_router73,
	out_router74,
	out_router75,
	out_router76,
	out_router77,
	out_router78,
	out_router79,
	out_router80,
	out_router81,
	out_router82,
	out_router83,
	out_router84,
	out_router85,
	out_router86,
	out_router87,
	out_router88,
	out_router89,
	out_router90,
	out_router91,
	out_router92,
	out_router93,
	out_router94,
	out_router95,
	out_router96,
	out_router97,
	out_router98,
	out_router99,
	out_router100,
	out_router101,
	out_router102,
	out_router103,
	out_router104,
	out_router105,
	out_router106,
	out_router107,
	out_router108,
	out_router109,
	out_router110,
	out_router111,
	out_router112,
	out_router113,
	out_router114,
	out_router115,
	out_router116,
	out_router117,
	out_router118,
	out_router119,
	out_router120,
	out_router121,
	out_router122,
	out_router123,
	out_router124,
	out_router125,
	out_router126,
	out_router127,
	out_router128,
	out_router129,
	out_router130,
	out_router131,
	out_router132,
	out_router133,
	out_router134,
	out_router135,
	out_router136,
	out_router137,
	out_router138,
	out_router139,
	out_router140,
	out_router141,
	out_router142,
	out_router143,
	out_router144,
	out_router145,
	out_router146,
	out_router147,
	out_router148,
	out_router149,
	out_router150,
	out_router151,
	out_router152,
	out_router153,
	out_router154,
	out_router155,
	out_router156,
	out_router157,
	out_router158,
	out_router159,
	out_router160,
	out_router161,
	out_router162,
	out_router163,
	out_router164,
	out_router165,
	out_router166,
	out_router167,
	out_router168,
	out_router169,
	out_router170,
	out_router171,
	out_router172,
	out_router173,
	out_router174,
	out_router175,
	out_router176,
	out_router177,
	out_router178,
	out_router179,
	out_router180,
	out_router181,
	out_router182,
	out_router183,
	out_router184,
	out_router185,
	out_router186,
	out_router187,
	out_router188,
	out_router189,
	out_router190,
	out_router191,
	out_router192,
	out_router193,
	out_router194,
	out_router195,
	out_router196,
	
	hex_data,
	hex_router
	
);
	input clk;
	input sw_on;
	input sw_sel_data;
	input sw_sel_router;
	input key_inc;
	input key_dec;
	
	output reg[`N2 - 1:0] out_router1;
	output reg[`N2 - 1:0] out_router2;
	output reg[`N2 - 1:0] out_router3;
	output reg[`N2 - 1:0] out_router4;
	output reg[`N2 - 1:0] out_router5;
	output reg[`N2 - 1:0] out_router6;
	output reg[`N2 - 1:0] out_router7;
	output reg[`N2 - 1:0] out_router8;
	output reg[`N2 - 1:0] out_router9;
	output reg[`N2 - 1:0] out_router10;
	output reg[`N2 - 1:0] out_router11;
	output reg[`N2 - 1:0] out_router12;
	output reg[`N2 - 1:0] out_router13;
	output reg[`N2 - 1:0] out_router14;
	output reg[`N2 - 1:0] out_router15;
	output reg[`N2 - 1:0] out_router16;
	output reg[`N2 - 1:0] out_router17;
	output reg[`N2 - 1:0] out_router18;
	output reg[`N2 - 1:0] out_router19;
	output reg[`N2 - 1:0] out_router20;
	output reg[`N2 - 1:0] out_router21;
	output reg[`N2 - 1:0] out_router22;
	output reg[`N2 - 1:0] out_router23;
	output reg[`N2 - 1:0] out_router24;
	output reg[`N2 - 1:0] out_router25;
	output reg[`N2 - 1:0] out_router26;
	output reg[`N2 - 1:0] out_router27;
	output reg[`N2 - 1:0] out_router28;
	output reg[`N2 - 1:0] out_router29;
	output reg[`N2 - 1:0] out_router30;
	output reg[`N2 - 1:0] out_router31;
	output reg[`N2 - 1:0] out_router32;
	output reg[`N2 - 1:0] out_router33;
	output reg[`N2 - 1:0] out_router34;
	output reg[`N2 - 1:0] out_router35;
	output reg[`N2 - 1:0] out_router36;
	output reg[`N2 - 1:0] out_router37;
	output reg[`N2 - 1:0] out_router38;
	output reg[`N2 - 1:0] out_router39;
	output reg[`N2 - 1:0] out_router40;
	output reg[`N2 - 1:0] out_router41;
	output reg[`N2 - 1:0] out_router42;
	output reg[`N2 - 1:0] out_router43;
	output reg[`N2 - 1:0] out_router44;
	output reg[`N2 - 1:0] out_router45;
	output reg[`N2 - 1:0] out_router46;
	output reg[`N2 - 1:0] out_router47;
	output reg[`N2 - 1:0] out_router48;
	output reg[`N2 - 1:0] out_router49;
	output reg[`N2 - 1:0] out_router50;
	output reg[`N2 - 1:0] out_router51;
	output reg[`N2 - 1:0] out_router52;
	output reg[`N2 - 1:0] out_router53;
	output reg[`N2 - 1:0] out_router54;
	output reg[`N2 - 1:0] out_router55;
	output reg[`N2 - 1:0] out_router56;
	output reg[`N2 - 1:0] out_router57;
	output reg[`N2 - 1:0] out_router58;
	output reg[`N2 - 1:0] out_router59;
	output reg[`N2 - 1:0] out_router60;
	output reg[`N2 - 1:0] out_router61;
	output reg[`N2 - 1:0] out_router62;
	output reg[`N2 - 1:0] out_router63;
	output reg[`N2 - 1:0] out_router64;
	output reg[`N2 - 1:0] out_router65;
	output reg[`N2 - 1:0] out_router66;
	output reg[`N2 - 1:0] out_router67;
	output reg[`N2 - 1:0] out_router68;
	output reg[`N2 - 1:0] out_router69;
	output reg[`N2 - 1:0] out_router70;
	output reg[`N2 - 1:0] out_router71;
	output reg[`N2 - 1:0] out_router72;
	output reg[`N2 - 1:0] out_router73;
	output reg[`N2 - 1:0] out_router74;
	output reg[`N2 - 1:0] out_router75;
	output reg[`N2 - 1:0] out_router76;
	output reg[`N2 - 1:0] out_router77;
	output reg[`N2 - 1:0] out_router78;
	output reg[`N2 - 1:0] out_router79;
	output reg[`N2 - 1:0] out_router80;
	output reg[`N2 - 1:0] out_router81;
	output reg[`N2 - 1:0] out_router82;
	output reg[`N2 - 1:0] out_router83;
	output reg[`N2 - 1:0] out_router84;
	output reg[`N2 - 1:0] out_router85;
	output reg[`N2 - 1:0] out_router86;
	output reg[`N2 - 1:0] out_router87;
	output reg[`N2 - 1:0] out_router88;
	output reg[`N2 - 1:0] out_router89;
	output reg[`N2 - 1:0] out_router90;
	output reg[`N2 - 1:0] out_router91;
	output reg[`N2 - 1:0] out_router92;
	output reg[`N2 - 1:0] out_router93;
	output reg[`N2 - 1:0] out_router94;
	output reg[`N2 - 1:0] out_router95;
	output reg[`N2 - 1:0] out_router96;
	output reg[`N2 - 1:0] out_router97;
	output reg[`N2 - 1:0] out_router98;
	output reg[`N2 - 1:0] out_router99;
	output reg[`N2 - 1:0] out_router100;
	output reg[`N2 - 1:0] out_router101;
	output reg[`N2 - 1:0] out_router102;
	output reg[`N2 - 1:0] out_router103;
	output reg[`N2 - 1:0] out_router104;
	output reg[`N2 - 1:0] out_router105;
	output reg[`N2 - 1:0] out_router106;
	output reg[`N2 - 1:0] out_router107;
	output reg[`N2 - 1:0] out_router108;
	output reg[`N2 - 1:0] out_router109;
	output reg[`N2 - 1:0] out_router110;
	output reg[`N2 - 1:0] out_router111;
	output reg[`N2 - 1:0] out_router112;
	output reg[`N2 - 1:0] out_router113;
	output reg[`N2 - 1:0] out_router114;
	output reg[`N2 - 1:0] out_router115;
	output reg[`N2 - 1:0] out_router116;
	output reg[`N2 - 1:0] out_router117;
	output reg[`N2 - 1:0] out_router118;
	output reg[`N2 - 1:0] out_router119;
	output reg[`N2 - 1:0] out_router120;
	output reg[`N2 - 1:0] out_router121;
	output reg[`N2 - 1:0] out_router122;
	output reg[`N2 - 1:0] out_router123;
	output reg[`N2 - 1:0] out_router124;
	output reg[`N2 - 1:0] out_router125;
	output reg[`N2 - 1:0] out_router126;
	output reg[`N2 - 1:0] out_router127;
	output reg[`N2 - 1:0] out_router128;
	output reg[`N2 - 1:0] out_router129;
	output reg[`N2 - 1:0] out_router130;
	output reg[`N2 - 1:0] out_router131;
	output reg[`N2 - 1:0] out_router132;
	output reg[`N2 - 1:0] out_router133;
	output reg[`N2 - 1:0] out_router134;
	output reg[`N2 - 1:0] out_router135;
	output reg[`N2 - 1:0] out_router136;
	output reg[`N2 - 1:0] out_router137;
	output reg[`N2 - 1:0] out_router138;
	output reg[`N2 - 1:0] out_router139;
	output reg[`N2 - 1:0] out_router140;
	output reg[`N2 - 1:0] out_router141;
	output reg[`N2 - 1:0] out_router142;
	output reg[`N2 - 1:0] out_router143;
	output reg[`N2 - 1:0] out_router144;
	output reg[`N2 - 1:0] out_router145;
	output reg[`N2 - 1:0] out_router146;
	output reg[`N2 - 1:0] out_router147;
	output reg[`N2 - 1:0] out_router148;
	output reg[`N2 - 1:0] out_router149;
	output reg[`N2 - 1:0] out_router150;
	output reg[`N2 - 1:0] out_router151;
	output reg[`N2 - 1:0] out_router152;
	output reg[`N2 - 1:0] out_router153;
	output reg[`N2 - 1:0] out_router154;
	output reg[`N2 - 1:0] out_router155;
	output reg[`N2 - 1:0] out_router156;
	output reg[`N2 - 1:0] out_router157;
	output reg[`N2 - 1:0] out_router158;
	output reg[`N2 - 1:0] out_router159;
	output reg[`N2 - 1:0] out_router160;
	output reg[`N2 - 1:0] out_router161;
	output reg[`N2 - 1:0] out_router162;
	output reg[`N2 - 1:0] out_router163;
	output reg[`N2 - 1:0] out_router164;
	output reg[`N2 - 1:0] out_router165;
	output reg[`N2 - 1:0] out_router166;
	output reg[`N2 - 1:0] out_router167;
	output reg[`N2 - 1:0] out_router168;
	output reg[`N2 - 1:0] out_router169;
	output reg[`N2 - 1:0] out_router170;
	output reg[`N2 - 1:0] out_router171;
	output reg[`N2 - 1:0] out_router172;
	output reg[`N2 - 1:0] out_router173;
	output reg[`N2 - 1:0] out_router174;
	output reg[`N2 - 1:0] out_router175;
	output reg[`N2 - 1:0] out_router176;
	output reg[`N2 - 1:0] out_router177;
	output reg[`N2 - 1:0] out_router178;
	output reg[`N2 - 1:0] out_router179;
	output reg[`N2 - 1:0] out_router180;
	output reg[`N2 - 1:0] out_router181;
	output reg[`N2 - 1:0] out_router182;
	output reg[`N2 - 1:0] out_router183;
	output reg[`N2 - 1:0] out_router184;
	output reg[`N2 - 1:0] out_router185;
	output reg[`N2 - 1:0] out_router186;
	output reg[`N2 - 1:0] out_router187;
	output reg[`N2 - 1:0] out_router188;
	output reg[`N2 - 1:0] out_router189;
	output reg[`N2 - 1:0] out_router190;
	output reg[`N2 - 1:0] out_router191;
	output reg[`N2 - 1:0] out_router192;
	output reg[`N2 - 1:0] out_router193;
	output reg[`N2 - 1:0] out_router194;
	output reg[`N2 - 1:0] out_router195;
	output reg[`N2 - 1:0] out_router196;
	
	output reg[6:0] hex_data;
	output reg[6:0] hex_router;
	
	reg[`N2-2:0] data = `K'b00000;
	reg[`N2-2:0] router = `BIT'b00000;
	reg flag_key_inc = 1'b0;
	reg flag_key_dec = 1'b0;
	
	reg[3331:0] out_to_router;  // размерность определяется как N*колво узлов сети
	
	always@(posedge clk)
	begin
		if(sw_on == 1'b1)
		begin
			out_to_router = (3332'b0 + {1'b1, data}) << router*`N2;
			
			out_router1 = out_to_router[16:0];
			out_router2 = out_to_router[33:17];
			out_router3 = out_to_router[50:34];
			out_router4 = out_to_router[67:51];
			out_router5 = out_to_router[84:68];
			out_router6 = out_to_router[101:85];
			out_router7 = out_to_router[118:102];
			out_router8 = out_to_router[135:119];
			out_router9 = out_to_router[152:136];
			out_router10 = out_to_router[169:153];
			out_router11 = out_to_router[186:170];
			out_router12 = out_to_router[203:187];
			out_router13 = out_to_router[220:204];
			out_router14 = out_to_router[237:221];
			out_router15 = out_to_router[254:238];
			out_router16 = out_to_router[271:255];
			out_router17 = out_to_router[288:272];
			out_router18 = out_to_router[305:289];
			out_router19 = out_to_router[322:306];
			out_router20 = out_to_router[339:323];
			out_router21 = out_to_router[356:340];
			out_router22 = out_to_router[373:357];
			out_router23 = out_to_router[390:374];
			out_router24 = out_to_router[407:391];
			out_router25 = out_to_router[424:408];
			out_router26 = out_to_router[441:425];
			out_router27 = out_to_router[458:442];
			out_router28 = out_to_router[475:459];
			out_router29 = out_to_router[492:476];
			out_router30 = out_to_router[509:493];
			out_router31 = out_to_router[526:510];
			out_router32 = out_to_router[543:527];
			out_router33 = out_to_router[560:544];
			out_router34 = out_to_router[577:561];
			out_router35 = out_to_router[594:578];
			out_router36 = out_to_router[611:595];
			out_router37 = out_to_router[628:612];
			out_router38 = out_to_router[645:629];
			out_router39 = out_to_router[662:646];
			out_router40 = out_to_router[679:663];
			out_router41 = out_to_router[696:680];
			out_router42 = out_to_router[713:697];
			out_router43 = out_to_router[730:714];
			out_router44 = out_to_router[747:731];
			out_router45 = out_to_router[764:748];
			out_router46 = out_to_router[781:765];
			out_router47 = out_to_router[798:782];
			out_router48 = out_to_router[815:799];
			out_router49 = out_to_router[832:816];
			out_router50 = out_to_router[849:833];
			out_router51 = out_to_router[866:850];
			out_router52 = out_to_router[883:867];
			out_router53 = out_to_router[900:884];
			out_router54 = out_to_router[917:901];
			out_router55 = out_to_router[934:918];
			out_router56 = out_to_router[951:935];
			out_router57 = out_to_router[968:952];
			out_router58 = out_to_router[985:969];
			out_router59 = out_to_router[1002:986];
			out_router60 = out_to_router[1019:1003];
			out_router61 = out_to_router[1036:1020];
			out_router62 = out_to_router[1053:1037];
			out_router63 = out_to_router[1070:1054];
			out_router64 = out_to_router[1087:1071];
			out_router65 = out_to_router[1104:1088];
			out_router66 = out_to_router[1121:1105];
			out_router67 = out_to_router[1138:1122];
			out_router68 = out_to_router[1155:1139];
			out_router69 = out_to_router[1172:1156];
			out_router70 = out_to_router[1189:1173];
			out_router71 = out_to_router[1206:1190];
			out_router72 = out_to_router[1223:1207];
			out_router73 = out_to_router[1240:1224];
			out_router74 = out_to_router[1257:1241];
			out_router75 = out_to_router[1274:1258];
			out_router76 = out_to_router[1291:1275];
			out_router77 = out_to_router[1308:1292];
			out_router78 = out_to_router[1325:1309];
			out_router79 = out_to_router[1342:1326];
			out_router80 = out_to_router[1359:1343];
			out_router81 = out_to_router[1376:1360];
			out_router82 = out_to_router[1393:1377];
			out_router83 = out_to_router[1410:1394];
			out_router84 = out_to_router[1427:1411];
			out_router85 = out_to_router[1444:1428];
			out_router86 = out_to_router[1461:1445];
			out_router87 = out_to_router[1478:1462];
			out_router88 = out_to_router[1495:1479];
			out_router89 = out_to_router[1512:1496];
			out_router90 = out_to_router[1529:1513];
			out_router91 = out_to_router[1546:1530];
			out_router92 = out_to_router[1563:1547];
			out_router93 = out_to_router[1580:1564];
			out_router94 = out_to_router[1597:1581];
			out_router95 = out_to_router[1614:1598];
			out_router96 = out_to_router[1631:1615];
			out_router97 = out_to_router[1648:1632];
			out_router98 = out_to_router[1665:1649];
			out_router99 = out_to_router[1682:1666];
			out_router100 = out_to_router[1699:1683];
			out_router101 = out_to_router[1716:1700];
			out_router102 = out_to_router[1733:1717];
			out_router103 = out_to_router[1750:1734];
			out_router104 = out_to_router[1767:1751];
			out_router105 = out_to_router[1784:1768];
			out_router106 = out_to_router[1801:1785];
			out_router107 = out_to_router[1818:1802];
			out_router108 = out_to_router[1835:1819];
			out_router109 = out_to_router[1852:1836];
			out_router110 = out_to_router[1869:1853];
			out_router111 = out_to_router[1886:1870];
			out_router112 = out_to_router[1903:1887];
			out_router113 = out_to_router[1920:1904];
			out_router114 = out_to_router[1937:1921];
			out_router115 = out_to_router[1954:1938];
			out_router116 = out_to_router[1971:1955];
			out_router117 = out_to_router[1988:1972];
			out_router118 = out_to_router[2005:1989];
			out_router119 = out_to_router[2022:2006];
			out_router120 = out_to_router[2039:2023];
			out_router121 = out_to_router[2056:2040];
			out_router122 = out_to_router[2073:2057];
			out_router123 = out_to_router[2090:2074];
			out_router124 = out_to_router[2107:2091];
			out_router125 = out_to_router[2124:2108];
			out_router126 = out_to_router[2141:2125];
			out_router127 = out_to_router[2158:2142];
			out_router128 = out_to_router[2175:2159];
			out_router129 = out_to_router[2192:2176];
			out_router130 = out_to_router[2209:2193];
			out_router131 = out_to_router[2226:2210];
			out_router132 = out_to_router[2243:2227];
			out_router133 = out_to_router[2260:2244];
			out_router134 = out_to_router[2277:2261];
			out_router135 = out_to_router[2294:2278];
			out_router136 = out_to_router[2311:2295];
			out_router137 = out_to_router[2328:2312];
			out_router138 = out_to_router[2345:2329];
			out_router139 = out_to_router[2362:2346];
			out_router140 = out_to_router[2379:2363];
			out_router141 = out_to_router[2396:2380];
			out_router142 = out_to_router[2413:2397];
			out_router143 = out_to_router[2430:2414];
			out_router144 = out_to_router[2447:2431];
			out_router145 = out_to_router[2464:2448];
			out_router146 = out_to_router[2481:2465];
			out_router147 = out_to_router[2498:2482];
			out_router148 = out_to_router[2515:2499];
			out_router149 = out_to_router[2532:2516];
			out_router150 = out_to_router[2549:2533];
			out_router151 = out_to_router[2566:2550];
			out_router152 = out_to_router[2583:2567];
			out_router153 = out_to_router[2600:2584];
			out_router154 = out_to_router[2617:2601];
			out_router155 = out_to_router[2634:2618];
			out_router156 = out_to_router[2651:2635];
			out_router157 = out_to_router[2668:2652];
			out_router158 = out_to_router[2685:2669];
			out_router159 = out_to_router[2702:2686];
			out_router160 = out_to_router[2719:2703];
			out_router161 = out_to_router[2736:2720];
			out_router162 = out_to_router[2753:2737];
			out_router163 = out_to_router[2770:2754];
			out_router164 = out_to_router[2787:2771];
			out_router165 = out_to_router[2804:2788];
			out_router166 = out_to_router[2821:2805];
			out_router167 = out_to_router[2838:2822];
			out_router168 = out_to_router[2855:2839];
			out_router169 = out_to_router[2872:2856];
			out_router170 = out_to_router[2889:2873];
			out_router171 = out_to_router[2906:2890];
			out_router172 = out_to_router[2923:2907];
			out_router173 = out_to_router[2940:2924];
			out_router174 = out_to_router[2957:2941];
			out_router175 = out_to_router[2974:2958];
			out_router176 = out_to_router[2991:2975];
			out_router177 = out_to_router[3008:2992];
			out_router178 = out_to_router[3025:3009];
			out_router179 = out_to_router[3042:3026];
			out_router180 = out_to_router[3059:3043];
			out_router181 = out_to_router[3076:3060];
			out_router182 = out_to_router[3093:3077];
			out_router183 = out_to_router[3110:3094];
			out_router184 = out_to_router[3127:3111];
			out_router185 = out_to_router[3144:3128];
			out_router186 = out_to_router[3161:3145];
			out_router187 = out_to_router[3178:3162];
			out_router188 = out_to_router[3195:3179];
			out_router189 = out_to_router[3212:3196];
			out_router190 = out_to_router[3229:3213];
			out_router191 = out_to_router[3246:3230];
			out_router192 = out_to_router[3263:3247];
			out_router193 = out_to_router[3280:3264];
			out_router194 = out_to_router[3297:3281];
			out_router195 = out_to_router[3314:3298];
			out_router196 = out_to_router[3331:3315];
		end
		else
		begin
			out_to_router = 3332'b0;
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
	