using MSCTranslateChs.Script.Module.Base;
using UnityEngine;

namespace MSCTranslateChs.Script.Module
{
    public class WelcomeWindows: BaseModule
    {
        public new string ModuleComment = "欢迎窗口";

        public new bool IsEnable = true;
        Rect welcomeWindowsRect;
        readonly float windowsWidth = 800;
        readonly float windowsHeight = 600;
        Vector2 scrollPoint;

        public override void Init()
        {
            welcomeWindowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);
        }


        public override void OnGUI()
        {
            if (IsEnable)
            {
                welcomeWindowsRect = GUI.Window(GlobalVariables.windowsIdByWelcomeWindows, welcomeWindowsRect, WelcomeWindowsFunction, "欢迎使用我的夏季汽车中文翻译Mod");
            }
        }

        public override void Update()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.W))
            {
                GlobalVariables.GetGlobalVariables().welcomeWindows.IsEnable = true;
            }
            if (Input.GetKey(KeyCode.RightAlt) && Input.GetKey(KeyCode.W))
            {
                GlobalVariables.GetGlobalVariables().welcomeWindows.IsEnable = false;
            }
        }

        private void WelcomeWindowsFunction(int windowsId)
        {
            scrollPoint = GUILayout.BeginScrollView(scrollPoint);
            GUILayout.BeginHorizontal("box");
            if (GUILayout.Button("关闭本窗口"))
            {
                IsEnable = false;
            }
            if (GUILayout.Button("访问MOD指南页面(按ESC或F1能够使用鼠标)"))
            {
                Application.OpenURL("https://steamcommunity.com/sharedfiles/filedetails/?id=1384837781");
            }
            GUILayout.EndHorizontal();
            GUILayout.Label("  欢迎使用我的夏季汽车中文翻译Mod(...缓慢更新...)");
            int viewHour = 1 - Mathf.FloorToInt(GlobalVariables.GetGlobalVariables().fsmFloatTimeRotationHour.Value / (360 / 12)) + 12;
            int viewMinutes = 60 - Mathf.FloorToInt(GlobalVariables.GetGlobalVariables().fsmFloatTimeRotationMinute.Value / (360 / 60));
            GUILayout.Label("游戏内时间:" + viewHour.ToString("D2") + ":" + viewMinutes.ToString("D2"));
            GUILayout.Label("翻译内容：状态UI、操作动作、配件、字幕(需要打开英文字幕),中英文对照显示，不会覆盖原有英文内容。");
            GUILayout.Label("详细使用教程请参考steam中文模组指南（建议分辨率:1024x768或以上,低了?你可能看不全本Mod的所有窗口内容）");


            GlobalVariables.GetGlobalVariables().mscTranslateChs.IsEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslateChs.IsEnable, "是否启用本Mod");
            GUILayout.Label("取消该选项,会加载Mod的相关信息和初始化,并启用欢迎窗口的OnGUI监听和Update");
            GUILayout.Label("(快捷键[显示/隐藏本窗口（左边ALT+W[Welcome]）/（右边ALT+W[Welcome]）]),其他所有功能均无法使用");
            GUILayout.Label(" ");
            GUILayout.Label("基础相关");
            GlobalVariables.GetGlobalVariables().physicsRaycast.IsEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().physicsRaycast.IsEnable, "是否启用Mod中的Unity3D射线[Physics Ray]");
            GUILayout.Label("启用后,Mod会从摄像机朝鼠标位置发送一条射线,并记录被射线射中的所有GameObject(必须启用,否则很多功能都无法使用)");

            GlobalVariables.GetGlobalVariables().develop.IsEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().develop.IsEnable, "是否启用Mod中的开发测试模式");
            GUILayout.Label("启用后,你能看到和游戏以及汉化Mod有关的更多细节 (快捷键[显示/隐藏测试窗口（左边ALT+T[Test]）/（右边ALT+T[Test]）])");
            GUILayout.Label(" ");
            GUILayout.Label("汉化相关");
            GlobalVariables.GetGlobalVariables().mscTranslate.IsEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsEnable, "是否启用汉化翻译");
            GUILayout.Label("启用汉化后,玩家在看到英文的同时,能同时看到各类中文内容,不影响英文内容显示.");
            GUILayout.Label("如果禁用该选项,和汉化相关的所有选项均无效");
            
            GlobalVariables.GetGlobalVariables().mscTranslate.isTranslateSubtitles = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.isTranslateSubtitles, "是否启用字幕翻译");
            GUILayout.Label("启用字幕翻译后,字幕会并行显示翻译文本(需要打开英文字幕,如果不开英文字幕...等同没启用)");
            
            GlobalVariables.GetGlobalVariables().mscTranslate.isTranslatePartnames = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.isTranslatePartnames, "是否启用部件/物品名称翻译");
            GUILayout.Label("启用部件/物品名称翻译后,车辆配件/购买的物品能并行显示翻译文本");
            
            GlobalVariables.GetGlobalVariables().mscTranslate.isTranslateInteractions = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.isTranslateInteractions, "是否启用操作动作翻译");
            GUILayout.Label("启用操作动作翻译后,车辆控制,商店物品能并行显示翻译文本");
            
            GlobalVariables.GetGlobalVariables().mscTranslate.isTranslateGameOverMessage = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.isTranslateGameOverMessage, "是否启用GameOver提示文本（报刊上的GameOver原因）");
            GUILayout.Label("启用GameOver提示后,玩家Over后报纸内容会显示出Over原因翻译（按下左边ALT+G，一次性读取全部原因到gameover.txt，导出文本用）");
            
            GlobalVariables.GetGlobalVariables().mscTranslate.isTranslateUI = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.isTranslateUI, "是否启用UI翻译(基于Mod中的Unity3D射线[Physics Ray])");
            GUILayout.Label("启用UI翻译后,鼠标移到菜单上,鼠标边上会显示翻译文本(只取有必要的文字部分翻译,按键,数值,快捷键等,翻译了也无意义,将来版本可能会过滤)");
            
            GlobalVariables.GetGlobalVariables().mscTranslate.isTranslateEscInitUI = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.isTranslateEscInitUI, "是否在按下ESC或F1时初始化UI碰撞体");
            GUILayout.Label("启用后,按下ESC或1时候,为UI相关的文本GameObject添加碰撞体以便射线捕捉到对应文本");
            
            GUILayout.Label(" ");
            GUILayout.Label("远程传送");
            GlobalVariables.GetGlobalVariables().teleport.IsEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().teleport.IsEnable, "是否启用远程传送功能");
            GUILayout.Label("启用后,可将玩家传送到特定物品/车辆/建筑物边上或将特定物品/车辆传送到玩家边上,你能传送到任意一个GameObject边上(如果你打开开发测试模式,你能遍历游戏中所有GameObject)");
            
            GUILayout.Label(" ");
            GUILayout.Label("金钱调整");
            GlobalVariables.GetGlobalVariables().money.IsEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().money.IsEnable, "是否启用金钱调整功能");
            GUILayout.Label("启用后,滚动到窗口最底部,点金钱调整窗口,要多少就有多少,显示存在上限,可惜这只是个游戏...");
            
            GUILayout.Label(" ");
            GUILayout.Label("物品传送");
            GlobalVariables.GetGlobalVariables().itemTransmitter.IsEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().itemTransmitter.IsEnable, "是否启用物品传送功能");
            GUILayout.Label("背包,这就是可以放无限个东东的背包 快捷键: 显示界面:TAB; 捡起/丢出物品:E/R;切换选中物品:鼠标滚轮;");
            GUILayout.Label("按下E,将能捡起来的物品传送到垃圾堆(不要传送到垃圾堆再捡起来了,这么做你除了能看到一堆东东从天上掉下来没其他意义)");
            GUILayout.Label("按下R,将能列表中选中的物品从垃圾堆中传送到你的摄像机前方;如果在列表,点击物品名称会传送到你边上而不是摄像机前方");
            GUILayout.Label("如果列表中有内容,退出游戏后请自行到垃圾堆找(启用远程传送功能后按右边ALT+7)");
            
            GUILayout.Label(" ");
            GUILayout.Label("螺栓提示");
            GlobalVariables.GetGlobalVariables().boltTip.IsEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().boltTip.IsEnable, "是否启用螺栓提示功能");
            GUILayout.Label("启用后,滚动到窗口最底部,点螺栓提示窗口");

            GUILayout.BeginHorizontal("box");
            if (GUILayout.Button("开发测试窗口"))
            {
                GlobalVariables.GetGlobalVariables().developWindows.IsEnable = true;
            }
            if (GUILayout.Button("远程传送窗口"))
            {
                GlobalVariables.GetGlobalVariables().teleport.isShowWindow = true;
            }
            if (GUILayout.Button("金钱调整窗口"))
            {
                GlobalVariables.GetGlobalVariables().money.isShowWindow = true;
            }
            if (GUILayout.Button("螺栓提示窗口"))
            {
                GlobalVariables.GetGlobalVariables().boltTip.isShowWindow = true;
            }
            if (GUILayout.Button("物品传送窗口"))
            {
                GlobalVariables.GetGlobalVariables().itemTransmitter.isShowWindow = true;
            }
            GUILayout.EndHorizontal();
            GUILayout.EndScrollView();
            GUI.DragWindow();
        }

    }
}
