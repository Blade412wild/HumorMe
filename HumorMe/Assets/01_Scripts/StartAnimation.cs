using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public enum AnimationState { Sit, Talk }
    public AnimationState state;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("");
        SetupAnimation();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetupAnimation()
    {
        if (state == AnimationState.Sit)
        {
            animator.SetBool("IsSitting", true);
        }
        else
        {
            animator.SetBool("IsTalking", true);
        }
    }
}
