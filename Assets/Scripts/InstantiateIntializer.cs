using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InstantiateIntializer : ARTrackedImage
{
    private void Start() => ModelManager.instance.SetModelByName(referenceImage.name, gameObject);
}
