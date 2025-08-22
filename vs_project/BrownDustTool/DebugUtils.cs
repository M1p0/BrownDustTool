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
    using GlobalConfig = ὣὨὢὩὯὨὣὭὢὤὢ;

    //[HarmonyPatch(typeof(LobbySettingUI))]
    //[HarmonyPatch("OnEnable")]
    //public static class LogInteractionItemDB
    //{
    //    static void Postfix()
    //    {

    //        Plugin.Log.LogError("--------------------Start Export InteractionItemDB-------------------------");
    //        // 确保在列表已初始化后遍历
    //        if (ὤὦὠὨὧὩὥὪὡὧὢ.ὭὠὮὮὡὩὮὠὠὬὣ != null)
    //        {
    //            foreach (var item in ὤὦὠὨὧὩὥὪὡὧὢ.ὭὠὮὮὡὩὮὠὠὬὣ)
    //            {
    //                Plugin.Log.LogError($"InvenIndex:{item.InvenIndex} - ID:{item.Id}" +
    //                    $"- Type:{item.Type} - Count:{item.Count} - KeepFlag:{item.KeepFlag}" +
    //                    $"- TimeValue:{item.TimeValue} - PictorialbookInfo:{item.PictorialbookInfo}" +
    //                    $"- ExpiryTime:{item.ExpiryTime} - SortId:{item.SortId} - UseCount:{item.UseCount}");
    //            }
    //        }
    //    }
    //}

    //[HarmonyPatch(typeof(LobbySettingUI))]
    //[HarmonyPatch("SaveLobbySettingSlotDatas")]
    //public static class SaveLobbySettingSlotDatas_Patch
    //{
    //    public static bool hasRun = false;
    //    public static string outputPath = Path.Combine(Application.dataPath, "LobbySettingItemTable_Output.txt");

    //    static void Prefix(List<object> ὪὮὤὯὢὢὫὣὪὩὦ)
    //    {
    //        if (hasRun) return;
    //        hasRun = true;

    //        Plugin.Log.LogInfo("检测到SaveLobbySettingSlotDatas调用，开始导出数据...");

    //        // 在UI线程中启动协程来执行耗时操作
    //        GameObject helper = new GameObject("LobbyTableDumper");
    //        helper.AddComponent<DumperComponent>();
    //    }
    //}

    //public class DumperComponent : MonoBehaviour
    //{
    //    private void Start()
    //    {
    //        DumpLobbySettingItems();
    //    }

    //    private void DumpLobbySettingItems()
    //    {
    //        try
    //        {
    //            Plugin.Log.LogInfo("开始导出LobbySettingItemTable数据...");
    //            // 获取混淆类型
    //            Type obfuscatedType = Type.GetType("ὣὨὢὩὯὨὣὭὢὤὢ, Assembly-CSharp");
    //            if (obfuscatedType == null)
    //            {
    //                Plugin.Log.LogError("无法找到混淆类型 ὣὨὢὩὯὨὣὭὢὤὢ");
    //                return;
    //            }

    //            // 获取混淆方法
    //            MethodInfo targetMethod = obfuscatedType.GetMethod("ὭὬὬὠὨὯὢὨὭὠὨ",
    //                BindingFlags.Public | BindingFlags.Static,
    //                null,
    //                new Type[] { typeof(int) },
    //                null);

    //            if (targetMethod == null)
    //            {
    //                Plugin.Log.LogError("无法找到方法 ὭὬὬὠὨὯὢὨὭὠὨ");
    //                return;
    //            }

    //            List<string> outputLines = new List<string>();
    //            outputLines.Add("ID,InteractionID");
    //            int successCount = 0;

    //            // 循环调用6000次
    //            for (int i = 0; i < 6000; i++)
    //            {
    //                try
    //                {
    //                    // 调用混淆方法
    //                    object result = targetMethod.Invoke(null, new object[] { i });

    //                    if (result != null)
    //                    {
    //                        // 使用反射获取属性值
    //                        FieldInfo idField = result.GetType().GetField("id_",
    //                            BindingFlags.NonPublic | BindingFlags.Instance);
    //                        FieldInfo interactionIdField = result.GetType().GetField("interactionId_",
    //                            BindingFlags.NonPublic | BindingFlags.Instance);

    //                        if (idField != null && interactionIdField != null)
    //                        {
    //                            int id = (int)idField.GetValue(result);
    //                            int interactionId = (int)interactionIdField.GetValue(result);
    //                            if (interactionId > 0)
    //                            {
    //                                outputLines.Add($"{id},{interactionId}");
    //                                successCount++;
    //                            }
    //                        }
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //                    // 某些ID可能无效，跳过继续
    //                    Plugin.Log.LogWarning($"调用ID {i} 时出错: {ex.Message}");
    //                }
    //            }

    //            // 写入文件
    //            File.WriteAllLines(SaveLobbySettingSlotDatas_Patch.outputPath, outputLines.ToArray());
    //            Plugin.Log.LogInfo($"成功导出 {successCount} 条记录到 {SaveLobbySettingSlotDatas_Patch.outputPath}");
    //        }
    //        catch (Exception ex)
    //        {
    //            Plugin.Log.LogWarning(ex.Message);
    //        }
    //        finally
    //        {
    //            Destroy(gameObject); // 清理
    //        }
    //    }
    //}
}
