using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Car : MonoBehaviour
{
    NodeParent nodeParent;

    public Rigidbody carRigid;
    public bool isMove;

    [SerializeField] float moveSpeed;
    [SerializeField] float steerPower;
    [SerializeField] float minDistance;
    [SerializeField] int curIndex;

    private void Awake()
    {
        // 씬에서 <>안에 걸 찾기
        nodeParent = FindObjectOfType<NodeParent>();
    }

    private void Start()
    {
        carRigid.transform.SetParent(null);
    }

    private void Update()
    {
        transform.position = carRigid.transform.position;
        carRigid.transform.rotation = transform.rotation;
        if (isMove)
        {
            Steerring();
        }
        FindNextNode();
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            Movement();
        }
    }

    void Movement()
    {
        int move = isMove ? 1 : 0;
        carRigid.AddForce(transform.forward * move * moveSpeed, ForceMode.Acceleration);
    }

    void FindNextNode()
    {
        if (curIndex >= nodeParent.nodes.Count)
        {
            return;
        }
        if (curIndex < nodeParent.nodes.Count)
        {
            if (minDistance > Vector3.Distance(transform.position
            , nodeParent.nodes[curIndex].transform.position))
            {
                curIndex++;
            }
            if (curIndex >= nodeParent.nodes.Count)
            {
                isMove = false;
                return;
            }
        }
    }

    void Steerring()
    {
        if (curIndex >= nodeParent.nodes.Count) return;
        Vector3 steer = nodeParent.nodes[curIndex].transform.position - transform.position;
        if (steer.magnitude < 0.1f)
        {
            return;
        }
        steer.y = 0;
        Quaternion steerAngle = Quaternion.LookRotation(steer);
        transform.rotation = Quaternion.RotateTowards(transform.rotation
            , steerAngle, steerPower * Time.deltaTime);
    }
}
