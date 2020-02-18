using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObject : MonoBehaviour
{

    public ScriptableCard cardScript;

    public Text cardName;
    public Text description;
    public Text cost;
    public Text power;

    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        cardName.text       = cardScript.name;
        description.text    = cardScript.description;
        cost.text           = cardScript.cost.ToString();
        power.text          = cardScript.power.ToString();
        image.sprite        = cardScript.image;
    }

}
