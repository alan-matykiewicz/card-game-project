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
            if (gameData.playerHand.Count < ScriptableGameData.cardHandLimit)
            {
                ScriptableCard nextCard = gameData.playerDeck.Draw();
                Card card = Instantiate(cardPrefab, new Vector2(0, 0), Quaternion.identity).GetComponent<Card>();
                card.SetCardScript(nextCard);
                gameData.playerHand.Add(card);
                card.transform.SetParent(playerHand.transform, false);
            }
            else
            {
                Debug.Log("Deine Hand ist voll");
                // die karte soll gezogen und discarded werden
            }
        }
        catch (System.ArgumentOutOfRangeException)
        {
            Debug.Log("No more cards to draw.");
        }
    }
}
