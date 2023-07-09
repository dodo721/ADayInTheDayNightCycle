using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{

    public NPCGenerator controller;

    public Transform dawn;
    public Transform noon;
    public Transform dusk;

    public AnimationCurve brightness;
    private Light mlight;

    // Start is called before the first frame update
    void Start()
    {
        mlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion lerpRotation;
        float progress = controller.progress;
        if (progress <= 0.5f) {
            float time = progress * 2f;
            lerpRotation = Quaternion.Lerp(dawn.rotation, noon.rotation, time);
        } else {
            float time = (progress * 2f) - 1f;
            lerpRotation = Quaternion.Lerp(noon.rotation, dusk.rotation, time);
        }
        mlight.intensity = brightness.Evaluate(progress);
        transform.rotation = lerpRotation;
    }
}
