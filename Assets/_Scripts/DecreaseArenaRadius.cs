using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseArenaRadius : MonoBehaviour
{
    private Vector3 arenaScaleChange;
    private Material material;
    private Vector2 materialScaleChange;
    private Vector2 originalMaterialTiling;

    [SerializeField] GameObject arena;
    [SerializeField] float shrinkRate;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        originalMaterialTiling = material.mainTextureScale;
    }

    // Update is called once per frame
    void Update()
    {
        arenaScaleChange = new Vector3(shrinkRate * Time.deltaTime, 0.0f, shrinkRate * Time.deltaTime);
        arena.transform.localScale -= arenaScaleChange;

        materialScaleChange = new Vector2(originalMaterialTiling.x * transform.localScale.x, originalMaterialTiling.y * transform.localScale.z);
        material.mainTextureScale = materialScaleChange;
    }
}
