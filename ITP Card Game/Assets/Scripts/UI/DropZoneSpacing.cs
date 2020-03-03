using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropZoneSpacing : MonoBehaviour
{
    public HorizontalLayoutGroup hlg;

    public void CheckSpacing()
    {
        hlg.spacing = 15 - (this.transform.childCount * 5);
        if (hlg.spacing < -50)
            hlg.spacing = -50;
    }
}
