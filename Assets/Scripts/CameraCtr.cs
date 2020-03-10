using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtr : MonoBehaviour
{
    public GameMgr GM;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        if (GM.MasterPlayer)
        {
            transform.position = new Vector3(-25.0f, 0, 0);
        }
        else
        {
            camera.ResetProjectionMatrix();
            camera.projectionMatrix = camera.projectionMatrix * Matrix4x4.Scale(new Vector3(-1, 1, 1));
            transform.position = new Vector3(25.0f, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
