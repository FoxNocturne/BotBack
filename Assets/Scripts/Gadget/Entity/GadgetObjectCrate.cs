using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetObjectCrate : GadgetObject
{
    protected override void Setup()
    {
        this.isGrabable = true;
    }
}
