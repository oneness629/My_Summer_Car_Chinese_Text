using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCTranslateChs.Script.Common
{
    class FsmVariablesUtil
    {

        public static string getAllFsmVariablesAndVaule()
        {
            string text = "";
            text += getAllBooleanFsmVariables() + "\n\n\n\n\n";
            text += getAllColorFsmVariables() + "\n\n\n\n\n";
            text += getAllFloatFsmVariables() + "\n\n\n\n\n";
            text += getAllGameObjectFsmVariables() + "\n\n\n\n\n";
            text += getAllIntFsmVariables() + "\n\n\n\n\n";
            text += getAllObjectFsmVariables() + "\n\n\n\n\n";
            text += getAllQuaternionFsmVariables() + "\n\n\n\n\n";
            text += getAllRectFsmVariables() + "\n\n\n\n\n";
            text += getAllStringFsmVariables() + "\n\n\n\n\n";
            text += getAllTextureFsmVariables() + "\n\n\n\n\n";
            text += getAllVector2FsmVariables() + "\n\n\n\n\n";
            text += getAllVector3FsmVariables() + "\n\n\n\n\n";
            return text;
        }


        public static string getAllFsmVariablesGlobalVariablesNames()
        {
            string text = "";
            foreach (NamedVariable namedVariable in FsmVariables.GlobalVariables.GetAllNamedVariables())
            {
                text += "namedVariable name: " + namedVariable.Name + "\n";
            }
            return text;
        }

        public static string getAllBooleanFsmVariables()
        {
            string text = "";
            foreach (FsmBool fsmBool in FsmVariables.GlobalVariables.BoolVariables)
            {
                text += "fsmBool name: " + fsmBool.Name + ":" + fsmBool.Value + "\n";
            }
            return text;
        }

        public static string getAllColorFsmVariables()
        {
            string text = "";
            foreach (FsmColor fsmColor in FsmVariables.GlobalVariables.ColorVariables)
            {
                text += "fsmColor name: " + fsmColor.Name + ":" + fsmColor.Value + "\n";
            }
            return text;
        }

        public static string getAllFloatFsmVariables()
        {
            string text = "";
            foreach (FsmFloat fsmFloat in FsmVariables.GlobalVariables.FloatVariables)
            {
                text += "fsmFloat name: " + fsmFloat.Name + ":" + fsmFloat.Value + "\n";
            }
            return text;
        }

        public static string getAllGameObjectFsmVariables()
        {
            string text = "";
            foreach (FsmGameObject fsmGameObject in FsmVariables.GlobalVariables.GameObjectVariables)
            {
                text += "fsmGameObject name: " + fsmGameObject.Name + ":" + GameObjectUtil.getGameObjectPath(fsmGameObject.Value) + "\n";
            }
            return text;
        }

        public static string getAllIntFsmVariables()
        {
            string text = "";
            foreach (FsmInt fsmInt in FsmVariables.GlobalVariables.IntVariables)
            {
                text += "fsmInt name: " + fsmInt.Name + ":" + fsmInt.Value + "\n";
            }
            return text;
        }

        public static string getAllMaterialFsmVariables()
        {
            string text = "";
            foreach (FsmMaterial fsmMaterial in FsmVariables.GlobalVariables.MaterialVariables)
            {
                text += "fsmMaterial name: " + fsmMaterial.Name + ":" + fsmMaterial.Value + "\n";
            }
            return text;
        }

        public static string getAllObjectFsmVariables()
        {
            string text = "";
            foreach (FsmObject fsmObject in FsmVariables.GlobalVariables.ObjectVariables)
            {
                text += "fsmObject name: " + fsmObject.Name + ":" + fsmObject.Value + "\n";
            }
            return text;
        }

        public static string getAllQuaternionFsmVariables()
        {
            string text = "";
            foreach (FsmQuaternion fsmQuaternion in FsmVariables.GlobalVariables.QuaternionVariables)
            {
                text += "fsmQuaternion name: " + fsmQuaternion.Name + ":" + fsmQuaternion.Value + "\n";
            }
            return text;
        }

        public static string getAllRectFsmVariables()
        {
            string text = "";
            foreach (FsmRect fsmRect in FsmVariables.GlobalVariables.RectVariables)
            {
                text += "fsmRect name: " + fsmRect.Name + ":" + fsmRect.Value + "\n";
            }
            return text;
        }

        public static string getAllStringFsmVariables()
        {
            string text = "";
            foreach (FsmString fsmString in FsmVariables.GlobalVariables.StringVariables)
            {
                text += "fsmString name: " + fsmString.Name + ":" + fsmString.Value + "\n";
            }
            return text;
        }

        public static string getAllTextureFsmVariables()
        {
            string text = "";
            foreach (FsmTexture fsmTexture in FsmVariables.GlobalVariables.TextureVariables)
            {
                text += "fsmTexture name: " + fsmTexture.Name + ":" + fsmTexture.Value + "\n";
            }
            return text;
        }

        public static string getAllVector2FsmVariables()
        {
            string text = "";
            foreach (FsmVector2 fsmVector2 in FsmVariables.GlobalVariables.Vector2Variables)
            {
                text += "fsmVector2 name: " + fsmVector2.Name + ":" + fsmVector2.Value + "\n";
            }
            return text;
        }

        public static string getAllVector3FsmVariables()
        {
            string text = "";
            foreach (FsmVector3 fsmVector3 in FsmVariables.GlobalVariables.Vector3Variables)
            {
                text += "fsmVector3 name: " + fsmVector3.Name + ":" + fsmVector3.Value + "\n";
            }
            return text;
        }
    }
}
