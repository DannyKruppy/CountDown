using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject scoutEnemy;
    [SerializeField] private GameObject tankEnemy;
    [SerializeField] private GameObject zoomerEnemy;

    [Header("Map Route")]
    public GameObject[] waypoints;
    [SerializeField] private Transform enemySpawn;

    private float elapsedTime = 0f;
    private float spawnTimer = 0f;
    private int health = 10;

    //health managment
    //money managment

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        spawnTimer += Time.deltaTime;

        //randomize spawning in some way
        if(spawnTimer > 1f)
        {
            spawnTimer -= 1;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        //way to spawn different enemies
        GameObject spawnedEnemy = Instantiate(scoutEnemy, enemySpawn);

        Enemy enemyScript = spawnedEnemy.GetComponent<Enemy>();
        enemyScript.waypoints = waypoints;
    }

    public void ReduceHealth()
    {
        health--;
        if(health <= 0)
        {
            //game over
        }
    }
}
