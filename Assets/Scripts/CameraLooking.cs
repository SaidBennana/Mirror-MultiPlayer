using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLooking : MonoBehaviour
{
    [SerializeField] float _senX, _senY;

    [SerializeField] CinemachineVirtualCamera cinemachineVirtual;

    Cinemachine3rdPersonFollow cinemachine3Rd;
    [SerializeField] Transform TargetLookingPlayer;


    float _Mouse_X, _Mouse_Y;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cinemachine3Rd = cinemachineVirtual.GetCinemachineComponent<Cinemachine3rdPersonFollow>();
    }


    // Update is called once per frame
    void Update()
    {
        _Mouse_X += Input.GetAxis("Mouse X") * _senX * Time.deltaTime;
        _Mouse_Y += Input.GetAxis("Mouse Y") * _senY * Time.deltaTime;

        TargetLookingPlayer.rotation = Quaternion.Euler(-_Mouse_Y, _Mouse_X, 0);

        // clampValue(cinemachine3Rd.ShoulderOffset.y, -1f, 1f);
        // cinemachine3Rd.ShoulderOffset.y = _Mouse_Y;


    }

    void clampValue(float value, float min, float max)
    {
        if (value < min)
        {
            cinemachine3Rd.ShoulderOffset.y = min;
            _Mouse_Y = min;
        }
        if (value > max)
        {
            cinemachine3Rd.ShoulderOffset.y = max;
            _Mouse_Y = max;

        }

    }


}
