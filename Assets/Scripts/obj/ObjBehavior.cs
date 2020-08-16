using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObjBehavior :MonoBehaviour
{
    public int hp;
    private bool isDead;
    public ObjTypeDefs objType;
    public int aoi_id;
    [HideInInspector]
    public List<LineLight> lineLights = new List<LineLight>();//被照到的光线 

    public virtual int Hp { get => hp; set => hp = value; }
    public bool IsDead { get => hp<=0; }

    private void Awake()
    {
        LogicMM.role.AddAOIObj(this);
    }

    private void Start()
    {

    }

    private void OnDestroy()
    {
        LogicMM.role.RemoveAOIObj(this);
        lineLights.Clear();
    }



}
public interface ITriggerBehaviour
{
    //处理交互
    void Handre();

}
public enum MonsterType
{
    None=1,
    Attack=2

}