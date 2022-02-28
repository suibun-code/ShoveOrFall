using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 7f;
    public float forceAmount = 10f;
    public bool playerInRange = false;
    public float attackCooldown = 1.75f;
    public float cantMoveCooldown = 1.1f;
    public bool canAttack = true;
    public bool canMove = false;

    public  ParticleSystem explosion;
    public AudioSource explosionSFX;

    public GameObject player;

    void Start()
    {

    }

    void Update()
    {
        if (canMove)
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, (speed * Time.deltaTime));
        else
        {
            StartCoroutine(CantMoveCooldown());
        }

        if (playerInRange)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (!canAttack)
            return;

        Rigidbody playerRB = player.GetComponent<Rigidbody>();

        Vector3 direction = playerRB.transform.position - transform.position;
        playerRB.AddForceAtPosition(direction.normalized * forceAmount, transform.position, ForceMode.Impulse);
        player.GetComponent<PlayerMovement>().canMove = false;
        canMove = false;

        canAttack = false;
        StartCoroutine(AttackCooldown());

        explosion.Play();
        explosionSFX.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    IEnumerator CantMoveCooldown()
    {
        yield return new WaitForSeconds(cantMoveCooldown);
        canMove = true;
    }
}
