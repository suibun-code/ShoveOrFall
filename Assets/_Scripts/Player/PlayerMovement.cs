using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;

    public bool canMove = true;
    public float cantMoveCooldown = 0.7f;

    [SerializeField] float speed = 10f;

    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool ableToJump = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (!canMove)
        {
            StartCoroutine(CantMoveCooldown());
            return;
        }

        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;

        Vector3 movementDirection = moveDirection * (speed * Time.deltaTime);
        transform.position += movementDirection;
    }

    public void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (ableToJump)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
            ableToJump = false;
            StartCoroutine(JumpCooldown());
        }
    }

    IEnumerator JumpCooldown()
    {
        yield return new WaitForSeconds(1.5f);

        ableToJump = true;
    }

    IEnumerator CantMoveCooldown()
    {
        yield return new WaitForSeconds(cantMoveCooldown);
        canMove = true;
    }
}
