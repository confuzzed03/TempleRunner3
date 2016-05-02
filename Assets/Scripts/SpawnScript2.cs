using UnityEngine;
using System.Collections;

public class SpawnScript2 : MonoBehaviour
{
    public GameObject rock;

    float timeElapsed = 0;
    public static float spawnCycle = 1.5f;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > spawnCycle)
        {
            GameObject temp;
           
            temp = Instantiate(rock);
            Vector3 pos = temp.transform.position;
            temp.transform.position = new Vector3(Random.Range(-3, 4), pos.y, pos.z + 60);

            timeElapsed -= spawnCycle;
        }
    }
}