using UnityEngine;
using UnityEditor;
using System.Collections;
/// <summary>
/// 结束场景
/// </summary>
public class EndSceneBehavior : SceneBehavior<EndSceneModel>
{
    public override void OnAppInit()
    {
        base.OnAppInit();
        LogicMM.sceneControl.RegisterBehavior(5,this);
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