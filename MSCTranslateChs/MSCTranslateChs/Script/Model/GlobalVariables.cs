using MSCLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using MSCTranslateChs.Script.Model;
using MSCTranslateChs.Script.Model.Develop;
using MSCTranslateChs.Script.Common;

namespace MSCTranslateChs.Script.Model
{
    public class GlobalVariables
    {
        private static readonly LOGGER logger = new LOGGER(typeof(GlobalVariables));

        public bool isInit = false;

        private static GlobalVariables globalVariables;

        public Develop.Develop develop;
        public DevelopConfigWindows developConfigWindows;
        public GuiGameObjectExplorer guiGameObjectExplorer;
        public WelcomeWindows welcomeWindows;
        public PhysicsRaycast physicsRaycast;
        public MSCTranslateChs mscTranslateChs;
        public ExecutionTime executionTime = new ExecutionTime();
        public Money money = new Money();
        public Teleport teleport = new Teleport();
        public BoltTip boltTip = new BoltTip();
        public ItemTransmitter itemTransmitter;
        public MSCTranslate mscTranslate;

        private GlobalVariables()
        {

        }

        public static GlobalVariables GetGlobalVariables()
        {
            if (globalVariables == null)
            {
                globalVariables = new GlobalVariables();
            }
            return globalVariables;
        }

        public void Init()
        {
            physicsRaycast = new PhysicsRaycast();
            develop = new Develop.Develop();
            welcomeWindows = new WelcomeWindows();
            itemTransmitter = new ItemTransmitter();

            this.isInit = true;
        }

    }
}
