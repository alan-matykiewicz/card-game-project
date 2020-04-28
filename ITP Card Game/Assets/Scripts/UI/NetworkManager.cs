using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance;

    public TextMeshProUGUI waitingStatusText;
    public TMP_InputField nameInputField;
    public Button continueButton;

    private bool isConnecting = false;

    private const string GameVersion = "0.1";
    private const int MaxPlayerPerRoom = 2;

    private void Awake()
    {
        if(NetworkManager.instance != null && NetworkManager.instance != this)
        {
            gameObject.SetActive(false);
        }
        else
        {
            instance = this;
            PhotonNetwork.AutomaticallySyncScene = true;
            DontDestroyOnLoad(gameObject);
        }
    }

    public static void Disconnect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
        }
        
    }

    public void FindOpponent()
    {
        isConnecting = true;
        
        nameInputField.enabled = false;
        continueButton.enabled = false;
        waitingStatusText.SetText("Searching...");

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        if (isConnecting)
        {
            waitingStatusText.SetText("Connected to master. Searching...");
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        if(waitingStatusText != null)
        {
            waitingStatusText.enabled = false;
            nameInputField.enabled = true;
            continueButton.enabled = true;
        }
        Debug.Log($"Disconnected due to: {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No open rooms. Creating a new room.");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayerPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Successfully joined a room");
        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        if(playerCount != MaxPlayerPerRoom)
        {
            waitingStatusText.text = "Waiting for opponent";
            Debug.Log("Client is waiting for an opponent");
        }
        else
        {
            waitingStatusText.text = "Opponent Found";
            Debug.Log("Match is ready to begin");
            //logs all players in current room
            Dictionary<int, Player> dict = PhotonNetwork.CurrentRoom.Players;
            foreach (KeyValuePair<int, Player> item in dict)
            {
                Debug.Log("Key: " + item.Key + ", Value: " + item.Value.NickName);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayerPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            Debug.Log("Match is ready to begin. " + newPlayer.NickName);
            waitingStatusText.text = "Opponent Found";

            //this line loads the game scene for all player in the room
            PhotonNetwork.LoadLevel("MainScene");
            //logs all players in current room
            Dictionary<int, Player> dict = PhotonNetwork.CurrentRoom.Players;
            foreach (KeyValuePair<int, Player> item in dict)
            {
                Debug.Log("Key: "+item.Key+", Value: "+item.Value.NickName);
            }
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " disconnected.");
        PhotonNetwork.LoadLevel("Menu");
        PhotonNetwork.LeaveRoom();
    }

    public Player GetLocalPlayer()
    {
        return PhotonNetwork.LocalPlayer;
    }

    public Player GetRemotePlayer()
    {
        Dictionary<int, Player> dict = PhotonNetwork.CurrentRoom.Players;
        foreach (KeyValuePair<int, Player> item in dict)
        {
            if (!item.Value.Equals(PhotonNetwork.LocalPlayer))
            {
                return item.Value;
            }
        }
        return null;
    }
}
