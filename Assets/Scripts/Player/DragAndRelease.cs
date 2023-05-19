using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndRelease : MonoBehaviour{
    public LineRenderer LineRenderer;
    public Rigidbody2D Rigidbody2D;

    public Material material;
    public float startWidth;
    public float endWidth;
    public Color startColor = Color.green;
    public Color endColor = Color.red;

    void Start(){
        LineRenderer.enabled = false;
        LineRenderer.positionCount = 2;
        LineRenderer.material = material;
        LineRenderer.startWidth = startWidth;
        LineRenderer.endWidth = endWidth;
        LineRenderer.startColor = startColor;
        LineRenderer.endColor = endColor;
    }

    void Update(){
    }

    
}
