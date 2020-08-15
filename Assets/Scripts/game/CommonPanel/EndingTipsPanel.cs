using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EndingTipsPanel : MyPanel
{
  
    Scrollbar sb;

    public EndingTipsPanel()
    {
        _panelResName = "ending_tips_panel ";
    }

    public override void OnInit()
    {
        base.OnInit();
        sb = gameObject.FindChild<Scrollbar>("Scrollbar");
        
    }

    public override void OnShow()
    {
        base.OnShow();
        RunUITask(Wait());
    }

    IEnumerator Wait()
    {
        gameObject.SetActive(true);
        //滚动sroll
        sb.value = 0.8f;
        float speed = 0.01f;
        while (sb.value >= 0.2f) ;
        {
            sb.value -= speed;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.SetActive(false);
        //游戏结束TODO....
    }


}
