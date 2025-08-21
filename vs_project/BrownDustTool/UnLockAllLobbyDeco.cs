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

    [HarmonyPatch(typeof(Proto.Design.common.SpineInteractionTable), "IsIgnoreUnlockDating", MethodType.Getter)]
    public static class SpineInteractionTablePatch
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result)
        {
            __result = true;
            return false; // 跳过原始方法
        }
    }


    [HarmonyPatch(typeof(MenuUI))]
    [HarmonyPatch("OnEnable")]
    public static class AddAllLobbyDeco
    {
        static void Prefix()
        {
            Plugin.Log.LogError($"[AddAllLobbyDeco] StartingAddItem");
            int[] ItemIdArray = { 32, 36, 50, 53, 59, 73, 77, 94, 99 };
            try
            {
                // 使用 AccessTools 获取字典字段
                var dictionaryField = AccessTools.Field(typeof(ὤὦὠὨὧὩὥὪὡὧὢ), "ὥὩὮὬὢὯὢὬὢὧὦ");
                var dictionary = dictionaryField?.GetValue(null) as Dictionary<int, ItemDBInfo>;

                if (dictionary != null)
                {
                    for (int i = 0; i < ItemIdArray.Length; i++)
                    {
                        int nItemId = ItemIdArray[i];
                        ItemDBInfo item = new ItemDBInfo();
                        item.Id = nItemId;
                        item.Type = (int)ὦὧὭὯὩὮὧὧὢὩὢ.LobbyDeco;  //todo:check一下类型
                        item.Count = 1;
                        item.KeepFlag = 0;
                        item.TimeValue = 1755416694000;  //这个时间戳有待商榷 不知道实际用处
                        item.ExpiryTime = 0;
                        item.SortId = 0;
                        item.UseCount = 0;
                        //item.PictorialbookInfo = "";
                        try
                        {
                            dictionary[item.Id] = item;
                            Plugin.Log.LogError($"[AddAllLobbyDeco] AddItemSuccess:{item.Id}");
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                }
                else
                {
                    Plugin.Log.LogError("[AddAllLobbyDeco] Cant Get Dict");
                }
            }
            catch (Exception ex)
            {
                Plugin.Log.LogError($"[AddAllLobbyDeco] {ex}");
            }

        }
    }
}
