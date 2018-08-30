using MSCLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace MSCTranslateChs.Script.Common
{
    public class LOGGER
    {
        private string typeName;
        private readonly string logFrontText;

        public LOGGER(Type type)
        {
            if (type != null)
            {
                this.typeName = type.Name;
                this.logFrontText = "[" + this.typeName + "]";
            }
            else
            {
                throw new Exception("type is null");
            }
        }

        public void LOG(string text)
        {
            string log = this.logFrontText + text;
            ModConsole.Print(log);
            Console.WriteLine(log);
        }

        public void LOG(object obj)
        {
            ModConsole.Print(this.logFrontText);
            ModConsole.Print(obj);
            Console.WriteLine(obj);
        }

    }
}
