using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceberg : MonoBehaviour
{
    public GameObject iceberg;
    public float speed;
    public float length;
    public float minHeight;
    public float maxHeight;

    void Start()
    {
    }

    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, length) * maxHeight - minHeight;
        iceberg.transform.position = new Vector3(0, y, 0);
    }
}
