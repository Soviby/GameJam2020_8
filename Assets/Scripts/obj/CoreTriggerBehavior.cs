using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CoreTriggerBehavior : TriggerBehavior
{
    public float angle = -30f;
    public override void Handre()
    {
        //旋转自己
        gameObject.transform.Rotate(Vector3.forward*angle);
    }
}