using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance;
    
    [SerializeField] private bool isDoubleJumpEnabled;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 jumpForce;
    [SerializeField] private KeyCode jumpKey;

    private Rigidbody2D rb;
    private bool canDoubleJump = true;
    private bool isGrounded = true;
    
    public bool IsGrounded => isGrounded;
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();

        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            CheckJump();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Deadly"))
        {
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
    }

    public void CheckJump()
    {
        if (!isGrounded && !canDoubleJump) return;
        if (!isGrounded && !isDoubleJumpEnabled) return;

        if (isGrounded) isGrounded = false;
        else canDoubleJump = false;

        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(jumpForce, ForceMode2D.Impulse);
    }

    public void ResetGrounding()
    {
        isGrounded = true;
        canDoubleJump = true;
    }

    public void DisableGrounding()
    {
        isGrounded = false;
    }
}
