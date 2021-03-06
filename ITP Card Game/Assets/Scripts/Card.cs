﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType { Human, Building, Farm, Soldier};
public enum CardCategory { Unit, Instant, Event, Victory };
public enum Faction { Blue, Black };

public class Card : MonoBehaviour
{

    public ScriptableCard cardScript;
    public Sprite goldTemplate;

    public Text cardNameText;
    public Text descriptionText;
    public Text costText;
    public Text powerText;
    public Text typeText;
    public Image image;

    public new string name;
    public int cost;
    public int power;
    public bool isGold;

    public Ability[] abilities;
    
    public bool isPlayed = false;

    public CardType[] types;
    public CardCategory category;
    public Faction faction;
    
    void Awake()
    {
        cardNameText.text       = cardScript.name;
        descriptionText.text    = cardScript.description;
        costText.text           = cardScript.cost.ToString();
        powerText.text          = cardScript.power.ToString();
        image.sprite            = cardScript.image;

        string txt = "";
        for(int i = 0; i < cardScript.types.Length; i++)
        {
            txt += cardScript.types[i] + " ";
        }
        typeText.text = txt;

        name    = cardNameText.text;
        cost    = cardScript.cost;
        power   = cardScript.power;
        types   = cardScript.types;
        isGold  = cardScript.isGold;

        category    = cardScript.category;
        faction     = cardScript.faction;

        if (isGold)
        {
            Transform temp = transform.Find("Card Front/Card Background");
            Image background = temp.gameObject.GetComponent<Image>();
            background.sprite = goldTemplate;
        }

        if (cardScript.category.Equals(CardCategory.Instant))
        {
            Transform powerGroup = transform.Find("Card Front/Power Group");
            powerGroup.gameObject.SetActive(false);
            typeText.text = "Instant";
        }

        transform.Find("Card Front").gameObject.SetActive(true);
        transform.Find("Card Back").gameObject.SetActive(false);

        abilities = cardScript.abilities;
    }

    /**
     * returns false if this card can't be played right now, 
     * for example if this cards cost exceeds the player's coins
     * returns true if this card has been played successfully
     */
    public bool PlayCard()
    {
        int playerCoins = GameHandler.Instance.gameData.player1Coins;
        if (this.cost > playerCoins) return false;

        isPlayed = true;
        //disable / dont show card cost anymore, because the card was already paid for
        Transform costGroup = transform.Find("Card Front/Cost Group");
        costGroup.gameObject.SetActive(false);
        //remove this card from player's hand
        GameHandler handler = GameHandler.Instance;
        handler.gameData.player1Hand.Remove(this);

        //todo: subtract this cards cost from playercoins

        //send the played card over the network
        int sibIndex = this.GetComponent<DragBehaviour>().GetPlaceholderSiblingIndex();
        NetworkManager.instance.CardPlayed(this.name, sibIndex);

        //when a card is played, all of its abilities are used
        if (abilities != null)
        {
            foreach(Ability a in abilities)
            {
                a.Use();
            }
        }
        return true;
    }

    public void Flip()
    {
        Transform front = transform.Find("Card Front");
        Transform backside = transform.Find("Card Back");
        if (front.gameObject.activeSelf)
        {
            front.gameObject.SetActive(false);
            backside.gameObject.SetActive(true);
        }
        else
        {
            front.gameObject.SetActive(true);
            backside.gameObject.SetActive(false);
        }
    }

    public void SetCardScript(ScriptableCard script)
    {
        if (script != null)
            cardScript = script;
        Awake();
    }

    public bool IsPlayed()
    {
        return isPlayed;
    }

}
