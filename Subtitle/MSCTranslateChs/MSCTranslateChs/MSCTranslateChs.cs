using HutongGames.PlayMaker;
using MSCLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace MSCTranslateChs
{
    public class MSCTranslateChs : Mod
    {
        private bool m_isLoaded;

        private TextMesh m_subtitlesText;

        private TextMesh m_subtitlesShadow;

        private FsmString m_Interaction;

        private TextMesh m_InteractionShadow;

        private FsmString m_PartName;

        private TextMesh m_PartNameShadow;

        private TextMesh m_HUDDay;

        private TextMesh[] m_Status;

        private List<TextMesh> m_Menu;

        private string m_ActualSub;

        private string m_ActualDay;

        private string m_ActualIteraction;

        private string m_ActualPartName;

        private bool statusTranslated;

        private bool configTranslated;

        private GameObject m_player;

        private List<string> m_SubtitlesList;

        private List<string> m_InteractionsList;

        private List<string> m_PartNameList;

        public override string ID => "MSCTranslateChs";

        public override string Name => "MSCTranslateChs";

        public override string Author => "oneness629";

        public override string Version => "1.0";

        public override bool UseAssetsFolder => true;

        public override void OnLoad()
        {
            m_isLoaded = false;
            m_ActualSub = "";
            m_ActualDay = "";
            m_ActualIteraction = "";
            m_ActualPartName = "";
            m_Status = (TextMesh[])new TextMesh[10];
            m_Menu = new List<TextMesh>();
            m_SubtitlesList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "subtitles.txt")).ToList();
            m_InteractionsList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "interactions.txt")).ToList();
            m_PartNameList = File.ReadAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "partnames.txt")).ToList();
        }

        public override void Update()
        {
            if (Application.loadedLevelName == "GAME")
            {
                if (!m_isLoaded)
                {
                    try
                    {
                        if (!(GameObject.Find("GUI/Indicators/Subtitles") == null) && !(GameObject.Find("PLAYER") == null))
                        {
                            ModConsole.Print("Load Subtitle");
                            m_subtitlesText = GameObject.Find("GUI/Indicators/Subtitles").GetComponent<TextMesh>();
                            
                            m_subtitlesShadow = GameObject.Find("GUI/Indicators/Subtitles/Shadow").GetComponent<TextMesh>();
                            m_Interaction = FsmVariables.GlobalVariables.FindFsmString("GUIinteraction");
                            m_InteractionShadow = GameObject.Find("GUI/Indicators/Interaction/Shadow").GetComponent<TextMesh>();
                            m_PartName = FsmVariables.GlobalVariables.FindFsmString("PickedPart");
                            m_PartNameShadow = GameObject.Find("GUI/Indicators/Partname/Shadow").GetComponent<TextMesh>();
                            m_HUDDay = GameObject.Find("GUI/HUD/Day/Data").GetComponent<TextMesh>();
                            m_player = GameObject.Find("PLAYER");
                            m_isLoaded = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        ModConsole.Print("MSCT: ERRO: " + ex.ToString());
                    }
                }
                else
                {
                    UpdateSubtitles();
                    UpdateInteraction();
                    UpdatePartName();
                    if (!statusTranslated)
                    {
                        loadStatusTextMesh();
                    }
                    if (!configTranslated)
                    {
                        loadConfigMenuText();
                    }
                }
            }
            else if (m_isLoaded)
            {
                m_isLoaded = false;
                m_subtitlesText = null;
                m_subtitlesShadow = null;
                m_Interaction = null;
                m_InteractionShadow = null;
                m_PartName = null;
                m_PartNameShadow = null;
                m_HUDDay = null;
                try
                {
                    ModConsole.Error("Saving updated files");
                    File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "subtitles.txt"), m_SubtitlesList.ToArray());
                    File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "interactions.txt"), m_InteractionsList.ToArray());
                    File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "partnames.txt"), m_PartNameList.ToArray());
                }
                catch (Exception ex2)
                {
                    ModConsole.Error("Save Error: " + ex2.ToString());
                }
            }
        }

        private void UpdateSubtitles()
        {
            if (m_subtitlesText.text != "" && m_subtitlesText.text != m_ActualSub)
            {
                try
                {
                    m_ActualSub = m_subtitlesText.text;
                    m_subtitlesText.text = TranslateString(m_subtitlesText.text, m_SubtitlesList);
                    m_subtitlesShadow.text = m_subtitlesText.text;
                }
                catch (Exception ex)
                {
                    ModConsole.Print("SubtitleERRO: " + ex.ToString());
                }
            }
            ChangeHudDay();
        }

        private void UpdateInteraction()
        {
            if (m_Interaction != null && m_Interaction.Value != "" && m_Interaction.Value != m_ActualIteraction)
            {
                try
                {
                    m_Interaction.Value = TranslateString(m_Interaction.Value, m_InteractionsList);
                    m_ActualIteraction = m_Interaction.Value;
                    m_InteractionShadow.text = m_Interaction.Value;
                }
                catch (Exception ex)
                {
                    ModConsole.Print("InteractionERRO: " + ex.ToString());
                }
            }
        }

        private void UpdatePartName()
        {
            if (m_PartName != null && m_PartName.Value != "" && m_PartName.Value != m_ActualPartName)
            {
                try
                {
                    m_PartName.Value = TranslateString(m_PartName.Value, m_PartNameList);
                    m_ActualPartName = m_PartName.Value;
                    m_PartNameShadow.text = (m_PartName.Value);
                    File.WriteAllLines(Path.Combine(ModLoader.GetModAssetsFolder(this), "partnames.txt"), m_PartNameList.ToArray());
                }
                catch (Exception ex)
                {
                    ModConsole.Print("PartNameERRO: " + ex.ToString());
                }
            }
        }

        private void loadStatusTextMesh()
        {
            try
            {
                m_Status[0] = GameObject.Find("GUI/HUD/Urine/Text").GetComponent<TextMesh>();
                m_Status[1] = GameObject.Find("GUI/HUD/Hunger/Text").GetComponent<TextMesh>();
                m_Status[2] = GameObject.Find("GUI/HUD/Thrist/Text").GetComponent<TextMesh>();
                m_Status[3] = GameObject.Find("GUI/HUD/Fatigue/Text").GetComponent<TextMesh>();
                m_Status[4] = GameObject.Find("GUI/HUD/Stress/Text").GetComponent<TextMesh>();
                m_Status[5] = GameObject.Find("GUI/HUD/Dirty/Text").GetComponent<TextMesh>();
                m_Status[6] = GameObject.Find("GUI/HUD/Money/Text").GetComponent<TextMesh>();
                m_Status[7] = GameObject.Find("GUI/HUD/Jailtime/Text").GetComponent<TextMesh>();
            }
            catch (Exception ex)
            {
                ModConsole.Print("MSCT: ERRO: " + ex.ToString());
                return;
            }
            for (int i = 0; i < 8; i++)
            {
                TextMesh val = m_Status[i];
                if (val.text != "")
                {
                    ModConsole.Print("|" + val.text.Trim() + "|");
                    val.text = TranslateString(val.text.Trim(), m_InteractionsList);
                }
            }
            statusTranslated = true;
        }

        private void loadConfigMenuText()
        {
            try
            {
                if (!(GameObject.Find("Systems/OptionsMenu") != null))
                {
                    return;
                }
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Btn_Resume/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Btn_Graphics/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Btn_CarControls/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Btn_PlayerControls/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Btn_Quit/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Antialiasing/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Bloom/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_RefProbes/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_ShadowsSun/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_ShadowsHouse/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Sunshafts/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Contrast/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Water/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Mirrors/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Traffic/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_FPS/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Gear/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Skidmarks/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_FOV/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Draw/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/Graphics/Btn_Subtitles/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/SteerLeft/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/SteerRight/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Throttle/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Brake/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Clutch/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Handbrake/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Shift Up/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Shift Down/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Neutral/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/1/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/2/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/3/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/4/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/5/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/6/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Reverse/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Range/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Beams/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Wipers/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/TurnSignalLeft/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/TurnSignalRight/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Boost/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/AutoClutch/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Shifter/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/SteerRotation/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/SteerHelp/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/SteerHelp/SteeringHelp/Btn_SteerTime/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/SteerHelp/SteeringHelp/Btn_SteerVelo/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/FFB/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/FFB/FFBsettings/Btn_FFBMultiplier/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/FFB/FFBsettings/Btn_FFBClamp/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/FFB/FFBsettings/Btn_FFBInvert/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Calibrate/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Invert/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/CarControls/Buttons/Defaults/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Forward/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Backward/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Left/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Right/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Jump/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Run/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/DrivingMode/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Zoom/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Use/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Crouch/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/ReachLeft/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/ReachRight/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Swear/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Drunk/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Hit/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Push/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Finger/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Urinate/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Hitchhike/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Smoking/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Btn_Mouse/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Btn_SensitivityX/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/Buttons/Btn_SensitivityY/Text").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Text 1").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Mouse/MouseLeft/Text 1").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Mouse/MouseLeft/Text 2").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Mouse/MouseLeft/Text 4").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Mouse/MouseLeft/Text 3").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Mouse/MouseMiddle/Text 1").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Mouse/MouseMiddle/Text 2").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Mouse/MouseMiddle/Text 3").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Mouse/MouseRight/Text 1").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Mouse/MouseRight/Text 2").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Mouse/MouseRight/Text 3").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Keyboard/Text 4/Text 2").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Keyboard/Text 3/Text 2").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Keyboard/Text 1/Text 2").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Keyboard/Text 2/Text 2").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Keyboard/Text 7/Text 2").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Keyboard/Text 6/Text 2").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Keyboard/Text 5/Text 2").GetComponent<TextMesh>());
                m_Menu.Add(GameObject.Find("Systems/OptionsMenu/PlayerControls/OtherControls/Text 2").GetComponent<TextMesh>());
            }
            catch (Exception ex)
            {
                ModConsole.Print("MSCT: ERRO: " + ex.ToString());
                return;
            }
            foreach (TextMesh item in m_Menu)
            {
                if (!(item != null))
                {
                    return;
                }
                if (!(item.text != ""))
                {
                    return;
                }
                ModConsole.Print("|" + item.text.Trim() + "|");
                item.text = TranslateString(item.text.Trim(), m_InteractionsList);
            }
            configTranslated = true;
        }

        private void ChangeHudDay()
        {
            if (m_HUDDay.text != "" && m_HUDDay.text != m_ActualDay)
            {
                m_ActualDay = m_HUDDay.text;
                m_HUDDay.text = TranslateString(m_ActualDay, m_InteractionsList);
            }
        }

        private string TranslateString(string text, List<string> textList)
        {
            string text2 = textList.FirstOrDefault((string s) => s.ToUpper().Contains(text.Trim().ToUpper()));
            if (string.IsNullOrEmpty(text2))
            {
                textList.Add(text + "=" + text);
                ModConsole.Print("Text Not Found: " + text);
                return text;
            }
            return text2.Split('=')[1];
        }

    }
}
