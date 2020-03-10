using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBarracksCtrl : MonoBehaviour
{
    public GameMgr GM;

    #region Private Fields;
    bool MasterPlayer;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        MasterPlayer = GM.MasterPlayer;
        if (!MasterPlayer)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
