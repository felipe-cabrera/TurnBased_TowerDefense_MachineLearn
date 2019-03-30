using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDragAndDrop : MonoBehaviour {

	public void RemoveDragDrop()
    {
        GameObject[] dragDrops = GameObject.FindGameObjectsWithTag("TowerDragDrop");
        foreach(GameObject dragDrop in dragDrops)
        {
            GameObject.Destroy(dragDrop.GetComponent<DragAndDrop>());
        }
    }
}
