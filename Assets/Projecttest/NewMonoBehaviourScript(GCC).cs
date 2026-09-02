using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    public int columns = 5;
    public int rows = 4;

    public float cellSize = 80;
    public float spacing = 10;

    public GameObject cellPrefab;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        float width = columns * cellSize + (columns - 1) * spacing;
        float height = rows * cellSize + (rows - 1) * spacing;

        float startX = -width / 2 + cellSize / 2;
        float startY = height / 2 - cellSize / 2;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                GameObject cell = Instantiate(cellPrefab, transform);

                float x = startX + col * (cellSize + spacing);
                float y = startY - row * (cellSize + spacing);

                cell.transform.localPosition = new Vector3(x, y, 0);

                cell.name = "Cell " + (row * columns + col + 1);
            }
        }
    }
}
