using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletTypes : MonoBehaviour
{

    [System.Serializable]
    public enum Types
    {
        Blue,
        Yellow,
        Green,
        Purple,
        Orange
    }

    public Types BulletType; // The type of this Bullet
}

