using HarmonyLib;
using LobbyTableDumper;
using Mosframe;
using Proto.Net;
using System;
using System.Collections.Generic;
using System.Text;
using static UnityEngine.ScriptingUtility;

namespace BrownDustTool
{
    //[HarmonyPatch(typeof(UnityEngine.Application), "version", MethodType.Getter)]
    //class ForceChangeVersion
    //{
    //    static bool Prefix(ref string __result)
    //    {
    //        // 修改版本号为2.4.0
    //        __result = "2.4.0";

    //        // 返回false表示跳过原始方法调用
    //        return false;
    //    }
    //}
}
