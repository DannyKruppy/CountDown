using UnityEngine;

public class PathArrowGenerator : MonoBehaviour
{
    [Header("References")]
    public Transform pathParent;
    public GameObject arrowPrefab;

    [Header("Settings")]
    public float spacing = 2f;
    public float heightOffset = 0.05f;

    public void GeneratePath()
    {
        // Delete previous arrows
        while (transform.childCount > 0)
        {
#if UNITY_EDITOR
            DestroyImmediate(transform.GetChild(0).gameObject);
#else
            Destroy(transform.GetChild(0).gameObject);
#endif
        }

        if (pathParent.childCount < 2)
            return;

        for (int i = 0; i < pathParent.childCount - 1; i++)
        {
            Transform start = pathParent.GetChild(i);
            Transform end = pathParent.GetChild(i + 1);

            Vector3 direction = end.position - start.position;
            float distance = direction.magnitude;

            direction.Normalize();

            int arrowCount = Mathf.FloorToInt(distance / spacing);

            for (int j = 0; j <= arrowCount; j++)
            {
                Vector3 position = start.position + direction * spacing * j;
                position.y += heightOffset;

                Quaternion rotation = Quaternion.LookRotation(direction);

                GameObject arrow =
                    Instantiate(arrowPrefab, position, rotation, transform);
            }
        }
    }

    private void Start()
    {
        GeneratePath();
    }
}