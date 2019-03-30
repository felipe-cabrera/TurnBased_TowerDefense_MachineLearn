using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour {

    public Color color; // New color to our material

	void Start () { 

        // Change material properties
        this.GetComponent<MeshRenderer>().material.color = color;
        this.GetComponent<MeshRenderer>().sortingLayerName = "Foreground";
        this.GetComponent<MeshRenderer>().sortingOrder = 10;
    }

}
