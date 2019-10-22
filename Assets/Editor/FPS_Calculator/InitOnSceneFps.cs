using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

class InitOnSceneFps : EditorWindow
{
    private static GameObject clone = null;
    [MenuItem("GameObject/FPS/FPSView", false, 10)]
    static void CreateFPS()
    {
        try
        {
            Debug.Log(clone.name);
        }
        catch (Exception)
        {
            Object prefab =
            AssetDatabase.LoadAssetAtPath("Assets/FPS_Calculator/Prefabs/FPSCalcCanvas.prefab", typeof(GameObject));
            clone = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
            clone.transform.position = Vector3.one;
            clone.name = "FPS_Calculator_Canvas";
            Selection.activeObject = clone;
        }
    }
}
