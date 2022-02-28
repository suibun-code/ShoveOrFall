using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerArenaChecker : MonoBehaviour
{
    public GameObject arenaTimeCanvas;
    public TextMeshProUGUI currentNoArenaTimeText;

    [SerializeField] float currentNoArenaTime = 3.0f;
    [SerializeField] float maxNoArenaTime = 3.0f;
    [SerializeField] bool onArena = true;

    void Update()
    {
        if (currentNoArenaTime < 2.8f)
            arenaTimeCanvas.SetActive(true);
        else
            arenaTimeCanvas.SetActive(false);

        if (!onArena)
            currentNoArenaTime -= Time.deltaTime;

        if (currentNoArenaTime < 0)
        {
            Debug.Log("currentNoArenaTime less than 0. Changing scene.");
            SceneChanger.ChangeScene("Lost");
        }

        currentNoArenaTimeText.text = currentNoArenaTime.ToString("F2");
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Arena"))
        {
            onArena = false;
        }
        else
        {
            onArena = true;
            currentNoArenaTime = maxNoArenaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Arena"))
        {
            onArena = true;
            currentNoArenaTime = maxNoArenaTime;
        }
    }
}
