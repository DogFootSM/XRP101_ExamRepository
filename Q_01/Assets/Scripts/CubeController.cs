using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //Private Set으로 되어 있어 값 할당이 불가하여 private 제거
    public Vector3 SetPoint { get; set; }

    public void SetPosition()
    {
        transform.position = SetPoint;
    }
}
