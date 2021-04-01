using System;
using System.Collections.Generic;
using TinaX.XILRuntime;
using TinaX.XILRuntime.Internal.Redirect;

namespace TinaX.GameStage.Internal.CLRMethodRedirections
{
    public unsafe static partial class RedirectGameStage
    {
        /// <summary>
        /// 重定向映射表
        /// </summary>
        private static readonly Dictionary<Type, RedirectMapping> m_Mappings;
        private static IXILRuntime m_XIL => TinaX.XCore.GetMainInstance().Services.Get<IXILRuntime>();

        static RedirectGameStage()
        {
            m_Mappings = new Dictionary<Type, RedirectMapping>();

            Register_IGameStage();
        }

        /// <summary>
        /// 注册CLR重定向
        /// </summary>
        /// <param name="appDomain">AppDomain</param>
        public static void Register(IXILRuntime xil)
        {
            foreach (var item in m_Mappings)
            {
                var mapping = item.Value;
                var type = item.Key;
                var methods = type.GetMethods();

                foreach (var method in methods)
                {
                    var redirection = mapping.GetRedirection(method);
                    if (redirection == null)
                        continue;

                    xil.RegisterCLRMethodRedirection(method, redirection);
                }
            }
        }

        private static void GetMappingOrCreate(Type type, out RedirectMapping mapping)
        {
            if (m_Mappings.ContainsKey(type))
            {
                mapping = m_Mappings[type];
            }
            else
            {
                mapping = new RedirectMapping();
                m_Mappings.Add(type, mapping);
            }
        }
    }
}
