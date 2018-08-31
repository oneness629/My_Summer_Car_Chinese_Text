using MSCLoader;
using MSCTranslateChs.Script;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Develop;
using MSCTranslateChs.Script.Translate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;


namespace MSCTranslateChs
{
    public class MSCTranslateChs : Mod
    {
        private static LOGGER logger = new LOGGER(typeof(MSCTranslateChs));

        public override string ID => "MSCTranslateChs";

        public override string Name => "MSCTranslateChs";

        public override string Author => "oneness629";

        public override string Version => "2.3";

        public override bool UseAssetsFolder => true;

        public Dictionary<string, ExecutionTime> allExecutionTime = new Dictionary<string, ExecutionTime>();
        public ExecutionTime executionTime = new ExecutionTime();

        public bool IsLoadResources = false;
        public bool IsLoadGameObject = false;
        public bool IsEnable = true;
        public bool IsTranslateSubtitles = true;
        public bool IsTranslatePartnames = true;
        public bool IsTranslateInteractions = true;
        public bool IsTranslateGameOverMessage = true;
        public bool IsTranslateUI = true;
        public bool IsTranslateEscInitUI = true;
        public bool IsDevelop = true;

        
        public TranslateText translateText;

        private TextMesh gameOverTextMesh;
        private TextMesh subtitlesTextMesh;
        private GUIStyle subtitlesGuiStyle;
        private Rect subtitlesRect;

        private TextMesh partnamesTextMesh;
        private GUIStyle partnamesGuiStyle;
        private Rect partnamesRect;

        private TextMesh interactionsTextMesh;
        private GUIStyle interactionsGuiStyle;
        private Rect interactionsRect;

        private GUIStyle mouseTipGuiStyle;

        private Develop develop;
        private WelcomeWindows welcomeWindows;

        public bool isShowWelcomeWindows = true;

        bool isInitSystemsGameObject = false;


        public override void OnLoad()
        {
            try
            {
                allExecutionTime.Add(typeof(MSCTranslateChs).Name ,executionTime);

                IsLoadResources = false;
                IsLoadGameObject = false;

                develop = new Develop(this);
                welcomeWindows = new WelcomeWindows(this);

                subtitlesGuiStyle = new GUIStyle();
                subtitlesGuiStyle.alignment = TextAnchor.MiddleCenter;
                subtitlesGuiStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
                subtitlesGuiStyle.normal.textColor = new Color(255, 165, 0);

                subtitlesRect = new Rect(0, (Screen.height) / 2.15f, Screen.width, Screen.height);

                partnamesGuiStyle = subtitlesGuiStyle;

                partnamesRect = new Rect(0, (Screen.height) / 2.4f, Screen.width, Screen.height);

                interactionsGuiStyle = new GUIStyle();
                interactionsGuiStyle.alignment = TextAnchor.MiddleCenter;
                interactionsGuiStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
                interactionsGuiStyle.normal.textColor = new Color(255, 255, 255);

                interactionsRect = new Rect(0, (Screen.height) / 12f, Screen.width, Screen.height);

                mouseTipGuiStyle = new GUIStyle();
                mouseTipGuiStyle.alignment = TextAnchor.LowerLeft;
                mouseTipGuiStyle.fontSize = (int)(14.0f * (float)(Screen.width) / 1000f);
                mouseTipGuiStyle.normal.textColor = new Color(255, 255, 255);

                translateText = new TranslateText(this);

                IsLoadResources = true;
            }
            catch (Exception e)
            {
                logger.LOG("OnLoad Exception : " + e.Message);
                logger.LOG(e);
            }
        }

