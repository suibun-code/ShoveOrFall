using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class CanvasSwapper : MonoBehaviour
{
    Canvas currentCanvas;

    void Start()
    {
        currentCanvas = GetComponent<Canvas>();
    }

    public void Switch(Canvas switchTo)
    {
        currentCanvas.enabled = false;
        switchTo.enabled = true;
    }
}
