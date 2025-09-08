using gamfs;
using gamfs.Profile;
using HarmonyLib;
using Proto.Net;
using SRDebugger.Services;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using static UnityEngine.UIElements.UIR.Allocator2D;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.UIElements;
using UnityEngine.XR;

namespace BrownDustTool
{

    //[HarmonyPatch(typeof(ὭὦὪὠὨὮὠὬὦὤὠ))]
    //[HarmonyPatch("ὧὩὧὥὥὨὮὡὮὡὭ")]
    public static class UnLockGmPanel
    {
        //[HarmonyPostfix]
        //public static void Postfix(ref Proto.Net.Define_AccessUserType __0)
        //{
        //    //入参读取规则 https://harmony.pardeike.net/articles/patching-injections.html#method-arguments
        //    if (__0 == Define_AccessUserType.AuNormal)
        //    {
        //        SRDebug.Init();
        //        IDebugService instance = SRDebug.Instance;
        //        if (instance != null)
        //        {
        //            instance.RemoveOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<UtilitiesOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance2 = SRDebug.Instance;
        //        if (instance2 != null)
        //        {
        //            instance2.AddOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<UtilitiesOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance3 = SRDebug.Instance;
        //        if (instance3 != null)
        //        {
        //            instance3.RemoveOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<CheatOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance4 = SRDebug.Instance;
        //        if (instance4 != null)
        //        {
        //            instance4.AddOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<CheatOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance5 = SRDebug.Instance;
        //        if (instance5 != null)
        //        {
        //            instance5.RemoveOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<MiniGameOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance6 = SRDebug.Instance;
        //        if (instance6 != null)
        //        {
        //            instance6.AddOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<MiniGameOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance7 = SRDebug.Instance;
        //        if (instance7 != null)
        //        {
        //            instance7.RemoveOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<CafeteriaOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance8 = SRDebug.Instance;
        //        if (instance8 != null)
        //        {
        //            instance8.AddOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<CafeteriaOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance9 = SRDebug.Instance;
        //        if (instance9 != null)
        //        {
        //            instance9.RemoveOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<MapToolOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance10 = SRDebug.Instance;
        //        if (instance10 != null)
        //        {
        //            instance10.AddOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<MapToolOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance11 = SRDebug.Instance;
        //        if (instance11 != null)
        //        {
        //            instance11.RemoveOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<TimelineToolOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance12 = SRDebug.Instance;
        //        if (instance12 != null)
        //        {
        //            instance12.AddOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<TimelineToolOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance13 = SRDebug.Instance;
        //        if (instance13 != null)
        //        {
        //            instance13.RemoveOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<ResourceOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance14 = SRDebug.Instance;
        //        if (instance14 != null)
        //        {
        //            instance14.AddOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<ResourceOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance15 = SRDebug.Instance;
        //        if (instance15 != null)
        //        {
        //            instance15.RemoveOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<LQAOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        IDebugService instance16 = SRDebug.Instance;
        //        if (instance16 != null)
        //        {
        //            instance16.AddOptionContainer(ὬὭὠὪὬὦὭὥὨὠὭ<LQAOptions>.ὤὪὪὮὧὫὯὭὥὡὯ);
        //        }
        //        Singleton<FPS_Check>.ὧὬὤὯὯὫὩὪὦὤὤ.StartFPS();
        //        ὯὯὫὯὠὠὧὫὭὥὯ.ὪὡὯὧὬὨὬὦὠὣὯ = true;  //这里不知道该不该改 貌似是gm的flag
        //        return;
        //    }
        //}
    }
}
