using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    private void Awake()
    {
        SetCubePosition(3, 0, 3);
    }

    private void Start()
    {
        CreateCube();
    }

    private void SetCubePosition(float x, float y, float z)
    {
        //이동할 위치
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;

    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();

        //잘못된 값 대입으로 수정
        _cubeController.SetPoint = _cubeSetPoint;

        //Controller 컴포넌트 가져온 후 참조하도록 위치 변경
        _cubeController.SetPosition();
    }
}
