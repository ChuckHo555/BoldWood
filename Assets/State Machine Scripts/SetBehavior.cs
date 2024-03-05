using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetBehavior : StateMachineBehaviour
{
    public string boolValue;
    public bool updateSM, updateS, valueOnEnter, valueOnExit;
    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateS)
        {
            animator.SetBool(boolValue, valueOnEnter);
        }
    }

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (updateS)
        {

            animator.SetBool(boolValue, valueOnExit);
        }
    }

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    {
        if (updateSM)
        {
            animator.SetBool(boolValue, valueOnEnter);
        }
}

// OnStateMachineExit is called when exiting a state machine via its Exit Node
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
{
    if (updateSM) {

        animator.SetBool(boolValue, valueOnExit);
    }
}
}