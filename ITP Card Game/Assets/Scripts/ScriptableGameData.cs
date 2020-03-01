using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data")]
public class ScriptableGameData : ScriptableObject
{
    public static byte cardHandLimit = 10;

    //PLAYER-DATA
    //player username
    //player coins
    //player VPs
    public Deck playerDeck;
    public List<Card> playerHand;

    //OPPONENT-DATA
    //enemy username
    //enemy coins
    //enemy VPs
    //enemy deck
    //enemy hand

}
