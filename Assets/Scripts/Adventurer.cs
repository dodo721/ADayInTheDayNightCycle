using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

[RequireComponent(typeof(DialogueSystemTrigger))]
[RequireComponent(typeof(Usable))]
public class Adventurer : MonoBehaviour
{

    public string name;
    public string conversation;

    private DialogueSystemTrigger trigger;
    private Usable usable;

    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<DialogueSystemTrigger>();
        usable = GetComponent<Usable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetupDialogue () {
        trigger.conversation = conversation;
        usable.overrideName = name;
    }
}
