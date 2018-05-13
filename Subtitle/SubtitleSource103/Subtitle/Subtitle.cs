using HutongGames.PlayMaker;
using UnityEngine;
using System.IO;
using MSCLoader;

namespace Subtitle
{
    public class Subtitle : Mod
    {
        public override string ID => "Subtitle";
        public override string Name => "Subtitle";
        public override string Author => "Roman266";
        public override string Version => "1.0.3";

        public override bool UseAssetsFolder => true;

        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private string text5;
        private string text6;
        private string text7;
        private string text8;
        private string text9;
        private string text10;
        private string text11;
        private string text12;
        private string text13;
        private string text14;
        private string text15;
        private string text16;
        private string text17;
        private string text18;
        private string text19;
        private string text20;
        private string text21;
        private string text22;
        private string text23;
        private string text24;
        private string text25;
        private string text26;
        private string text27;
        private string text28;
        private string text29;
        private string text30;
        private string text31;
        private string text32;
        private string text33;
        private string text34;
        private string text35;
        private string text36;
        private string text37;
        private string text38;
        private string text39;
        private string text40;
        private string text41;
        private string text42;
        private string text43;
        private string text44;
        private string text45;
        private string text46;
        private string text47;
        private string text48;
        //private string text49;
        private string text50;
        private string text51;
        private string text52;
        private string text53;
        private string text54;
        private string text55;
        private string text56;
        private string text57;
        private string text58;
        private string text59;
        private string text60;
        private string text61;
        private string text62;
        private string text63;
        private string text64;
        private string text65;
        private string text66;
        private string text67;
        private string text68;
        private string text69;
        private string text70;
        private string text71;
        private string text72;
        private string text73;
        private string text74;
        private string text75;
        private string text76;
        private string text77;
        private string text78;
        private string text79;
        private string text80;
        private string text81;
        private string text82;
        private string text83;
        private string text84;
        private string text85;
        private string text86;
        private string text87;
        private string text88;
        private string text89;
        private string text90;
        private string text91;
        private string text92;
        private string text93;
        private string text94;
        private string text95;
        private string text96;
        private string text97;
        private string text98;
        private string text99;
        private string text100;
        private string text101;
        private string text102;
        private string text103;
        private string text104;
        private string text105;
        private string text106;
        private string text107;
        private string text108;
        private string text109;
        private string text110;
        private string text111;
        private string text112;
        private string text113;
        private string text114;
        private string text115;
        private string text116;
        private string text117;
        private string text118;
        private string text119;
        private string text120;
        private string text121;
        private string text122;
        private string text123;
        private string text124;
        private string text125;
        private string text126;
        private string text127;
        private string text128;
        private string text129;
        private string text130;
        private string text131;
        private string text132;
        private string text133;
        private string text134;
        private string text135;
        private string text136;
        private string text137;
        private string text138;
        private string text139;
        private string text140;
        private string text141;
        private string text142;
        private string text143;
        private string text144;
        private string text145;
        private string text146;
        private string text147;
        private string text148;
        private string text149;
        private string text150;
        private string text151;
        private string text152;
        private string text153;
        private string text154;
        private string text155;
        private string text156;
        private string text157;
        private string text158;
        private string text159;
        private string text160;
        private string text161;
        private string text162;
        private string text163;
        private string text164;
        private string text165;
        private string text166;
        private string text167;
        private string text168;
        private string text169;
        private string text170;
        private string text171;
        private string text172;
        private string text173;
        private string text174;
        private string text175;
        private string text176;
        private string text177;
        private string text178;
        private string text179;
        private string text180;
        private string text181;
        private string text182;
        private string text183;
        private string text184;
        private string text185;
        private string text186;
        private string text187;
        private string text188;
        private string text189;
        private string text190;
        private string text191;
        private string text192;
        private string text193;
        private string text194;
        private string text195;
        private string text196;
        private string text197;
        private string text198;
        private string text199;
        private string text200;
        private string text201;
        private string text202;
        private string text203;
        private string text204;
        private string text205;
        private string text206;
        private string text207;
        private string text208;
        private string text209;
        private string text210;
        private string text211;
        private string text212;
        private string text213;
        private string text214;
        private string text215;
        private string text216;
        private string text217;
        private string text218;
        private string text219;
        private string text220;
        private string text221;
        private string text222;
        private string text223;
        private string text224;
        private string text225;
        private string text226;
        private string text227;
        private string text228;
        private string text229;
        private string text230;
        private string text231;
        private string text232;
        private string text233;
        private string text234;
        private string text235;
        private string text236;
        private string text237;
        private string text238;
        private string text239;
        private string text240;
        private string text241;
        private string text242;
        private string text243;
        private string text244;
        private string text245;
        private string text246;
        private string text247;
        private string text248;
        private string text249;
        private string text250;
        private string text251;
        private string text252;
        private string text253;
        private string text254;
        private string text255;
        private string text256;
        private string text257;
        private string text258;
        private string text259;
        private string text260;
        private string text261;
        private string text262;
        private string text263;
        private string text264;
        private string text265;
        private string text266;
        private string text267;
        private string text268;
        private string text269;
        private string text270;
        private string text271;
        private string text272;
        private string text273;
        private string text274;
        private string text275;
        private string text276;
        private string text277;
        private string text278;
        private string text279;
        private string text280;
        private string text281;
        private string text282;
        private string text283;
        private string text284;
        private string text285;
        private string text286;
        private string text287;
        private string text288;
        private string text289;
        private string text290;
        private string text291;
        private string text292;
        //private string text293;
        private bool text1b;
        private bool text2b;
        private bool text3b;
        private bool text4b;
        private bool text5b;
        private bool text6b;
        private bool text7b;
        private bool text8b;
        private bool text9b;
        private bool text10b;
        private bool text11b;
        private bool text12b;
        private bool text13b;
        private bool text14b;
        private bool text15b;
        private bool text16b;
        private bool text17b;
        private bool text18b;
        private bool text19b;
        private bool text20b;
        private bool text21b;
        private bool text22b;
        private bool text23b;
        private bool text24b;
        private bool text25b;
        private bool text26b;
        private bool text27b;
        private bool text28b;
        private bool text29b;
        private bool text30b;
        private bool text31b;
        private bool text32b;
        private bool text33b;
        private bool text34b;
        private bool text35b;
        private bool text36b;
        private bool text37b;
        private bool text38b;
        private bool text39b;
        private bool text40b;
        private bool text41b;
        private bool text42b;
        private bool text43b;
        private bool text44b;
        private bool text45b;
        private bool text46b;
        private bool text47b;
        private bool text48b;
        //private bool text49b;
        private bool text50b;
        private bool text51b;
        private bool text52b;
        private bool text53b;
        private bool text54b;
        private bool text55b;
        private bool text56b;
        private bool text57b;
        private bool text58b;
        private bool text59b;
        private bool text60b;
        private bool text61b;
        private bool text62b;
        private bool text63b;
        private bool text64b;
        private bool text65b;
        private bool text66b;
        private bool text67b;
        private bool text68b;
        private bool text69b;
        private bool text70b;
        private bool text71b;
        private bool text72b;
        private bool text73b;
        private bool text74b;
        private bool text75b;
        private bool text76b;
        private bool text77b;
        private bool text78b;
        private bool text79b;
        private bool text80b;
        private bool text81b;
        private bool text82b;
        private bool text83b;
        private bool text84b;
        private bool text85b;
        private bool text86b;
        private bool text87b;
        private bool text88b;
        private bool text89b;
        private bool text90b;
        private bool text91b;
        private bool text92b;
        private bool text93b;
        private bool text94b;
        private bool text95b;
        private bool text96b;
        private bool text97b;
        private bool text98b;
        private bool text99b;
        private bool text100b;
        private bool text101b;
        private bool text102b;
        private bool text103b;
        private bool text104b;
        private bool text105b;
        private bool text106b;
        private bool text107b;
        private bool text108b;
        private bool text109b;
        private bool text110b;
        private bool text111b;
        private bool text112b;
        private bool text113b;
        private bool text114b;
        private bool text115b;
        private bool text116b;
        private bool text117b;
        private bool text118b;
        private bool text119b;
        private bool text120b;
        private bool text121b;
        private bool text122b;
        private bool text123b;
        private bool text124b;
        private bool text125b;
        private bool text126b;
        private bool text127b;
        private bool text128b;
        private bool text129b;
        private bool text130b;
        private bool text131b;
        private bool text132b;
        private bool text133b;
        private bool text134b;
        private bool text135b;
        private bool text136b;
        private bool text137b;
        private bool text138b;
        private bool text139b;
        private bool text140b;
        private bool text141b;
        private bool text142b;
        private bool text143b;
        private bool text144b;
        private bool text145b;
        private bool text146b;
        private bool text147b;
        private bool text148b;
        private bool text149b;
        private bool text150b;
        private bool text151b;
        private bool text152b;
        private bool text153b;
        private bool text154b;
        private bool text155b;
        private bool text156b;
        private bool text157b;
        private bool text158b;
        private bool text159b;
        private bool text160b;
        private bool text161b;
        private bool text162b;
        private bool text163b;
        private bool text164b;
        private bool text165b;
        private bool text166b;
        private bool text167b;
        private bool text168b;
        private bool text169b;
        private bool text170b;
        private bool text171b;
        private bool text172b;
        private bool text173b;
        private bool text174b;
        private bool text175b;
        private bool text176b;
        private bool text177b;
        private bool text178b;
        private bool text179b;
        private bool text180b;
        private bool text181b;
        private bool text182b;
        private bool text183b;
        private bool text184b;
        private bool text185b;
        private bool text186b;
        private bool text187b;
        private bool text188b;
        private bool text189b;
        private bool text190b;
        private bool text191b;
        private bool text192b;
        private bool text193b;
        private bool text194b;
        private bool text195b;
        private bool text196b;
        private bool text197b;
        private bool text198b;
        private bool text199b;
        private bool text200b;
        private bool text201b;
        private bool text202b;
        private bool text203b;
        private bool text204b;
        private bool text205b;
        private bool text206b;
        private bool text207b;
        private bool text208b;
        private bool text209b;
        private bool text210b;
        private bool text211b;
        private bool text212b;
        private bool text213b;
        private bool text214b;
        private bool text215b;
        private bool text216b;
        private bool text217b;
        private bool text218b;
        private bool text219b;
        private bool text220b;
        private bool text221b;
        private bool text222b;
        private bool text223b;
        private bool text224b;
        private bool text225b;
        private bool text226b;
        private bool text227b;
        private bool text228b;
        private bool text229b;
        private bool text230b;
        private bool text231b;
        private bool text232b;
        private bool text233b;
        private bool text234b;
        private bool text235b;
        private bool text236b;
        private bool text237b;
        private bool text238b;
        private bool text239b;
        private bool text240b;
        private bool text241b;
        private bool text242b;
        private bool text243b;
        private bool text244b;
        private bool text245b;
        private bool text246b;
        private bool text247b;
        private bool text248b;
        private bool text249b;
        private bool text250b;
        private bool text251b;
        private bool text252b;
        private bool text253b;
        private bool text254b;
        private bool text255b;
        private bool text256b;
        private bool text257b;
        private bool text258b;
        private bool text259b;
        private bool text260b;
        private bool text261b;
        private bool text262b;
        private bool text263b;
        private bool text264b;
        private bool text265b;
        private bool text266b;
        private bool text267b;
        private bool text268b;
        private bool text269b;
        private bool text270b;
        private bool text271b;
        private bool text272b;
        private bool text273b;
        private bool text274b;
        private bool text275b;
        private bool text276b;
        private bool text277b;
        private bool text278b;
        private bool text279b;
        private bool text280b;
        private bool text281b;
        private bool text282b;
        private bool text283b;
        private bool text284b;
        private bool text285b;
        private bool text286b;
        private bool text287b;
        private bool text288b;
        private bool text289b;
        private bool text290b;
        private bool text291b;
        private bool text292b;
        //private bool text293b;		
        private Rect guiBox = new Rect((Screen.width - 1024) / 2, (Screen.height - 1024) / 2, 1024, 1024);
        private bool guiShow;
        private float subtitle;
        private string path;

