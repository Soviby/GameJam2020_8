using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
/// <summary>
/// 被反射者，  
/// 计算角度和创建发射者
/// </summary>
public class ReflectionBehavior:MonoBehaviour
{
    //bool isTrigger = false;//是否被照射到
    //public Vector2 normal;//法线
    //public Vector2 pos;//入射点
    //public GameObject in_light;
    //private void Awake()
    //{
    //    Physics2D.queriesStartInColliders = false;
    //}
    //private void Start()
    //{

    //}

    //    private void Update()
    //    {
    //        if (isTrigger)
    //        {
    //            //计算反射角度，然后发射
    //            lineLight = gameObject.GetComponentInChildren<Light2D>();
    //            if (!lineLight)
    //            {
    //                var go = Instantiate(in_light.gameObject, transform);
    //                go.transform.localPosition = Vector3.zero;
    //                lineLight = go.GetComponent<LineLight>();
    //            }
    //            lineLight.gameObject.SetActive(true);
    //            //入射向量

    //            lineLight.gameObject.transform.position = pos;

    //            lineLight.angle = 0;
    //            lineLight.enabled = true;


    //        }

    //    }

    //void OnDisable()
    //{
    //    in_light = null;
    //}
}