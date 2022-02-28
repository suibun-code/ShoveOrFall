using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    BoxCollider boxCollider;

    public float forceAmount = 20f;

    public List<GameObject> collidedGameObjects;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public void OnAttack(InputValue value)
    {
        foreach (var gb in collidedGameObjects)
        {
            Rigidbody enemyRB = gb.GetComponent<Rigidbody>();

            Vector3 direction = enemyRB.transform.position - transform.position;
            enemyRB.AddForceAtPosition(direction.normalized * forceAmount, transform.position, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            collidedGameObjects.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collidedGameObjects.Remove(other.gameObject);
    }
}
