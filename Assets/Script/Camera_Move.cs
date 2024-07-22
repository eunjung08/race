using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Move : MonoBehaviour
{
    public Transform Target;

    public float MoveSpeed;
    public float Height;
    public float distance;

    void Update()
    {
        Vector3 dir = 
            Target.transform.position -
            Target.forward * distance + Vector3.up * Height;

        transform.position = Vector3.Lerp(transform.position,
            dir, MoveSpeed * Time.deltaTime);
        transform.LookAt(Target.position);
        }
}
