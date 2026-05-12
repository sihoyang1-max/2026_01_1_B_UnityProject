using System.Xml.XPath;
using UnityEngine;

public class DraggableRank : MonoBehaviour
{
    public Vector3 orignalPosition;
    public GridCell currentCell;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MovetoCell(GridCell targetCell)
    {
        if (currentCell != null)
        {
            currentCell.currentRank = null;
        }

        currentCell = targetCell;
        targetCell.currentRank = this;

        orignalPosition = new Vector3(targetCell.transform.position.x, targetCell.transform.position.y, 0);
        transform.position = orignalPosition;
    }
    public void ReturnToOriginalPosition()
    {
        transform.position = orignalPosition;
    }
    public void MergeWithCell(GridCell targetCell)
    {
        if (targetCell.currentRank == null || targetCell.currentRank.rankLevel != rankLevel)
        {
            ReturnToOriginalPosition();
            return;
        }

        if (currentCell != null)
        {

}
