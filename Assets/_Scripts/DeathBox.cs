using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision!" + other.gameObject.name);

        if (!other.gameObject.CompareTag("Player")) 
            return;

        SceneChanger.ChangeScene("MainMenu");
    }
}
