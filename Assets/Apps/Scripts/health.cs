using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class health : MonoBehaviour
{
    public int current;
    public int max;

    public UnityEvent lowHP;
    public void reduceHealth(int value)
    {
        current -= value;
        if (current <= 0)
        {
            current = 0;
            lowHP.Invoke();
        }
    }
}
