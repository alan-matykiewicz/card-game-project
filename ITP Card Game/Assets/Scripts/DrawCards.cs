using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject playerHand;

    public void OnClick()
    {
        GameObject card = Instantiate(cardPrefab, new Vector2(0, 0), Quaternion.identity);
        card.transform.SetParent(playerHand.transform, false);
    }
}
