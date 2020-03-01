using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck : ScriptableObject
{
    public List<ScriptableCard> original;
    public List<ScriptableCard> instance;

    public byte maxDeckSize = 35;
    public byte minMaxRegularCards = 30;
    public byte minVictoryCards = 3;
    public byte maxVictoryCards = 5;

    public void Init(List<ScriptableCard> list)
    {
        original = list;
        instance = new List<ScriptableCard>(original);
    }

    /**
     * Shuffles instance of this deck
     */
    public void Shuffle()
    {
        System.Random rand = new System.Random();
        int n = instance.Count;
        while(n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            ScriptableCard value = instance[k];
            instance[k] = instance[n];
            instance[n] = value;
        }
    }

    public ScriptableCard Draw()
    {
        ScriptableCard temp = instance[0];
        instance.RemoveAt(0);
        return temp;
    }

    public bool AddCard(ScriptableCard script)
    {
        original.Add(script);
        return true;
    }

    public bool IsValid()
    {
        byte size = (byte) original.Count;
        return size >= 33 && size <= 35;
    }
}
