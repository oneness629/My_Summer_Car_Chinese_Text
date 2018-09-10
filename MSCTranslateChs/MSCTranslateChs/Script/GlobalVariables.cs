using System;
using System.Collections.Generic;
using UnityEngine;
using MSCTranslateChs.Script.Common;
using HutongGames.PlayMaker;
using MSCTranslateChs.Script.Module.Base;
using MSCTranslateChs.Script.Module;
using System.Reflection;

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
