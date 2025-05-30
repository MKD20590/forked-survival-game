using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour, IPoolObject
{
    [SerializeField] private Vector3 position;
    float lifetime = 10f;
    //public GameObject enemy;
    void Update()
    {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else
        {
            lifetime = 10f;
            Deactivate();
        }
        if (this.gameObject.tag == "Bullet")
        {    
            transform.position += position * Time.deltaTime * 10;
        }
        else
        {
            transform.position += position * Time.deltaTime * 3;
        }
        //transform.position = Vector3.MoveTowards(transform.position, position.normalized, Time.deltaTime * 10);
    }
    public void Activate()
    {
        GetComponent<TrailRenderer>().Clear();
        if (this.gameObject.tag == "Bullet")
        {
            transform.position = GameObject.Find("Player").transform.position;
        }
        else
        {
            transform.position = transform.parent.position;
        }
        gameObject.SetActive(true);
        GetComponent<TrailRenderer>().emitting = true;
    }

    public void Deactivate()
    {
        GetComponent<TrailRenderer>().emitting = false;
        gameObject.SetActive(false);
    }

    internal void SetPosition(Vector3 position)
    {
        //transform.position = position;
        this.position = new Vector3((position - transform.position).x, (position - transform.position).y, 0);
        if (this.gameObject.tag == "Bullet_Enemy")
        {
            this.position = position;
        }
        this.position.Normalize();
    }

    internal void SetRotation(Quaternion rotation)
    {
        transform.rotation = rotation;
    }
/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
            collision.GetComponent<enemy>().hp -= 20;
            lifetime = 20f;
            Deactivate();
        }
    }*/
}
//jadiin class biar bs dipake sm enemy jg
/*public class CollisionHandler : MonoBehaviour
{
    //public UnityEvent onCollide; //buat function tanpa parameter
    //public UnityEvent<Color> onCollide_color; //buat function dengan parameter
    public UnityEvent onCollide_ply;
    public UnityEvent<enemy> onCollide_dmg;
    public List<string> targetTag; //yg sesuai targetTag, baru dijalanin functionnya (misal: enemy overlap sm enemy = di ignore) -> hrsnya targetTag buat enemy = "Player"
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //function yg jalan itu function yg gk ada parameternya
        //onCollide += Blink;
        //onCollide_color += setColor;

        enemy e = collision.GetComponent<enemy>();
        player p = collision.GetComponent<player>();
        if (gameObject.name == "Player")
        {
            targetTag.Add("enemy");
            onCollide_ply.AddListener(e.attack);
        }
        else
        {
            targetTag.Add("Player");
            onCollide_dmg.AddListener(p.attack);
        }

        foreach (string tag in targetTag)
        {
            if (e == null || e.tag != tag)
            {
                return;
            }
            else if (p == null || p.tag != tag)
            {
                return;
            }
            //onCollide?.Invoke();
            onCollide_dmg?.Invoke(e);
            onCollide_ply?.Invoke();
            Destroy(gameObject);
            return;
        }

    }
*//*    public void setColor(Color color)
    {

    }
    public void Blink()
    {

    }*//*
}*/