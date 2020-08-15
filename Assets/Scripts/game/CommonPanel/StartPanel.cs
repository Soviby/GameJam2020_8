using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MyPanel
{

    public StartPanel()
    {
        _panelResName = "Start_panel";
    }

    public override void OnInit()
    {
        base.OnInit();


    }

    public override void OnShow()
    {
        base.OnShow();

    }

    public void __OnPointerDown(object btn)
    {

    }

    public void __OnPointerUp(object btn)
    {

    }

    public void OnClickEvent(object btn)
    {
        GameObject GoBtn = (GameObject)btn;
        if (GoBtn.name == "Start")
        {
            gameObject.SetActive(true);
        }
        else
        {
            Application.Quit();
        }
    }



}
