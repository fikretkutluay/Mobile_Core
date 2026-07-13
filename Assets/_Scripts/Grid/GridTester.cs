using UnityEngine;

public class GridTester : MonoBehaviour
{
    private GridManager<int> gridManager;
    [SerializeField]
    private int width = 10;
    [SerializeField]
    private int height = 10;
    [SerializeField]        
    private float cellSize = 1f;

    public void OnDrawGizmos()
    {
        if (gridManager == null)
        {
            gridManager = new GridManager<int>(width, height, cellSize, transform.position);
        }

        Gizmos.color = Color.yellow;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 worldPosition = gridManager.GetWorldPosition(x, y);
                Vector3 cellCenterOffset = new Vector3(cellSize * 0.5f, cellSize * 0.5f, 0);
                
                Gizmos.DrawWireCube(worldPosition + cellCenterOffset, new Vector3(cellSize, cellSize, 0));
            }
        }
    }
}