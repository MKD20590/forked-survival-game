using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerHandler : MonoBehaviour
{ 
        //public UnityEvent onCollide; //buat function tanpa parameter
        //public UnityEvent<Color> onCollide_color; //buat function dengan parameter
        public UnityEvent onCollide;
        public List<string> targetTag; //yg sesuai targetTag, baru dijalanin functionnya (misal: enemy overlap sm enemy = di ignore) -> hrsnya targetTag buat enemy = "Player"
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (targetTag.Contains(collision.tag))
        {
            onCollide?.Invoke();
        }
        return;
    }
}
