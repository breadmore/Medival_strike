using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class BtnBuildOK : MonoBehaviourPunCallbacks
{
    GameObject P1Barracks;
    GameObject P2Barracks;
    public GameObject UIBarracks;
    public GameObject UIBatch;
    public Sprite dotFrame;
    public GameMgr GM;
    public DataMgr DM;
    public void Start()
    {
        P1Barracks = GameObject.Find("AsiteBarracks");
        P2Barracks = GameObject.Find("BsiteBarracks");

    }

    public void BtnBuildYes()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("P1Build", RpcTarget.AllViaServer, null);
        }
        else
        {
            photonView.RPC("P2Build", RpcTarget.AllViaServer, null);
        }
    }

    [PunRPC]
    void P1Build()
    {
        switch (GM.BBC)
        {
            case GameMgr.BtnBuildClass.Barrack:
                Debug.Log("P1 Build");
                P1Barracks.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = GM.currentBuildertexture;
                P1Barracks.transform.GetChild(GM.currentBuilderPos).GetComponent<Barrack>().Life = 5;
                P1Barracks.transform.GetChild(GM.currentBuilderPos).GetComponent<Barrack>().IsAwake = true;
                GM.IsBarracks[GM.currentBuilderPos] = true;
                GM.Money -= DM.Price_Barrack[GM.currentBuildernumber];
                GM.UI_GoldBar.fillAmount = GM.Money / 10;
                break;
            case GameMgr.BtnBuildClass.Delete:
                UIBarracks.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = dotFrame;
                P1Barracks.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = null;
                P1Barracks.transform.GetChild(GM.currentBuilderPos).GetComponent<Barrack>().IsAwake = false;
                GM.IsBarracks[GM.currentBuilderPos] = false;
                break;
        }

        GM.touchstate = GameMgr.TouchState.none;
        UIBarracks.SetActive(false);
        UIBatch.transform.localPosition = Vector3.zero;
    }
    [PunRPC]
    void P2Build()
    {
        switch (GM.BBC)
        {
            case GameMgr.BtnBuildClass.Barrack:
                Debug.Log("P2 Build");
                P2Barracks.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = GM.currentBuildertexture;
                P2Barracks.transform.GetChild(GM.currentBuilderPos).GetComponent<Barrack>().Life = 5;
                P2Barracks.transform.GetChild(GM.currentBuilderPos).GetComponent<Barrack>().IsAwake = true;
                GM.IsBarracks[GM.currentBuilderPos] = true;
                GM.Money -= DM.Price_Barrack[GM.currentBuildernumber];
                GM.UI_GoldBar.fillAmount = GM.Money / 10;
                break;
            case GameMgr.BtnBuildClass.Delete:
                UIBarracks.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = dotFrame;
                P2Barracks.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = null;
                P2Barracks.transform.GetChild(GM.currentBuilderPos).GetComponent<Barrack>().IsAwake = false;
                GM.IsBarracks[GM.currentBuilderPos] = false;
                break;
        }

        GM.touchstate = GameMgr.TouchState.none;
        UIBarracks.SetActive(false);
        UIBatch.transform.localPosition = Vector3.zero;
    }
    public void BtnBuildNo()
    {

        UIBarracks.transform.GetChild(GM.currentBuilderPos).GetComponent<SpriteRenderer>().sprite = dotFrame;
        GM.touchstate = GameMgr.TouchState.none;
        UIBarracks.SetActive(false);
        UIBatch.transform.localPosition = Vector3.zero;

    }


}
