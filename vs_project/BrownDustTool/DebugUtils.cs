using HarmonyLib;
using LobbyTableDumper;
using Proto.Design.common;
using Proto.Local;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace BrownDustTool
{
    using GlobalConfig = ὯὥὠὥὤὧὮὤὭὭὥ;

    //[HarmonyPatch(typeof(LobbySettingUI))]
    //[HarmonyPatch("OnEnable")]
    //public static class LogInteractionItemDB
    //{
    //    static void Postfix()
    //    {
    //        //LobbySettingUI可以找到GlobalConfig的名字
    //        //GlobalConfig这三个表里面的其中一个
    //        //private static Dictionary<int, ItemDBInfo> ὨὬὥὭὩὥὣὦὩὠὦ = new Dictionary<int, ItemDBInfo>(); 在globaltable下

    //        Plugin.Log.LogError("--------------------Start Export InteractionItemDB-------------------------");
    //        // 确保在列表已初始化后遍历
    //        if (GlobalConfig.ὮὮὡὤὪὫὦὠὠὩὩ != null)
    //        {
    //            foreach (var item in GlobalConfig.ὮὮὡὤὪὫὦὠὠὩὩ)
    //            {
    //                Plugin.Log.LogError($"InvenIndex:{item.InvenIndex} - ID:{item.Id}" +
    //                    $"- Type:{item.Type} - Count:{item.Count} - KeepFlag:{item.KeepFlag}" +
    //                    $"- TimeValue:{item.TimeValue} - PictorialbookInfo:{item.PictorialbookInfo}" +
    //                    $"- ExpiryTime:{item.ExpiryTime} - SortId:{item.SortId} - UseCount:{item.UseCount}");
    //            }
    //        }
    //    }
    //}
}
