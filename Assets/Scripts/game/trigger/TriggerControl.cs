using UnityEngine;
using System.Collections;

public class TriggerControl : SmartControl<TriggerModel>
{

    InteractivePanel panel=null;
    public override void OnFrameUpdate()
    {
        base.OnFrameUpdate();
        //检测附近的触发器
        if (!LogicMM.role.objs.ContainsKey(Entity.ObjTypeDefs.trigger) || LogicMM.role.objs[Entity.ObjTypeDefs.trigger].Count<=0 ||!LogicMM.mainRole.model.mainRole)
        {
            panel?.Display(false);
            return;
        }
        var mainrole = LogicMM.mainRole.model.mainRole;
        TriggerBehavior triggerBehavior = null;
        foreach (var trigger in LogicMM.role.objs[Entity.ObjTypeDefs.trigger])
        {
            if (!trigger.GetComponent<TriggerBehavior>())
                continue;
            triggerBehavior = trigger.GetComponent<TriggerBehavior>();
            if (triggerBehavior.dis >= Vector2.Distance(mainrole.transform.position, triggerBehavior.transform.position))
                break;
            triggerBehavior = null;
        }
        if (triggerBehavior == null)
        {
            panel?.Display(false);
            return;
        }
        if (!string.IsNullOrEmpty(triggerBehavior.tip))
        {
            //展示UI
            panel = MyGUIManager.GetInstance().GetOrCreatePanel<InteractivePanel>();
            panel.InitData(triggerBehavior.transform.position, triggerBehavior.tip);
            panel.Display(true);
            //判断按钮
            if (Input.GetKeyDown(KeyCode.E))
            {
                triggerBehavior.Handre();
            }
        }
        else
        {
            triggerBehavior.Handre();
        }
       

    }


}
