using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    ObjectPooler enemyPool;

	// Use this for initialization
	IEnumerator Start () {
        enemyPool = ObjectPooler.instance;
        yield return StartCoroutine(SpawnAllWaves());
	}

    private IEnumerator SpawnAllWaves()
    {
        for (int i = startingWave; i < waveConfigs.Count; i++)
        {
            WaveConfig currentWave = waveConfigs[i];
            yield return StartCoroutine(SpawnWave(currentWave));
        }
    }
	
	private IEnumerator SpawnWave(WaveConfig waveConfig)
    {
        int numberOfEnemies = waveConfig.NumberOfEnemies;
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject obj = enemyPool.GetPooledObject("Enemy");
            if (obj != null)
            {
                Animator animator = obj.GetComponent<Animator>();
                animator.runtimeAnimatorController = waveConfig.PathAnimController;
                obj.SetActive(true);
                yield return new WaitForSeconds(waveConfig.SpawnDelayTimer);
            }
            yield return null;
        }
    }
}
