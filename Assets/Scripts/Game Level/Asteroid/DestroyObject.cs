using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script only exists to destroy the asteroid after  the end of its animation.

public class DestroyObject : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject, stateInfo.length/2);
    }
}
