using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NametagNameSetter : MonoBehaviour
{
    public Text nameText;
    
    public void SetName (string name) {
        nameText.text = name;
    }

    void Update () {
        Camera camera = Camera.main;
        transform.LookAt(camera.transform, Vector3.up);
    }
}
