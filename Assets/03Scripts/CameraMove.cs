using UnityEngine;
using Cinemachine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] 
    CinemachineFreeLook _freeLookCamera;
    [SerializeField]
    private float _scrollSmooth = 5f;
    [SerializeField]
    private float _cameraXMax;
    [SerializeField]
    private float _cameraYMax;

    private void Start()
    {
       
       

        _freeLookCamera.m_XAxis.m_MaxSpeed = 0f;
        _freeLookCamera.m_YAxis.m_MaxSpeed = 0f;

        //Managers.Client.SetCameraTarget += SetCameraTargetLisener;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _freeLookCamera.m_XAxis.m_MaxSpeed = _cameraXMax;
            _freeLookCamera.m_YAxis.m_MaxSpeed = _cameraYMax;
        }
        else if (Input.GetMouseButtonUp(0))
        {

            _freeLookCamera.m_XAxis.m_MaxSpeed = 0;
            _freeLookCamera.m_YAxis.m_MaxSpeed = 0;
        }

        if (Input.mouseScrollDelta.y != 0)
        {
            SetCameraDistance(Input.mouseScrollDelta.y);
        }
    }

    private void SetCameraDistance(float factor)
    {
        for (int i = 0; i < _freeLookCamera.m_Orbits.Length; ++i)
        {
            _freeLookCamera.m_Orbits[i].m_Radius = _freeLookCamera.m_Orbits[i].m_Radius - factor * _scrollSmooth;
        }
    }

    void SetCameraTargetLisener(Transform target){ //Listen for changes(when our player is spawned)
        _freeLookCamera.Follow = target;
        _freeLookCamera.LookAt = target;
    }
}
