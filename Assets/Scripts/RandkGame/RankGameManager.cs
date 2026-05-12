using UnityEditor;
using UnityEngine;

public class RankGameManager : MonoBehaviour
{
    public int gridWidth = 7;
    public int gridHeight = 7;
    public float CellSize = 1.3f;
    public GameObject cellPrefabs;
    public Transform gridContainer;

    public GameObject rankPrefabs;
    public Sprite[] rankSprites;
    public int maxRankLevel = 7;

    public GridCell[,] grid;

    void InitializeGrid()
    {
        grid = new GridCell[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3(
                    x * CellSize - (gridWidth * CellSize / 2) + CellSize / 2,
                    y * CellSize - (gridHeight * CellSize / 2) + CellSize / 2,
                    1f
                );

                GameObject cellObj = Instantiate(cellPrefabs, position, Quaternion.identity, gridContainer);
                GridCell cell = cellObj.GetComponent<GridCell>();
                cell.initialize(x,y);

                grid[x,y] = cell;
            }
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public DraggableRank CreateRanklnCell(GridCell cell , int level)
    {
        if(cell == null || !cell.isEmpty()) return null;

        level = Mathf.Clamp(level, 1, maxRankLevel);

        Vector3 rankPosition = new Vector3(cell.transform.position.x, cell.transform.position.y, 0f);

        GameObject rankObj = Instantiate(rankPrefabs, rankPosition, Quaternion.identity, gridContainer);
        rankObj.name = "Rank_Level_" + level;

        DraggableRank rank = rankObj.AddComponent<DraggableRank>();

        return rank;
    }
}
