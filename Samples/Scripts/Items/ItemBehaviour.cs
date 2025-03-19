using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemBehaviour : MonoBehaviour {
    public UnityEvent onActivate;
    public bool requiresKey = false;

    public void ClearEventInstructions() {
        Destroy(this);
    }
}
