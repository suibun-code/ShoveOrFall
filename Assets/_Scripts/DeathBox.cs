using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!" + other.gameObject.name);

        if (other.gameObject.CompareTag("Player"))
            SceneChanger.ChangeScene("Lost");
        else if (other.gameObject.CompareTag("Enemy"))
            SceneChanger.ChangeScene("Win");
    }
}
