using HutongGames.PlayMaker;
using MSCLoader;
using MSCTranslateChs.Script;
using MSCTranslateChs.Script.Common;
using MSCTranslateChs.Script.Develop;
using MSCTranslateChs.Script.Teleport;
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

        public override string Version => "2.5";

        public override bool UseAssetsFolder => true;

        public Dictionary<string, ExecutionTime> allExecutionTime = new Dictionary<string, ExecutionTime>();
        public ExecutionTime executionTime = new ExecutionTime();
        public Money money = new Money();

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
        public bool isEnableTeleport = true;

        public TranslateText translateText;

        private TextMesh gameOverTextMesh;
        private TextMesh subtitlesTextMesh;
        private GUIStyle subtitlesGuiStyle;
        private Rect subtitlesRect;

        public TextMesh partnamesTextMesh;
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

        public Teleport teleport = new Teleport();
        public BoltTip boltTip = new BoltTip();
        public ItemTransmitter itemTransmitter;

        public override void OnLoad()
        {
            try
            {
                allExecutionTime.Add(typeof(MSCTranslateChs).Name ,executionTime);

                IsLoadResources = false;
                IsLoadGameObject = false;

                develop = new Develop(this);
                welcomeWindows = new WelcomeWindows(this);
                itemTransmitter = new ItemTransmitter(this);


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
                            RayGuiGameObject();
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
                    executionTime.Start("Teleport");
                    if (isEnableTeleport)
                    {
                        teleport.Update();
                    }
                    executionTime.End("Teleport");

                    if (money.isShowWindow)
                    {
                        money.OnGUI();
                    }
                    if (boltTip.isShowWindow)
                    {
                        boltTip.OnGUI();
                    }
                    executionTime.Start("物品传送(背包)");
                    itemTransmitter.OnGUI();
                    executionTime.End("物品传送(背包)");


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
            InitSystemRayGameObject();
            InitGuiRayGameObject();
        }

        public GameObject gameObjectSystems;
        public GameObject gameObjectSystemsDeath;
        public GameObject gameObjectSystemsDeathGameOverScreen;
        public GameObject gameObjectSystemsDeathGameOverScreenPaper;
        public string gameOverMessage;
        public bool isGameOverScreen = false;

        private void GameOverMessageGUI()
        {
            if (gameOverMessage != null && isGameOverScreen)
            {
                GUI.Label(subtitlesRect, gameOverMessage, subtitlesGuiStyle);
            }
        }

        private void GameOverMessage()
        {
            // gameObjectGameOverScreenPaper = GameObject.Find("Systems/Death/GameOverScreen/Paper");
            if (gameObjectSystems == null)
            {
                gameObjectSystems = GameObject.Find("Systems");
            }
            if (gameObjectSystems == null)
            {
                return;
            }
            gameObjectSystemsDeath = GameObjectUtil.GetChildGameObject(gameObjectSystems, "Death");
            if (gameObjectSystemsDeath == null)
            {
                return;
            }
            gameObjectSystemsDeathGameOverScreen = GameObjectUtil.GetChildGameObject(gameObjectSystemsDeath, "GameOverScreen");
            if (gameObjectSystemsDeathGameOverScreen == null)
            {
                return;
            }
            gameObjectSystemsDeathGameOverScreenPaper = GameObjectUtil.GetChildGameObject(gameObjectSystemsDeathGameOverScreen, "Paper");
            if (gameObjectSystemsDeathGameOverScreenPaper == null)
            {
                return;
            }
            for (int i = 0; i < gameObjectSystemsDeathGameOverScreenPaper.transform.childCount; i++)
            {
                isGameOverScreen = false;
                GameObject childGameObject = gameObjectSystemsDeathGameOverScreenPaper.transform.GetChild(i).gameObject;
                if (childGameObject != null && (childGameObject.activeSelf || Input.GetKey(KeyCode.LeftAlt) && Input.GetKey(KeyCode.G)))
                {
                    isGameOverScreen = true;
                    // string path = GameObjectUtil.getGameObjectPath(childGameObject);
                    // string pathTextEn = path + "/TextEN";
                    // GameObject textEnGameObject = GameObject.Find(pathTextEn);
                    GameObject textEnGameObject = GameObjectUtil.GetChildGameObject(childGameObject, "TextEN");
                    if (textEnGameObject != null)
                    {
                        gameOverTextMesh = GameObjectUtil.FindGameObjectTextMesh(textEnGameObject);
                        if (gameOverTextMesh != null)
                        {
                            string gameOverText = gameOverTextMesh.text.Trim();
                            string translateString = translateText.TranslateString(gameOverText, TranslateText.DICT_GAMEOVER);

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

        // Camera cameraMenu;

        private void RaySystemsGameObject()
        {
            if (!isInitSystemsGameObject)
            {
                InitSystemRayGameObject();
                isInitSystemsGameObject = true;
            }
            else
            {
                if (Camera.main == null)
                {
                    return;
                }
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] raycastHits = Physics.RaycastAll(ray, Mathf.Infinity, 1 << 14);
                if (raycastHits != null && raycastHits.Length > 0)
                {
                    string text = "";
                    foreach (RaycastHit hitInfo in raycastHits)
                    {
                        if (hitInfo.collider != null)
                        {
                            GameObject gameObject = hitInfo.collider.gameObject;
                            if (gameObject != null)
                            {
                                string textMeshString = GameObjectUtil.getGameObjectTextMeshString(gameObject);
                                if (textMeshString != null && textMeshString.Trim().Length > 0)
                                {
                                    text = translateText.TranslateString(textMeshString, TranslateText.DICT_UI);
                                }
                            }
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

        Camera guiCamera;
        bool isInitGuiGameObject = false;

        private void InitGuiRayGameObject()
        {
            GameObject hudGameObject = GameObject.Find("GUI/HUD");
            if (hudGameObject != null)
            {
                GameObjectUtil.addBoxColliderByChildByTextMesh(hudGameObject);
            }
            if (guiCamera == null)
            {
                GameObject GuiGameObjectExplorer = GameObject.Find("GUI/CAM");
                if (GuiGameObjectExplorer != null)
                {
                    guiCamera = GuiGameObjectExplorer.GetComponent<Camera>();
                }

            }
        }

        private void RayGuiGameObject()
        {
            if (!isInitGuiGameObject)
            {
                InitGuiRayGameObject();
                isInitGuiGameObject = true;
            }
            else
            {
              
                if (guiCamera == null)
                {
                    return;
                }
                Ray ray = guiCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit[] raycastHits = Physics.RaycastAll(ray, Mathf.Infinity, 1 << 14);
                if (raycastHits != null && raycastHits.Length > 0)
                {
                    string text = "";
                    foreach (RaycastHit hitInfo in raycastHits)
                    {
                        if (hitInfo.collider != null)
                        {
                            GameObject gameObject = hitInfo.collider.gameObject;
                            if (gameObject != null)
                            {
                                string textMeshString = GameObjectUtil.getGameObjectTextMeshString(gameObject);
                                if (textMeshString != null && textMeshString.Trim().Length > 0)
                                {
                                    text = translateText.TranslateString(textMeshString, TranslateText.DICT_UI);
                                }
                            }
                        }
                    }
                    GUI.Label(new Rect(Input.mousePosition.x, (-Input.mousePosition.y), Screen.width, Screen.height), text, mouseTipGuiStyle);
                }
            }
        }


    }
}
