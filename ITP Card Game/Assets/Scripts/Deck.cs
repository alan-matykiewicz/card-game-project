using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> original;
    public List<Card> instance;

    public byte maxDeckSize = 35;
    public byte minMaxRegularCards = 30;
    public byte minVictoryCards = 3;
    public byte maxVictoryCards = 5;

    public Deck()
    {
        original = new List<Card>();
        instance = original;
    }

    public Deck(List<Card> cards)
    {
        original = cards;
        instance = original;
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
            Card value = instance[k];
            instance[k] = instance[n];
            instance[n] = value;
        }
    }

    public Card Draw()
    {
        Card temp = instance[0];
        instance.RemoveAt(0);
        return temp;
    }

    public bool AddCard(ScriptableCard script)
    {
        Card card = new Card();
        card.SetCardScript(script);
        return AddCard(card);
    }

    public bool AddCard(Card card)
    {
        original.Add(card);
        return true;
    }

    public bool IsValid()
    {
        byte size = (byte) original.Count;
        return size >= 33 && size <= 35;
    }
}
