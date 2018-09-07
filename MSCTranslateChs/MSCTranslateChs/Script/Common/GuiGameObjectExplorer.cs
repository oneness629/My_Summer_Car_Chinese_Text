using MSCLoader;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
namespace MSCTranslateChs.Script.Common
{
    public class GuiGameObjectExplorer
    {
        private static LOGGER logger = new LOGGER(typeof(GuiGameObjectExplorer));

        public bool isShow = false;
        public int windowsId = 6293;
        public float windowsWidth = 1000;
        public float windowsHeight = 600;
        public Rect windowsRect;
        public Vector2 scrollPosition;
        public Vector2 gameObjectListScrollPosition;
        public Vector2 viewScrollPosition;
        public string searchName = "";

        public GameObject parentGameObject;
        public List<GameObject> gameObjectList;
        public GameObject selectGameObject;
        public List<Component> selectGameObjectComponent;

        public GuiGameObjectExplorer()
        {
            windowsRect = new Rect(Screen.width / 2 - windowsWidth / 2, Screen.height / 2 - windowsHeight / 2, windowsWidth, windowsHeight);
        }

        public void OnGUI()
        {
            if (isShow)
            {
                windowsRect = GUI.Window(windowsId, windowsRect, GuiGameObjectExplorerWindows, "GameObject查看");
            }
        }

        private void GuiGameObjectExplorerWindows(int windowsId)
        {

            if (GUILayout.Button("关闭 unity版本:" + Application.unityVersion))
            {
                isShow = false;
            }

            try
            {
                scrollPosition = GUILayout.BeginScrollView(scrollPosition);

                GUILayout.BeginArea(new Rect(0, 0, 500, 600));

                if (GUILayout.Button("所有GameObject列表(先输筛选的文本再点)"))
                {
                    parentGameObject = null;
                    gameObjectList = GameObjectUtil.GetAllGameObject();
                }
                if (GUILayout.Button("所有GameObject写入txt(out目录,会卡)"))
                {
                    parentGameObject = null;
                    gameObjectList = GameObjectUtil.GetAllGameObject();
                    string text = "";
                    int index = 0;
                    foreach (GameObject gameObject in gameObjectList)
                    {
                        text += GameObjectUtil.GetGameObjectText(gameObject, 0, true, true, true, false, false);
                        text += "\n";
                        logger.LOG("写入gameObject ->" + index++);
                        File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(GlobalVariables.GetGlobalVariables().mscTranslateChs), "out/_AllGameObject" + index + "_" + gameObject.name + ".txt"), text);
                    }
                }

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("读取根节点"))
                {
                    parentGameObject = null;
                    // gameObjectList = new List<GameObject>(Application. UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects());
                    gameObjectList = GameObjectUtil.GetRootGameObject();
                }

                if (parentGameObject != null)
                {
                    if (GUILayout.Button("<"))
                    {
                        if (parentGameObject.transform.parent == null)
                        {
                            parentGameObject = null;
                            gameObjectList = GameObjectUtil.GetRootGameObject();
                            // gameObjectList = new List<GameObject>( UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects());
                        }
                        else
                        {
                            gameObjectList = GameObjectUtil.GetChildGameObjectList(parentGameObject.transform.parent.gameObject);
                            parentGameObject = parentGameObject.transform.parent.gameObject;
                        }
                    }
                }
                GUILayout.EndHorizontal();
                searchName = GUILayout.TextField(searchName);

