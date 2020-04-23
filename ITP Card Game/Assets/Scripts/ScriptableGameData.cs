using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data")]
public class ScriptableGameData : ScriptableObject
{
    public static byte cardHandLimit = 10;
    public static byte startCoins = 20;

    //PLAYER-1
    //player 1 username
    public short player1Coins;
    public short player1VictoryPoints;
    public Deck player1Deck;
    public List<Card> player1Hand;

    //PLAYER-2
    //player 2 username
    public short player2Coins;
    public short player2VictoryPoints;
    public Deck player2Deck;
    public List<Card> player2Hand;
}
