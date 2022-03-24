using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInventory : MonoBehaviour
{
  public int numJewels { get; private set; }

    public void jewelsCollected()
    {
        numJewels++;
    }
}
