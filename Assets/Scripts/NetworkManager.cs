using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    private GameObject spawnerPlayerPrefrab;
    public string sceneNameToChange;
    

    void Start()
    {
        ConnectedToServer();
    }

    void ConnectedToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try connect to server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server.");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Sala1", roomOptions, TypedLobby.Default);

    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined on room.");
        base.OnJoinedRoom();
        switch (SceneManager.GetActiveScene().name)
        {
            case "Game":
                Vector3 posToSet = new Vector3(0f, 4.237f, 0.6f);
                spawnerPlayerPrefrab = PhotonNetwork.Instantiate("Player", posToSet, transform.rotation);
                break;
        }
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        sceneNameToChange = "Loby";
        ChangeRoom();
    }

    public void ChangeRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        Debug.Log("Left room");
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnerPlayerPrefrab);
        PhotonNetwork.Disconnect();
        ChanegScene();
    }
    void ChanegScene()
    {
        PhotonNetwork.LoadLevel(sceneNameToChange);
    }
     
}
