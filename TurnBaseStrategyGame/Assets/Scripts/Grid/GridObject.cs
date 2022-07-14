using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{

  private GridSystem gridSystem;
  private GridPosition gridPosition;

  private List<Unit> unitList;

  public GridObject(GridSystem gridSystem, GridPosition gridPosition)
  {
    this.gridSystem = gridSystem;
    this.gridPosition = gridPosition;
    unitList = new List<Unit>;

  }

  public override string ToString()
  {
    return gridPosition.ToString() + "\n" + unit;
  }

  public void SetUnit(Unit unit)
  {
    this.unit = unit;
  }

  public Unit GetUnit()
  {
    return unit;
  }
}