        public override void OnLoad()
        {
            path = ModLoader.GetModAssetsFolder(this);

            if (File.Exists(path + "/subtitle.txt"))
            {
                guiShow = false;
            }
            else
            {
                guiShow = true;
            }

            GameObject.Find("Subtitles").GetComponent<MeshRenderer>().enabled = false;
            GameObject.Find("Shadow").GetComponent<MeshRenderer>().enabled = false;
        }

        public override void OnGUI()
        {
            if (guiShow)
            {
                GUI.ModalWindow(1, this.guiBox, new GUI.WindowFunction(this.Window), "字幕 中文"); //startup window name
            }

            GUIStyle myStyle = new GUIStyle();
            myStyle.alignment = TextAnchor.MiddleCenter;
            myStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
            myStyle.normal.textColor = new Color(255, 165, 0);

            text1 = "\"" + "Don't be lazy. Fix your dad's old car. Uncle's blue van can be loaned. Don't drink alcohol! We will come back when we get bored. Yours, mom and dad" + "\"";
            if (text1b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "不要偷懒。快去修理你爸爸的旧车，" + "\n" + "叔叔的蓝色小货车可以借给你。不要喝酒，当我们玩到无聊之后， 我们会回来的 。你的爸爸妈妈.", myStyle);
            }

            text2 = "\"" + "Hello! I would like to buy a flatbed load of firewoods. You can deliver them any time!" + "\" ";
            if (text2b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我想买一车劈好的木柴。你可以随时送货过来！", myStyle);
            }

            text3 = "\"" + "Our sewage well is full of crap. Come and empty it." + "\"";
            if (text3b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我的污水井已经满了。来把它抽空。", myStyle);
            }

            text4 = "\"" + "My dad asked me to call about the sewage well, it is full. He is drunk." + "\"";
            if (text4b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我爸爸叫我打电话给有关污水井，已经满了。他喝醉了", myStyle);
            }

            text5 = "\"" + "Hi! Our shit is full of crap... sewage well. You should come here and suck it..." + "\"";
            if (text5b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你好！我们的屎满出来了…污水井。你应该来这里抽光它…", myStyle);
            }

            text6 = "\"" + "How could I say... Our sewage well is completely full... Could you empty it?" + "\"";
            if (text6b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我怎么能说…我们的污水井已经完全填满了。你能把它清空吗？", myStyle);
            }

            text7 = "\"" + "Could you suck our sewage well dry? I pay of course!" + "\"";
            if (text7b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你能把我们的污水干好吗？当然，我付钱！", myStyle);
            }

            text8 = "\"" + "Fleetari here! Your repair work is ready. Come here and get your stuff." + "\"";
            if (text8b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "Fleetari这里！你的修理工作已经完成了。过来拿你的东西。", myStyle);
            }

            text9 = "\"" + "Your post order has arrived. You can pick it up from the store." + "\"";
            if (text9b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你的邮购已经到了。你可以从商店里付款收件了。", myStyle);
            }

