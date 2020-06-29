using System.Collections;
using System.Collections.Generic;
using TinaX.GameStage;
using TinaXEditor.XILRuntime.Generator;
using UnityEngine;
using UnityEditor;

namespace TinaXEditor.GameStage.Internal.ILRT
{
    public class DevGenCode
    {
#if TINAX_DEV


        /// <summary>
        /// 
        /// </summary>
        [MenuItem("TinaX/GameStage/Dev/生成StageControllerBase 跨域适配器")]
        static void GenStageControllerCore()
        {
            CrossBindingGenerator.Generate("Assets/StageControllerAdaptor.cs", typeof(StageControllerBase), "TinaX.GameStage.Internal.Adaptors");
        }

#endif
    }
}

