using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObjBehavior :MonoBehaviour
{
    public ObjTypeDefs objType;
    public int aoi_id;

    private void Awake()
    {
        LogicMM.role.AddAOIObj(this);
    }

    private void OnDestroy()
    {
        LogicMM.role.RemoveAOIObj(this);
    }



}