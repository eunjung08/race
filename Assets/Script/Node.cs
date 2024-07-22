using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int nodeIdx;

    public float circleRadius;

    private void Awake()
    {
        var Name = " ";

        foreach (var n in gameObject.name)
        {
            if (n >= '0' && n <= '9')
            {
                Name += n;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, circleRadius);
    }
}
