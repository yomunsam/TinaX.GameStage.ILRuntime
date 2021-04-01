using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.Utils;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.Runtime.Stack;

namespace TinaX.GameStage.Internal.CLRMethodRedirections
{
    public unsafe static partial class RedirectGameStage
    {
        private static void Register_IGameStage()
        {
            GetMappingOrCreate(typeof(TinaX.GameStage.IGameStage), out var mapping);

            mapping.Register("Register", 0, 2, Register_Name_Controller);  
            mapping.Register("Register", 0, 4, Register_Name_Controller_DI_Init);  
        }

        //void Register(string stageName, StageControllerBase controller)
        static StackObject* Register_Name_Controller(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 3);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            TinaX.GameStage.StageControllerBase @stageControllerBase = (TinaX.GameStage.StageControllerBase)typeof(TinaX.GameStage.StageControllerBase).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.String @stageName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            TinaX.GameStage.IGameStage instance_of_this_method = (TinaX.GameStage.IGameStage)typeof(TinaX.GameStage.IGameStage).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            //添加依赖注入流程
            m_XIL.InjectObject(@stageControllerBase);

            instance_of_this_method.Register(@stageName, @stageControllerBase);

            return __ret;
        }

        //void Register(string stageName, StageControllerBase stageController, bool DI = true, bool initialStage = false);
        static StackObject* Register_Name_Controller_DI_Init(ILIntepreter __intp, StackObject* __esp, IList<object> __mStack, CLRMethod __method, bool isNewObj)
        {
            ILRuntime.Runtime.Enviorment.AppDomain __domain = __intp.AppDomain;
            StackObject* ptr_of_this_method;
            StackObject* __ret = ILIntepreter.Minus(__esp, 5);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 1);
            System.Boolean @initialStage = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 2);
            System.Boolean @DI = ptr_of_this_method->Value == 1;

            ptr_of_this_method = ILIntepreter.Minus(__esp, 3);
            TinaX.GameStage.StageControllerBase @stageController = (TinaX.GameStage.StageControllerBase)typeof(TinaX.GameStage.StageControllerBase).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 4);
            System.String @stageName = (System.String)typeof(System.String).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            ptr_of_this_method = ILIntepreter.Minus(__esp, 5);
            TinaX.GameStage.IGameStage instance_of_this_method = (TinaX.GameStage.IGameStage)typeof(TinaX.GameStage.IGameStage).CheckCLRTypes(StackObject.ToObject(ptr_of_this_method, __domain, __mStack));
            __intp.Free(ptr_of_this_method);

            //添加依赖注入流程
            if (@DI)
            {
                m_XIL.InjectObject(@stageController);
                @DI = false;
            }
            instance_of_this_method.Register(@stageName, @stageController, @DI, @initialStage);

            return __ret;
        }
    }
}
