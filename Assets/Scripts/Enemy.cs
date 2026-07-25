using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentWP = 0;

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float health = 100f;

    private void Update()
    {
        if(Vector3.Distance(this.transform.position, waypoints[currentWP].transform.position) < 3)
        {
            currentWP++;
        }

        this.transform.LookAt(waypoints[currentWP].transform);
        this.transform.Translate(0 , 0, speed * Time.deltaTime);
    }
}
