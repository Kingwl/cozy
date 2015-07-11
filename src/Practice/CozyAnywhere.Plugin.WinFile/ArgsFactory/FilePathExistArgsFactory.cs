﻿using CozyAnywhere.Plugin.WinFile.Args;
using CozyAnywhere.Protocol;
using Newtonsoft.Json;

namespace CozyAnywhere.Plugin.WinFile.ArgsFactory
{
    public class FilePathExistArgsFactory : IPluginCommandMethodArgsFactory
    {
        public PluginCommandMethodArgs Create(string argsContent)
        {
            return JsonConvert.DeserializeObject<FilePathExistArgs>(argsContent);
        }
    }
}