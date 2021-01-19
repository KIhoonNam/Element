using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniAttack : StateMachineBehaviour
{
    MonsterCtrl Attack;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Attack = animator.gameObject.GetComponent<MonsterCtrl>();
        Attack.SetStopMon(true);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        float Time = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        if (Attack.name == "OrcTanker(Clone)")
        {
            if (Time - Mathf.Floor(Time) >= 63.4f / 100)
            {
                if (Attack.AttackGet1())
                {
                    Attack.SetAttackTime(false);
                    Attack.SetAttack(false,1);
                }
            }
            else if(Time - Mathf.Floor(Time) >= 59.8f / 100)
            {
                if (!Attack.AttackGet1())
                {
                    Attack.SetAttackTime(true);
                    Attack.SetAttack(true,1);
                    Attack.Sound.ChangeAudio("En_Hammer");
                }
            }
            else if(Time - Mathf.Floor(Time) >= 38.1f / 100)
            {
                if (Attack.AttackGet())
                {
                    Attack.SetAttackTime(false);
                    Attack.SetAttack(false,0);
                }
            }
            else if (Time - Mathf.Floor(Time) >= 35.6f / 100)
            {
                if (!Attack.AttackGet())
                {
                    Attack.SetAttackTime(true);
                    Attack.SetAttack(true,0);
                    Attack.Sound.ChangeAudio("En_Hammer");

                }
            }
        }
        else if (Attack.name == "OrcSoldier(Clone)")
        {

            if (Time - Mathf.Floor(Time) >= 81.2f / 100)
            {
                if (Attack.AttackGet())
                {
                    Attack.SetAttackTime(false);
                    Attack.SetAttack(false,0);
                }
            }
            else if (Time - Mathf.Floor(Time) >= 64.4f / 100)
            {
                if (!Attack.AttackGet())
                {
                    Attack.SetAttackTime(true);
                    Attack.SetAttack(true,0);
                    
                    Attack.Sound.ChangeAudio("En_Sword");
                }
            }

        }
            
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Attack.SetStopMon(false);
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
