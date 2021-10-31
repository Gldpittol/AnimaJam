using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationState
{
    Idle,
    Run,
    Jump,
    Fall
}

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation Instance;
    public AnimationState animationState;
    private Player myPlayer;
    [SerializeField] private Animator animator;
    private void Awake()
    {
        Instance = this;
        myPlayer = GetComponent<Player>();
    }

    private void Update()
    {
        if(GameController.Instance.gameState == GameState.Gameplay)
        ChangeState();
    }

    public void ChangeState()
    {
        if (!myPlayer.IsGrounded) return;
        
        switch (animationState)
        {
            case AnimationState.Idle:
                if (Input.GetAxisRaw("Horizontal") != 0)
                {
                    animationState = AnimationState.Run;
                    animator.Play("PlayerRun");
                }
                break;
            case AnimationState.Run:
                if (Input.GetAxisRaw("Horizontal") == 0)
                {
                    animationState = AnimationState.Idle;
                    animator.Play("PlayerIdle");
                }
                break;
            case AnimationState.Jump:
                if (Input.GetAxisRaw("Horizontal") == 0)
                {
                    animationState = AnimationState.Run;
                    animator.Play("PlayerRun");
                }
                else
                {
                    animationState = AnimationState.Idle;
                    animator.Play("PlayerIdle");
                }
                break;
        }
    }

    public void InitiateJump(bool isJumping)
    {
        if (!isJumping && animationState == AnimationState.Jump) return;
        
        if (isJumping)
        {
            animationState = AnimationState.Jump;
            animator.Play("PlayerJump");
        }
        else
        {
            animationState = AnimationState.Jump;
            animator.Play("PlayerFall");
        }
    }

    public void DeathAnimation()
    {
        animator.Play("PlayerDeath");
    }
}
