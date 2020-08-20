using IPA.Loader;
using IPA.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;

namespace JustRainbowLights.Utilities
{
    public class Utils
    {
        public static IEnumerable<string> GetFileNames(string path, IEnumerable<string> filters, SearchOption searchOption, bool returnShortPath = false)
        {
            IList<string> filePaths = new List<string>();

            foreach (string filter in filters)
            {
                IEnumerable<string> directoryFiles = Directory.GetFiles(path, filter, searchOption);

                if (returnShortPath)
                {
                    foreach (string directoryFile in directoryFiles)
                    {
                        string filePath = directoryFile.Replace(path, "");
                        if (filePath.Length > 0 && filePath.StartsWith(@"\"))
                        {
                            filePath = filePath.Substring(1, filePath.Length - 1);
                        }

                        if (!string.IsNullOrWhiteSpace(filePath) && !filePaths.Contains(filePath))
                        {
                            filePaths.Add(filePath);
                        }
                    }
                }
                else
                {
                    filePaths = filePaths.Union(directoryFiles).ToList();
                }
            }

            return filePaths.Distinct();
        }

        public static byte[] LoadFromResource(string resourcePath)
        {
            return GetResource(Assembly.GetCallingAssembly(), resourcePath);
        }

        public static byte[] GetResource(Assembly assembly, string resourcePath)
        {
            Stream stream = assembly.GetManifestResourceStream(resourcePath);
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, (int)stream.Length);
            return data;
        }

        public static string GetEmbeddedResource(string resourceName, Assembly assembly)
        {
            resourceName = FormatResourceName(assembly, resourceName);
            using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    return null;
                }

                using (StreamReader reader = new StreamReader(resourceStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static Texture2D LoadTextureRaw(byte[] file)
        {
            if (file.Length > 0)
            {
                Texture2D texture = new Texture2D(2, 2);
                if (texture.LoadImage(file))
                {
                    return texture;
                }
            }

            return null;
        }

        public static Texture2D LoadIcon(string file)
        {
            Texture2D texture = null;
            byte[] resource = LoadFromResource($"JustRainbowLights.Img.{file}");
            texture = LoadTextureRaw(resource);

            return texture;
        }

        public static string SafeUnescape(string text)
        {
            string unescapedString;

            try
            {
                if (string.IsNullOrWhiteSpace(text))
                {
                    unescapedString = string.Empty;
                }
                else
                {
                    // Unescape just some of the basic formatting characters
                    unescapedString = text;
                    unescapedString = unescapedString.Replace("\\n", "\n");
                    unescapedString = unescapedString.Replace("\\t", "\t");
                }
            }
            catch
            {
                unescapedString = text;
            }

            return unescapedString;
        }

        public static bool IsPluginEnabled(string pluginName)
        {
            if (IsPluginPresent(pluginName))
            {
                PluginMetadata metadata = PluginManager.GetPluginFromId(pluginName);
                if (metadata != null)
                {
                    return PluginManager.IsEnabled(metadata);
                }
            }

            return false;
        }

        public static bool IsPluginPresent(string pluginName)
        {
            // Check in BSIPA
            if (PluginManager.GetPlugin(pluginName) != null ||
                PluginManager.GetPluginFromId(pluginName) != null)
            {
                return true;
            }

#pragma warning disable CS0618 // IPA is obsolete
            // Check in old IPA
            foreach (IPlugin plugin in PluginManager.Plugins)
            {
                if (plugin.Name == pluginName)
                {
                    return true;
                }
            }
#pragma warning restore CS0618 // IPA is obsolete

            return false;
        }

        private static string FormatResourceName(Assembly assembly, string resourceName)
        {
            return string.Format($"{assembly.GetName().Name}.{resourceName.Replace(" ", "_").Replace("\\", ".").Replace("/", ".")}");
        }
    }
}
