using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class NPCBehavior : ObjBehavior
{
    bool isFinish=false;
    public GameObject _light;
    
    

    private void Update()
    {
        if (lineLights.Count > 0)//判断是否被光照射
        {
            isFinish = true;
        }
        if (isFinish)
        {
            _light.SetActive(true);
        }



    }

}