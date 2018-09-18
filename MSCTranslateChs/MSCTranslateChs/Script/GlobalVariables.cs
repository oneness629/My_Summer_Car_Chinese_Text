using System;
using System.Collections.Generic;
using UnityEngine;
using MSCTranslateChs.Script.Common;
using HutongGames.PlayMaker;
using MSCTranslateChs.Script.Module.Base;
using MSCTranslateChs.Script.Module;
using System.Reflection;
using MSCLoader;

namespace MSCTranslateChs.Script
{
    public class GlobalVariables
    {
        private static readonly LOGGER logger = new LOGGER(typeof(GlobalVariables));

        public bool isInit = false;

        public const int windowsIdByWelcomeWindows = 629;
        public const int windowsIdByDevelopWindows = 6291;
        public const int windowsIdByTeleport = 6292;
        public const int windowsIdByBoltTip = 6293;
        public const int windowsIdByMoney = 6294;
        public const int windowsIdByItemTransmitter = 6295;
        public const int windowsIdByGuiGameObjectExplorer = 6296;
        public const int windowsIdByCarReport = 6297;
        
        private static readonly GlobalVariables globalVariables = new GlobalVariables();

        public MSCTranslateChs mscTranslateChs;
        public ExecutionTime executionTime = new ExecutionTime();

        
        public Develop develop = new Develop();
        public DevelopWindows developWindows = new DevelopWindows();
        public WelcomeWindows welcomeWindows = new WelcomeWindows();
        public PhysicsRaycast physicsRaycast = new PhysicsRaycast();
        public Money money = new Money();
        public Teleport teleport = new Teleport();
        public BoltTip boltTip = new BoltTip();
        public ItemTransmitter itemTransmitter = new ItemTransmitter();
        public MSCTranslate mscTranslate = new MSCTranslate();
        public GuiGameObjectExplorer guiGameObjectExplorer = new GuiGameObjectExplorer();
        public CarReport carReport = new CarReport();


        public string fsmFloatTimeRotationHourName = "TimeRotationHour";
        public FsmFloat fsmFloatTimeRotationHour;
        public string fsmFloatTimeRotationMinuteName = "TimeRotationMinute";
        public FsmFloat fsmFloatTimeRotationMinute;
        public string fsmFloatPlayerMoneyName = "PlayerMoney";
        public FsmFloat fsmFloatPlayerMoney;
        public string fsmBoolPlayerInMenuName = "PlayerInMenu";
        public FsmBool fsmBoolPlayerInMenu;

        public string gameObjectPalyerName = "PLAYER";
        public GameObject gameObjectPalyer;

        public string gameObjectSystemsName = "Systems";
        public GameObject gameObjectSystems;

        public string gameObjectGuiHudName = "GUI/HUD";
        public GameObject gameObjectGuiHud;

        public string gameObjectLandfillSpawnName = "LandfillSpawn";
        public GameObject gameObjectLandfillSpawn;

        public string gameObjectSatsumaName = "SATSUMA(557kg, 248)";
        public GameObject gameObjectSatsuma;

        public string gameObjectEngineName = "block(Clone)";
        public GameObject gameObjectEngine;

        public List<BaseModule> executeModuleList;

        public Keybind keyBindShowWelcomeWindows = new Keybind("keyBindShowWelcomeWindows", "欢迎界面-> 显示欢迎界面窗口", KeyCode.W, KeyCode.LeftAlt);
        public Keybind keyBindHideWelcomeWindows = new Keybind("keyBindHideWelcomeWindows", "欢迎界面-> 隐藏欢迎界面窗口", KeyCode.W, KeyCode.RightAlt);

        public Keybind keyBindTargetTeleportToPlayer = new Keybind("keyBindTargetTeleportToPlayer", "远程传送-> (部分快捷键)将动态目标(如:摩托车,拖拉机等)传送到玩家", KeyCode.LeftAlt);
        public Keybind keyBindStaticTargetTeleportToPlayer = new Keybind("keyBindStaticTargetTeleportToPlayer", "远程传送-> (部分快捷键)将玩家传送到静态目标(如:家,商店,修车店等)", KeyCode.RightControl);
        public Keybind keyBindPlayerTeleportToTarget = new Keybind("keyBindPlayerTeleportToTarget", "远程传送-> (部分快捷键)将玩家传送到动态目标(如:摩托车,拖拉机等)", KeyCode.RightAlt);

        public Keybind keyBindGameOverTextToTxt = new Keybind("keyBindGameOverTextToTxt", "文本翻译-> 在GameOver报纸显示原因界面按下快捷键写入所有英文原因", KeyCode.G, KeyCode.LeftAlt);

