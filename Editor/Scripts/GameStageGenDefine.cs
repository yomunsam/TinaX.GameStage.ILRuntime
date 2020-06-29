﻿//using System;
//using System.Collections.Generic;
//using TinaX.XComponent;
//using TinaXEditor.XILRuntime;
using System;
using System.Collections.Generic;
using System.Reflection;
using TinaX.GameStage;
using TinaX.GameStage.Internal.Adaptors;
using TinaXEditor.XILRuntime;

namespace TinaXEditor.GameStage.XILRuntime.Generator
{
    public class GenCodeDefine : ICLRGenerateDefine
    {
        public void GenerateByAssemblies_InitILRuntime(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        {
            //注册跨域
            appdomain.RegisterCrossBindingAdaptor(new StageControllerBaseAdapter());
        }

        /// <summary>
        /// 生成CLR绑定代码的列表
        /// </summary>
        /// <returns></returns>
        public List<Type> GetCLRBindingTypes() => new List<Type>
        {
            typeof(IGameStage),
        };

        public HashSet<FieldInfo> GetCLRBindingExcludeFields() => null;

        public HashSet<MethodBase> GetCLRBindingExcludeMethods() => null;



        public List<Type> GetDelegateTypes() => null;

        public List<Type> GetValueTypeBinders() => null;
    }
}