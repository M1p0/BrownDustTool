using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Proto.Design.common;
using Proto.Local;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace LobbyTableDumper
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public static ManualLogSource Log;

        private void Awake()
        {
            Log = Logger;

            // 应用Harmony补丁
            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll();

            Logger.LogInfo($"插件 {PluginInfo.PLUGIN_GUID} 已加载!");
        }
    }

    public static class PluginInfo
    {
        public const string PLUGIN_GUID = "com.yourname.lobbytabledumper";
        public const string PLUGIN_NAME = "Lobby Table Dumper";
        public const string PLUGIN_VERSION = "1.0.0";
    }
}