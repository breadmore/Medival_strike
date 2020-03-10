using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
public class PhotonInit : MonoBehaviourPunCallbacks
{
    public GameObject HQ;
    public bool MasterPlayer = false;
    int idx;

    void Start()
    {
        Transform[] points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        if (PhotonNetwork.IsMasterClient) MasterPlayer = true;
        if (MasterPlayer)
            idx = 1;
        else
            idx = 2;

        PlayerManager.LocalPlayerInstance = null;
        if (HQ == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
        }
        else
        {
            if (PlayerManager.LocalPlayerInstance == null)
            {
                Debug.LogFormat("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName);
                PhotonNetwork.Instantiate(this.HQ.name, points[idx].position, Quaternion.identity);
            }
            else
            {
                Debug.LogFormat("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName);
            }
        }
    }
    void Update()
    {
       
    }


    #region Photon Callbacks
    /// <summary>
    /// Called when the local player left the room. We need to load the launcher scene.
    /// </summary>
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }


    #endregion


    #region Public Methods


    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    #endregion
}
