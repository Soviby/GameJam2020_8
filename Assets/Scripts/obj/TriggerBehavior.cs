using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// 触发器
/// </summary>
public abstract class TriggerBehavior : ObjBehavior, ITriggerBehaviour
{
    public string tip = "";
    public float dis = 2f;//交互距离
    public abstract void Handre();
}
