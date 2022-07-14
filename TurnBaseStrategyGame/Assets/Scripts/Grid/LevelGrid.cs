using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
  public static LevelGrid Instance { get; private set; }
  [SerializeField] Transform gridDebugObjectPrefab;

  private GridSystem gridSystem;

  // Start is called before the first frame update
  void Awake()
  {
    if (Instance != null)
    {
      Debug.LogError("there's more than one LevelGrid." + transform + Instance);
      Destroy(gameObject);
      return;
    }
    Instance = this;

    gridSystem = new GridSystem(10, 10, 2f);
    gridSystem.CreateDebugObjects(gridDebugObjectPrefab);
  }

  public void SetUnitAtGridPosition(GridPosition gridPosition, Unit unit)
  {
    GridObject gridObject = gridSystem.GetGridObject(gridPosition);
    gridObject.SetUnit(unit);
  }

  public Unit GetUnitAtGridPosition(GridPosition gridPosition)
  {
    GridObject gridObject = gridSystem.GetGridObject(gridPosition);
    return gridObject.GetUnit();
  }

  public void ClearUnitAtGridPosition(GridPosition gridPosition)
  {
    GridObject gridObject = gridSystem.GetGridObject(gridPosition);
    gridObject.SetUnit(null);

  }

  public void UnitMovedGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
  {
    ClearUnitAtGridPosition(fromGridPosition);
    SetUnitAtGridPosition(toGridPosition, unit);
  }

  public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);
  // Update is called once per frame
  void Update()
  {

  }
}
