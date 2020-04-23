using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameHandler : MonoBehaviour
{
    public ScriptableGameData gameData;

    public Player localPlayer;
    public Player remotePlayer;

    public TextMeshProUGUI localPlayerName;
    public TextMeshProUGUI remotePlayerName;

    public ScriptableCard[] cards;  //temp

    private static GameHandler _instance;
    public static GameHandler Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        localPlayer = NetworkManager.instance.GetLocalPlayer();
        remotePlayer = NetworkManager.instance.GetRemotePlayer();
        localPlayerName.text = localPlayer.NickName;
        remotePlayerName.text = remotePlayer.NickName;

        gameData.player1Coins = ScriptableGameData.startCoins;
        gameData.player2Coins = ScriptableGameData.startCoins;
        List<ScriptableCard> l = new List<ScriptableCard>(cards);
        Deck deck = ScriptableObject.CreateInstance("Deck") as Deck;
        deck.Init(l);
        gameData.player1Deck = deck;
        gameData.player1Hand = new List<Card>();
        gameData.player1Deck.Shuffle();
        gameData.player2Deck = deck;
        gameData.player2Hand = new List<Card>();
        gameData.player2Deck.Shuffle();
    }
    
}
