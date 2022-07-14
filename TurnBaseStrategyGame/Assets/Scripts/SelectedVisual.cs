using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedVisual : MonoBehaviour
{

  [SerializeField] private Unit unit;

  private MeshRenderer meshRenderer;

  void Awake()
  {
    meshRenderer = this.GetComponent<MeshRenderer>();
  }

  private void Start()
  {
    UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChanged;

    UpdateVisual();
  }

  private void UnitActionSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
  {
    Debug.Log("o evento aconteceu!!!");
    UpdateVisual();
  }

  private void UpdateVisual()
  {
    if (UnitActionSystem.Instance.GetSelectedUnit() == unit)
    {
      meshRenderer.enabled = true;
    }
    else
    {
      meshRenderer.enabled = false;
    }
  }
}
