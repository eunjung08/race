using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class Car_Movement : MonoBehaviour
{
    public Rigidbody sphereRigid;
    public float MoveSpeed = 0f;
    public float speedUpTimer;
    public float angleForce;

    public float moveSpeed;

    private float inputHorizontal;
    private float inputVertical;

    private void Awake()
    {
        sphereRigid.transform.SetParent(null);
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        transform.position = sphereRigid.transform.position;
        sphereRigid.transform.rotation = transform.rotation;

        if (inputVertical != 0)
        {
            MoveSpeed = Mathf.Lerp(MoveSpeed, moveSpeed,
                speedUpTimer * Time.deltaTime);
        }
        else
        {
            MoveSpeed = 0;
        }

        // 힘에 따른 회전
        transform.Rotate(0,inputHorizontal * angleForce * Time.deltaTime, 0, Space.World);
    }

    void FixedUpdate()
    {
        // 이동 방향대로 움직임
        sphereRigid.AddForce(transform.forward * inputVertical * moveSpeed
            , ForceMode.Acceleration);
    }
}
