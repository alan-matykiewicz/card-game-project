using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        DragBehaviour dB = eventData.pointerDrag.GetComponent<DragBehaviour>();
        if(dB != null)
        {
            dB.ogParent = this.transform;
        }
    }
}
