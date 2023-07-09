using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

[RequireComponent(typeof(DialogueSystemTrigger))]
public class Adventurer : MonoBehaviour
{

    public NPCGenerator spawner;

    public void OnAnimationEnd () {
        spawner.CycleNPC();
    }

    void Start () {
        NametagNameSetter nametag = GetComponentInChildren<NametagNameSetter>();
        if (nametag) nametag.SetName(gameObject.name.Replace("(Clone)", ""));
    }

}
