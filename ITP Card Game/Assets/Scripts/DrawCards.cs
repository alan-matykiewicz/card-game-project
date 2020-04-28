using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject player1Hand;
    public ScriptableGameData gameData;

    public void OnClick()
    {
        try
        {
            if (gameData.player1Hand.Count < ScriptableGameData.cardHandLimit)
            {
                ScriptableCard nextCard = gameData.player1Deck.Draw();
                Card card = Instantiate(cardPrefab, new Vector2(0, 0), Quaternion.identity).GetComponent<Card>();
                card.SetCardScript(nextCard);
                gameData.player1Hand.Add(card);
<<<<<<< HEAD
                card.transform.SetParent(playerHand.transform, false);
                //NetworkManager.instance.CardDraw(GameHandler.Instance.gameData.player1Hand.Count);
=======
                card.transform.SetParent(player1Hand.transform, false);
                NetworkManager.instance.CardDraw(GameHandler.Instance.gameData.player1Hand.Count);
>>>>>>> a47613272e6cbdc8dd7f322973b9933b503625db
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
