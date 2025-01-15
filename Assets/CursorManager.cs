using UnityEngine;
using UnityEngine.InputSystem;

public class CursorManager : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 raycastStartPoint;
    private GameControls gameControls;
    private Tile selectedTile;

    private void Awake()
    {
        mainCamera = Camera.main;

        gameControls = new GameControls();
        gameControls.Enable();

        gameControls.Cursor.Click.performed += OnClickPerformed;
    }

    private void Update()
    {
        Debug.Log("Cursor is on " + gameControls.Cursor.CursorMovement.ReadValue<Vector2>());
    }

    private void OnClickPerformed(InputAction.CallbackContext obj)
    {
        Debug.Log("!Click! is on " +  gameControls.Cursor.CursorMovement.ReadValue<Vector2>());
        if(ShootRaycastForTile(out Tile newTile))
            HandleTileSelection(newTile);

        else if(selectedTile != null)
        {
            selectedTile.Desellect();
            selectedTile = null;
        }

    }

    private void OnDisable()
    {
        gameControls.Cursor.Click.performed -= OnClickPerformed;
    }

    /// <summary>
    /// Shoots raycast. Returns true if hitted tile. out Tile tile.
    /// </summary>
    /// <param name="tile"></param>
    /// <returns></returns>
    private bool ShootRaycastForTile(out Tile tile)
    {
        tile = null;
        raycastStartPoint = gameControls.Cursor.CursorMovement.ReadValue<Vector2>();
        raycastStartPoint = mainCamera.ScreenToWorldPoint(raycastStartPoint);

        var hit = Physics2D.Raycast(raycastStartPoint, Vector3.forward);
        if(hit.collider != null) {
            if (hit.collider.TryGetComponent<Tile>(out tile))
            {
                return true;
            }
        }

        return false;
    }
    private void HandleTileSelection(Tile newTile)
    {
        if (newTile == selectedTile)
            return;

        if (selectedTile != null)
            selectedTile.Desellect();
        newTile.Select();
        selectedTile = newTile;
    }
}
