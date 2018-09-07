using MSCLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace MSCTranslateChs.Script.Common
{
    public class ExecutionTime
    {
        private static readonly LOGGER logger = new LOGGER(typeof(ExecutionTime));

        public Dictionary<string, long> executionStartTimeDict = new Dictionary<string, long>();
        public Dictionary<string, long> executionEndTimeDict = new Dictionary<string, long>();
        public Dictionary<string, long> executionTimeDict = new Dictionary<string, long>();

        public void Start(string key)
        {
            long currentTicks = DateTime.Now.Ticks;
            executionStartTimeDict[key] = currentTicks;
        }

        public long End(string key)
        {
            if (!executionStartTimeDict.ContainsKey(key))
            {
                return -1;
            }
            long currentTicks = DateTime.Now.Ticks;
            executionEndTimeDict[key] = currentTicks;
            executionTimeDict[key] = currentTicks - executionStartTimeDict[key];
            return executionTimeDict[key];
        }
    }
}
