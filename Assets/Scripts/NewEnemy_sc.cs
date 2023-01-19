using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy_sc : MonoBehaviour
{
    public float SecondsToWait;
    public GameObject enemyPrefab;
    public GameObject enemyContainer;
    
    public bool yeniyiDurdur = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    
    void Update()
    {
        
    }
    
    

    IEnumerator SpawnEnemyRoutine() {
        while (yeniyiDurdur == false) {
            Vector3 position = new Vector3(Random.Range(-6f, 6f), 1, 25);
            GameObject newEnemy = Instantiate(enemyPrefab, position, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(SecondsToWait);
        }
    }
}
