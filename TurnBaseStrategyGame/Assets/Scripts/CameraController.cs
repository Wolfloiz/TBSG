using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
  // Start is called before the first frame update
  private const float MIN_FOLLOW_Y_OffSET = 2f;
  private const float MAX_FOLLOW_Y_OffSET = 12f;

  private Vector3 targetFollowOffset;

  [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
  private CinemachineTransposer cinemachineTransposer;

  void Start()
  {
    cinemachineTransposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    targetFollowOffset = cinemachineTransposer.m_FollowOffset;

  }
  // Update is called once per frame
  void Update()
  {

    handleMoveCamera();
    handleRotationCamera();
    handleZoomCamera();
  }

  private void handleZoomCamera()
  {
    float zoomAmount = 1f;
    if (Input.mouseScrollDelta.y > 0)
    {
      targetFollowOffset.y -= zoomAmount;
    }

    if (Input.mouseScrollDelta.y < 0)
    {
      targetFollowOffset.y += zoomAmount;
    }

    targetFollowOffset.y = Mathf.Clamp(targetFollowOffset.y, MIN_FOLLOW_Y_OffSET, MAX_FOLLOW_Y_OffSET);

    float zoomSpeed = 5;
    cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetFollowOffset, Time.deltaTime * zoomSpeed);
  }

  private void handleRotationCamera()
  {
    Vector3 rotationVector = new Vector3(0, 0, 0);
    if (Input.GetKey(KeyCode.Q))
    {
      rotationVector.y = +1f;
    }
    if (Input.GetKey(KeyCode.E))
    {
      rotationVector.y = -1f;
    }
    float rotationSpeed = 100f;

    transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
  }

  private void handleMoveCamera()
  {
    Vector3 inputMoveDir = new Vector3(0, 0, 0);

    if (Input.GetKey(KeyCode.W))
    {
      inputMoveDir.z = +1f;
    }


    if (Input.GetKey(KeyCode.S))
    {
      inputMoveDir.z = -1f;
    }

    if (Input.GetKey(KeyCode.A))
    {
      inputMoveDir.x = -1f;
    }

    if (Input.GetKey(KeyCode.D))
    {
      inputMoveDir.x = +1f;
    }

    float moveSpeed = 10f;
    Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
    transform.position += moveSpeed * moveVector * Time.deltaTime;
  }
}
