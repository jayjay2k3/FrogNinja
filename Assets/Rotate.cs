using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    float horizontal;
    public float rotateSpeed;

    private void Update()
    {
        Rotating();
    }
    void Rotating()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, horizontal * rotateSpeed);
    }
}
