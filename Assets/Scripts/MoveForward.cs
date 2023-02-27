using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public bool start;
    public float speed = 10f;
    [SerializeField] private LayerMask layerMask;
    private float checkDistance = 3f;
    [SerializeField] private Transform rayPosition;

    private void Update()
    {
        if (!start)
        {

        }
        if (start)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            CheckDistance();
        }
        
    }
    private void CheckDistance()
    {
        if (Physics.Raycast(rayPosition.position, rayPosition.forward, out RaycastHit raycastHit, checkDistance, layerMask))
        {
            float distance = Vector3.Distance(rayPosition.position, raycastHit.point);
            {
                if(distance <= checkDistance)
                {
                    speed = 0;
                }
            }
        }
    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(rayPosition.position, rayPosition.forward * checkDistance);
    }
}
