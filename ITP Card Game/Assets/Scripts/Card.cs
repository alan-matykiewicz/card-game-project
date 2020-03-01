using System.Collections;
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

    public CardType[] types;
    public CardCategory category;
    public Faction faction;

    // Start is called before the first frame update
    void Start()
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
            Transform temp = transform.Find("Card Background");
            Image background = temp.gameObject.GetComponent<Image>();
            background.sprite = goldTemplate;
        }

        if (cardScript.category.Equals(CardCategory.Instant))
        {
            Transform powerGroup = transform.Find("Power Group");
            powerGroup.gameObject.SetActive(false);
            typeText.text = "Instant";
        }
    }

    public void PlayCard()
    {
        //disable / dont show card cost anymore, because the card was already paid for
        Transform costGroup = transform.Find("Cost Group");
        costGroup.gameObject.SetActive(false);
    }

    public void SetCardScript(ScriptableCard script)
    {
        if (script != null)
            cardScript = script;
        Start();
    }

}
