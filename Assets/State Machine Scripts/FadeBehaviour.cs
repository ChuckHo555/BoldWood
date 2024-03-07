using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeBehaviour : StateMachineBehaviour
{
    public float fadeTime = 0.5f;
    private float timeElapsed = 0;
    SpriteRenderer spriteRenderer;
    GameObject gameObject;
    Color color;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeElapsed = 0;
        spriteRenderer = animator.GetComponent<SpriteRenderer>();
        gameObject = animator.gameObject;
        color = spriteRenderer.color;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeElapsed += Time.deltaTime;

        float alphaColor = color.a * (1- (timeElapsed/fadeTime));

        spriteRenderer.color = new Color(color.r, color.g, color.b, alphaColor);
        if(timeElapsed > fadeTime)
        {
            Destroy(gameObject);
        }
    }

}
