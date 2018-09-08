using System;
using UnityEngine;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Module.Base;

namespace MSCTranslateChs.Script.Module
{
    
    public class Money : BaseModule
    {
        private static LOGGER logger = new LOGGER(typeof(Money));
        public new string ModuleComment = "金钱调整";

        public new bool IsEnable = true;
        public bool isShowWindow = false;
        Rect windowsRect;

        public float windowsWidth = 260;
        public float windowsHeight = 50;

        float money;

        public override void Init()
        {
            if (GlobalVariables.GetGlobalVariables().fsmFloatPlayerMoney != null)
            {
                money = GlobalVariables.GetGlobalVariables().fsmFloatPlayerMoney.Value;
            }
            windowsRect = new Rect(0, 0, windowsWidth, windowsHeight);

        }

        public override void OnGUI()
        {
            if (isShowWindow)
            {
                windowsRect = GUI.Window(GlobalVariables.windowsIdByMoney, windowsRect, MoneyWindowFunction, "金钱调整");
            }
        }

        public override void Update()
        {
        }

        public void MoneyWindowFunction(int windowsId)
        {
            string moneyStr = money.ToString();
            GUILayout.BeginHorizontal("box");
            GUILayout.Label("修改金钱：");
            moneyStr = GUILayout.TextField(moneyStr);
            try
            {
                money = float.Parse(moneyStr);
            }
            catch (Exception e)
            {
                logger.LOG("金钱值转换异常:" + e.Message);
                moneyStr = money.ToString();
            }
            if (GUILayout.Button("修改"))
            {
                GlobalVariables.GetGlobalVariables().fsmFloatPlayerMoney.Value = money;
            }
            if (GUILayout.Button("关闭"))
            {
                isShowWindow = false;
            }
            GUILayout.EndHorizontal();
            GUI.DragWindow();
        }

       
    }

   
}
