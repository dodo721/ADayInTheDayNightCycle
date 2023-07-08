using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{

    public SettingsObject settings;
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = settings.volume;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = settings.volume;
    }
}
