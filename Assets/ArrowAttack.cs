using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAttack : StateMachineBehaviour
{
    MonsterCtrl Arrow;
    bool Set;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Arrow = animator.gameObject.GetComponent<MonsterCtrl>();
        Arrow.SetStopMon(true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float Time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime - Mathf.Floor(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
        if (!Set)
        {
            if (Time >= 52.5f / 100)
            {
                var bullet = ObjectPolling.GetObject("Arrow");
                bullet.transform.position = Arrow.transform.GetChild(1).transform.position;
                bullet.transform.rotation = Arrow.transform.rotation;
                bullet.Set(bullet, Vector3.forward, "Arrow");
                Set = true;
            }
        }
        else if (Set)
        {
            if (Time < (40.0f / 100))
                Set = false;
        }



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Arrow.SetStopMon(false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
