using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraMove : MonoBehaviour
{

    #region Private Fields
    Vector3 originMousePosition;
    float dragSpeed = 20.0f;
    bool Masterplayer;
    #endregion

    #region Public Fields

    public GameMgr GM;

    #endregion

    // Start is called before the first frame update
    #region Private Methods
    void Start()
    {
        originMousePosition = Vector2.zero;
        Masterplayer = GM.MasterPlayer;


    }
    void DragCamera()
    {
        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - originMousePosition);
        Vector3 move = new Vector3(pos.x * dragSpeed, 0, 0);
        if (!Masterplayer) move *= -1;
        transform.Translate(-move, Space.World);
        if (transform.position.x > 28.0f ||
            transform.position.x < -28.0f)
        {
            transform.Translate(move, Space.World);
        }
        originMousePosition = Input.mousePosition;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            originMousePosition = Input.mousePosition;
        }
        DragCamera();

    }
    #endregion




    // Update is called once per frame



}
