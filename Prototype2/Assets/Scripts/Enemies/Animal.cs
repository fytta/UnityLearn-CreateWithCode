using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Animal: MonoBehaviour
{
    public float speed;
    private int _hp;
    protected int hp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    void Start()
    {
        hp = 2;
    }

    void Update()
    {
        MoveForward();
    }

    protected void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);

        hp--;
        if (hp == 0)
        {
            PlayerController.score++;
            Destroy(gameObject);
        }
    }
}
