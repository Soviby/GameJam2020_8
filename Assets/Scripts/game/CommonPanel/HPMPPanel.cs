using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class HPMPPanel : MyPanel
{
    Image hpBar;
    Image hp;
    Image preHP;
    Text hpValue;

    Image mpBar;
    Image mp;
    Image preMP;
    Text mpValue;

    private float totalHP = 100;//总的血量
    private float curHP = 100;//当前剩余的血量

    private float totalMP = 100;//总的血量
    private float curMP = 100;//当前剩余的血量

    private bool isHurt = false;  //是否受到伤害
    private bool isConsume = false; //是否消耗能量

    public HPMPPanel()
    {
        _panelResName = "HP_MP_Panel";
    }

    public override void OnInit()
    {
        base.OnInit();
        hpBar = gameObject.FindChild<Image>("HPBar");
        preHP = hpBar.transform.Find("PreHP").GetComponent<Image>();
        hp = hpBar.transform.Find("HP").GetComponent<Image>();
        hpValue =hpBar.transform.Find("HPValue").GetComponent<Text>();
        mpBar = gameObject.FindChild<Image>("MPBar");
        preMP = mpBar.transform.Find("PreMP").GetComponent<Image>();
        mp = mpBar.transform.Find("MP").GetComponent<Image>();
        mpValue = mpBar.transform.Find("MPValue").GetComponent<Text>();
    }


    /// <summary>
    /// [技能] 受伤，模拟受到攻击
    /// </summary>
    public void Hurt(float damage)
    {

        //修改血条，修改血量数值
        curHP -= damage;//假设每次扣除30血量
        if (curHP < 0) curHP = 0;//避免出现负值
        hp.fillAmount = (float)curHP / totalHP;//修改血条显示
        hpValue.text = curHP + " / 100";//修改血量数值显示4
        RunUITask(PreHPWaite());
    }
    IEnumerator PreHPWaite()
    {
        yield return new WaitForSeconds(0.2f);
        isHurt = true;
        while (isHurt == true)
        {
            if (isHurt)//受到攻击时执行
            {
                preHP.fillAmount = Mathf.Lerp(preHP.fillAmount, (float)curHP / totalHP, 4 * 0.02f);
                if (preHP.fillAmount - (float)curHP / totalHP <= 0.001f)
                isHurt = false;
            }
        }
        
    }

    /// <summary>
    /// [技能] 受伤，模拟受到攻击
    /// </summary>
    public void Consume(float consume)
    {

        //修改血条，修改血量数值
        curMP -= consume;//假设每次扣除30血量
        if (curMP < 0) curMP = 0;//避免出现负值
        mp.fillAmount = (float)curMP / totalMP;//修改血条显示
        mpValue.text = curMP + " / 100";//修改血量数值显示4
        RunUITask(PreMPWaite());
    }
    IEnumerator PreMPWaite()
    {
        yield return new WaitForSeconds(0.2f);
        isConsume = true;
        while (isConsume == true)
        {
            if (isConsume)//受到攻击时执行
            {
                preMP.fillAmount = Mathf.Lerp(preMP.fillAmount, (float)curMP / totalMP, 4 * 0.02f);
                if (preMP.fillAmount - (float)curMP / totalMP <= 0.001f)
                    isConsume = false;
            }
        }

    }


}
