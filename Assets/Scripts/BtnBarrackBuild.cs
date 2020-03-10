using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBarrackBuild : MonoBehaviour
{
    public GameMgr GM;
    public DataMgr DM;
    public GameObject UIBatch;
    public BtnBuildArrow[] Arrow;
    public Sprite image;

    #region Private Fields
    GameObject Builder;
    #endregion

    public enum UnitClass { spear = 0, knight = 1, archer, delete};

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        while (true)
        {
            Builder = GameObject.Find("Manager").transform.Find("UIBarracks").gameObject;
            yield return null;
        }
    }
    public void BtnCreateBarrack(int value)
    {
        switch ((UnitClass)value)
        {
            case UnitClass.spear:
                if (GM.Money >= DM.Price_Barrack[value] && GM.touchstate == GameMgr.TouchState.none)
                {
                    int count = 0;
                    while (true)
                    {
                        if (GM.IsBarracks[count] == false)
                            break;
                        else
                        {
                            count++;
                            if (count >= GM.IsBarracks.Length)
                                return;
                        }
                    }
                    GM.touchstate = GameMgr.TouchState.build;
                    GM.currentBuildertexture = image;
                    GM.currentBuilderPos = count;
                    GM.currentBuildernumber = value;
                    Builder.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = image;
                    for (int i = 0; i < count; i++)
                    {
                        UIBatch.transform.Translate(3.33f, 0, 0);
                    }
                    GM.BBC = GameMgr.BtnBuildClass.Barrack;
                    Builder.SetActive(true);
                }
                break;
            case UnitClass.knight:
                break;
            case UnitClass.archer:
                break;
            case UnitClass.delete:
                GM.touchstate = GameMgr.TouchState.build;
                GM.currentBuildertexture = image;
                GM.currentBuilderPos = 0;
                Builder.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = image;
                GM.BBC = GameMgr.BtnBuildClass.Delete;

                Builder.SetActive(true);
                break;
            default:
                break;
        }

    }
}
