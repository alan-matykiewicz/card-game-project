using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject playerHand;
    public ScriptableGameData gameData;

    public void OnClick()
    {
        try
        {
            ScriptableCard nextCard = gameData.playerDeck.Draw();
            Card card = Instantiate(cardPrefab, new Vector2(0, 0), Quaternion.identity).GetComponent<Card>();
            card.SetCardScript(nextCard);
            card.transform.SetParent(playerHand.transform, false);
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Debug.Log("No more cards to draw.");
        }
    }
}
