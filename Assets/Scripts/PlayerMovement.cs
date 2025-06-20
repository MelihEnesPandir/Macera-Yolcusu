using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float baseSpeed = 5f;
    public float baseHorizontalSpeed = 4f;     // Horizontal için taban hýz
    public float rightLimit = 5.5f;
    public float leftLimit = -5.5f;
    public float maxSpeed = 15f;
    public float coinSpeedMultiplier = 0.0001f;
    public float jumpForce = 6f;

    private Rigidbody rb;
    private Animator anim;
    private bool isGrounded;
    [SerializeField] AudioSource jumpFX;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    void FixedUpdate()
    {
        float playerSpeed = Mathf.Min(baseSpeed + (MasterInfo.coinCount * coinSpeedMultiplier), maxSpeed);
        // Horizontal speed, playerSpeed'e orantýlý artsýn
        float horizontalSpeed = baseHorizontalSpeed * (playerSpeed / baseSpeed);

        Vector3 move = Vector3.forward * playerSpeed;
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > leftLimit)
        {
            move += Vector3.left * horizontalSpeed;
        }
        else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && transform.position.x < rightLimit)
        {
            move += Vector3.right * horizontalSpeed;
        }
        move *= Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            anim.SetTrigger("JumpTrig");
            jumpFX.Play();
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
