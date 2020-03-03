using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This ability grants you coins
 */
public class A_Gain : Ability
{
    private short coinsToGain;

    public A_Gain(short coins)
    {
        coinsToGain = coins;
    }

    public override void Use()
    {
        Gain(coinsToGain);
    }

    public void Gain(short coins)
    {
        gameData.playerCoins += coins;
    }
}
