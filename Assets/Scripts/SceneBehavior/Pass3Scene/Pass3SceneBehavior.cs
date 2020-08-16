using UnityEngine;
using UnityEditor;
using System.Collections;
/// <summary>
/// 第三关卡场景
/// </summary>
public class Pass3SceneBehavior : SceneBehavior<Pass3SceneModel>
{
    public override void OnAppInit()
    {
        base.OnAppInit();
        LogicMM.sceneControl.RegisterBehavior(4,this);
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