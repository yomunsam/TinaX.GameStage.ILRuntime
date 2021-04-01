using TinaX.GameStage.Internal.Adaptors;
using TinaX.GameStage.Internal.CLRMethodRedirections;

namespace TinaX.XILRuntime.Registers
{
    public unsafe static class GameStageILRTRegisterExtend
    {
        public static IXILRuntime RegisterGameStage(this IXILRuntime xil)
        {
            //跨域继承适配器
            xil.RegisterCrossBindingAdaptor(new StageControllerBaseAdapter());

            //CLR重定向
            RedirectGameStage.Register(xil);

            return xil;
        }
    }
}
