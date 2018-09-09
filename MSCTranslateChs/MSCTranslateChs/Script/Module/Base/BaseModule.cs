using MSCTranslateChs.Script.Common;
using System;
using System.Collections.Generic;

namespace MSCTranslateChs.Script.Module.Base
{

    public abstract class BaseModule
    {
        private static readonly LOGGER logger = new LOGGER(typeof(BaseModule));

        public virtual string ModuleComment { get => "基础模块"; }

        public bool IsEnable { get; set; }

        public abstract void Init();

        public abstract void OnGUI();

        public abstract void Update();

    }

    class TestModule : BaseModule
    {
        public override string ModuleComment { get => "测试模块"; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Init()
        {
            throw new System.NotImplementedException();
        }

        public override void OnGUI()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Update()
        {
            throw new System.NotImplementedException();
        }

        public static void Main(string[] args)
        {
            BaseModule baseModule = new TestModule();
            BaseModule baseModule2 = new TestModule();

            Console.WriteLine("baseModule ModuleComment : " + baseModule.ModuleComment);
            Console.WriteLine("baseModule IsEnable : " + baseModule.IsEnable);
            baseModule.IsEnable = false;
            Console.WriteLine("baseModule IsEnable : " + baseModule.IsEnable);
            baseModule.IsEnable = true;
            Console.WriteLine("baseModule IsEnable : " + baseModule.IsEnable);

            List<BaseModule> list = new List<BaseModule>
            {
                baseModule,
                baseModule2
            };
            foreach (BaseModule module in list)
            {
                Console.WriteLine("module ModuleComment : " + module.ModuleComment);
            }
        }
    }

}
