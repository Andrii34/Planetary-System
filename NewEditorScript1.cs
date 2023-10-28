using UnityEditor;
using UnityEngine;

namespace Assembly_CSharp
{
    public class NewEditorScript1 : ScriptableObject
    {
        [MenuItem("Tools/MyTool/Do It in C#")]
        static void DoIt()
        {
            EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
        }
    }
}