            text10 = "\"" + "Good morning and welcome to Rindell Car Inspection." + "\"";
            if (text10b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "早上好，欢迎光临Rindell Car Inspection.", myStyle);
            }

            text11 = "\"" + "Not sure what happened, your car passed." + "\"";
            if (text11b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "不知道发生了什么事，你的车通过了。", myStyle);
            }

            text12 = "\"" + "There is no way this is going to pass. But more money for me." + "\"";
            if (text12b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这是不可能实现的。除非你给我更多的钱。", myStyle);
            }

            text13 = "\"" + "I don't know what to say. My life and my job sucks." + "\"";
            if (text13b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我不知道说什么好。我的生活和工作糟透了。", myStyle);
            }

            text14 = "\"" + "Do not even bother to fix this. This car is ready for scrapping." + "\"";
            if (text14b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "不用费心去修理它。这辆车准备报废了。", myStyle);
            }

            text15 = "\"" + "You are such a character with this car of yours." + "\"";
            if (text15b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你真是一个拥有你这辆车的人。", myStyle);
            }

            text16 = "\"" + "I am not getting neither baby chickens or eggs." + "\"";
            if (text16b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我既没有鸡宝宝也没有鸡蛋。", myStyle);
            }

            text17 = "\"" + "Satan..." + "\"";
            if (text17b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "撒旦...", myStyle);
            }

            text18 = "\"" + "God help me." + "\"";
            if (text18b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "上帝保佑。", myStyle);
            }

            text19 = "\"" + "Oh pussy again..." + "\"";
            if (text19b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "哦，又是这脓样的", myStyle);
            }

            text20 = "\"" + "Satan again." + "\"";
            if (text20b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "撒旦再临.", myStyle);
            }

            text21 = "\"" + "Not the satan." + "\"";
            if (text21b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "不是这个撒旦。", myStyle);
            }

            text22 = "\"" + "Pussy." + "\"";
            if (text22b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "脓样的.", myStyle);
            }

            text23 = "\"" + "Go to pussy, satan." + "\"";
            if (text23b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "去你脓样的, 撒旦.", myStyle);
            }

            text24 = "\"" + "Go to pussy, please." + "\"";
            if (text24b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "请去你脓样的", myStyle);
            }

            text25 = "\"" + "You dork of the pussy." + "\"";
            if (text25b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你个傻脓样的.", myStyle);
            }

            text26 = "\"" + "You, go home." + "\"";
            if (text26b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你，回家.", myStyle);
            }

            text27 = "\"" + "Go to hell." + "\"";
            if (text27b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "下地狱", myStyle);
            }

            text28 = "\"" + "Smell a pussy!" + "\"";
            if (text28b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我闻到一个脓样的", myStyle);
            }

            text29 = "\"" + "Oh pussy!" + "\"";
            if (text29b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "奥，脓样的!", myStyle);
            }

            text30 = "\"" + "Oh satan!" + "\"";
            if (text30b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "奥, 撒旦!", myStyle);
            }

            text31 = "\"" + "One spring of pussies!" + "\"";
            if (text31b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "一个春天!", myStyle);
            }

            text32 = "\"" + "What the hell!?" + "\"";
            if (text32b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我勒个去!?", myStyle);
            }

            text33 = "\"" + "Satan?" + "\"";
            if (text33b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "撒旦?", myStyle);
            }

            text34 = "\"" + "It is the spring of pussies for sure!" + "\"";
            if (text34b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "肯定是春天的来了。!", myStyle);
            }

            text35 = "\"" + "Oh hell, for real!" + "\"";
            if (text35b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "奥，真是地狱啊!", myStyle);
            }

            text36 = "\"" + "The pussy of all pussies!" + "\"";
            if (text36b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "所有的娘娘腔!", myStyle);
            }

            text37 = "\"" + "God of thunder!" + "\"";
            if (text37b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "雷神!", myStyle);
            }

            text38 = "\"" + "God help me already!" + "\"";
            if (text38b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "上帝已经帮助我了！", myStyle);
            }

            text39 = "\"" + "There is no blood in my alcohol, much." + "\"";
            if (text39b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我的酒里没有血。", myStyle);
            }

            text40 = "\"" + "I used to be sober and I walked next to the fields." + "\"";
            if (text40b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我过去是清醒的，我走在田野旁边。", myStyle);
            }

            text41 = "\"" + "I haven't drank... enough... yet." + "\"";
            if (text41b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我还没喝过…够了…然而。", myStyle);
            }

            text42 = "\"" + "It is easy to be drunk. No stress from life and being sober." + "\"";
            if (text42b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "喝醉是很容易的。没有生活的压力和清醒。", myStyle);
            }

            text43 = "\"" + "I haven't drank anything, and I won't." + "\"";
            if (text43b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我什么都没喝，也不会喝。", myStyle);
            }

            text44 = "\"" + "Andy of the large house and the Shore of lake... blrb... braah..." + "\"";
            if (text44b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "安迪的大房子和湖的岸边…BRRB…布拉…", myStyle);
            }

            text45 = "\"" + "Let's take it easy." + "\"";
            if (text45b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "让我们轻松一下.", myStyle);
            }

            text46 = "\"" + "We are taking it hard at all." + "\"";
            if (text46b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我们完全是硬的.", myStyle);
            }

            text47 = "\"" + "Feels good, yes, for sure." + "\"";
            if (text47b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "感觉很好，是的，当然.", myStyle);
            }

            text48 = "\"" + "I am drunk as satan, but doesn't matter!" + "\"";
            if (text48b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我喝醉了撒旦，但不要紧！", myStyle);
            }

            //text49 = "\""+"Good lady-mister, I haven't drank at all, and I won't. When I am sober.+"\"";
            //if(text49b)
            //{
            //GUI.Label(new Rect(0, (Screen.height)/2.35f, Screen.width, Screen.height), "亲爱的先生”，我一点都不喝，我也不喝。当我清醒的时候。", myStyle);
            //}

            text50 = "\"" + "Hello! Are you a fly or a bird?" + "\"";
            if (text50b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你好！你是一只苍蝇还是一只鸟？", myStyle);
            }

            text51 = "\"" + "Andy of the large house and the Shore of lake!" + "\"";
            if (text51b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "安迪的大房子和湖滨！", myStyle);
            }

            text52 = "\"" + "Well. Looks like it's finished. Take the money." + "\"";
            if (text52b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "嗯。看起来已经结束了。拿钱。", myStyle);
            }

            text53 = "\"" + "Thank you very much, you've deserved your money." + "\"";
            if (text53b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "非常谢谢你，你应该得到你的钱。", myStyle);
            }

            text54 = "\"" + "I am very happy with your work. I couldn't do any better." + "\"";
            if (text54b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我对你的工作很满意。换我来的话我没办法做这么好。", myStyle);
            }

            text55 = "\"" + "Thank you. I am very happy with this, here is your money." + "\"";
            if (text55b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "谢谢”。我对此很高兴，这是你的钱。", myStyle);
            }

            text56 = "\"" + "Just take the money and let's continue with our lives." + "\"";
            if (text56b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "拿着钱，让我们继续我们的生活", myStyle);
            }

            text57 = "\"" + "No money, no rally participation for you." + "\"";
            if (text57b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "没有钱，没有集会参与为你。", myStyle);
            }

            text58 = "\"" + "You are required to wear a crash helmet." + "\"";
            if (text58b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你必须戴上头盔。", myStyle);
            }

            text59 = "\"" + "Your car is missing required safety gear." + "\"";
            if (text59b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你的汽车缺少所需的安全装置。", myStyle);
            }

            text60 = "\"" + "Your car needs to be inspected and registered." + "\"";
            if (text60b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你的车需要通过检查并挂牌。", myStyle);
            }

            text61 = "\"" + "You are drunk. Go home." + "\"";
            if (text61b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你喝醉了。回家", myStyle);
            }

            text62 = "\"" + "Hello! What is on your mind young man?" + "\"";
            if (text62b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你好”！年轻人，你在想什么？", myStyle);
            }

            text63 = "\"" + "That car of yours ruins my driveway." + "\"";
            if (text63b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你的车毁了（冲到？）我的车道", myStyle);
            }

            text64 = "\"" + "Come back when you have the money." + "\"";
            if (text64b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "当你有钱的时候再来”", myStyle);
            }

            text65 = "\"" + "Why do you even come here if you don't have any money?" + "\"";
            if (text65b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "如果你没有钱，你为什么还要来这里？", myStyle);
            }

            text66 = "\"" + "You can take my Ferndale if you need to get back home." + "\"";
            if (text66b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "如果你需要回家的话，你可以顺便带我Ferndale", myStyle);
            }

            text67 = "\"" + "It's Fleetari here! You moron, bring back my car or I make sure your shit bucket car does not see another day!" + "\"";
            if (text67b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这里是FrelaLi！你这个笨蛋，把我的车拿回来，不然我肯定你再也见不到你的车了！", myStyle);
            }

            text68 = "\"" + "What a great junk find! Thanks boy. Here is some money for it." + "\"";
            if (text68b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "一个伟大的垃圾（废车？）找到！谢谢孩子。这里有一些钱。", myStyle);
            }

            text69 = "\"" + "I can't believe it... You are rally winner. I must admit you have such big balls. I thought you were going to die, but you won!" + "\"";
            if (text69b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我不敢相信…你是拉力赛冠军。我必须承认你有这么大的能耐。我以为你要输了，但你赢了！", myStyle);
            }

            text70 = "\"" + "It is Fleetari here. Want to earn 10 bottles of booze? Dump some shit at the front of the Lindell inspection shop. That sucker deserves it." + "\"";
            if (text70b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这是Fleetari。想赚10瓶酒吗？把一些(抽出来的）屎扔到Lindell检验店的前面。这是他应得的。", myStyle);
            }

            text71 = "\"" + "Oh boy, I heard what you did! Here is a ten bottles of booze, you really deserve this!" + "\"";
            if (text71b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "哦，孩子，我听到你做了什么！这是十瓶酒，你真的配得上这个！", myStyle);
            }

            text72 = "\"" + "My neighbor is a dick." + "\"";
            if (text72b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我的邻居是个混蛋", myStyle);
            }

            text73 = "\"" + "You dick of a pussy." + "\"";
            if (text73b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你这个混蛋脓样", myStyle);
            }

            text74 = "\"" + "You truly are a wart of a dick." + "\"";
            if (text74b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你真是个恶棍", myStyle);
            }

            text75 = "\"" + "Stop walking around like a damn fool. You do not make any sense, ruining my perfect day." + "\"";
            if (text75b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "别像一个该死的傻瓜一样走来走去。你这么做没有任何意义，还毁掉了我完美的一天。", myStyle);
            }

            text76 = "\"" + "So the signs are in the air? You know, someone is going to get hurt soon." + "\"";
            if (text76b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "那么看这迹象？你知道，有人很快就会受伤", myStyle);
            }

            text77 = "\"" + "Let me see that finger one more time and I will smash your head." + "\"";
            if (text77b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "让我再看一次手指，我会砸碎你的头。", myStyle);
            }

            text78 = "\"" + "What the fuck? Come here and show me that finger of yours." + "\"";
            if (text78b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "他妈的什么？过来，给我看看你的手指。", myStyle);
            }

            text79 = "\"" + "Who is this pussy-ass idiot?" + "\"";
            if (text79b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这个笨蛋蠢驴是谁？", myStyle);
            }

            text80 = "\"" + "So you want that I make a dinner out from your finger? And shove it down to your throat?" + "\"";
            if (text80b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "所以你要我用你的手指做晚餐？把它推到你的喉咙里？", myStyle);
            }

            text81 = "\"" + "Stop fooling around or I will smash your head and hard!" + "\"";
            if (text81b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "别胡闹了，否则我会砸烂你的脑袋！", myStyle);
            }

            text82 = "\"" + "God of Thunder! You are so dead!" + "\"";
            if (text82b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "雷神”！你死定了！", myStyle);
            }

            text83 = "\"" + "So you would like to race with that shit bucket of yours? Which one is faster?" + "\"";
            if (text83b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "所以你想与你的狗屎比赛吗？哪一个更快？", myStyle);
            }

            text84 = "\"" + "What is that piss you're drinking? Like drinking from a wc bowl. You should drink Kurjala beer!" + "\" ";
            if (text84b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你喝的尿是什么？就像从WC碗里喝水一样。你应该喝库拉拉啤酒！", myStyle);
            }

            text85 = "\"" + "Is Teimo selling you that shit? He should sell some Kurjala instead. Everything is just shit." + "\"";
            if (text85b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "是Teimo卖给你那狗屎吗？他应该卖掉一些库尔亚拉。一切都是狗屎。", myStyle);
            }

            text86 = "\"" + "Fuck you, no one is drinking that shit. Just throw it away, you little shit." + "\"";
            if (text86b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "操，没有人在喝那狗屎。扔掉它，你这个小狗屎。", myStyle);
            }

            text87 = "\"" + "I don't have energy to watch your face." + "\"";
            if (text87b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我没有精力去看你的脸。", myStyle);
            }

            text88 = "\"" + "You dick of a pussy!" + "\"";
            if (text88b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你这个脓样的混蛋！", myStyle);
            }

            text89 = "\"" + "Smell a shit!" + "\"";
            if (text89b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "臭狗屎!", myStyle);
            }

            text90 = "\"" + "Smell pussy!" + "\"";
            if (text90b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "臭脓样!", myStyle);
            }

            text91 = "\"" + "I taste little bit yeast in this..." + "\"";
            if (text91b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我尝了一点点酵母菌...", myStyle);
            }

            text92 = "\"" + "I taste some vinegar here... could be better." + "\"";
            if (text92b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我喜欢吃一些醋。可以更好。", myStyle);
            }

            text93 = "\"" + "Could be stronger for sure... little lame." + "\"";
            if (text93b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "可以肯定更强。小瘸腿。", myStyle);
            }

            text94 = "\"" + "Let's see how good sugar wine this is..." + "\"";
            if (text94b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "让我们看看这是多么好的糖酒...", myStyle);
            }

            text95 = "\"" + "This tastes nothing but yeast! This is shit, take it a away." + "\"";
            if (text95b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这只不过是酵母！这是狗屎，拿走它。", myStyle);
            }

            text96 = "\"" + "What the hell, this is like drinking pickels in piss! Take this shit out of here." + "\"";
            if (text96b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "什么该死的，这就像是在小便里喝泡泡糖！把这狗屎从这里拿出来。", myStyle);
            }

            text97 = "\"" + "This tastes like water and piss, I want alcohol, not this mess..." + "\"";
            if (text97b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这味道像水和尿，我想要酒精，不是这个烂摊子...", myStyle);
            }

            text98 = "\"" + "This is drinkable... I can pay something for this." + "\"";
            if (text98b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这是可以喝的…我可以为此付出代价。", myStyle);
            }

            text99 = "\"" + "Very good sugar wine! I love this, strong as hell! I pay good for this." + "\"";
            if (text99b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "非常好的糖酒！”我爱这个，像地狱一样坚强！我为此付出了很好的代价。", myStyle);
            }

            text99 = "\"" + "Very good sugar wine! I love this, strong as hell! I pay good for this." + "\"";
            if (text99b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "非常好的糖酒！”我爱这个，像地狱一样坚强！我为此付出了很好的代价。", myStyle);
            }

            text100 = "\"" + "I tried to call everybody. Please can you pick me up from the Pub and drive me home?" + "\"";
            if (text100b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我试图给每个人打电话。请你从酒吧接我，开车送我回家好吗？", myStyle);
            }

            text101 = "\"" + "This is good, this here is my house, this here... house." + "\"";
            if (text101b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这是好的，这是我的房子，这里…房子", myStyle);
            }

            text102 = "\"" + "Here is a small compensation of your troubles." + "\"";
            if (text102b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这是麻烦你的一个小小的补偿。", myStyle);
            }

            text103 = "\"" + "My wife constantly reminds me of my drinking... But drinking is a job... for drunkman." + "\"";
            if (text103b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我妻子经常提醒我别喝酒。但是作为醉汉···喝酒是一项工作啊。", myStyle);
            }

            text104 = "\"" + "My wife is going to move to Vaasa and get herself a finnswede man. Those are so clean and sober! 30 years of marriage down the drain." + "\"";
            if (text104b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我的妻子打算搬到瓦萨，给自己找一个芬兰男人。" + "\n" + "那些是如此干净利落！30年婚姻要没了", myStyle);
            }

            text105 = "\"" + "That train is driving me crazy. It blows that whistle just to fuck with me. Every day!" + "\"";
            if (text105b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "那辆火车快把我逼疯了。每一天，它的噪音就像要和我做爱！", myStyle);
            }

            text106 = "\"" + "One of these days I will run to the rail tracks and shout: Blow that whistle and run over me, sucker!" + "\"";
            if (text106b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "有一天，我会跑到铁轨上大喊：吵死了，滚蛋，傻瓜！", myStyle);
            }

            text107 = "\"" + "You are wise boy... I need to tell you something. You know, nobody knows that I am very rich man. A millionaire..." + "\" ";
            if (text107b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你是个聪明的男孩…我需要告诉你一些事情。你知道，" + "\n" + "没人知道我是个非常有钱的人。百万富翁……", myStyle);
            }

            text108 = "\"" + "I need to act like I always do... I am richest drunk bum there is! At least my wife stays with me. Not with some dorky finnswede tomato farmer." + "\"";
            if (text108b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我需要像我现在的生活一样继续…我是最富有的酒鬼！" + "\n" + "至少我妻子和我在一起。不是和一些笨手笨脚的西红柿农场主。", myStyle);
            }

            text109 = "\"" + "My wife did not know she had a winning Lottery ticket. I took it and got the money myself... 5 million marks!" + "\"";
            if (text109b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我妻子不知道她有一张中奖的彩票。我自己拿了钱500万分！", myStyle);
            }

            text110 = "\"" + "I have the money in a hidden suitcase. But I can't use the money because wife would get suspicious... She would leave me if she had that money!" + "\"";
            if (text110b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我有一个隐藏在手提箱里的钱。但我不能用这笔钱，" + "\n" + "因为妻子会怀疑…如果她有钱，她就会离开我！", myStyle);
            }

            text111 = "\"" + "You little bastard! You have taken my money!" + "\"";
            if (text111b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你这个小杂种！”你拿走了我的钱！", myStyle);
            }

            text112 = "\"" + "What is the problem if money does not do it for you?" + "\"";
            if (text112b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "如果钱不是为你拿的，那么是谁拿的？", myStyle);
            }

            text113 = "\"" + "Good evening! Thank you for coming!" + "\"";
            if (text113b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "晚上好！谢谢您的光临！", myStyle);
            }

            text114 = "\"" + "Thank you and see you later!" + "\"";
            if (text114b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "谢谢你，再见！", myStyle);
            }

            text115 = "\"" + "You are too poor for these purchases." + "\"";
            if (text115b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你太穷了就买这些.", myStyle);
            }

            text116 = "\"" + "Oh my god... Adult man peeing all over the place. My store is not a toilet." + "\"";
            if (text116b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "哦，我的上帝……成年男子到处撒尿。我的商店不是厕所。", myStyle);
            }

            text117 = "\"" + "Well well... Good day for you too, glumpsy." + "\" ";
            if (text117b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "嗯…祝你好运，glumpsy", myStyle);
            }

            text118 = "\"" + "Welcome to the Teim... Oh it's you." + "\"";
            if (text118b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "欢迎来到TEIM…哦，是你。", myStyle);
            }

            text119 = "\"" + "I am about to close the store, so shake that booty little faster." + "\"";
            if (text119b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我快关店了，所以想要买东西的请快一点。", myStyle);
            }

            text120 = "\"" + "Did you know I used to be a wrestler? Not professional though." + "\"";
            if (text120b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你知道我曾经是个摔跤手吗？但不专业。", myStyle);
            }

            text121 = "\"" + "What and odd summer. It rains and then rain stops." + "\"";
            if (text121b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "多么奇怪的夏天。雨来了又停了", myStyle);
            }

            text122 = "\"" + "Have you listened a radio lately? It is full of punks these days." + "\"";
            if (text122b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你最近听过收音机吗？这些日子里到处都说朋克", myStyle);
            }

            text123 = "\"" + "I used to be a quite a fisherman. Thats one thing I used to be." + "\"";
            if (text123b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我曾经是一个相当不错的渔夫。这是我曾经做过的一件事。", myStyle);
            }

            text124 = "\"" + "Tourists don't buy milk. They buy beer and milk goes sour. That's how it goes I guess." + "\"";
            if (text124b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "游客不买牛奶。他们买啤酒，牛奶会变酸。我猜是这样的", myStyle);
            }

            text125 = "\"" + "I used to have a dog. Again one thing I used to have." + "\"";
            if (text125b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我过去有一只狗。还有一件事我曾经有过..", myStyle);
            }

            text126 = "\"" + "I can't understand today's music at all. Must be something that has been made for punks." + "\"";
            if (text126b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我根本听不懂今天的音乐。必须是为朋克制造的东西..", myStyle);
            }

            text127 = "\"" + "Marjattaaaaaaa...... You used to carry light to me..." + "\"";
            if (text127b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "Marjattaaaaaaa……你曾经给我带着光……", myStyle);
            }

            text128 = "\"" + "Those little punks are buying all the sugar and yeast. Let them enjoy their farts, all I care." + "\"";
            if (text128b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "那些小朋克正在购买所有的糖和酵母。让他们享受他们的屁，我只在乎", myStyle);
            }

            text129 = "\"" + "They say fuel price is high. I say, they haven't seen anything yet. It will cost more than milk one day." + "\"";
            if (text129b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "他们说燃油价格高。我说，他们还没有看到任何东西。一天比牛奶还要贵。", myStyle);
            }

            text130 = "\"" + "This economic regression. It can get quite bad. I might need to discount sausage prices." + "\"";
            if (text130b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这种经济回归。可能会很糟糕。我可能需要打折香肠价格", myStyle);
            }

            text131 = "\"" + "Very beautiful finger you got there. Really, I am not kidding." + "\" ";
            if (text131b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "非常漂亮的手指你到达那里。”真的，我不是开玩笑的。", myStyle);
            }

            text132 = "\"" + "Fuck off little punk." + "\"";
            if (text132b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "操 小朋克", myStyle);
            }

            text133 = "\"" + "You know the green car that drives the backroads and never stops for gas? I think the car runs with alcohol." + "\"";
            if (text133b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你知道绿色汽车，后轮驱动，永不停止的排气" + "\n" + "我想这辆车是用酒精行驶的。", myStyle);
            }

            text134 = "\"" + "I do not think that mosquito spray really works. Even after spraying full can those little punks keep flying around." + "\"";
            if (text134b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我不认为蚊子喷雾真的起作用。" + "\n" + "即使喷满后，这些小朋克也能四处飞翔。", myStyle);
            }

            text135 = "\"" + "Could you possibly pay with coins? I lost the key for the slot machine and I can't get the money out..." + "\"";
            if (text135b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你能用硬币支付吗？我把老虎机的钥匙丢了，我拿不到钱...", myStyle);
            }

            text136 = "\"" + "Those punks. Why do they keep calling me in the middle of the night? I have since unplugged my phone for the night." + "\"";
            if (text136b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "那些朋克”。为什么他们一直在半夜给我打电话？从那以后我就拔出了我的手机", myStyle);
            }

            text137 = "\"" + "My washing machine is broken. I have only one pair of clean underwear... Oh... I mean I had... Well, shit happens." + "\"";
            if (text137b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我的洗衣机坏了。我只有一双干净的内衣…哦。。。我的意思是…嗯，狗屎发生了。", myStyle);
            }

            text138 = "\"" + "I am done with drinking. You know how my eyes are not focusing straight after I have drank some." + "\"";
            if (text138b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我喝完了。你知道我的眼睛是不是在我喝了一些东西之后一直不停地聚焦。", myStyle);
            }

            text139 = "\"" + "So, are you participating the rally? I was once second when there were two competitors. Sometimes you come out alive." + "\"";
            if (text139b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "那么，你参加集会了吗？”有两个竞争者时，我一度位居第二。有时你活着出来。", myStyle);
            }

            text140 = "\"" + "Did you know that a small sticker representing country of Finland costs many hunderds of marks? That is insane." + "\"";
            if (text140b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你知道一个代表芬兰国家的小贴纸要花很多马克吗？那是疯狂的。", myStyle);
            }

            text141 = "\"" + "Throw yourself up on to the hill, you little punk." + "\"";
            if (text141b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "把你自己扔到山上，你这个小朋克。", myStyle);
            }

            text142 = "\"" + "Hey you little drunk punk, do not lean on to the shelf and mess up my store. I hate drunk cretins." + "\"";
            if (text142b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "嘿，你这个小酒鬼，不要趴在架子上弄乱我的商店。”我讨厌醉鬼。", myStyle);
            }

            text143 = "\"" + "No no no... Why are you peeing there? Adult man, you little punk!" + "\"";
            if (text143b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "不不不。你为什么在那儿撒尿？大人，你这个小混蛋！", myStyle);
            }

            text144 = "\"" + "What...? You damn punk, now get the hell out of here. Peeing all over the place!" + "\"";
            if (text144b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "什么？你这个该死的朋克，现在滚开。到处撒尿！", myStyle);
            }

            text145 = "\"" + "I know you've stolen fuel. Come back and pay!" + "\"";
            if (text145b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我知道你偷了燃料。回来付钱！", myStyle);
            }

            text146 = "\"" + "Hello!" + "\"";
            if (text146b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你好!", myStyle);
            }

            text147 = "\"" + "Good day!" + "\"";
            if (text147b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "好日子!", myStyle);
            }

            text148 = "\"" + "Thank you for visiting!" + "\"";
            if (text148b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "谢谢你的来访!", myStyle);
            }

            text149 = "\"" + "Hey to the dishes and dishes to the dish washer!" + "\"";
            if (text149b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "嘿，菜和菜到洗碗机!", myStyle);
            }

            text150 = "\"" + "Well good day, what brings you to the city?" + "\"";
            if (text150b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "好的一天，是什么把你带到城市的？", myStyle);
            }

            text151 = "\"" + "508... 509... Well hello! What can I do for you?" + "\"";
            if (text151b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "508…509…你好！我能为您做点什么？", myStyle);
            }

            text152 = "\"" + "Thank you and so long!" + "\"";
            if (text152b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "谢谢你，这么久！", myStyle);
            }

            text153 = "\"" + "We'll see again!" + "\"";
            if (text153b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我们再看一遍！", myStyle);
            }

            text154 = "\"" + "Thank you for business co-operation!" + "\"";
            if (text154b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "谢谢您的业务合作！", myStyle);
            }

            text155 = "\"" + "Thank you very much and have nice day!" + "\"";
            if (text155b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "非常感谢你，祝你有美好的一天！", myStyle);
            }

            text156 = "\"" + "Wha... I... Th... Piss... Yo... Damn punk peeing... Oh my god what is this, you get out of here now!" + "\"";
            if (text156b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "WHA…I.…钍…撒尿…哟。。。该死的朋克嘘声…哦，天哪，这是什么，你现在离开这里！", myStyle);
            }

            text157 = "\"" + "For such young punk, you are quite a man when it comes to drinking." + "\"";
            if (text157b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "对于这样一个年轻的朋克，当你喝酒的时候，你是个相当不错的人。", myStyle);
            }

            text158 = "\"" + "How about one bottle of Noble booze and asbestos gloves, or tall friends?" + "\"";
            if (text158b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "一瓶高贵的酒和石棉手套，还是高的朋友？", myStyle);
            }

            text159 = "\"" + "What would you like? Golden brown Nivalan Kalia together with horrible day after ramifications?" + "\"";
            if (text159b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你想要什么？Golden brown Nivalan Kalia together with horrible day after ramifications？", myStyle);
            }

            text160 = "\"" + "Today we have a special offer! If you buy one beer, you are able to buy second beer as well!" + "\"";
            if (text160b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "今天我们有一个特别优惠！如果你买一杯啤酒，你也能买到第二杯啤酒！", myStyle);
            }

            text161 = "\"" + "So, you too are here to make your brains forgot how depressing is our life in here?" + "\"";
            if (text161b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "所以，你也在这里让你的大脑忘记我们这里的生活有多么压抑吗？", myStyle);
            }

            text162 = "\"" + "Hey punk! You are going to pay for that!" + "\"";
            if (text162b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "嘿朋克！你会为此付出代价的！", myStyle);
            }

            text163 = "\"" + "So... How much can you absorb alcohol?" + "\"";
            if (text163b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "所以…你能吸收多少酒精？", myStyle);
            }

            text164 = "\"" + "Should you stop the drinking now that you are still able to stand?" + "\"";
            if (text164b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "如果你还可以站立，你应该停止喝酒吗？", myStyle);
            }

            text165 = "\"" + "Just go for it and shatter your life!" + "\"";
            if (text165b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "只为它，粉碎你的生命!", myStyle);
            }

            text166 = "\"" + "I assume this is your last drink, right?" + "\"";
            if (text166b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我想这是你最后一杯饮料，对吧?", myStyle);
            }

            text167 = "\"" + "I hate these flies and mosquitos. Buzzing.... These suckers are pissing me off!" + "\"";
            if (text167b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我讨厌这些苍蝇和蚊子。嗡嗡声…这些吸食鬼把我惹火了！", myStyle);
            }

            text168 = "\"" + "If you have problem with this, you can go to another store. But oh... you can't. He he" + "\"";
            if (text168b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "如果你有这个问题，你可以去另一个商店。但是哦…你不能。他.", myStyle);
            }

            text169 = "\"" + "Is this your birthday or what sort of festival are you having?" + "\"";
            if (text169b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这是你的生日或是什么节日？", myStyle);
            }

            text170 = "\"" + "Yeah yeah, and now add some butter in between." + "\"";
            if (text170b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "是的，是的，现在在中间加一些黄油", myStyle);
            }

            text171 = "\"" + "I wonder if I am committing a crime here, serving you." + "\"";
            if (text171b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我想知道我是否在这里犯罪，为你服务？", myStyle);
            }

            text172 = "\"" + "Sooo.. It seems like you are starting to drink for the third leg as well." + "\"";
            if (text172b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "SOOO。看来你也开始为第三条腿喝水了", myStyle);
            }

            text173 = "\"" + "There seems to be no point with your drinking..." + "\"";
            if (text173b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你的饮酒似乎没有任何意义…", myStyle);
            }

            text174 = "\"" + "I wonder whether I should enlarge the corridors here because the wide dance moves of yours." + "\"";
            if (text174b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我不知道我是否应该扩大这里的走廊，因为你的舞蹈动作很宽。", myStyle);
            }

            text175 = "\"" + "Well look at the kid. You are such bottomless pit, I must say." + "\"";
            if (text175b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "看孩子。”我必须说，你是个无底洞。", myStyle);
            }

            text176 = "\"" + "This is what human relationships are, you live with it." + "\"";
            if (text176b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这就是人类的关系，你和它一起生活。", myStyle);
            }

            text177 = "\"" + "It is our own boy, human waste transport guy! Stop smelling like shit and go to hell." + "\"";
            if (text177b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "它是我们自己的男孩，人类浪费运输的家伙！”停止闻狗屎，然后去地狱。", myStyle);
            }

            text178 = "\"" + "You don't have better things to do but smell bad? There is piss already everywhere, now it smells like shit too." + "\"";
            if (text178b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你没有更好的事情做，但气味不好？到处都有尿，现在闻起来像狗屎。", myStyle);
            }

            text179 = "\"" + "Oh boy... Even the most famous cuckoo would say that, you sir, are drunk." + "\"";
            if (text179b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "哦男孩”即使是最有名的杜鹃也会说，先生，你喝醉了。", myStyle);
            }

            text180 = "\"" + "And drunk again? Please do not puke inside the frozen fish fridge, like that one occasion." + "\"";
            if (text180b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "然后又喝醉了吗？请不要在冷冻鱼冰箱里呕吐，就像那个场合。", myStyle);
            }

            text181 = "\"" + "Stop dancing with your fist female. I will smack your face and you fly like a wooden javelin!" + "\"";
            if (text181b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "停止与拳头女性跳舞。我会打你的脸，你像木头标枪一样飞！", myStyle);
            }

            text182 = "\"" + "I am president of Finland." + "\"";
            if (text182b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我是芬兰总统", myStyle);
            }

            text183 = "\"" + "There is first lady." + "\"";
            if (text183b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "有第一夫人", myStyle);
            }

            text184 = "\"" + "So, this is the way I am a president all along." + "\"";
            if (text184b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "所以，这就是我一直是总统的方式。.", myStyle);
            }

            text185 = "\"" + "From the president jail, to here to countryside." + "\"";
            if (text185b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "从总统监狱，到这里到农村.", myStyle);
            }

            text186 = "\"" + "My drivers name is Cadet Tenho." + "\"";
            if (text186b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我的司机名字是Cadet Tenho.", myStyle);
            }

            text187 = "\"" + "Of course not! I am a president." + "\"";
            if (text187b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "当然不是！我是总统。", myStyle);
            }

            text188 = "\"" + "He? I haven't even heard about it." + "\"";
            if (text188b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "他？我还没有听说过", myStyle);
            }

            text189 = "\"" + "My personal assistant is mr. Wood-Field-Forest." + "\"";
            if (text189b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我的私人助理是Wood-Field-Forest.。", myStyle);
            }

            text190 = "\"" + "Well after all, I am a president." + "\"";
            if (text190b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "毕竟，我是一个总统", myStyle);
            }

            text191 = "\"" + "See, a birch. Flowery rose." + "\"";
            if (text191b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "看，桦树。玫瑰花", myStyle);
            }

            text192 = "\"" + "It is hard as a wet bedrock." + "\"";
            if (text192b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "它是一个硬的湿基岩.", myStyle);
            }

            text193 = "\"" + "Well I am a president." + "\"";
            if (text193b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我是总统.", myStyle);
            }

            text194 = "\"" + "The first lady is quite thin person." + "\"";
            if (text194b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "第一夫人是相当瘦的人.", myStyle);
            }

            text195 = "\"" + "When president was a carpenter, wife was still young. So does the profession make us old." + "\"";
            if (text195b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "当总统是木匠时，妻子还年轻。工作也使我们变老了.", myStyle);
            }

            text196 = "\"" + "Change is welcomed. I used to sit in jail all the time." + "\"";
            if (text196b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "改变是受欢迎的。我过去总是坐在监狱里.", myStyle);
            }

            text197 = "\"" + "I was not in Alcatraz, but in presidential jail." + "\"";
            if (text197b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我不在恶魔岛，而是在总统监狱里.", myStyle);
            }

            text198 = "\"" + "So after all, I am a president." + "\"";
            if (text198b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "所以毕竟，我是总统.", myStyle);
            }

            text199 = "\"" + "Listen, officer. I am a president." + "\"";
            if (text199b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "听着。我是总统.", myStyle);
            }

            text200 = "\"" + "I could fire you at any moment, officer." + "\"";
            if (text200b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我随时可以开火，警官。", myStyle);
            }

            text201 = "\"" + "I am a president, after all." + "\"";
            if (text201b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我毕竟是总统.", myStyle);
            }

            text202 = "\"" + "I am not drunk, and not in St Michel, I am here." + "\"";
            if (text202b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我没有醉，而不是在圣米歇尔，我在这里.", myStyle);
            }

            text203 = "\"" + "I haven't had a single drink." + "\"";
            if (text203b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "“我没有喝过一杯.", myStyle);
            }

            text204 = "\"" + "I am the president." + "\"";
            if (text204b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我是总统.", myStyle);
            }

            text205 = "\"" + "I am first president of Finland who has his pants upside down." + "\"";
            if (text205b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我是芬兰的第一任总统，他的裤子上下颠倒.", myStyle);
            }

            text206 = "\"" + "My watch shows the correct time of Finnish republic." + "\"";
            if (text206b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我的表显示芬兰共和国的正确时间。.", myStyle);
            }

            text207 = "\"" + "I am police officer." + "\"";
            if (text207b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我是警官.", myStyle);
            }

            text208 = "\"" + "I am here to check drunk state of potato president." + "\"";
            if (text208b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我在这里检查土豆总统的醉状态.", myStyle);
            }

            text209 = "\"" + "I know you are not coming from a jail." + "\"";
            if (text209b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我知道你不是从监狱来的.", myStyle);
            }

            text210 = "\"" + "Not like Alcatraz, but presidential jail." + "\"";
            if (text210b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "不象恶魔岛，而是总统监狱", myStyle);
            }

            text211 = "\"" + "I am police officer, after all." + "\"";
            if (text211b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我是警官，毕竟，", myStyle);
            }

            text212 = "\"" + "Mr. President." + "\"";
            if (text212b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "总统先生.", myStyle);
            }

            text213 = "\"" + "You can't go here." + "\"";
            if (text213b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你不能到这里", myStyle);
            }

            text214 = "\"" + "Because of my rights." + "\"";
            if (text214b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "因为我的权利", myStyle);
            }

            text215 = "\"" + "I cannot deliver you." + "\"";
            if (text215b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我不能递送你.", myStyle);
            }

            text216 = "\"" + "In to jail." + "\"";
            if (text216b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "在监狱中.", myStyle);
            }

            text217 = "\"" + "Because." + "\"";
            if (text217b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "因为.", myStyle);
            }

            text218 = "\"" + "Because you are... of Finland." + "\"";
            if (text218b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "因为你是…芬兰的.", myStyle);
            }

            text219 = "\"" + "President." + "\"";
            if (text219b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "总统.", myStyle);
            }

            text220 = "\"" + "The first lady." + "\"";
            if (text220b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "第一夫人.", myStyle);
            }

            text221 = "\"" + "It truly looks like." + "\"";
            if (text221b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "它看起来像", myStyle);
            }

            text222 = "\"" + "That...'" + "\"";
            if (text222b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "那个...", myStyle);
            }

            text223 = "\"" + "Looks like a bad shape to me." + "\"";
            if (text223b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "看起来像是一个坏的形状.", myStyle);
            }

            text224 = "\"" + "Finnish president of Zanzibar of Africa." + "\"";
            if (text224b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "芬兰桑给巴尔总统”.", myStyle);
            }

            text225 = "\"" + "To the moment." + "\"";
            if (text225b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "到此刻", myStyle);
            }

            text226 = "\"" + "You are." + "\"";
            if (text226b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你是.", myStyle);
            }

            text227 = "\"" + "Right here, right now." + "\"";
            if (text227b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "在这里，现在.", myStyle);
            }

            text228 = "\"" + "At this time." + "\"";
            if (text228b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "此时.", myStyle);
            }

            text229 = "\"" + "About here." + "\"";
            if (text229b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "在这里.", myStyle);
            }

            text230 = "\"" + "For this." + "\"";
            if (text230b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "为此.", myStyle);
            }

            text231 = "\"" + "I am a officer... ding dong." + "\"";
            if (text231b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我是一名军官… ding dong.", myStyle);
            }

            text232 = "\"" + "I guarantee your safety." + "\"";
            if (text232b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我保证您的安全.", myStyle);
            }

            text233 = "\"" + "That is not what I said." + "\"";
            if (text233b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "那不是我所说的", myStyle);
            }

            text234 = "\"" + "Well I am just a human, as you can see." + "\"";
            if (text234b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "正如你所见，我只是一个人", myStyle);
            }

            text235 = "\"" + "I salute your wife, Mr. President." + "\"";
            if (text235b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "总统先生，我向您的妻子致敬.", myStyle);
            }

            text236 = "\"" + "Party? I don't want to." + "\"";
            if (text236b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "党？我不想", myStyle);
            }

            text237 = "\"" + "But, I do not accept." + "\"";
            if (text237b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "但是，我不接受", myStyle);
            }

            text238 = "\"" + "You are drunk." + "\"";
            if (text238b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你喝醉了.", myStyle);
            }

            text239 = "\"" + "Yes?" + "\"";
            if (text239b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "是?", myStyle);
            }

            text240 = "\"" + "Good day, good day! Here have some coffee." + "\"";
            if (text240b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "好日子，好日子！这里有一些咖啡!", myStyle);
            }

            text241 = "\"" + "Your dad is quite sober man. I thought he would start drinking after being rejected from 1972 Olympics." + "\"";
            if (text241b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你父亲是个相当清醒的人。我想他会在1972奥运会被拒绝后开始喝酒。", myStyle);
            }

            text242 = "\"" + "Maybe the alcohol gene is gotten into you. Keep away from drinking! Take a look at your uncle. I hope he is doing okay." + "\"";
            if (text242b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "可能是酒精基因进入你。远离饮酒！" + "\n" + "看看你叔叔。我希望他没事", myStyle);
            }

            text243 = "\"" + "Like Valto your granddad. After he came from war he was different man. No talking, no kissing. Only drinking." + "\"";
            if (text243b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "就像Valto，你的爷爷。他出战后是个与众不同的人。" + "\n" + "不说话，不接吻。只有喝酒。", myStyle);
            }

            text244 = "\"" + "The war was hard place for those young boys. But Valto came back and built this house and set up those fields before dying from drinking." + "\"";
            if (text244b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "战争对于那些年轻男孩来说是很难的。" + "\n" + "但Valto回来建造了这所房子，然后在喝酒前把那些田地建起来。", myStyle);
            }

            text245 = "\"" + "And here is little money for you. I know you need it." + "\"";
            if (text245b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这是给你的一点钱。我知道你需要它。", myStyle);
            }

            text246 = "\"" + "Just a warning, never pick a lift from your cousing with the green car. Same family with the drinking problem, always drunk." + "\"";
            if (text246b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "只是一个警告，不要搭一辆绿色车。同一家人喝酒的问题，总是醉醺醺的。.", myStyle);
            }

            text247 = "\"" + "One day I was picking up mail, and almost got run over by him! Happy and drunk he was. Don't go with him." + "\"";
            if (text247b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "有一天我捡起邮件，差点被他撞倒！他醉醺醺的。不要和他一起去。", myStyle);
            }

            text248 = "\"" + "Do you have a plans for future? Are you staying here? No reason to move to the city, there you find only foolishness." + "\"";
            if (text248b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你有未来的计划吗？你住在这里吗？没有理由搬到城市去，在那里你只会发现愚蠢。", myStyle);
            }

            text249 = "\"" + "And there are no jobs either. They only say that, lots of people applying same jobs! You should stay here and get a wife." + "\"";
            if (text249b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "也没有作业。他们只是说，很多人申请同样的工作！你应该呆在这儿找个老婆。", myStyle);
            }

            text250 = "\"" + "Do you have a job? There aren't many jobs here. Good thing you are looking after the house while your parents are away." + "\"";
            if (text250b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你有工作吗？这里的工作不多。当你父母不在家的时候，你正在照看房子。", myStyle);
            }

            text251 = "\"" + "Your uncle might have something for you as well. I wonder where he is... When he drinks, he usually disappears for long times." + "\" ";
            if (text251b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你叔叔可能也有东西给你。我不知道他在哪里…当他喝酒时，他通常会消失很长时间。", myStyle);
            }

            text252 = "\"" + "What is it with the young people at the store. Playing that thumping music out loud." + "\"";
            if (text252b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "与商店里的年轻人有什么关系？”大声地演奏那砰砰的音乐。", myStyle);
            }

            text253 = "\"" + "And the language. I see all sorts of genitalia in my head when listening them talk! I can't visit the store these days." + "\"";
            if (text253b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "和语言。听他们谈话时，我看到各种各样的生殖器！这几天我不能逛商店了。", myStyle);
            }

            text254 = "\"" + "When are your parents coming back from the holiday? I wonder what is it that the summer here in Finland is not enough." + "\"";
            if (text254b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你的父母什么时候度假回来？我想知道芬兰的夏天是不够的。", myStyle);
            }

            text255 = "\"" + "I've had 78 summers in Finland and never needed to travel into some foolish places abroad. Well your parents have always been such active people I guess." + "\"";
            if (text255b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我在芬兰度过了78个夏天，从不需要去国外一些愚蠢的地方旅行。." + "\n" + "我想，你的父母一直都是这样活跃的人.", myStyle);
            }

            text256 = "\"" + "I wonder how the Teimo has motivation to keep the Store open. All the mega markets and all these days. People don't like small local stores any more." + "\"";
            if (text256b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我想知道Teimo的动机是如何保持商店的开放。所有的大市场和所有这些日子。人们不再喜欢当地的小商店了。", myStyle);
            }

            text257 = "\"" + "People getting older and having bad legs and all... Maybe the restaurant next to the store makes enough income for Teimo." + "\"";
            if (text257b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "人越来越老，腿又坏了……也许商店旁边的餐馆为Teimo赚到足够的收入", myStyle);
            }

            text258 = "\"" + "Hear this warning. Do not go to play cards to that lake side cabin. I've heard this story and it is true story." + "\"";
            if (text258b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "听到这个警告。不要去湖边小屋玩扑克牌。我听过这个故事，这是真实的故事。", myStyle);
            }

            text259 = "\"" + "And I say this. Do not play with matches. Not one time that families have lost their homes." + "\"";
            if (text259b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我这样说。不要玩火柴。没有一次家庭失去家园。", myStyle);
            }

            text260 = "\"" + "What is it there that we don't have here? You really should find yourself a wife." + "\"";
            if (text260b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我们这里没有什么？”你真的应该找到自己的妻子。", myStyle);
            }

            text261 = "\"" + "Great job hey! There is still some good people left! Here is some compensation for your troubles." + "\"";
            if (text261b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "伟大的工作嘿！还有一些好人离开了！这是对你的麻烦的补偿。", myStyle);
            }

            text262 = "\"" + "I almost forgot that I need to pay to you as well, damn." + "\"";
            if (text262b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我几乎忘记了我还需要支付给你，该死的", myStyle);
            }

            text263 = "\"" + "Getting bored already? Well, have some little candy money." + "\"";
            if (text263b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "已经厌倦了吗？”好吧，吃点糖果吧.", myStyle);
            }

            text264 = "\"" + "Hello there." + "\"";
            if (text264b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你好.", myStyle);
            }

            text265 = "\"" + "So so..." + "\"";
            if (text265b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "So so...", myStyle);
            }

            text266 = "\"" + "So... Lets see how much it costs... Hmm, yeah... Well yeah." + "\"";
            if (text266b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "所以…让我们看看它花了多少钱…嗯，是的…嗯，是的.", myStyle);
            }

            text267 = "\"" + "Just back up your truck through the garage doors. Then empty your tank at the grate on floor." + "\"";
            if (text267b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "就回来了，哟，车通过你的车库门。然后在对空坦克的grate地板”", myStyle);
            }

            text268 = "\"" + "Every single day full of shit." + "\"";
            if (text268b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "每一个单一的一天充满了屎。", myStyle);
            }

            text269 = "\"" + "Yep, yeah." + "\"";
            if (text269b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "是的，是的", myStyle);
            }

            text270 = "\"" + "So, this kind of case here." + "\"";
            if (text270b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "相比，这种情况在这里.", myStyle);
            }

            text271 = "\"" + "At least shit cant turn into any worse. Heh heh." + "\"";
            if (text271b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "至少cant变成任何糟糕变得更糟。嘿嘿嘿.", myStyle);
            }

            text272 = "\"" + "If shit were gold, I would be a rich man. But it is not. Heh heh." + "\"";
            if (text272b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "如果大便是金，我将是一个丰富的人。但它不是。嘿嘿嘿.", myStyle);
            }

            text273 = "\"" + "To me equality means that every single persons rear end produces crap." + "\"";
            if (text273b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我的每一个单一的平等意味着结束生产后患者废话", myStyle);
            }

            text274 = "\"" + "I just wanted to say that this is shitty job. Not as shitty as yours, but almost." + "\"";
            if (text274b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我只是想说，这是shitty工作。你shitty为不作为，但几乎", myStyle);
            }

            text275 = "\"" + "No no no... Bring only completely full boxes!" + "\"";
            if (text275b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "没有没有没有……只有完全完整的带盒", myStyle);
            }

            text276 = "\"" + "Thank you so much! Hey if you still have that Kilju I am always buying for more!" + "\"";
            if (text276b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "非常感谢你！嘿，如果你仍然有，吉州郡这里总是买更多!", myStyle);
            }

            text277 = "\"" + "You have sold me shit, you little bastard! Smell pussy!" + "\"";
            if (text277b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "你有sold我该死，你的小混蛋！女人的气息!", myStyle);
            }

            text278 = "\"" + "Is that music or what is it? Just thumping away. There is no slightest sense in that!" + "\"";
            if (text278b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "是音乐或是什么，它？只是thumping离开。有没有slightest意义在那!", myStyle);
            }

            text279 = "\"" + "Young people these days... They should go to work! Thumping away in middle of the town. There is even church there!" + "\"";
            if (text279b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "年轻人这些天…他们应该去工作！在中间的thumping离开该镇。甚至教堂也有!", myStyle);
            }

            text280 = "\"" + "Long time ago that thing and his dad played cards. His dad won and the thing got so angry that he cursed his dad. Then his dad died in house fire!" + "\"";
            if (text280b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这件事很长时间以前饰演的卡和他的爸爸。他的爸爸和这件事有比赢得了他的爸爸" + "\n" + "他愤怒的诅咒。然后他的爸爸死在房子火", myStyle);
            }

            text281 = "\"" + "And the thing is not a human! He even has claws like a pig. Never go there to play cards!" + "\" ";
            if (text281b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "和这件事是不是一个人类！他甚至有爪的像猪。永远的走有发挥卡!", myStyle);
            }

            text282 = "\"" + "I remember the cowhouse that burnt down. Kids were playing with matches, it went down fast. And the cattle that screamed in agony. Those matches are not for children!" + "\"";
            if (text282b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我记得那被烧毁的牛舍。孩子们在玩火柴，它很快就掉下来了。" + "\n" + "那些痛苦的尖叫着的牛。那些火柴不是给孩子们吃的!", myStyle);
            }

            text283 = "\"" + "Hey this here is my new apartment. Look at the view!" + "\"";
            if (text283b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "这是我的新公寓。看风景!", myStyle);
            }

            text284 = "\"" + "Let's do so that you carry all the stuff inside and I wait. I will pay of course!" + "\"";
            if (text284b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "让我们这样做，你把所有的东西里面，我等待。当然，我会付钱的!", myStyle);
            }

            text285 = "\"" + "Damn it will be dark before this field is done!" + "\"";
            if (text285b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "该死的，在这个领域完成之前将是黑暗的!", myStyle);
            }

            text286 = "\"" + "Damn those strawberries will go rotten before you finish that job!" + "\"";
            if (text286b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "在你完成那份工作之前，那些草莓会腐烂的!", myStyle);
            }

            text287 = "\"" + "Damn, my mother who had fatality would have picked four boxes in same time you pick one!" + "\"";
            if (text287b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "该死，我的母亲谁有致命性将挑选了四个盒子在同一时间，你挑选一个!", myStyle);
            }

            text288 = "\"" + "I haven't slept for three weeks because of night frost warning! Damn strawberries going bad!" + "\"";
            if (text288b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "因为夜间霜冻警告，我已经三个星期没有睡觉了！该死的草莓坏了!", myStyle);
            }

            text289 = "\"" + "Money dishes! Good thing I can pay in dark without you having to pay taxes!" + "\"";
            if (text289b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "钱碟！好东西，我可以在黑暗中支付而不必纳税!", myStyle);
            }

            text290 = "\"" + "My wife left me. I bought a apartment with nice lakeview. Could you come by and help me with moving my stuff?" + "\"";
            if (text290b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "我妻子离开了我。我买了一套漂亮的湖景公寓。你能过来帮我搬一下东西吗？", myStyle);
            }

            text291 = "\"" + "Young girls don't like it here unless they get married and have children. What does the city life offer?" + "\"";
            if (text291b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "除非她们结婚生子，否则年轻女孩不喜欢这里。城市生活提供了什么?", myStyle);
            }

            text292 = "\"" + "Funny thing, I was lifting a TV set and somehow my back snapped... I guess you could carry all this?" + "\"";
            if (text292b)
            {
                GUI.Label(new Rect(0, (Screen.height) / 2.35f, Screen.width, Screen.height), "有趣”的东西，我举着一台电视机，不知为什么我的背断了……我猜你能承担所有这些责任吗？", myStyle);
            }

            //text293 = "\""+"So do you already have a girl in mind? You should look for one before they move to the city.+"\"";
            //if(text293b)
            //{
            //GUI.Label(new Rect(0, (Screen.height)/2.35f, Screen.width, Screen.height), "那么你是否已经想到了一个女孩？你应该在他们搬到城市之前找一个。", myStyle);
            //}
        }

        public override void Update()
        {
            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text1)
            {
                text1b = true;
            }
            else
            {
                text1b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text2)
            {
                text2b = true;
            }
            else
            {
                text2b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text3)
            {
                text3b = true;
            }
            else
            {
                text3b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text4)
            {
                text4b = true;
            }
            else
            {
                text4b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text5)
            {
                text5b = true;
            }
            else
            {
                text5b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text6)
            {
                text6b = true;
            }
            else
            {
                text6b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text7)
            {
                text7b = true;
            }
            else
            {
                text7b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text8)
            {
                text8b = true;
            }
            else
            {
                text8b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text9)
            {
                text9b = true;
            }
            else
            {
                text9b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text10)
            {
                text10b = true;
            }
            else
            {
                text10b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text11)
            {
                text11b = true;
            }
            else
            {
                text11b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text12)
            {
                text12b = true;
            }
            else
            {
                text12b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text13)
            {
                text13b = true;
            }
            else
            {
                text13b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text14)
            {
                text14b = true;
            }
            else
            {
                text14b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text15)
            {
                text15b = true;
            }
            else
            {
                text15b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text16)
            {
                text16b = true;
            }
            else
            {
                text16b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text17)
            {
                text17b = true;
            }
            else
            {
                text17b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text18)
            {
                text18b = true;
            }
            else
            {
                text18b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text19)
            {
                text19b = true;
            }
            else
            {
                text19b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text20)
            {
                text20b = true;
            }
            else
            {
                text20b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text21)
            {
                text21b = true;
            }
            else
            {
                text21b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text22)
            {
                text22b = true;
            }
            else
            {
                text22b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text23)
            {
                text23b = true;
            }
            else
            {
                text23b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text24)
            {
                text24b = true;
            }
            else
            {
                text24b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text25)
            {
                text25b = true;
            }
            else
            {
                text25b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text26)
            {
                text26b = true;
            }
            else
            {
                text26b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text27)
            {
                text27b = true;
            }
            else
            {
                text27b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text28)
            {
                text28b = true;
            }
            else
            {
                text28b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text29)
            {
                text29b = true;
            }
            else
            {
                text29b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text30)
            {
                text30b = true;
            }
            else
            {
                text30b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text31)
            {
                text31b = true;
            }
            else
            {
                text31b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text32)
            {
                text32b = true;
            }
            else
            {
                text32b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text33)
            {
                text33b = true;
            }
            else
            {
                text33b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text34)
            {
                text34b = true;
            }
            else
            {
                text34b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text35)
            {
                text35b = true;
            }
            else
            {
                text35b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text36)
            {
                text36b = true;
            }
            else
            {
                text36b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text37)
            {
                text37b = true;
            }
            else
            {
                text37b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text38)
            {
                text38b = true;
            }
            else
            {
                text38b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text39)
            {
                text39b = true;
            }
            else
            {
                text39b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text40)
            {
                text40b = true;
            }
            else
            {
                text40b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text41)
            {
                text41b = true;
            }
            else
            {
                text41b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text42)
            {
                text42b = true;
            }
            else
            {
                text42b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text43)
            {
                text43b = true;
            }
            else
            {
                text43b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text44)
            {
                text44b = true;
            }
            else
            {
                text44b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text45)
            {
                text45b = true;
            }
            else
            {
                text45b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text46)
            {
                text46b = true;
            }
            else
            {
                text46b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text47)
            {
                text47b = true;
            }
            else
            {
                text47b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text48)
            {
                text48b = true;
            }
            else
            {
                text48b = false;
            }

            //if(FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text49)
            //{
            //text49b = true;
            //}
            //else
            //{
            //text49b = false;
            //}

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text50)
            {
                text50b = true;
            }
            else
            {
                text50b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text51)
            {
                text51b = true;
            }
            else
            {
                text51b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text52)
            {
                text52b = true;
            }
            else
            {
                text52b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text53)
            {
                text53b = true;
            }
            else
            {
                text53b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text54)
            {
                text54b = true;
            }
            else
            {
                text54b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text55)
            {
                text55b = true;
            }
            else
            {
                text55b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text56)
            {
                text56b = true;
            }
            else
            {
                text56b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text57)
            {
                text57b = true;
            }
            else
            {
                text57b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text58)
            {
                text58b = true;
            }
            else
            {
                text58b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text59)
            {
                text59b = true;
            }
            else
            {
                text59b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text60)
            {
                text60b = true;
            }
            else
            {
                text60b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text61)
            {
                text61b = true;
            }
            else
            {
                text61b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text62)
            {
                text62b = true;
            }
            else
            {
                text62b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text63)
            {
                text63b = true;
            }
            else
            {
                text63b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text64)
            {
                text64b = true;
            }
            else
            {
                text64b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text65)
            {
                text65b = true;
            }
            else
            {
                text65b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text66)
            {
                text66b = true;
            }
            else
            {
                text66b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text67)
            {
                text67b = true;
            }
            else
            {
                text67b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text68)
            {
                text68b = true;
            }
            else
            {
                text68b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text69)
            {
                text69b = true;
            }
            else
            {
                text69b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text70)
            {
                text70b = true;
            }
            else
            {
                text70b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text71)
            {
                text71b = true;
            }
            else
            {
                text71b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text72)
            {
                text72b = true;
            }
            else
            {
                text72b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text73)
            {
                text73b = true;
            }
            else
            {
                text73b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text74)
            {
                text74b = true;
            }
            else
            {
                text74b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text75)
            {
                text75b = true;
            }
            else
            {
                text75b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text76)
            {
                text76b = true;
            }
            else
            {
                text76b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text77)
            {
                text77b = true;
            }
            else
            {
                text77b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text78)
            {
                text78b = true;
            }
            else
            {
                text78b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text79)
            {
                text79b = true;
            }
            else
            {
                text79b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text80)
            {
                text80b = true;
            }
            else
            {
                text80b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text81)
            {
                text81b = true;
            }
            else
            {
                text81b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text82)
            {
                text82b = true;
            }
            else
            {
                text82b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text83)
            {
                text83b = true;
            }
            else
            {
                text83b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text84)
            {
                text84b = true;
            }
            else
            {
                text84b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text85)
            {
                text85b = true;
            }
            else
            {
                text85b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text86)
            {
                text86b = true;
            }
            else
            {
                text86b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text87)
            {
                text87b = true;
            }
            else
            {
                text87b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text88)
            {
                text88b = true;
            }
            else
            {
                text88b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text89)
            {
                text89b = true;
            }
            else
            {
                text89b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text90)
            {
                text90b = true;
            }
            else
            {
                text90b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text91)
            {
                text91b = true;
            }
            else
            {
                text91b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text92)
            {
                text92b = true;
            }
            else
            {
                text92b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text93)
            {
                text93b = true;
            }
            else
            {
                text93b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text94)
            {
                text94b = true;
            }
            else
            {
                text94b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text95)
            {
                text95b = true;
            }
            else
            {
                text95b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text96)
            {
                text96b = true;
            }
            else
            {
                text96b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text97)
            {
                text97b = true;
            }
            else
            {
                text97b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text98)
            {
                text98b = true;
            }
            else
            {
                text98b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text99)
            {
                text99b = true;
            }
            else
            {
                text99b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text100)
            {
                text100b = true;
            }
            else
            {
                text100b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text101)
            {
                text101b = true;
            }
            else
            {
                text101b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text102)
            {
                text102b = true;
            }
            else
            {
                text102b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text103)
            {
                text103b = true;
            }
            else
            {
                text103b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text104)
            {
                text104b = true;
            }
            else
            {
                text104b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text105)
            {
                text105b = true;
            }
            else
            {
                text105b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text106)
            {
                text106b = true;
            }
            else
            {
                text106b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text107)
            {
                text107b = true;
            }
            else
            {
                text107b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text108)
            {
                text108b = true;
            }
            else
            {
                text108b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text109)
            {
                text109b = true;
            }
            else
            {
                text109b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text110)
            {
                text110b = true;
            }
            else
            {
                text110b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text111)
            {
                text111b = true;
            }
            else
            {
                text111b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text112)
            {
                text112b = true;
            }
            else
            {
                text112b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text113)
            {
                text113b = true;
            }
            else
            {
                text113b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text114)
            {
                text114b = true;
            }
            else
            {
                text114b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text115)
            {
                text115b = true;
            }
            else
            {
                text115b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text116)
            {
                text116b = true;
            }
            else
            {
                text116b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text117)
            {
                text117b = true;
            }
            else
            {
                text117b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text118)
            {
                text118b = true;
            }
            else
            {
                text118b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text119)
            {
                text119b = true;
            }
            else
            {
                text119b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text120)
            {
                text120b = true;
            }
            else
            {
                text120b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text121)
            {
                text121b = true;
            }
            else
            {
                text121b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text122)
            {
                text122b = true;
            }
            else
            {
                text122b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text123)
            {
                text123b = true;
            }
            else
            {
                text123b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text124)
            {
                text124b = true;
            }
            else
            {
                text124b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text125)
            {
                text125b = true;
            }
            else
            {
                text125b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text126)
            {
                text126b = true;
            }
            else
            {
                text126b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text127)
            {
                text127b = true;
            }
            else
            {
                text127b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text128)
            {
                text128b = true;
            }
            else
            {
                text128b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text129)
            {
                text129b = true;
            }
            else
            {
                text129b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text130)
            {
                text130b = true;
            }
            else
            {
                text130b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text131)
            {
                text131b = true;
            }
            else
            {
                text131b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text132)
            {
                text132b = true;
            }
            else
            {
                text132b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text133)
            {
                text133b = true;
            }
            else
            {
                text133b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text134)
            {
                text134b = true;
            }
            else
            {
                text134b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text135)
            {
                text135b = true;
            }
            else
            {
                text135b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text136)
            {
                text136b = true;
            }
            else
            {
                text136b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text137)
            {
                text137b = true;
            }
            else
            {
                text137b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text138)
            {
                text138b = true;
            }
            else
            {
                text138b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text139)
            {
                text139b = true;
            }
            else
            {
                text139b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text140)
            {
                text140b = true;
            }
            else
            {
                text140b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text141)
            {
                text141b = true;
            }
            else
            {
                text141b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text142)
            {
                text142b = true;
            }
            else
            {
                text142b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text143)
            {
                text143b = true;
            }
            else
            {
                text143b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text144)
            {
                text144b = true;
            }
            else
            {
                text144b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text145)
            {
                text145b = true;
            }
            else
            {
                text145b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text146)
            {
                text146b = true;
            }
            else
            {
                text146b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text147)
            {
                text147b = true;
            }
            else
            {
                text147b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text148)
            {
                text148b = true;
            }
            else
            {
                text148b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text149)
            {
                text149b = true;
            }
            else
            {
                text149b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text150)
            {
                text150b = true;
            }
            else
            {
                text150b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text151)
            {
                text151b = true;
            }
            else
            {
                text151b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text152)
            {
                text152b = true;
            }
            else
            {
                text152b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text153)
            {
                text153b = true;
            }
            else
            {
                text153b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text154)
            {
                text154b = true;
            }
            else
            {
                text154b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text155)
            {
                text155b = true;
            }
            else
            {
                text155b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text156)
            {
                text156b = true;
            }
            else
            {
                text156b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text157)
            {
                text157b = true;
            }
            else
            {
                text157b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text158)
            {
                text158b = true;
            }
            else
            {
                text158b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text159)
            {
                text159b = true;
            }
            else
            {
                text159b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text160)
            {
                text160b = true;
            }
            else
            {
                text160b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text161)
            {
                text161b = true;
            }
            else
            {
                text161b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text162)
            {
                text162b = true;
            }
            else
            {
                text162b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text163)
            {
                text163b = true;
            }
            else
            {
                text163b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text164)
            {
                text164b = true;
            }
            else
            {
                text164b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text165)
            {
                text165b = true;
            }
            else
            {
                text165b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text166)
            {
                text166b = true;
            }
            else
            {
                text166b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text167)
            {
                text167b = true;
            }
            else
            {
                text167b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text168)
            {
                text168b = true;
            }
            else
            {
                text168b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text169)
            {
                text169b = true;
            }
            else
            {
                text169b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text170)
            {
                text170b = true;
            }
            else
            {
                text170b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text171)
            {
                text171b = true;
            }
            else
            {
                text171b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text172)
            {
                text172b = true;
            }
            else
            {
                text172b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text173)
            {
                text173b = true;
            }
            else
            {
                text173b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text174)
            {
                text174b = true;
            }
            else
            {
                text174b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text175)
            {
                text175b = true;
            }
            else
            {
                text175b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text176)
            {
                text176b = true;
            }
            else
            {
                text176b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text177)
            {
                text177b = true;
            }
            else
            {
                text177b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text178)
            {
                text178b = true;
            }
            else
            {
                text178b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text179)
            {
                text179b = true;
            }
            else
            {
                text179b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text180)
            {
                text180b = true;
            }
            else
            {
                text180b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text181)
            {
                text181b = true;
            }
            else
            {
                text181b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text182)
            {
                text182b = true;
            }
            else
            {
                text182b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text183)
            {
                text183b = true;
            }
            else
            {
                text183b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text184)
            {
                text184b = true;
            }
            else
            {
                text184b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text185)
            {
                text185b = true;
            }
            else
            {
                text185b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text186)
            {
                text186b = true;
            }
            else
            {
                text186b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text187)
            {
                text187b = true;
            }
            else
            {
                text187b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text188)
            {
                text188b = true;
            }
            else
            {
                text188b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text189)
            {
                text189b = true;
            }
            else
            {
                text189b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text190)
            {
                text190b = true;
            }
            else
            {
                text190b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text191)
            {
                text191b = true;
            }
            else
            {
                text191b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text192)
            {
                text192b = true;
            }
            else
            {
                text192b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text193)
            {
                text193b = true;
            }
            else
            {
                text193b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text194)
            {
                text194b = true;
            }
            else
            {
                text194b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text195)
            {
                text195b = true;
            }
            else
            {
                text195b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text196)
            {
                text196b = true;
            }
            else
            {
                text196b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text197)
            {
                text197b = true;
            }
            else
            {
                text197b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text198)
            {
                text198b = true;
            }
            else
            {
                text198b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text199)
            {
                text199b = true;
            }
            else
            {
                text199b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text200)
            {
                text200b = true;
            }
            else
            {
                text200b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text201)
            {
                text201b = true;
            }
            else
            {
                text201b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text202)
            {
                text202b = true;
            }
            else
            {
                text202b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text203)
            {
                text203b = true;
            }
            else
            {
                text203b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text204)
            {
                text204b = true;
            }
            else
            {
                text204b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text205)
            {
                text205b = true;
            }
            else
            {
                text205b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text206)
            {
                text206b = true;
            }
            else
            {
                text206b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text207)
            {
                text207b = true;
            }
            else
            {
                text207b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text208)
            {
                text208b = true;
            }
            else
            {
                text208b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text209)
            {
                text209b = true;
            }
            else
            {
                text209b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text210)
            {
                text210b = true;
            }
            else
            {
                text210b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text211)
            {
                text211b = true;
            }
            else
            {
                text211b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text212)
            {
                text212b = true;
            }
            else
            {
                text212b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text213)
            {
                text213b = true;
            }
            else
            {
                text213b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text214)
            {
                text214b = true;
            }
            else
            {
                text214b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text215)
            {
                text215b = true;
            }
            else
            {
                text215b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text216)
            {
                text216b = true;
            }
            else
            {
                text216b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text217)
            {
                text217b = true;
            }
            else
            {
                text217b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text218)
            {
                text218b = true;
            }
            else
            {
                text218b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text219)
            {
                text219b = true;
            }
            else
            {
                text219b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text220)
            {
                text220b = true;
            }
            else
            {
                text220b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text221)
            {
                text221b = true;
            }
            else
            {
                text221b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text222)
            {
                text222b = true;
            }
            else
            {
                text222b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text223)
            {
                text223b = true;
            }
            else
            {
                text223b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text224)
            {
                text224b = true;
            }
            else
            {
                text224b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text225)
            {
                text225b = true;
            }
            else
            {
                text225b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text226)
            {
                text226b = true;
            }
            else
            {
                text226b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text227)
            {
                text227b = true;
            }
            else
            {
                text227b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text228)
            {
                text228b = true;
            }
            else
            {
                text228b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text229)
            {
                text229b = true;
            }
            else
            {
                text229b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text230)
            {
                text230b = true;
            }
            else
            {
                text230b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text231)
            {
                text231b = true;
            }
            else
            {
                text231b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text232)
            {
                text232b = true;
            }
            else
            {
                text232b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text233)
            {
                text233b = true;
            }
            else
            {
                text233b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text234)
            {
                text234b = true;
            }
            else
            {
                text234b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text235)
            {
                text235b = true;
            }
            else
            {
                text235b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text236)
            {
                text236b = true;
            }
            else
            {
                text236b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text237)
            {
                text237b = true;
            }
            else
            {
                text237b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text238)
            {
                text238b = true;
            }
            else
            {
                text238b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text239)
            {
                text239b = true;
            }
            else
            {
                text239b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text240)
            {
                text240b = true;
            }
            else
            {
                text240b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text241)
            {
                text241b = true;
            }
            else
            {
                text241b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text242)
            {
                text242b = true;
            }
            else
            {
                text242b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text243)
            {
                text243b = true;
            }
            else
            {
                text243b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text244)
            {
                text244b = true;
            }
            else
            {
                text244b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text245)
            {
                text245b = true;
            }
            else
            {
                text245b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text246)
            {
                text246b = true;
            }
            else
            {
                text246b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text247)
            {
                text247b = true;
            }
            else
            {
                text247b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text248)
            {
                text248b = true;
            }
            else
            {
                text248b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text249)
            {
                text249b = true;
            }
            else
            {
                text249b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text250)
            {
                text250b = true;
            }
            else
            {
                text250b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text251)
            {
                text251b = true;
            }
            else
            {
                text251b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text252)
            {
                text252b = true;
            }
            else
            {
                text252b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text253)
            {
                text253b = true;
            }
            else
            {
                text253b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text254)
            {
                text254b = true;
            }
            else
            {
                text254b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text255)
            {
                text255b = true;
            }
            else
            {
                text255b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text256)
            {
                text256b = true;
            }
            else
            {
                text256b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text257)
            {
                text257b = true;
            }
            else
            {
                text257b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text258)
            {
                text258b = true;
            }
            else
            {
                text258b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text259)
            {
                text259b = true;
            }
            else
            {
                text259b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text260)
            {
                text260b = true;
            }
            else
            {
                text260b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text261)
            {
                text261b = true;
            }
            else
            {
                text261b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text262)
            {
                text262b = true;
            }
            else
            {
                text262b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text263)
            {
                text263b = true;
            }
            else
            {
                text263b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text264)
            {
                text264b = true;
            }
            else
            {
                text264b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text265)
            {
                text265b = true;
            }
            else
            {
                text265b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text266)
            {
                text266b = true;
            }
            else
            {
                text266b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text267)
            {
                text267b = true;
            }
            else
            {
                text267b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text268)
            {
                text268b = true;
            }
            else
            {
                text268b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text269)
            {
                text269b = true;
            }
            else
            {
                text269b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text270)
            {
                text270b = true;
            }
            else
            {
                text270b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text271)
            {
                text271b = true;
            }
            else
            {
                text271b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text272)
            {
                text272b = true;
            }
            else
            {
                text272b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text273)
            {
                text273b = true;
            }
            else
            {
                text273b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text274)
            {
                text274b = true;
            }
            else
            {
                text274b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text275)
            {
                text275b = true;
            }
            else
            {
                text275b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text276)
            {
                text276b = true;
            }
            else
            {
                text276b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text277)
            {
                text277b = true;
            }
            else
            {
                text277b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text278)
            {
                text278b = true;
            }
            else
            {
                text278b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text279)
            {
                text279b = true;
            }
            else
            {
                text279b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text280)
            {
                text280b = true;
            }
            else
            {
                text280b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text281)
            {
                text281b = true;
            }
            else
            {
                text281b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text282)
            {
                text282b = true;
            }
            else
            {
                text282b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text283)
            {
                text283b = true;
            }
            else
            {
                text283b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text284)
            {
                text284b = true;
            }
            else
            {
                text284b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text285)
            {
                text285b = true;
            }
            else
            {
                text285b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text286)
            {
                text286b = true;
            }
            else
            {
                text286b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text287)
            {
                text287b = true;
            }
            else
            {
                text287b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text288)
            {
                text288b = true;
            }
            else
            {
                text288b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text289)
            {
                text289b = true;
            }
            else
            {
                text289b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text290)
            {
                text290b = true;
            }
            else
            {
                text290b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text291)
            {
                text291b = true;
            }
            else
            {
                text291b = false;
            }

            if (FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text292)
            {
                text292b = true;
            }
            else
            {
                text292b = false;
            }

            //if(FsmVariables.GlobalVariables.FindFsmString("GUIsubtitle").Value == text293)
            //{
            //text293b = true;
            //}
            //else
            //{
            //text293b = false;
            //}

            if (guiShow)
            {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    Write();
                    guiShow = false;
                }
            }
        }

        private void Window(int windowId)
        {
            GUIStyle myStyle = new GUIStyle();
            myStyle.alignment = TextAnchor.MiddleCenter;
            myStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
            myStyle.normal.textColor = Color.yellow;

            GUI.Label(new Rect(0, 0, 1024, 1024), "中文字幕正确的设置方法" + "\n" + "取消英文字幕(F1 - GRAPHICS - ENGLISH SUBTITLES)." + "\n" + "按L键关闭当前界面" + "\n" +
                "" + "\n" + "" + "\n" + "作者：oneness629" + "\n" + "https://steamcommunity.com/id/oneness629/" + "\n" + "" + "\n" + "" + "\n" + "原字幕作者：Roman266" + "\n" + "" + "源MOD来源" + "\n" + "https://www.racedepartment.com/downloads/plugin-translated-subtitles.17118/" + "\n" + "" + "\n" + "本翻译全部百度翻译机翻", myStyle); //startup windows text: 1. For correct work standard subtitles should be enabled(F1 - GRAPHICS - ENGLISH SUBTITLES). 2. Press L button to close startup window. 3. Author of plugin and author of translate. 4. Links.
            GUI.DragWindow();
        }

        private void Write()
        {
            subtitle = 1;
            string[] array = new string[1];
            string[] arg_11_0 = array;
            int arg_11_1 = 0;
            float num1 = this.subtitle;
            arg_11_0[arg_11_1] = num1.ToString();
            File.WriteAllLines(path + "/subtitle.txt", array);
        }
    }
}
