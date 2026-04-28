using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int friutType;

    public bool hasMerged = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasMerged)
            return;
        Fruit otherFruit = collision.gameObject.GetComponent<Fruit>();

        if(otherFruit != null && !otherFruit.hasMerged && otherFruit.fruitTyp == friutType)
        {
            hasMerged = true;
            otherFruit.hasMerged = true;

            Vector3 MergePosition = (transform.position + otherFruit.transform.position) / 2f;

            Destroy(otherFruit.gameObject);
            Destroy(gameObject);
        }
    }
}
