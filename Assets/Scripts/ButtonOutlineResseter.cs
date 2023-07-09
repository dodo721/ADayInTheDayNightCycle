using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Outline))]
public class ButtonOutlineResseter : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Outline outline = GetComponent<Outline>();
        outline.enabled = false;
    }
}
