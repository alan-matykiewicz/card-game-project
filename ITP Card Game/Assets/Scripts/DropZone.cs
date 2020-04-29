using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DragBehaviour dB = eventData.pointerDrag.GetComponent<DragBehaviour>();
        if(dB != null)
        {
            if(dB.ogParent != this.transform)
            {
                Card c = eventData.pointerDrag.GetComponent<Card>();
                if (c.PlayCard())
                {
                    dB.ogParent = this.transform;
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragBehaviour dB = eventData.pointerDrag.GetComponent<DragBehaviour>();
        if (dB != null)
        {
            dB.placeholderParent = this.transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        DragBehaviour dB = eventData.pointerDrag.GetComponent<DragBehaviour>();
        if (dB != null && dB.placeholderParent==this.transform)
        {
            dB.placeholderParent = dB.ogParent;
        }
    }
}
