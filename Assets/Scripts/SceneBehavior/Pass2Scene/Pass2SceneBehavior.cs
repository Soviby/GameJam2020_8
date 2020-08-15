using UnityEngine;
using UnityEditor;
using System.Collections;
/// <summary>
/// 第二关卡场景
/// </summary>
public class Pass2SceneBehavior : SceneBehavior<Pass2SceneModel>
{
    public override void OnAppInit()
    {
        base.OnAppInit();
        LogicMM.sceneControl.RegisterBehavior(3,this);
    }

    public override void LeaveBehavior()
    {
        base.LeaveBehavior();
    }

    public override void EnterScene()
    {
        base.EnterScene();
    }

}