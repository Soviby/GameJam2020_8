using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
/// <summary>
/// 发射者
/// </summary>
public class LineLight :MonoBehaviour
{
    public GameObject pre_light2D;//预制体
    private Light2D _light2D=null;//光对象

    public float angle=0;//角度
    public LayerMask layer;//被照射的物体
    public GameObject target=null;//被照射的对象
    public GameObject father = null;//光的来源
    public bool isSource = false;//是否是光源
    public float distance = 50;//光照距离
    public Transform tf_pos;//
    private void Awake()
    {
       // Physics2D.queriesStartInColliders = false;
    }
    private void Start()
    {
        if (!_light2D)
        {
            var go = Instantiate(pre_light2D);
            _light2D = go.GetComponent<Light2D>();
        }
       

    }

    private void Update()
    {
        if (!_light2D) return;
        if (isSource)//光源
        {
            //float d = angle * (Mathf.PI / 180);
            //Launch(new Vector2(Mathf.Cos(d), Mathf.Sin(d)));

            Launch(tf_pos? tf_pos.position-transform.position: transform.right);
            SetPos();
            return;
        }


        if (father)
        {
            //计算角度
            var dir =GetReflectedDir(in_dir, normal);
            Launch(dir);
            SetPos();
        }
        else  //中间光，没有光源
        {
            NoFather();
        }
    }

    private void NoFather()
    {
        _light2D.transform.localScale = new Vector3(0, 1, 1);
        //将上一个被照射的对象还原
        if (target)
        {
            var target_lineLight = target.GetComponent<LineLight>();
            if (target_lineLight)
            {
                target_lineLight.father = null;
            }
        }
        target = null;
    }

    private void NoTrriger(Vector2 dir)
    {
        //将上一个被照射的对象还原
        if (target)
        {
            var target_lineLight = target.GetComponent<LineLight>();
            if (target_lineLight)
            {
                target_lineLight.father = null;
            }
        }
        target = null;
        if (father || isSource)
        {
            SetLength(dir, 100);
        }
        else
        {
            _light2D.transform.localScale = new Vector3(0, 1, 1);
        }

       
    }

    private void SetPos()
    {
        if (isSource)//光源
        {
            _light2D.transform.position = tf_pos? tf_pos.position: transform.position;
        }
        else
        {
            _light2D.transform.position = pos;
        }
    }

    void OnDisable()
    {
        target = null;
        father = null;
    }

    private void OnDestroy()
    {
        if(_light2D)
            GameObject.Destroy(_light2D.gameObject);
        target = null;
        father = null;
    }

    private void SetLength(Vector2 dir,float length) {
        //_light2D.transform.localScale = new Vector3(length * 2, 1, 1);//会受父节点影响
        _light2D.transform.localScale = new Vector3(length * 2, 1, 1);
        //旋转
        //_light2D.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan(dir.y / dir.x) * (180 / Mathf.PI));
        //_light2D.transform.LookAt(new Vector3(_light2D.transform.position.x+ dir.x, _light2D.transform.position.y + dir.y, _light2D.transform.position.z), Vector3.forward);
        //_light2D.transform.eulerAngles = LookTargetAngle(_light2D.transform, dir);
        _light2D.transform.right = dir;

    }

    //发射
    private void Launch(Vector2 dir)
    {
        dir = dir.normalized;
        Vector3 end_pos = Vector3.zero;
        if (isSource && tf_pos)
        {
            end_pos = tf_pos.position;
        }
        else
        {
            if (father)
                end_pos = this.pos;
            else
                end_pos = transform.position;
        }
        var hit = Physics2D.Raycast(end_pos,
               dir, distance, layer);
        //2.改变go_2d_light 的长度和角度
        if (hit.collider != null)
        {
            if(target !=hit.collider.gameObject)//如果不是上一个被照射的对象
            {
                if (target)
                {
                    var target_lineLight = target.GetComponent<LineLight>();
                    if (target_lineLight)
                    {
                        target_lineLight.father = null;
                    }
                }
            }
            Vector3 pos = new Vector3(hit.point.x, hit.point.y, 0);
            var p = pos - transform.position;
            float length = 0;
            if (isSource && tf_pos)
            {
                length=Vector3.Distance(pos, tf_pos.position);
            }
            else {
                if(father)
                    length=Vector3.Distance(pos, this.pos);
                else
                    length=Vector3.Distance(pos, transform.position);
            }

            SetLength(dir, length);
            target = hit.collider.gameObject;
            if (target.GetComponent<ReflectionBehavior>())
            {
                
                var target_LineLight = target.GetMissComponent<LineLight>();
                target_LineLight.normal = hit.normal;
                target_LineLight.in_dir = dir;
                target_LineLight.father = gameObject;
                target_LineLight.pos = hit.point;
                target_LineLight.layer = layer;
                target_LineLight.pre_light2D = pre_light2D;
            }
        }
        else {//没有照到对象
 
              NoTrriger(dir);
        }
    }

    Vector2 normal;//法线
    Vector2 in_dir;//入射方向
    Vector2 pos = Vector2.zero;//发光的位置
    /// <summary>
    /// 求入射方向的反射方向（入射方向和方向量都要求是单位向量）
    /// </summary>
    /// <param name="v1">入射方向</param>
    /// <param name="n">法向量</param>
    /// <returns>反射方向</returns>
    public static Vector3 GetReflectedDir(Vector3 v1, Vector3 n)
    {
        return v1 - 2 * Vector3.Dot(v1, n) * n;
    }
}