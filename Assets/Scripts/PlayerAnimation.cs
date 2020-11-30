using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator playerAnimator;

    private bool m_IsJumping;
    public bool IsJumping
    {
        get { return m_IsJumping; }
        set 
        {
            if (value == m_IsJumping)
                return;

            m_IsJumping = value;
            playerAnimator.SetBool("IsJumping", m_IsJumping);

            if (m_IsJumping)
                StartCoroutine(Jumping());
        }
    }

    private bool m_IsRunning;
    public bool IsRunning
    {
        get { return m_IsRunning; }
        set
        {
            if (value == m_IsRunning)
                return;

            m_IsRunning = value;
            playerAnimator.SetBool("IsRunning", m_IsRunning);
        }
    }

    private const string ANIMATION_IDLE_NAME = "Idle01";
    private const string ANIMATION_JUMP_NAME = "Jump";
    private const string ANIMATION_RUN_NAME = "Run";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsRunning && !IsJumping)
            playerAnimator.Play(ANIMATION_IDLE_NAME);
        else if (IsRunning && !IsJumping)
            playerAnimator.Play(ANIMATION_RUN_NAME);
    }

    private IEnumerator Jumping()
    {
        playerAnimator.Play(ANIMATION_JUMP_NAME);
        yield return new WaitForSeconds(1.1f);
        IsJumping = false;
    }
}
