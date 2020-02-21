using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public ScriptableCard cardScript;

    public Text cardNameText;
    public Text descriptionText;
    public Text costText;
    public Text powerText;
    public Image image;

    public new string name;
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        cardNameText.text       = cardScript.name;
        descriptionText.text    = cardScript.description;
        costText.text           = cardScript.cost.ToString();
        powerText.text          = cardScript.power.ToString();
        image.sprite        = cardScript.image;

        name = cardNameText.text;
        cost = cardScript.cost;
    }

    public void PlayCard()
    {
        //disable / dont show card cost anymore, because the card was already paid for
        Transform costGroup = transform.Find("Cost Group");
        costGroup.gameObject.SetActive(false);
    }

}
