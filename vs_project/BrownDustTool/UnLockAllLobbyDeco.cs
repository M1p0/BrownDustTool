using HarmonyLib;
using LobbyTableDumper;
using Mosframe;
using Proto.Design.common;
using Proto.Net;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;
using static UnityEngine.ScriptingUtility;
using static UnityEngine.UIElements.StylePropertyAnimationSystem;

namespace BrownDustTool
{
    using LocalDBInfoCache = ὯὥὠὥὤὧὮὤὭὭὥ;
    using GlobalConfig = ὬὠὥὬὡὫὬὫὨὡὢ;

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
        public static List<int> interactionIdList;

        static void Prefix()
        {
            //private static Dictionary<ὦὡὪὢὦὥὣὨὠὢὫ, Dictionary<long, ItemDBInfo>> ὦὣὬὤὠὬὪὢὤὯὫ = new Dictionary<ὦὡὪὢὦὥὣὨὠὢὫ, Dictionary<long, ItemDBInfo>>();
            //private static Dictionary<ὦὡὪὢὦὥὣὨὠὢὫ, Dictionary<long, ItemDBInfo>> ὣὤὧὮὤὡὠὧὭὧὩ = new Dictionary<ὦὡὪὢὦὥὣὨὠὢὫ, Dictionary<long, ItemDBInfo>>();
            //private static Dictionary<ὦὡὪὢὦὥὣὨὠὢὫ, Dictionary<long, ItemDBInfo>> ὨὡὣὯὦὩὪὦὫὯὥ = new Dictionary<ὦὡὪὢὦὥὣὨὠὢὫ, Dictionary<long, ItemDBInfo>>();
            //private static Dictionary<int, ItemDBInfo> ὨὬὥὭὩὥὣὦὩὠὦ = new Dictionary<int, ItemDBInfo>(); 在globaltable里面找这个的引用 两个list的其中一个
            //这里存储的是已拥有的



            //Plugin.Log.LogError("--------------------Start Export InteractionItemDB Real-------------------------");
            //// 确保在列表已初始化后遍历
            //try
            //{
            //    foreach (var item in LocalDBInfoCache.ὧὢὯὪὥὠὢὡὨὬὦ)
            //    {
            //        Plugin.Log.LogError($"InvenIndex:{item.InvenIndex} - ID:{item.Id}" +
            //            $"- Type:{item.Type} - Count:{item.Count} - KeepFlag:{item.KeepFlag}" +
            //            $"- TimeValue:{item.TimeValue} - PictorialbookInfo:{item.PictorialbookInfo}" +
            //            $"- ExpiryTime:{item.ExpiryTime} - SortId:{item.SortId} - UseCount:{item.UseCount}");
            //    }
            //}
            //catch (Exception e)
            //{
            //}

            DumpLobbySettingItems();


            Plugin.Log.LogError($"[AddAllLobbyDeco] StartingAddItem");
            try
            {
                // 使用 AccessTools 获取字典字段
                var dictionaryField = AccessTools.Field(typeof(LocalDBInfoCache), "ὨὬὥὭὩὥὣὦὩὠὦ");
                var dictionary = dictionaryField?.GetValue(null) as Dictionary<int, ItemDBInfo>;

                if (dictionary != null)
                {
                    for (int i = 0; i < interactionIdList.Count; i++)
                    {
                        int nItemId = interactionIdList[i];
                        ItemDBInfo item = new ItemDBInfo();
                        item.Id = nItemId;
                        item.Type = (int)ὦὡὪὢὦὥὣὨὠὢὫ.LobbyDeco;  //todo:check一下类型
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


        static void DumpLobbySettingItems()
        {
            //"LobbySettingUI_CUTSCENE";
            //"LobbySettingUI_COSTUME_TEXT";
            //"LobbySettingUI_PLAY_LIST";
            //"LobbySettingUI_PLAY_METHOD";
            //"LobbySettingUI_AutoPlay";
            //"LobbySettingUI_RandomIncludeStory";
            //"LobbySettingUI_RandomIncludeSkill";
            //"LobbySettingUI_RandomIncludeIllust";
            //"LobbySettingUI_RandomIncludeDatingSpine";
            //public static LobbySettingItemTable ὪὫὦὭὧὯὮὩὪὫὪ(int ὣὠὪὦὤὥὭὪὤὥὯ)  通过上面的字符串找到这个全局配置表  LobbySettingItemTable GetItem(nItemId)

            if (interactionIdList != null && interactionIdList.Count > 0)
                return;
            interactionIdList = new List<int>();
            try
            {
                Type type = AccessTools.TypeByName("ὬὠὥὬὡὫὬὫὨὡὢ");
                if (type == null)
                {
                    Plugin.Log.LogError("[AddAllLobbyDeco] Type not found!");
                    return;
                }

                MethodInfo method = AccessTools.Method(type, "ὪὫὦὭὧὯὮὩὪὫὪ", new Type[] { typeof(int) });
                if (method == null)
                {
                    Plugin.Log.LogError("[AddAllLobbyDeco] Method not found!");
                    return;
                }

                // 获取LobbySettingItemTable类型，假设我们知道完整类型名
                Type resultType = AccessTools.TypeByName("Proto.Design.common.LobbySettingItemTable");
                if (resultType == null)
                {
                    Plugin.Log.LogError("[AddAllLobbyDeco] LobbySettingItemTable type not found!");
                    return;
                }

                // 循环调用6000次
                for (int i = 1; i < 6000; i++)
                {
                    try
                    {
                        int nItemId = i; // 替换为实际的itemId
                        object result = method.Invoke(null, new object[] { nItemId });
                        if (result == null)
                        {
                            continue;
                        }

                        // 如果类型匹配，我们可以转换或使用反射访问属性
                        if (resultType.IsInstanceOfType(result))
                        {
                            // 使用反射获取属性示例
                            PropertyInfo property = null;
                            object objValue = null;
                            int nId = 0;
                            int nInteractionId = 0;

                            property = AccessTools.Property(resultType, "Id");
                            if (property != null)
                            {
                                objValue = property.GetValue(result);
                                nId = Convert.ToInt32(objValue);
                            }
                            if (nId != nItemId)
                            {
                                Plugin.Log.LogError($"[AddAllLobbyDeco] GetItemFailed Id not same {nId}, {nItemId}");
                                continue;
                            }

                            property = AccessTools.Property(resultType, "InteractionId");
                            if (property != null)
                            {
                                objValue = property.GetValue(result);
                                nInteractionId = Convert.ToInt32(objValue);
                            }
                            if (nInteractionId > 0)
                            {
                                interactionIdList.Add(nId);
                                //Plugin.Log.LogError($"[AddAllLobbyDeco] AddItemSuccess: ItemId:{nId}, nInteractionId:{nInteractionId}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }
    }

}
