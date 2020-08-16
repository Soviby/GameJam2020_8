using UnityEngine;
using UnityEditor;
using System.Collections;
/// <summary>
/// 登录场景
/// </summary>
public class LoginSceneBehavior : SceneBehavior<LoginSceneModel>
{
    public override void OnAppInit()
    {
        base.OnAppInit();
        LogicMM.sceneControl.RegisterBehavior(2,this);
    }

    public override void LeaveBehavior()
    {
        base.LeaveBehavior();
    }

    public override void EnterScene()
    {
        base.EnterScene();
        //播放背景音乐
        SoundManager.PlayMusic("event:/login_bg");
        RunTask(enumerator());
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(5);
        LogicMM.sceneControl.EnterScene(4);
    }
}