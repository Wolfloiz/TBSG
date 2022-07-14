using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
  private Vector3 targetPosition;

  private GridPosition gridPosition;
  [SerializeField] private Animator unitAnimator;
  // Start is called before the first frame update

  void Awake()
  {
    targetPosition = transform.position;

  }

  void Start()
  {
    gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
    LevelGrid.Instance.SetUnitAtGridPosition(gridPosition, this);
  }

  // Update is called once per frame
  void Update()
  {

    float stopDistance = .1f;
    if (Vector3.Distance(transform.position, targetPosition) > stopDistance)
    {
      Vector3 moveDirection = (targetPosition - transform.position).normalized;
      float moveSpeed = 4f;
      transform.position += moveDirection * Time.deltaTime * moveSpeed;

      float rotateSpeed = 10f;
      transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);

      unitAnimator.SetBool("IsWalking", true);
    }
    else
    {
      unitAnimator.SetBool("IsWalking", false);
    }

    GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

    if (newGridPosition != gridPosition)
    {
      LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);
      gridPosition = newGridPosition;
    }

  }

  public void Move(Vector3 targetPosition)
  {
    this.targetPosition = targetPosition;
  }
}
