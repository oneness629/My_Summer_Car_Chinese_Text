using HutongGames.PlayMaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MSCTranslateChs.Script.Common
{
    class FsmVariablesTextUtil
    {
        private static string getAllFsmVariablesGlobalVariablesNames()
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
            return text;
        }
    }
}
