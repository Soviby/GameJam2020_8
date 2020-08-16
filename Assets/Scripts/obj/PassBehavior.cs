using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
/// <summary>
/// 传送门触发器
/// </summary>
public class PassBehavior : TriggerBehavior
{
    public int scence_id;
    public override void Handre()
    {
        LogicMM.sceneControl.EnterScene(scence_id);
    }
}