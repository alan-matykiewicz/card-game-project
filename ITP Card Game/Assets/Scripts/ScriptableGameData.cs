using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Data", menuName = "Game Data")]
public class ScriptableGameData : ScriptableObject
{
    //PLAYER-DATA
    //player username
    //player coins
    //player VPs
    public Deck playerDeck;
    //player hand

    //OPPONENT-DATA
    //enemy username
    //enemy coins
    //enemy VPs
    //enemy deck
    //enemy hand 

}
