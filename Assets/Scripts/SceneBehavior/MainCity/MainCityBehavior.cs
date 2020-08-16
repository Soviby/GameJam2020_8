using UnityEngine;
using UnityEditor;
using System.Collections;
/// <summary>
/// 第一关
/// </summary>
public class MainCityBehavior : SceneBehavior<MainCityModel>
{
    public override void OnAppInit()
    {
        base.OnAppInit();
        LogicMM.sceneControl.RegisterBehavior(1,this);
    }

    public override void LeaveBehavior()
    {
        base.LeaveBehavior();
    }

    public override void EnterScene()
    {
        base.EnterScene();
       // RunTask(enumerator());

    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(5);
        LogicMM.sceneControl.EnterScene(3);
    }
}