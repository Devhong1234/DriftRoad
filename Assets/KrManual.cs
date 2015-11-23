using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
public class KrManual
{
    [MenuItem("Help/Unity Manual(Kr) %F1", false, 10)]
    public static void OpenKrManual()
    {
        Help.BrowseURL("http://docs.unity3d.com/kr/current/Manual/UnityManualRestructured.html");
    }

    [MenuItem("Help/Scripting Reference(Kr) %F2", false, 11)]
    public static void OpenKrReference()
    {
        Help.BrowseURL("http://docs.unity3d.com/kr/current/ScriptReference/index.html");
    }
}
#endif
