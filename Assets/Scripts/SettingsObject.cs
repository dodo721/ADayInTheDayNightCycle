using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SettingsObject : ScriptableObject
{
    [Range(0f, 1f)]
    public float volume;
    
#if UNITY_EDITOR
    [MenuItem("Custom/Create Game Settings")]
    static void MenuCallback()
    {
        ScriptableObject obj = ScriptableObject.CreateInstance<SettingsObject>();
        AssetDatabase.CreateAsset(obj, "Assets/GameSettings.asset");
    }
#endif

    public void ChangeVolume (float volume) {
        this.volume = volume;
    }

}
