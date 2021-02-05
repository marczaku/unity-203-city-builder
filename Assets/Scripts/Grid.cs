using UnityEngine;

public class Grid : MonoBehaviour {
    public Cell[] cells;
    public int width;
    public int height;
    public Cell cellPrefab;

    public Cell GetCell(int x, int y) {
        return this.cells[y * this.width + x];
    }

    void SetCell(int x, int y, Cell cell) {
        this.cells[y * this.width + x] = cell;
    }
    
    // void MoveObject(GridObject object, Vector2Int toPosition)
    // void MoveObject(GridObject object, Cell toCell)

    void Awake() {
        SpawnGridCells();
    }

    void SpawnGridCells() {
        this.cells = new Cell[this.width * this.height];
        for (var x = 0; x < this.width; x++) {
            for (var y = 0; y < this.height; y++) {
                var cell = Instantiate(this.cellPrefab, this.transform);
                // not needed here, but this would reset the local rotation:
                // cell.transform.localRotation = Quaternion.identity;
                cell.Position = new Vector2Int(x, y);
                SetCell(x, y, cell);
            }
        }
    }
}