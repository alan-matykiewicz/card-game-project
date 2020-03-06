using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform ogParent = null;
    public Transform placeholderParent = null;

    private GameObject placeholder = null;

    private Vector2 offsetVector;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (this.GetComponent<Card>().IsPlayed())
            return;

        placeholder = new GameObject();
        placeholder.transform.SetParent(this.transform.parent);
        placeholder.transform.localScale = new Vector3(1,1,1);
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;

        offsetVector = eventData.position - (Vector2)transform.position;

        ogParent = transform.parent;
        placeholderParent = ogParent;
        transform.SetParent(transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (this.GetComponent<Card>().IsPlayed())
            return;

        transform.position = (Vector2)Input.mousePosition - offsetVector;

        if (placeholder.transform.parent != placeholderParent)
            placeholder.transform.SetParent(placeholderParent);

        int newSiblingIndex = placeholderParent.childCount;
        for(int i = 0; i < placeholderParent.childCount; i++)
        {
            if(this.transform.position.x < placeholderParent.GetChild(i).position.x)
            {
                newSiblingIndex = i;

                if (placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    newSiblingIndex--;

                break;
            }
        }

        placeholder.transform.SetSiblingIndex(newSiblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ogParent);
        transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());

        GetComponent<CanvasGroup>().blocksRaycasts = true;

        offsetVector = new Vector2(0, 0);

        Destroy(placeholder);

        if (this.GetComponent<Card>().IsPlayed())
        {
            this.enabled = false;
        }
    }
}
