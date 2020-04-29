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
    public GameObject player2DropZone;

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
                //creates a placeholder (ambiguous) card in enemy's hand, flipped
                Card card = Instantiate(cardPrefab, new Vector2(0, 0), Quaternion.identity).GetComponent<Card>();
                gameData.player2Hand.Add(card);
                card.transform.SetParent(player2Hand.transform, false);
                card.Flip();
                card.GetComponent<DragBehaviour>().enabled = false;
                card.GetComponent<CardFocus>().enabled = false;
            }
        }
    }

    public void EnemyCardPlayed(ScriptableCard cardScript, int sibIndex)
    {
        //create the played card
        Card card = Instantiate(cardPrefab, new Vector2(0, 0), Quaternion.identity).GetComponent<Card>();
        card.SetCardScript(cardScript);
        card.isPlayed = true;
        card.transform.Find("Card Front/Cost Group").gameObject.SetActive(false);
        //remove a placeholder card from enemys hand
        Destroy(player2Hand.GetComponentInChildren<Card>().gameObject);
        //place the card on the enemys dropzone
        card.transform.SetParent(player2DropZone.transform, false);

        player2DropZone.GetComponent<DropZoneSpacing>().CheckSpacing();
        card.transform.SetSiblingIndex(sibIndex);
        card.GetComponent<DragBehaviour>().enabled = false;
    }
    
}
