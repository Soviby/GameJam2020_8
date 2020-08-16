using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering.Universal;

public class CameraContol : SmartControl<CameraModel>
{
    private GameObject _root;
    private Camera uiCamera;


    public Camera mainCamera {
        get {
            return Camera.main;
        }
    }

    public Camera UiCamera {
        get {
            if (!uiCamera)
            {
                var go = new GameObject();
                go.transform.parent = Root.transform;
                var uiCamera= go.AddComponent<Camera>();
                var cameraData = uiCamera.GetUniversalAdditionalCameraData();
                cameraData.renderType = CameraRenderType.Overlay;
                go.name = "uiCamera";
                uiCamera.cullingMask = 1 << GameConfig.LAYER_UI;
                //uiCamera.clearFlags = CameraClearFlags.Depth;
                //uiCamera.depth = 1;
                uiCamera.orthographic = true;
                go.transform.position = new Vector3(100000,0,0);
                this.uiCamera = uiCamera;

                cameraData = mainCamera.GetUniversalAdditionalCameraData();
                cameraData.cameraStack.Add(uiCamera);
            }
            return uiCamera;
        }
    }

    public GameObject Root {
        get {
            if (!_root)
            {
                var go = new GameObject();
                go.name = "Camera";
                _root = go;
            }
            return _root;
        }
    }

    
}