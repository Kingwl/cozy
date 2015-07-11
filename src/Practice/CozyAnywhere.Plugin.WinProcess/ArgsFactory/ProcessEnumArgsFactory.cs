﻿using CozyAnywhere.Plugin.WinProcess.Args;
using CozyAnywhere.Protocol;
using Newtonsoft.Json;

namespace CozyAnywhere.Plugin.WinProcess.ArgsFactory
{
    public class ProcessEnumArgsFactory : IPluginCommandMethodArgsFactory
    {
        public PluginCommandMethodArgs Create(string argsContent)
        {
            return JsonConvert.DeserializeObject<ProcessEnumArgs>(argsContent);
        }
    }
}