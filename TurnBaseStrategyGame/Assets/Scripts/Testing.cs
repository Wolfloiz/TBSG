using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{

  [SerializeField] Transform gridDebugLayout;
  private GridSystem gridSystem;
  void Start()
  {
    gridSystem = new GridSystem(10, 10, 2f);
    gridSystem.CreateDebugObjects(gridDebugLayout);

  }

  // Update is called once per frame
  void Update()
  {
    //Debug.Log(MouseWorld.GetPosition());
    Debug.Log(gridSystem.GetGridPosition(MouseWorld.GetPosition()));

  }
}
