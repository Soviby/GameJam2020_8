﻿using Entity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehaviour : MonoBehaviour
{
    public int damage;
    public float startTime;
    public float time;
    public bool isAttacking = false;
    public ObjTypeDefs objTypeDefs =  ObjTypeDefs.monster;


    private Animator anim;
    private PolygonCollider2D collider2D;

 //   private PlayerInputActions controls;

    void Awake()
    {
      //  controls = new PlayerInputActions();

       // controls.GamePlay.Attack.started += ctx => Attack();
    }

    void OnEnable()
    {
      //  controls.GamePlay.Enable();
    }

    void OnDisable()
    {
        //  controls.GamePlay.Disable();
        isAttacking = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ///Attack();
    }
    Coroutine coroutine;
    void Attack()
    {
        if(Input.GetButtonDown("Attack"))
        {
            OneAttack();
        }
    }

    public void OneAttack() {
        if (isAttacking)
            return;
        StartCoroutine(StartAttack());
    }

    IEnumerator StartAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(startTime);
        collider2D.enabled = true;
        StartCoroutine(disableHitBox());
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider2D.enabled = false;
        isAttacking = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ObjBehavior>())
        {
            var obj = other.gameObject.GetComponent<ObjBehavior>();
            if (obj.objType == Entity.ObjTypeDefs.monster)
            {
                obj.Hp -= damage;
            }
            else if (obj.objType == Entity.ObjTypeDefs.main_role)
            {
                obj.Hp -= damage;
            }
        }
        //if(other.gameObject.CompareTag("Enemy"))
        //{
        //   // other.GetComponent<Enemy>().TakeDamage(damage);
        //}
    }
}
