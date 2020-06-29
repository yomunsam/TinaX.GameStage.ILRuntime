using System;
using ILRuntime.CLR.Method;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;

namespace TinaX.GameStage.Internal.Adaptors
{   
    public class StageControllerBaseAdapter : CrossBindingAdaptor
    {
        //static CrossBindingMethodInfo<System.String> mOnInit_0 = new CrossBindingMethodInfo<System.String>("OnInit");
        //static CrossBindingMethodInfo<System.String> mOnEnter_1 = new CrossBindingMethodInfo<System.String>("OnEnter");
        //static CrossBindingMethodInfo<System.String> mOnExit_2 = new CrossBindingMethodInfo<System.String>("OnExit");
        //static CrossBindingMethodInfo mOnDestroy_3 = new CrossBindingMethodInfo("OnDestroy");
        public override Type BaseCLRType
        {
            get
            {
                return typeof(TinaX.GameStage.StageControllerBase);
            }
        }

        public override Type AdaptorType
        {
            get
            {
                return typeof(Adapter);
            }
        }

        public override object CreateCLRInstance(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
        {
            return new Adapter(appdomain, instance);
        }

        public class Adapter : TinaX.GameStage.StageControllerBase, CrossBindingAdaptorType
        {
            ILTypeInstance instance;
            ILRuntime.Runtime.Enviorment.AppDomain appdomain;

            IMethod m_OnInit;
            bool m_OnInitGot;
            bool m_OnInitInvoking;

            IMethod m_OnEnter;
            bool m_OnEnterGot;
            bool m_OnEnterInvoking;

            IMethod m_OnExit;
            bool m_OnExitGot;
            bool m_OnExitInvoking;

            IMethod m_OnDestroy;
            bool m_OnDestroyGot;
            bool m_OnDestroyInvoking;

            object[] param_1 = new object[1];


            public Adapter()
            {

            }

            public Adapter(ILRuntime.Runtime.Enviorment.AppDomain appdomain, ILTypeInstance instance)
            {
                this.appdomain = appdomain;
                this.instance = instance;
            }

            public ILTypeInstance ILInstance { get { return instance; } }

            public override void OnInit(System.String RegisterStageName)
            {
                if (!m_OnInitGot)
                {
                    m_OnInit = instance.Type.GetMethod("OnInit", 1);
                    m_OnInitGot = true;
                }
                if (m_OnInit != null && !m_OnInitInvoking)
                {
                    m_OnInitInvoking = true;
                    param_1[0] = RegisterStageName;
                    appdomain.Invoke(m_OnInit, instance, param_1);
                    m_OnInitInvoking = false;
                }
                else
                    base.OnInit(RegisterStageName);
            }

            public override void OnEnter(System.String LastStageName)
            {
                if (!m_OnEnterGot)
                {
                    m_OnEnter = instance.Type.GetMethod("OnEnter", 1);
                    m_OnEnterGot = true;
                }
                if (m_OnEnter != null && !m_OnEnterInvoking)
                {
                    m_OnEnterInvoking = true;
                    param_1[0] = LastStageName;
                    appdomain.Invoke(m_OnEnter, instance, param_1);
                    m_OnEnterInvoking = false;
                }
                else
                    base.OnEnter(LastStageName);

                //if (mOnEnter_1.CheckShouldInvokeBase(this.instance))
                //    base.OnEnter(LastStageName);
                //else
                //    mOnEnter_1.Invoke(this.instance, LastStageName);
            }

            public override void OnExit(System.String NextStageName)
            {
                if (!m_OnExitGot)
                {
                    m_OnExit = instance.Type.GetMethod("OnExit", 1);
                    m_OnExitGot = true;
                }
                if (m_OnExit != null && !m_OnExitInvoking)
                {
                    m_OnExitInvoking = true;
                    param_1[0] = NextStageName;
                    appdomain.Invoke(m_OnExit, instance, param_1);
                    m_OnExitInvoking = false;
                }
                else
                    base.OnExit(NextStageName);
            }

            public override void OnDestroy()
            {
                if (!m_OnDestroyGot)
                {
                    m_OnDestroy = instance.Type.GetMethod("OnDestroy", 0);
                    m_OnDestroyGot = true;
                }
                if (m_OnDestroy != null && !m_OnDestroyInvoking)
                {
                    m_OnDestroyInvoking = true;
                    appdomain.Invoke(m_OnDestroy, instance);
                    m_OnDestroyInvoking = false;
                }
                else
                    base.OnDestroy();
            }

            public override string ToString()
            {
                IMethod m = appdomain.ObjectType.GetMethod("ToString", 0);
                m = instance.Type.GetVirtualMethod(m);
                if (m == null || m is ILMethod)
                {
                    return instance.ToString();
                }
                else
                    return instance.Type.FullName;
            }
        }
    }
}

