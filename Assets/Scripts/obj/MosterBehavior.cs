using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class MosterBehavior : ObjBehavior
{
    Vector2 pos_1;
    Vector2 pos_2;
    public float speed=1;

    private Rigidbody2D rb;
    private Animator ani;
    public AnimationParams animationParams;
    public MonsterType monsterType;
    private SpriteRenderer sp;
    public float hurtLength;//MARKER 效果持续多久
    private float hurtCounter;//MARKER 相当于计数器
    public Material material;
    private Material materialed;
    private PlayerAttackBehaviour playerAttackBehaviour;
    public override int Hp {
        get => base.Hp;
        set
        {
            if (value < base.Hp)
            {
                HurtShader();
            }
            base.Hp = value;
            if (base.Hp <= 0)
            {
                //死亡动画
                ani.SetBool(animationParams.Dead,true);

            }
        }
    }

    private void Start()
    {
        Transform tf = null;
        tf = gameObject.FindChild<Transform>("pos_1", false);
        if (tf)
            pos_1 = new Vector2(tf.position.x, transform.position.y);
        else
            pos_1 = transform.position;
        tf = gameObject.FindChild<Transform>("pos_2", false);
        if (tf)
            pos_2 = new Vector2(tf.position.x, transform.position.y);
        else
            pos_2 = transform.position;

        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        pos = pos_1;
        sp = GetComponent<SpriteRenderer>();

        materialed = sp.material;
        if (monsterType == MonsterType.Attack)
            playerAttackBehaviour = GetComponentInChildren<PlayerAttackBehaviour>();

    }

    
    Vector2 pos;
    private void FixedUpdate()
    {
        if (IsDead) return;
        if (monsterType == MonsterType.Attack && LogicMM.mainRole.model.mainRole)
        {
            //距离和朝向
            if (Vector2.Distance(LogicMM.mainRole.model.mainRole.transform.position, transform.position) <= 3f)
            {
                if (LogicMM.mainRole.model.mainRole.transform.right != transform.right)
                {
                    ani.SetBool(animationParams.Attack, true);
                    playerAttackBehaviour.OneAttack();
                    return;
                }

            }
        }
        ani.SetBool(animationParams.Attack, false);
        if (pos_1 != pos_2)
        {
            if (Vector2.Distance(pos, transform.position) <= 0.2f)//到达
            {
                pos= pos == pos_1?pos_2: pos_1;
            }
            else {
                var v = (pos - new Vector2(transform.position.x, transform.position.y)).normalized;
                Move(v.x,v.y);
            }
        }

        
    }

    private void Update()
    {
        hurtCounter -= Time.deltaTime;
        if (hurtCounter <= 0)
        {
            sp.material.SetFloat("_FlashAmount", 0);
            sp.material = materialed;
        }
            
    }

    public void Move(float moveH, float moveV)
    {
        moveV = 0;
        rb.velocity = new Vector2(moveH * speed, moveV * speed);

        if (moveH != 0 && Mathf.Sign(transform.localScale.x) != Mathf.Sign(moveH))
        {
            transform.localScale =
                        new Vector3(-1 * transform.localScale.x,
                        transform.localScale.y, transform.localScale.z);
        }

        //动画
        ani.SetBool(animationParams.Run, rb.velocity != Vector2.zero);

    }

    private void HurtShader()
    {
        sp.material = material;
        sp.material.SetFloat("_FlashAmount", 1);
        hurtCounter = hurtLength;
    }
}