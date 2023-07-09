using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Sky : MonoBehaviour
{

    public NPCGenerator controller;
    private MeshRenderer renderer;
    private Material mat;
    public Gradient fogColor;

    public float speedIdle;
    public float speedLerping;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        mat = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        float progress = controller.progress;
        mat.SetFloat("_Progress", progress);
        mat.SetFloat("_SpeedMultiplier", controller.lerping ? speedLerping : speedIdle);
        RenderSettings.fogColor = fogColor.Evaluate(progress);
    }
}