        public Keybind keyBindAddGameObjectToItemList = new Keybind("keyBindAddGameObjectToItemList", "物品传送-> 拾取物品", KeyCode.E);
        public Keybind keyBindRemoveGameObjectFormItemList = new Keybind("keyBindRemoveGameObjectFormItemList", "物品传送-> 取出物品", KeyCode.R);
        public Keybind keyBindShowItemListUI = new Keybind("keyBindShowItemListUI", "物品传送-> 显示物品栏", KeyCode.Tab);

        public Keybind keyBindShowDevelopWindows = new Keybind("keyBindShowDevelopWindows", "开发模式-> 显示开发模式窗口", KeyCode.T, KeyCode.LeftAlt );
        public Keybind keyBindHideDevelopWindows = new Keybind("keyBindHideDevelopWindows", "开发模式-> 隐藏开发模式窗口", KeyCode.T, KeyCode.RightAlt);
        public Keybind keyBindReadAllTxt = new Keybind("keyBindReadAllTxt", "开发模式-> 重新读取所有TXT文件", KeyCode.R, KeyCode.LeftControl);
        public Keybind keyBindWriteGameObjectToTxt = new Keybind("keyBindWriteGameObjectToTxt", "开发模式-> 写入Systems下的内容到TXT", KeyCode.W, KeyCode.LeftControl);
        public Keybind keyBindWriteFVToTxt = new Keybind("keyBindWriteFVToTxt", "开发模式-> 写入所有全局变量到TXT", KeyCode.F, KeyCode.LeftControl);

        public Keybind keyBindShowOtherBolt = new Keybind("keyBindShowOtherBolt", "螺栓提示-> 显示其他螺栓", KeyCode.LeftAlt);




        public List<string> checkWhiteList = new List<string>()
        {
            "gameObjectEngine"
        };

        private GlobalVariables()
        {
        }

        public static GlobalVariables GetGlobalVariables()
        {
            return globalVariables;
        }

        public void Init()
        {
            logger.LOG("Mod初始化 ... ");

            ModelInit();
            GameObjectInit();
            FsmVariablesInit();
            logger.LOG("Mod初始化完成");
            this.isInit = true;
        }

        public void FsmVariablesInit()
        {
            fsmFloatTimeRotationHour = FsmVariables.GlobalVariables.FindFsmFloat(fsmFloatTimeRotationHourName);
            fsmFloatTimeRotationMinute = FsmVariables.GlobalVariables.FindFsmFloat(fsmFloatTimeRotationMinuteName);
            fsmFloatPlayerMoney = FsmVariables.GlobalVariables.FindFsmFloat(fsmFloatPlayerMoneyName);
            fsmBoolPlayerInMenu = FsmVariables.GlobalVariables.FindFsmBool(fsmBoolPlayerInMenuName);
        }

        public void ModelInit()
        {
            executeModuleList = new List<BaseModule>
            {
                physicsRaycast,
                develop,
                developWindows,
                mscTranslate,
                money,
                teleport,
                boltTip,
                itemTransmitter,
                guiGameObjectExplorer,
                carReport,
            };

            welcomeWindows = new WelcomeWindows();
            welcomeWindows.Init();

            welcomeWindows.IsEnable = true;
            physicsRaycast.IsEnable = true;
            develop.IsEnable = false;
            developWindows.IsEnable = false;
            mscTranslate.IsEnable = true;
            money.IsEnable = true;
            teleport.IsEnable = true;
            boltTip.IsEnable = true;
            itemTransmitter.IsEnable = true;
            guiGameObjectExplorer.IsEnable = true;

            foreach (BaseModule baseModule in executeModuleList)
            {
                baseModule.Init();
            }

        }

        public void GameObjectInit()
        {
            gameObjectPalyer = GameObject.Find(gameObjectPalyerName);
            gameObjectSystems = GameObject.Find(gameObjectSystemsName);
            gameObjectGuiHud = GameObject.Find(gameObjectGuiHudName);
            gameObjectLandfillSpawn = GameObject.Find(gameObjectLandfillSpawnName);
            gameObjectSatsuma = GameObject.Find(gameObjectSatsumaName);
            gameObjectEngine = GameObject.Find(gameObjectEngineName);
            


        }

        public void CheckIsInit()
        {
            // logger.LOG("CheckIsInit");
            Type type = GetGlobalVariables().GetType();
            foreach (FieldInfo fieldInfo in type.GetFields())
            {
                // logger.LOG("fieldInfo.GetValue(GetGlobalVariables()) " + fieldInfo.GetValue(GetGlobalVariables()));
                if (Convert.ToString(fieldInfo.GetValue(GetGlobalVariables())).ToLower().Equals("null"))
                {
                    if (checkWhiteList.Contains(fieldInfo.Name))
                    {
                        logger.LOG("检查到部分全局变量为空,但是该变量在白名单中...");
                        
                    }
                    else
                    {
                        logger.LOG("检查到部分全局变量为空,可能尚未初始化成功,下一帧将重新初始化...过程中可能存在异常...");
                        GetGlobalVariables().isInit = false;
                    }
                    
                }
            }
        }

    }
}
