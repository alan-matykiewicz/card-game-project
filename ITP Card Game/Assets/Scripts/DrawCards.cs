using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject playerHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick()
    {
        GameObject card = Instantiate(cardPrefab, new Vector2(0, 0), Quaternion.identity);
        card.transform.SetParent(playerHand.transform, false);
    }
}
