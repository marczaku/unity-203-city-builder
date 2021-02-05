using UnityEngine;
using UnityEngine.EventSystems;

// A grid has a two-dimensional array of cells
// And keeps track on what cells are taken by which objects.
// It needs to be notified when something is moved.
// So we can update the cells.
// We can ask it, if a certain cell
// Or a cell area is empty.

// not sure, if this is really needed?

// A grid object is one object on the grid.
// For now, it mostly only has a position on the grid.
// But it might also have a size different from 1x1 later.

public class Wall : MonoBehaviour, IDragHandler {
    public void OnDrag(PointerEventData eventData){
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo)) {
            this.transform.position = hitInfo.point;
            this.transform.localPosition = Vector3Int.FloorToInt(this.transform.localPosition);
        }
    }
}