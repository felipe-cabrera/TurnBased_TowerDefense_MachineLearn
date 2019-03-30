using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletTypes : MonoBehaviour
{

    [System.Serializable]
    public enum Types
    {
        Voador,
        Quadrupede,
        Bipede,
        Rastejante,
        Subterraneo
    }

    public Types BulletType; // The type of this Bullet
}

