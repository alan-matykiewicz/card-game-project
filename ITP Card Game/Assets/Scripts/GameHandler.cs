using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public ScriptableGameData gameData;

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
