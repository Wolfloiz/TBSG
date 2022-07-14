
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

  public static UnitActionSystem Instance { get; private set; }
  public event EventHandler OnSelectedUnitChanged;
  [SerializeField] private Unit selectedUnit;
  [SerializeField] private LayerMask layerMask;

  private void Awake()
  {
    if (Instance != null)
    {
      Debug.LogError("there's more than one Unity Action." + transform + Instance);
      Destroy(gameObject);
      return;
    }
    Instance = this;
  }
  // Update is called once per frame
  void Update()
  {


    if (Input.GetMouseButtonDown(0))
    {
      if (TryHandleUnitSelection()) return;
      selectedUnit.Move(MouseWorld.GetPosition());
    }
  }

  private bool TryHandleUnitSelection()
  {

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
    {
      if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
      {
        SetSelectedUnit(unit);
        return true;
      }
    }
    return false;
  }

  private void SetSelectedUnit(Unit unit)
  {
    selectedUnit = unit;

    OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);

    // if (OnSelectedUnitChanged == null)
    // {
    //   return;
    // }
    // OnSelectedUnitChanged(this, EventArgs.Empty);
  }

  public Unit GetSelectedUnit()
  {
    return selectedUnit;
  }
}
