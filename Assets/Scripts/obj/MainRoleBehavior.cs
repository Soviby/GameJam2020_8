using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class MainRoleBehavior : ObjBehavior
{

    private SpriteRenderer sp;
    public float hurtLength;//MARKER 效果持续多久
    private float hurtCounter;//MARKER 相当于计数器
    public Material material;
    private Material materialed;
    public override int Hp {
        get => base.Hp;
        set
        {
            if (value < base.Hp)
            {
                HurtShader();
            }
            base.Hp = value;

        }
    }

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();

        materialed = sp.material;

    }

    
    Vector2 pos;

    private void Update()
    {
        hurtCounter -= Time.deltaTime;
        if (hurtCounter <= 0)
        {
            sp.material.SetFloat("_FlashAmount", 0);
            sp.material = materialed;
        }
            
    }

    private void HurtShader()
    {
        sp.material = material;
        sp.material.SetFloat("_FlashAmount", 1);
        hurtCounter = hurtLength;
    }
}