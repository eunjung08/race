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
        // ���� ������Ʈ���������� list�� ��ȯ
        nodes = GetComponentsInChildren<Node>().ToList<Node>();
        // �ε��� ������ ����
        nodes.OrderBy(i => i.nodeIdx);
    }
}
