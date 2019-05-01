using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class LightSaber : VRTK_InteractableObject
{

    // Use this for initialization

    public Color activeColor;
    public Color deactivatedColor;

    public GameObject blade;

    Vector3 startSize = new Vector3(0, 0, 0);
    Vector3 endSize = new Vector3(0.9f, 4f, 0.9f);

    public override void StartUsing(VRTK_InteractUse currentObject = null)
    {
        base.StartUsing(currentObject);
        blade.transform.localScale = endSize;
        print("start");

    }

    public override void StopUsing(VRTK_InteractUse previousUsingObject = null, bool resetUsingObjectState = true)
    {
        base.StopUsing(previousUsingObject, resetUsingObjectState);
        blade.transform.localScale = startSize;
        print("stop");
    }
}


