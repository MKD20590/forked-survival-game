using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float attackDelay;
    [SerializeField] private ObjectPool pool;
    [SerializeField] private GameObject target;

    private void Awake()
    {
        //pool = FindObjectOfType<ObjectPool>();
    }

    private void Start()
    {
        StartCoroutine(AttackEnumerator());
    }

    private IEnumerator AttackEnumerator()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(attackDelay);
        }
    }

    public void Shoot()
    {
        Bullet b = pool.Request<Bullet>();
        if (b != null) 
        { 
            if (transform.parent.name == "Player")
            {
                b.SetPosition(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
                b.SetRotation(transform.rotation);
            }
            else
            {
                b.SetPosition(target.transform.position - transform.position);
                b.SetRotation(transform.rotation);
            }
        }
    }
}
