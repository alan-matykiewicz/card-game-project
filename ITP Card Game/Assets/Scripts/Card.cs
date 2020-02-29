using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
    Human, 
    Wizard,
    Beast
};

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

    public CardType type;

    // Start is called before the first frame update
    void Start()
    {
        cardNameText.text       = cardScript.name;
        descriptionText.text    = cardScript.description;
        costText.text           = cardScript.cost.ToString();
        powerText.text          = cardScript.power.ToString();
        image.sprite            = cardScript.image;

        typeText.text = cardScript.type.ToString();

        name    = cardNameText.text;
        cost    = cardScript.cost;
        power   = cardScript.power;
        type    = cardScript.type;
        isGold  = cardScript.isGold;

        if (isGold)
        {
            Transform temp = transform.Find("Card Background");
            Image background = temp.gameObject.GetComponent<Image>();
            background.sprite = goldTemplate;
        }
    }

    public void PlayCard()
    {
        //disable / dont show card cost anymore, because the card was already paid for
        Transform costGroup = transform.Find("Cost Group");
        costGroup.gameObject.SetActive(false);
    }

}
