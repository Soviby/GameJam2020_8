using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RoleControl : SmartControl<RoleModel>
{
    public GameObject root;

    public GameObject CreatRole(int aoi_id) {
        var config = DB.AOIBaseMap[aoi_id];
        var _gameObject = GameObject.Instantiate(Resources.Load<GameObject>(ResPathDefs.AOI_PETH + config.res));
        if (!_gameObject) Debug.Log($"{config.res},Resources中找不到");
        //创建根节点
        if (!root)
        {
            root = new GameObject("aoi_root");
        }
        _gameObject.transform.parent = root.transform;
        _gameObject.transform.position = Vector3.zero;
        _gameObject.name = config.id.ToString();
        return _gameObject;
    }

    public override void OnAppInit()
    {
        base.OnAppInit();
        //GameMng.instance.StartCoroutine(StarTimeline());
    }

    //private IEnumerator StarTimeline() {
    //    var timeline =TimelineManager.GetOrCreatInstance().AddScenarioTimeline("timeline/test");
    //    while (!timeline.isInitOk)
    //    {
    //        yield return null;
    //    }
    //    timeline.StartPlay();
    //}

    public int aoi_id = -1;
    public Dictionary<ObjTypeDefs,List<ObjBehavior>  > objs = new Dictionary<ObjTypeDefs, List<ObjBehavior>>();
    public int AddAOIObj(ObjBehavior objBehavior) {
        aoi_id++;
        objBehavior.aoi_id = aoi_id;
        if (!objs.ContainsKey(objBehavior.objType))
        {
            objs.Add(objBehavior.objType,new List<ObjBehavior>());
        }
        objs[objBehavior.objType].Add(objBehavior);

        if (objBehavior.objType == ObjTypeDefs.main_role)
            LogicMM.mainRole.model.mainRole= objBehavior;
        return aoi_id;
    }

    public void RemoveAOIObj(ObjBehavior objBehavior) {
        if (objs.ContainsKey(objBehavior.objType)&&  objs[objBehavior.objType].Contains(objBehavior))
        {
            objs[objBehavior.objType].Remove(objBehavior);
        }
    }
}