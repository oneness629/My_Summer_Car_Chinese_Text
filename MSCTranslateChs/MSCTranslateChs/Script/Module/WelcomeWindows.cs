using MSCTranslateChs.Script.Module.Base;
using UnityEngine;

namespace MSCTranslateChs.Script.Module
{
    public class WelcomeWindows: BaseModule
    {
        public new string moduleComment = "欢迎窗口";

        public bool isEnable = true;
        Rect welcomeWindowsRect;
        readonly float windowsWidth = 800;
        readonly float windowsHeight = 600;
        Vector2 scrollPoint;

        public WelcomeWindows()
        {
            welcomeWindowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);
        }


        public override void OnGUI()
        {
            if (isEnable)
            {
                welcomeWindowsRect = GUI.Window(GlobalVariables.windowsIdByWelcomeWindows, welcomeWindowsRect, WelcomeWindowsFunction, "欢迎使用我的夏季汽车中文翻译Mod");
            }
        }

        public override void Update()
        {
            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.W))
            {
                GlobalVariables.GetGlobalVariables().welcomeWindows.isEnable = true;
            }
            if (Input.GetKey(KeyCode.RightAlt) && Input.GetKey(KeyCode.W))
            {
                GlobalVariables.GetGlobalVariables().welcomeWindows.isEnable = false;
            }
        }

        private void WelcomeWindowsFunction(int windowsId)
        {
            scrollPoint = GUILayout.BeginScrollView(scrollPoint);
            GUILayout.Label("  欢迎使用我的夏季汽车中文翻译Mod(...缓慢更新...)");
            int viewHour = 1 - Mathf.FloorToInt(GlobalVariables.GetGlobalVariables().fsmFloatTimeRotationHour.Value / (360 / 12)) + 12;
            int viewMinutes = 60 - Mathf.FloorToInt(GlobalVariables.GetGlobalVariables().fsmFloatTimeRotationMinute.Value / (360 / 60));
            GUILayout.Label("游戏内时间:" + viewHour.ToString("D2") + ":" + viewMinutes.ToString("D2"));
            GUILayout.Label("翻译内容：状态UI、操作动作、配件、字幕(需要打开英文字幕),中英文对照显示，不会覆盖原有英文内容。");
            GUILayout.Label("详细使用教程请参考steam中文模组指南（建议分辨率，800x600以上，）");


            GlobalVariables.GetGlobalVariables().mscTranslateChs.IsEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslateChs.IsEnable, "是否启用翻译Mod");
            GUILayout.Label("取消翻译Mod,会加载Mod的相关信息和初始化,并启用欢迎窗口的OnGUI监听和Update(快捷键[显示/隐藏本窗口（左边ALT+W）/（右边ALT+W）]),其他所有功能均无法使用");

            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateGameOverMessage = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateGameOverMessage, "是否启用GameOver提示文本（报刊上的GameOver原因）");
            GUILayout.Label("启用GameOver提示后,玩家Over后报纸内容会显示出Over原因翻译（按下左边ALT+G，一次性读取全部原因到gameover.txt，导出文本用）");

            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateInteractions = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateInteractions, "是否启用操作动作翻译");
            GUILayout.Label("启用操作动作翻译后,车辆控制,商店物品能并行显示翻译文本");

            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslatePartnames = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslatePartnames, "是否启用部件/物品名称翻译");
            GUILayout.Label("启用部件/物品名称翻译后,车辆配件/购买的物品能并行显示翻译文本");

            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateSubtitles = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateSubtitles, "是否启用字幕翻译");
            GUILayout.Label("启用字幕翻译后,字幕会并行显示翻译文本(需要打开英文字幕,如果不开英文字幕...等同没启用)");

            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateUI = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateUI, "是否启用UI翻译(基于Unity3D的射线[Physics Ray])");
            GUILayout.Label("启用UI翻译后,鼠标移到菜单上,鼠标边上会显示翻译文本(只取有必要的文字部分翻译,按键,数值,快捷键等,翻译了也无意义,将来版本可能会过滤)");

            GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateEscInitUI = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().mscTranslate.IsTranslateEscInitUI, "是否在按下ESC或F1时初始化UI碰撞体");
            GUILayout.Label("启用后,按下ESC或1时候,为UI相关的文本GameObject添加碰撞体以便射线捕捉到对应文本");

            GlobalVariables.GetGlobalVariables().teleport.isEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().teleport.isEnable, "是否启用远程传送功能");
            GUILayout.Label("启用后,可将玩家传送到特定物品边上或将特定物品传送到玩家边上");

            GlobalVariables.GetGlobalVariables().develop.isEnable = GUILayout.Toggle(GlobalVariables.GetGlobalVariables().develop.isEnable, "是否启用开发模式（左边Alt+T（显示）和右边Alt+T（隐藏））");

            if (GUILayout.Button("关闭本窗口")){
                isEnable = false;
            }
            if (GUILayout.Button("访问MOD指南页面(按ESC或F1能够使用鼠标)"))
            {
                Application.OpenURL("https://steamcommunity.com/sharedfiles/filedetails/?id=1384837781");
            }
            GUILayout.BeginHorizontal("box");
            if (GUILayout.Button("显示远程传送窗口"))
            {
                GlobalVariables.GetGlobalVariables().teleport.isShowWindow = true;
            }
            if (GUILayout.Button("显示金钱调整窗口"))
            {
                GlobalVariables.GetGlobalVariables().money.isEnable = true;
                GlobalVariables.GetGlobalVariables().money.isShowWindow = true;
            }
            if (GUILayout.Button("显示螺栓提示窗口"))
            {
                GlobalVariables.GetGlobalVariables().boltTip.isShowWindow = true;
            }
            if (GUILayout.Button("显示物品传送(背包)窗口"))
            {
                GlobalVariables.GetGlobalVariables().itemTransmitter.isShowWindow = true;
            }
            GUILayout.EndHorizontal();
            GUILayout.EndScrollView();
            GUI.DragWindow();
        }
    }
}
