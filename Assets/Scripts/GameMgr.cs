using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class GameMgr : MonoBehaviourPunCallbacks
{
    public GameObject HQ;
    public static GameMgr Instance;
    public enum TouchState { none, build }
    public TouchState touchstate;
    public enum BtnBuildClass { None, Barrack, Delete }
    public BtnBuildClass BBC;

    public bool[] IsBarracks;
    [HideInInspector]
    public float Money;
    [HideInInspector]
    public int currentBuilderPos;
    [HideInInspector]
    public Sprite currentBuildertexture;
    public int currentBuildernumber;

    public GameObject ASiteBarracks;
    public GameObject BSiteBarracks;
    public Image UI_RoundTimer;
    public Image UI_GoldBar;
    public Barrack[] Barracks;
    //[HideInInspector]
    public bool MasterPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient) MasterPlayer = true;
        Money = 0;
        currentBuilderPos = 0;

            StartCoroutine(StartGame());
    }

    // Update is called once per frame
    

    IEnumerator StartGame()
    {
        while (true)
        {
            for (int i = 0; i < Barracks.Length; i++)
            {
                if (MasterPlayer)
                    Barracks[i] = ASiteBarracks.transform.GetChild(i).GetComponent<Barrack>();
                else
                    Barracks[i] = BSiteBarracks.transform.GetChild(i).GetComponent<Barrack>();
            }
            StartCoroutine(StartRoundTimer());
            StartCoroutine(GoldTimer());
            break;

            yield return null;
        }
    }

    IEnumerator StartRoundTimer()
    {
        while (true)
        {
            UI_RoundTimer.fillAmount -= Time.deltaTime / 5.0f;
            if (UI_RoundTimer.fillAmount <= 0)
            {
                UI_RoundTimer.fillAmount = 1;
                ActiveTurnAction();
            }
            yield return null;
        }
    }

    IEnumerator GoldTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            if (Money <= 10)
                Money += 0.5f;
            UI_GoldBar.fillAmount = Money / 10;
        }
    }

    void ActiveTurnAction()
    {
        for (int i = 0; i < Barracks.Length; i++)
        {
            Barracks[i].CreateUnit();
            if (Barracks[i].Life <= 0)
            {
                Barracks[i].SleepBarrack();
                IsBarracks[i] = false;
            }
        }
    }


}