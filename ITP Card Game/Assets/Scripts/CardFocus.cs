using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardFocus : MonoBehaviour, IPointerClickHandler
{
    public GameObject cardPrefab;
    private Card cardCopy;
    public GameObject backgroundPrefab;
    private GameObject background;
    public TextMeshProUGUI tooltipPrefab;
    private TextMeshProUGUI tooltip;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            background = Instantiate(backgroundPrefab, new Vector2(0, 0), Quaternion.identity);
            background.transform.SetParent(transform.parent.parent);
            background.transform.localPosition = new Vector3(0, 0);
            cardCopy = Instantiate(cardPrefab, new Vector2(200,200), Quaternion.identity).GetComponent<Card>();
            cardCopy.SetCardScript(this.GetComponent<Card>().cardScript);
            cardCopy.transform.SetParent(transform.parent.parent);
            cardCopy.transform.localPosition = new Vector3(0, 0, 0);
            cardCopy.transform.localScale += new Vector3(1.2f,1.2f,0);
            tooltip = Instantiate(tooltipPrefab, new Vector2(0, 0), Quaternion.identity);
            tooltip.transform.SetParent(transform.parent.parent);
            tooltip.transform.localPosition = new Vector3(-296.46f, 131.56f, 0);
            tooltip.enabled = true;
        }
    }
    public void Update()
    {
        if(cardCopy == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Destroy(cardCopy.gameObject);
            Destroy(background);
            Destroy(tooltip);
        }
    }
}