        public override void OnGUI()
        {
            executionTime.Start("OnGUI");
            try
            {
                if (IsLoadResources && IsLoadGameObject && Application.loadedLevelName == "GAME")
                {
                    if (IsEnable)
                    {
                        executionTime.Start("字幕");
                        if (IsTranslateSubtitles)
                        {
                            
                            // 字幕
                            string subtitlesText = subtitlesTextMesh.text.Trim();
                            if (subtitlesTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(subtitlesText))
                            {
                                GUI.Label(subtitlesRect, translateText.TranslateString(subtitlesText, TranslateText.DICT_SUBTITLE), subtitlesGuiStyle);
                            }
                        }
                        executionTime.End("字幕");
                        executionTime.Start("物品名称");
                        if (IsTranslatePartnames)
                        {
                            // 部件/物品名称
                            string partnamesText = partnamesTextMesh.text.Trim();
                            if (partnamesTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(partnamesText))
                            {
                                GUI.Label(partnamesRect, translateText.TranslateString(partnamesText, TranslateText.DICT_PARTNAME), partnamesGuiStyle);
                            }
                        }
                        executionTime.End("物品名称");
                        executionTime.Start("操作动作");
                        if (IsTranslateInteractions)
                        {
                            // 操作动作
                            string interactionsText = interactionsTextMesh.text.Trim();
                            if (interactionsTextMesh.gameObject.activeSelf && !string.IsNullOrEmpty(interactionsText))
                            {
                                GUI.Label(interactionsRect, translateText.TranslateString(interactionsText, TranslateText.DICT_INTERACTION), interactionsGuiStyle);
                            }
                        }
                        executionTime.End("操作动作");
                        executionTime.Start("GameOver");
                        if (IsTranslateGameOverMessage)
                        {
                            // game over 提示
                            GameOverMessage();
                        }
                        executionTime.End("GameOver");
                        executionTime.Start("UI");
                        if (IsTranslateUI)
                        {
                            // 额外的菜单
                            RaySystemsGameObject();
                        }
                        executionTime.End("UI");
                        executionTime.Start("Esc initUI");
                        if (IsTranslateEscInitUI)
                        {
                            if (Input.GetKey(KeyCode.Escape))
                            {
                                initUIRay();
                            }
                        }
                        executionTime.End("Esc initUI");
                        executionTime.Start("Develop");
                        if (IsDevelop)
                        {
                            develop.Update();
                            if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.R))
                            {
                                translateText.ReadTranslateTextDict();
                            }
                        }
                        executionTime.End("Develop");
                    }
                    if (Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.W))
                    {
                        isShowWelcomeWindows = true;
                    }
                    if (Input.GetKey(KeyCode.RightAlt) && Input.GetKey(KeyCode.W))
                    {
                        isShowWelcomeWindows = false;
                    }
                    executionTime.Start("WelcomeWindows");
                    if (isShowWelcomeWindows)
                    {
                        welcomeWindows.Update();
                    }
                    executionTime.End("WelcomeWindows");

                }
            }
            catch (Exception e)
            {
                logger.LOG("OnGUI Exception : " + e.Message);
                logger.LOG(e);
            }
            executionTime.End("OnGUI");
        }

        public void initUIRay()
        {
            GameObject systemsGameObject = GameObject.Find("Systems");
            if (systemsGameObject != null)
            {
                GameObjectUtil.addBoxColliderByChild(systemsGameObject, "");
            }
        }

        private void GameOverMessage()
        {
            GameObject gameObject = GameObject.Find("Systems/Death/GameOverScreen/Paper");
            if (gameObject == null)
            {
                return;
            }
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                GameObject childGameObject = gameObject.transform.GetChild(i).gameObject;
                if (childGameObject != null && (childGameObject.activeSelf || Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.G)))
                {
                    string path = GameObjectUtil.getGameObjectPath(childGameObject);
                    string pathTextEn = path + "/TextEN";
                    GameObject textEnGameObject = GameObject.Find(pathTextEn);
                    if (textEnGameObject != null)
                    {
                        gameOverTextMesh = GameObjectUtil.FindGameObjectTextMesh(pathTextEn);
                        if (gameOverTextMesh != null)
                        {
                            string gameOverText = gameOverTextMesh.text.Trim();
                            string translateString = translateText.TranslateString(gameOverText, TranslateText.DICT_GAMEOVER);
                            
                            // ModConsole.Print("GameOver文本GameObject读取：");
                            // ModConsole.Print("EN:" + gameOverText);
                            // ModConsole.Print("TranslateString:" + translateString);
                            GUI.Label(subtitlesRect, translateString, subtitlesGuiStyle);
                        }
                    }
                }
            }
            
        }

        public override void Update()
        {
            if (IsLoadResources && Application.loadedLevelName == "GAME")
            {
                if (!IsLoadGameObject)
                {
                    // load gameobject
                    try
                    {
                        subtitlesTextMesh = GameObjectUtil.FindGameObjectTextMesh("GUI/Indicators/Subtitles");
                        partnamesTextMesh = GameObjectUtil.FindGameObjectTextMesh("GUI/Indicators/Partname");
                        interactionsTextMesh = GameObjectUtil.FindGameObjectTextMesh("GUI/Indicators/Interaction");

                        IsLoadGameObject = true;
                    }
                    catch (Exception e)
                    {
                        IsLoadGameObject = false;
                        logger.LOG("加载GameObject过程出现异常: " + e.Message);
                    }
                }
            }
        }

        private void RaySystemsGameObject()
        {
            if (!isInitSystemsGameObject)
            {
                InitSystemRayGameObject();
                isInitSystemsGameObject = true;
            }
            else
            {
                GameObject cam = GameObject.Find("Systems/OptionsMenu/CAM");
                if (cam == null)
                {
                    return;
                }
                Camera camera = cam.GetComponent<Camera>();
                if (camera == null)
                {
                    return;
                }
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                RaycastHit[] raycastHits = Physics.RaycastAll(ray, Mathf.Infinity, 1 << 14);
                if (raycastHits != null && raycastHits.Length > 0)
                {
                    string text = "";
                    foreach (RaycastHit hitInfo in raycastHits)
                    {
                        GameObject gameObject = hitInfo.collider.gameObject;
                        string textMeshString = GameObjectUtil.getGameObjectTextMeshString(gameObject);
                        if (textMeshString != null && textMeshString.Trim().Length > 0)
                        {
                            text = translateText.TranslateString(textMeshString, TranslateText.DICT_UI);
                            // text += textMeshString;
                        }
                    }
                    GUI.Label(new Rect(Input.mousePosition.x, (-Input.mousePosition.y), Screen.width, Screen.height), text, mouseTipGuiStyle);
                }
            }
        }

        private void InitSystemRayGameObject()
        {
            GameObject systemsGameObject = GameObject.Find("Systems");
            if (systemsGameObject != null)
            {
                GameObjectUtil.addBoxColliderByChildByTextMesh(systemsGameObject);
            }
        }
        

    }
}
