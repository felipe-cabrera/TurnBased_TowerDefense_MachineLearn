using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTypes : MonoBehaviour {

    // Enum with all types of Towers
    [System.Serializable]
    public enum Types
    {
        Voador,
        Quadrupede,
        Bipede,
        Rastejante,
        Subterraneo
    }

    public Types TowerType; // The type of this tower

}
