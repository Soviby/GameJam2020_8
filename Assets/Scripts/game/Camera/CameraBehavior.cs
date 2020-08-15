using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CameraBehavior :MonoBehaviour
{
    public float minY = -100, maxY = 100, minX = -100, maxX = 100;
    Camera mainCamera;


    private void Start()
    {
        mainCamera = Camera.main;
    }
    Vector3 pos;
    Transform mianrole_tf;
    private void FixedUpdate()
    {
        if (!LogicMM.mainRole.model.mainRole) return;
        mianrole_tf = LogicMM.mainRole.model.mainRole.transform;

        pos = Vector3.Lerp(mainCamera.transform.position,
            new Vector3(mianrole_tf.position.x, mianrole_tf.position.y, mainCamera.transform.position.z), Time.deltaTime * 3);
        mainCamera.transform.position = new Vector3(Mathf.Clamp(pos.x, minX, maxX),
            Mathf.Clamp(pos.y, minY, maxY), pos.z);
    }
}