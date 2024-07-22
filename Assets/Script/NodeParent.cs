using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeParent : MonoBehaviour
{
    public List<Node> nodes;
    public float circleRadius;

    private void Awake()
    {
        // 지식 오브젝트에서가져와 list로 변환
        nodes = GetComponentsInChildren<Node>().ToList<Node>();
        // 인덱스 순으로 정령
        nodes.OrderBy(i => i.nodeIdx);
    }
}