                gameObjectListScrollPosition = GUILayout.BeginScrollView(gameObjectListScrollPosition);
                if (gameObjectList != null)
                {
                    foreach (GameObject gameObject in gameObjectList)
                    {
                        if (searchName != null && !searchName.Equals(""))
                        {
                            if (gameObject.name.ToLower().IndexOf(searchName.ToLower()) == -1)
                            {
                                continue;
                            }
                        }
                        GUILayout.BeginHorizontal();
                        if (GUILayout.Button(gameObject.name))
                        {
                            selectGameObject = gameObject;
                            selectGameObjectComponent = new List<Component>(gameObject.GetComponents<Component>());
                        }
                        if (GUILayout.Button(">"))
                        {
                            parentGameObject = gameObject;
                            gameObjectList = GameObjectUtil.GetChildGameObjectList(gameObject);
                        }
                        if (GUILayout.Button("去"))
                        {
                            GlobalVariables.GetGlobalVariables().teleport.TeleportTo(GameObjectUtil.GetGameObjectPath(gameObject));
                        }
                        if (GUILayout.Button("来"))
                        {
                            GameObject playerGameObject = GameObject.Find("PLAYER");
                            Vector3 clonePosition = new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y + 3f, playerGameObject.transform.position.z);
                            gameObject.transform.position = clonePosition;
                        }
                        if (GUILayout.Button("克隆"))
                        {
                            GameObject playerGameObject = GameObject.Find("PLAYER");
                            Vector3 clonePosition = new Vector3(playerGameObject.transform.position.x, playerGameObject.transform.position.y + 3f, playerGameObject.transform.position.z);
                            // GameObject cloneGameObject = MonoBehaviour.Instantiate(gameObject, clonePosition, gameObject.transform.rotation) as GameObject;
                            gameObject.SetActive(false);
                            GameObject cloneGameObject = GameObject.Instantiate(gameObject);
                            cloneGameObject.transform.position = clonePosition;
                        }
                        if (gameObject.activeSelf == false)
                        {
                            if (GUILayout.Button("启用"))
                            {
                                gameObject.SetActive(true);
                            }
                        }
                        else
                        {
                            if (GUILayout.Button("禁用"))
                            {
                                gameObject.SetActive(false);
                            }
                        }

                        GUILayout.EndHorizontal();
                    }
                }
                GUILayout.EndScrollView();

                GUILayout.EndArea();


                GUILayout.BeginArea(new Rect(500, 0, 500, 600));
                if (selectGameObject != null)
                {
                    GUILayout.Label("选中GameObject:" + GameObjectUtil.GetGameObjectPath(selectGameObject));
                    if (GUILayout.Button("写入txt"))
                    {
                        File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(GlobalVariables.GetGlobalVariables().mscTranslateChs), "_gameObject.txt"), GameObjectUtil.GetGameObjectText(selectGameObject, 0, false, true, true, false, false));
                    }

                    viewScrollPosition = GUILayout.BeginScrollView(viewScrollPosition);
                    string text = "";
                    foreach (Component component in selectGameObjectComponent)
                    {
                        Type type = component.GetType();
                        GUILayout.Label(type.FullName);
                        GUILayout.BeginVertical("box");
                        foreach (FieldInfo fieldInfo in type.GetFields())
                        {
                            string view = fieldInfo.Name + " : " + fieldInfo.GetValue(component);
                            text += view + "\n";
                            GUILayout.Label(view);
                        }
                        foreach (PropertyInfo propertyInfo in type.GetProperties())
                        {
                            try
                            {
                                string view = "  " + propertyInfo.Name + " : \n" + propertyInfo.GetValue(component, null);
                                text += view + "\n";
                                GUILayout.Label(view);
                            }
                            catch (Exception e)
                            {
                                string view = "  " + propertyInfo.Name + " : \n Error " + e.Message;
                                text += view + "\n";
                                GUILayout.Label(view);
                            }

                        }
                        if (component.GetType().Name.Equals("PlayMakerFSM"))
                        {
                            PlayMakerFSM playMakerFSM = component as PlayMakerFSM;
                            string view = "Component is PlayMakerFSM : \n" + FsmVariablesUtil.GetAllFsmVariablesAndVaule(playMakerFSM.FsmVariables);
                            text += view + "\n";
                            GUILayout.Label(view);
                        }

                        GUILayout.EndVertical();
                    }

                    GUILayout.EndScrollView();
                    if (GUILayout.Button("写入显示内容到txt"))
                    {
                        File.WriteAllText(Path.Combine(ModLoader.GetModAssetsFolder(GlobalVariables.GetGlobalVariables().mscTranslateChs), "_gameObjectViewText.txt"), text);
                    }
                }
                GUILayout.EndArea();


                GUILayout.EndScrollView();
            }
            catch (Exception e)
            {
                GUILayout.Label("exception : " + e.Message);
            }
            GUI.DragWindow();
        }
    }
}