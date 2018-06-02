using HutongGames.PlayMaker;
using MSCLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;


namespace MSCTranslateChs
{
    public class Develop
    {
        Mod mod;
       
        public Develop(Mod mod)
        {
            this.mod = mod;
        }

        public void Update()
        {
            if ( Input.GetKey(KeyCode.LeftAlt) &&
                 Input.GetKey(KeyCode.RightAlt) &&
                 Input.GetKey(KeyCode.W)
                )
            {
                // writeAllFsmVariablesGlobalVariablesNames();

                // writeAllGameObject();

                // writeGameObject("GUI/Indicators/Subtitles");

                // writeGameObject("GUI");

                ModConsole.Print("写入测试文件完成");
            }
                
        }

        private void writeGameObject(string path)
        {
            GameObject gameObject = GameObject.Find(path);
            string text = getGameObjectText(gameObject, 0);
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(mod), "singleGameObject.txt"), text);
        }

        private void writeAllGameObject()
        {
            string text = "";
            GameObject[] allGameObjects = Resources.FindObjectsOfTypeAll<GameObject>();
            List<GameObject> topGameObjectList = new List<GameObject>();
            foreach (GameObject gameObject in allGameObjects)
            {
                if (gameObject != null && gameObject.transform != null && gameObject.transform.parent == null)
                {
                    topGameObjectList.Add(gameObject);
                }
            }

            int level = 1;
            foreach (GameObject gameObject in topGameObjectList)
            {
                text += getGameObjectText(gameObject, level);
            }
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(mod), "GameObjects.txt"), text);

        }

        private string getLevelText(int level)
        {
            string text = "";
            for (int i = 0; i < level; i++)
            {
                text += "\t";
            }
            return text;
        }

        private string getGameObjectText(GameObject gameObject, int level)
        {
            string text = "";
            if (gameObject != null)
            {
                
                string tabText = getLevelText(level);
                text += (
                   tabText + "gameObject.name : " + gameObject.name + "\n" +
                    tabText + "\t gameObject.tag : " + gameObject.tag + "\n" +
                    tabText + "\t gameObject.hideFlags : " + gameObject.hideFlags + "\n" +
                    tabText + "\t gameObject.isStatic : " + gameObject.isStatic + "\n" +
                    tabText + "\t gameObject.layer : " + gameObject.layer + "\n" +
                    tabText + "\t GetComponentsText : " + GetComponentsText(gameObject, tabText + "\t") + "\n"
                    );
                if (gameObject.transform != null && gameObject.transform.childCount > 0 )
                {
                    for (int i = 0; i < gameObject.transform.childCount; i++)
                    {
                        text += (getGameObjectText(gameObject.transform.GetChild(i).gameObject, level + 1));
                    }
                }
            }
            return text;
        }

        private string GetComponentsText(GameObject gameObject, string levelText)
        {
            string text = "\n";
            if (gameObject != null)
            {
                Component[] Components = gameObject.GetComponents<Component>();
                foreach (Component component in Components)
                {
                    text += (
                        levelText + "\t" + "component.GetType().FullName : \t" + component.GetType().FullName + "\n" +
                        levelText + "\t" + "component.GetType().GetFields : \t" + getFieldsString(component.GetType().GetFields(), levelText, component) + "\n" +
                        levelText + "\t" + "component.GetType().GetMembers : \t" + getGetMembersString(component.GetType().GetMembers(), levelText, component) + "\n" +
                        levelText + "\t" + "component.GetType().GetMethods : \t" + getGetMethodsString(component.GetType().GetMethods(), levelText, component) + "\n" +
                        "\n"
                        );
                }
            }
            return text;
        }

        private string getGetMethodsString(MethodInfo[] methodInfos, string levelText, object obj)
        {
            string text = levelText + "\t";
            levelText += "\t";
            foreach (MethodInfo methodInfo in methodInfos)
            {
                text += (
                    levelText + "\t" +
                    "methodInfo -> " + methodInfo.Name + "\t memberInfo.ReturnType: \t" + methodInfo.ReturnType +
                    "\n"
                    );
            }
            return text;
        }

        private string getGetMembersString(MemberInfo[] memberInfos, string levelText, object obj)
        {
            string text = levelText + "\t";
            levelText += "\t";
            foreach (MemberInfo memberInfo in memberInfos)
            {
                text += (
                    levelText + "\t" +
                    "memberInfo -> " + memberInfo.Name + "\t memberInfo.MemberType: \t" + memberInfo.MemberType + "\n"
                    );
            }
            return text;
        }

        private string getFieldsString(FieldInfo[] fieldInfos , string levelText, object obj)
        {
            string text = levelText + "\t";
            levelText += "\t";
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                text += (
                    levelText + "\t" +
                    "fieldInfo -> " + fieldInfo.Name + "\t:\t" + Convert.ToString(fieldInfo.GetValue(obj)) + "\n"
                    );
            }
            return text;
        }

        private void writeAllFsmVariablesGlobalVariablesNames()
        {
            string text = "";
            foreach (NamedVariable namedVariable in FsmVariables.GlobalVariables.GetAllNamedVariables())
            {
                text += (
                    "namedVariable name: " + namedVariable.Name + ""
                    + "\n\tnamedVariable Tooltip : " + namedVariable.Tooltip + "\t"
                    + "\n\tnamedVariable IsNone : " + namedVariable.IsNone + "\t"
                    + "\n\tnamedVariable NetworkSync : " + namedVariable.NetworkSync + "\t"
                    + "\n\tnamedVariable ShowInInspector : " + namedVariable.ShowInInspector + "\t"
                    + "\n\tnamedVariable UsesVariable : " + namedVariable.UsesVariable + "\t"
                    + "\n\tnamedVariable UseVariable : " + namedVariable.UseVariable + "\t\n\n"
                    );
            }
            File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(mod), "FsmVariables.txt"), text);
        }
    }

}
