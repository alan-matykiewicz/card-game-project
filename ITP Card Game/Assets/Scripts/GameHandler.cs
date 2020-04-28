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

    public GameObject cardPrefab;
    public GameObject player2Hand;

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

    public void SetEnemyCardAmount(int amount)
    {
        int curCount = gameData.player2Hand.Count;
        if(amount > curCount)
        {
            for(int i = curCount; i < amount; i++)
            {
                Card card = Instantiate(cardPrefab, new Vector2(0, 0), Quaternion.identity).GetComponent<Card>();
                gameData.player2Hand.Add(card);
                card.transform.SetParent(player2Hand.transform, false);
            }
        }else if(curCount > amount)
        {
            gameData.player2Hand.RemoveAt(0);
            Destroy(player2Hand.GetComponentInChildren<Card>());
        }
    }
    
}
