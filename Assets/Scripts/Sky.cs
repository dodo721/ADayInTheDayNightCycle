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

    private float offset = 0;
    private float lastProgress = 0;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        mat = renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += speedIdle * Time.deltaTime;
        float progress = controller.progress;
        offset += progress - lastProgress;
        lastProgress = progress;
        mat.SetFloat("_Progress", progress);
        mat.SetFloat("_Scroll", offset);
        RenderSettings.fogColor = fogColor.Evaluate(progress);
    }
}
