using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBuildArrow : MonoBehaviour
{
    public GameMgr GM;
    public GameObject Builder;
    public Sprite dotFrame;
    public GameObject batchUI;
    void Start()
    {
    }
    public void MoveBuilder(int dir)
    {
        switch (GM.BBC)
        {
            case GameMgr.BtnBuildClass.Barrack:
                MoveBarrack(dir);
                break;
            case GameMgr.BtnBuildClass.Delete:
                MoveDelete(dir);
                break;
        }
    }
    void MoveBarrack(int dir)
    {
        int oldBuilderPos = GM.currentBuilderPos;
        while (true)
        {
            if ((oldBuilderPos > 4 && dir >= 1)
                || (oldBuilderPos <= 0 && dir <= -1))
            {
                break;
            }
            if (GM.IsBarracks[oldBuilderPos + dir] == false)
            {
                GM.currentBuilderPos = oldBuilderPos + dir;
                Builder.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = GM.currentBuildertexture;
                Builder.transform.GetChild(GM.currentBuilderPos - dir).GetComponent<SpriteRenderer>().sprite = dotFrame;
                batchUI.transform.Translate(3.33f * dir, 0, 0);
                break;
            }
            else
            {
                oldBuilderPos++;
                batchUI.transform.Translate(3.33f * dir, 0, 0);
                Builder.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = dotFrame;
            }
        }
    }
    void MoveDelete(int dir)
    {
        int oldBuilderPos = GM.currentBuilderPos;
        if ((oldBuilderPos > 4 && dir >= 1)
            || (oldBuilderPos <= 0 && dir <= -1))
        {
            return;
        }
        GM.currentBuilderPos = oldBuilderPos + dir;
        Builder.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = GM.currentBuildertexture;
        Builder.transform.GetChild(GM.currentBuilderPos - dir).GetComponent<SpriteRenderer>().sprite = dotFrame;
        batchUI.transform.Translate(3.33f * dir, 0, 0);

    }
}
