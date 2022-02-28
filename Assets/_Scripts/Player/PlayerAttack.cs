using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public Image swordImage;

    BoxCollider boxCollider;
    public float forceAmount = 20f;
    public List<GameObject> collidedGameObjects;
    public float attackCooldown = 1.75f;
    public bool canAttack = true;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    public void OnAttack(InputValue value)
    {
        if (!canAttack)
            return;

        foreach (var gb in collidedGameObjects)
        {
            Rigidbody enemyRB = gb.GetComponent<Rigidbody>();

            Vector3 direction = enemyRB.transform.position - transform.position;
            enemyRB.AddForceAtPosition(direction.normalized * forceAmount, transform.position, ForceMode.Impulse);

            canAttack = false;
            swordImage.color = Color.red;
            StartCoroutine(AttackCooldown());
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

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);

        canAttack = true;
        swordImage.color = Color.green;
    }
}
