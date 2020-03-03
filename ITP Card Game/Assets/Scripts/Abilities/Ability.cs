using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability
{
    protected ScriptableGameData gameData;

    public Ability()
    {
        gameData = GameObject.Find("GameHandler").GetComponent<GameHandler>().gameData;
    }

    public abstract void Use();
}
