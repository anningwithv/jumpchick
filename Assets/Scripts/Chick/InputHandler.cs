using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    public System.Action OnMousePressed = null;
    public System.Action OnMouseReleased = null;

	void Start () {
		
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (OnMousePressed != null) {
                OnMousePressed.Invoke();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (OnMouseReleased != null)
            {
                OnMouseReleased.Invoke();
            }
        }
    }
}
