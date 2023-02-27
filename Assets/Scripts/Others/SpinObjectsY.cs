using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpinObjectsY : MonoBehaviour
{
    public float spinSpeed;
    public RotateY rotateY;
    public enum RotateY
    {
        Right,
        Left
    }
    

    // Update is called once per frame
    void Update()
    {
        if(rotateY== RotateY.Right)
        {
            transform.Rotate(Vector3.right, spinSpeed * Time.deltaTime);
        }
        if (rotateY == RotateY.Left)
        {
            transform.Rotate(Vector3.left, spinSpeed * Time.deltaTime);
        }
    }
}
