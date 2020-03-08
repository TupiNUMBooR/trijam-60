using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class Builder
    {
        public static void BuildDefault()
        {
            Build("Windows64", BuildTarget.StandaloneWindows64, false);
            Build("Linux64", BuildTarget.StandaloneLinux64, false);
            Build("WebGL", BuildTarget.WebGL, false);
        }
        
        public static void BuildPC()
        {
            Build("Windows64", BuildTarget.StandaloneWindows64, false);
            Build("Linux64", BuildTarget.StandaloneLinux64, false);
        }

        static void Build(string platform, BuildTarget bt, bool dev)
        {
            var l = (from scene in EditorBuildSettings.scenes where scene.enabled select scene.path).ToArray();
            BuildPipeline.BuildPlayer(l, Path(dev ? "Dev" : "", platform), bt, dev ? BuildOptions.Development : BuildOptions.None);
        }

        static string Path(string type, string platform)
        {
            return $"Builds/Basic{type}/{platform}/{Application.productName}/{Application.productName}";
        }
    }
}