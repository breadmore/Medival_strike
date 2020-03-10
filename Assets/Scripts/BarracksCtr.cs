using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksCtr : MonoBehaviour
{

    public GameMgr GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameMgr").GetComponent<GameMgr>();
        if (!GM.MasterPlayer)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
