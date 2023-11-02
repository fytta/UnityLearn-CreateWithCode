using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Animal: MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }

    void Update()
    {
        MoveForward();
    }

    protected void MoveForward()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
