using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This ability grants you coins
 */
[CreateAssetMenu(fileName ="New Gain" , menuName ="Ability/Gain")]
public class A_Gain : Ability
{
    public short coinsToGain;

    public override void Use()
    {
        gameData = GameHandler.Instance.gameData;
        gameData.playerCoins += coinsToGain;
    }
}
