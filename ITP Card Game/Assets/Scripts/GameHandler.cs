using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public ScriptableGameData gameData;

    public ScriptableCard[] cards;

    // Start is called before the first frame update
    void Start()
    {
        gameData.playerCoins = ScriptableGameData.startCoins;
        List<ScriptableCard> l = new List<ScriptableCard>(cards);
        Deck deck = ScriptableObject.CreateInstance("Deck") as Deck;
        deck.Init(l);
        gameData.playerDeck = deck;
        gameData.playerHand = new List<Card>();
        gameData.playerDeck.Shuffle();
    }
}
