using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movie : MonoBehaviour
{
    public void Movie_Lvl(Transform place)
    {
        transform.position = place.position;
    }
}
