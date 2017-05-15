﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanBehavior : MonoBehaviour
{

    private float rotateX;
    private float rotateY;
    private float rotateZ;

    public List<Enemy> enemiesToKill;

    // Use this for initialization
    void Start()
    {
        // Randomise the rotation of bean
        rotateX = Random.Range(-2f, 2f);
        rotateY = Random.Range(-2f, 2f);
        rotateZ = Random.Range(-2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateX, rotateY, rotateZ);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Enemy target = col.gameObject.GetComponent<Enemy>();
            enemiesToKill.Add(target);
            StartCoroutine(killEnemies(.25f));
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            Enemy target = col.gameObject.GetComponent<Enemy>();
            enemiesToKill.Remove(target);
        }
    }

    private IEnumerator killEnemies(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        for (int i = 0; i < enemiesToKill.Count; i++)
        {
            enemiesToKill[i].health -= 3;
        }
    }
}
