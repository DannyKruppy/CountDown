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

        if (currentWP == waypoints.Length)
        {
            Destroy(this.gameObject);
            currentWP = 0;
            //reduce hp
        }

        if(health <= 0)
        {
            Destroy(this.gameObject);
            currentWP = 0;
            //give money
        }

        this.transform.LookAt(waypoints[currentWP].transform);
        this.transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        this.transform.Translate(0 , 0, speed * Time.deltaTime);
    }
}
