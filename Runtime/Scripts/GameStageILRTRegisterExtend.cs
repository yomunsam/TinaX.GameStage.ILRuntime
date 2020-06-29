using TinaX.GameStage.Internal.Adaptors;

namespace TinaX.XILRuntime.Registers
{
    public unsafe static class GameStageILRTRegisterExtend
    {
        public static IXILRuntime RegisterGameStage(this IXILRuntime xil)
        {
            //跨域继承适配器
            xil.RegisterCrossBindingAdaptor(new StageControllerBaseAdapter());

            return xil;
        }
    }
}
