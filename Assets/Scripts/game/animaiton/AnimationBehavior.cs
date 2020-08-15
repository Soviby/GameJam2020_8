using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class AnimationBehavior :MonoBehaviour
{
    string preAnimName = "idle";
    public AnimationParams animationParams=new AnimationParams();
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayAnimation(string animName)
    {
        if (preAnimName == animName)
            return;
        animator.SetBool(preAnimName, false);
        animator.SetBool(animName, true);
        preAnimName = animName;//
    }


    private void Update()
    {
        var horValue = Input.GetAxisRaw("Horizontal");
        if (horValue != 0)
        {
            if (gameObject.GetComponent<MoveBehaviour>())
            {
                PlayAnimation(animationParams.Run);
                return;
            }
            
        }
        if (Input.GetButtonDown("Attack"))
        {
            if (gameObject.GetComponentInChildren<PlayerAttackBehaviour>())
            {
                PlayAnimation(animationParams.Attack);
                return;
            }
        }
        //正在攻击
        if (gameObject.GetComponentInChildren<PlayerAttackBehaviour>() && gameObject.GetComponentInChildren<PlayerAttackBehaviour>().isAttacking)
        {
            PlayAnimation(animationParams.Attack);
            return;
        }

        PlayAnimation(animationParams.Idle);
    }
}