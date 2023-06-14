using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chain_Render : MonoBehaviour
{
    LineRenderer line;
    public Transform entryPoint;
    public Transform exitPoint;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        line.SetPosition(0, entryPoint.position);
        line.SetPosition(1, exitPoint.position);
    }
}
