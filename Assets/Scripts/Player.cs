using System;
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

    public AudioClip jumpClip;
    public AudioClip gameOverClip;

    public bool IsGrounded => isGrounded;
    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameController.Instance.gameState != GameState.Gameplay) return;
        
        if (Input.GetKeyDown(jumpKey))
        {
            CheckJump();
        }
    }

    private void FixedUpdate()
    {
        if (GameController.Instance.gameState != GameState.Gameplay) return;

        Move();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (GameController.Instance.gameState != GameState.Gameplay) return;

        if (other.CompareTag("Deadly"))
        {
            Die();
        }
    }

    public void Die()
    {
        GameController.Instance.gameState = GameState.Cutscene;
        rb.velocity = Vector2.zero;
        StopAllCoroutines();
        StartCoroutine(DieCoroutine());
    }

    public IEnumerator DieCoroutine()
    {
        AudioManager.Instance.PlayClip(gameOverClip);

        GetComponent<PlayerAnimation>().DeathAnimation();
        yield return new WaitForSeconds(1f);
        GameObject temp = Instantiate(GameController.Instance.TransitionIn, Vector3.zero, Quaternion.identity);
        yield return new WaitForSeconds(temp.GetComponent<Transition>().transitionDuration + 0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        
        if (horizontal == -1) transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontal == 1) transform.localScale = new Vector3(1, 1, 1);
        
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
        PlayerAnimation.Instance.InitiateJump(true);
        AudioManager.Instance.PlayClip(jumpClip);
    }

    public void ResetGrounding()
    {
        isGrounded = true;
        canDoubleJump = true;
    }

    public void DisableGrounding()
    {
        PlayerAnimation.Instance.InitiateJump(false);
        isGrounded = false;
    }
}
