using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //Private Set���� �Ǿ� �־� �� �Ҵ��� �Ұ��Ͽ� private ����
    public Vector3 SetPoint { get; set; }

    public void SetPosition()
    {
        transform.position = SetPoint;
    }
}
