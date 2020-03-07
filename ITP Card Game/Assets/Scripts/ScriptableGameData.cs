using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data")]
public class ScriptableGameData : ScriptableObject
{
    public static byte cardHandLimit = 10;
    public static byte startCoins = 20;

    //PLAYER-DATA
    //player username
    public short playerCoins;
    public short playerVictoryPoints;
    public Deck playerDeck;
    public List<Card> playerHand;

    //OPPONENT-DATA
    //enemy username
    public short opponentCoins;
    public short opponentVictoryPoints;
    public Deck opponentDeck;
    public List<Card> opponentHand;
}
