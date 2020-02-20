using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragBehaviour : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform ogParent = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        ogParent = transform.parent;
        transform.SetParent(transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(ogParent);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
