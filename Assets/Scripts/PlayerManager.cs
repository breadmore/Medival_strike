using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerManager : MonoBehaviourPunCallbacks
{

    #region Private Fields
    bool IsBarraack;
    bool MasterPlayer = false;
    GameObject Barracks;

    #endregion

    #region Public Fields
    public static GameObject LocalPlayerInstance;
    #endregion

    void Awake()
    {
        if (photonView.IsMine)
        {
            PlayerManager.LocalPlayerInstance = this.gameObject;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {

        MasterPlayer = PhotonNetwork.IsMasterClient;

    }
    
    void Update()
    {
        if (photonView.IsMine)
        {
            return;
        }
    }
   
}
