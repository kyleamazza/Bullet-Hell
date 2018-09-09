using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] RuntimeAnimatorController pathAnimController;
    //[SerializeField] int numberOfEnemies;
    [SerializeField] int numberOfEnemies;
    [SerializeField] float spawnDelayTimer;
    [SerializeField] float movementSpeed;
    // TODO: bullet pattern/bullet emitter w/ pattern

    public RuntimeAnimatorController PathAnimController
    {
        get { return pathAnimController; }
    }

	public int NumberOfEnemies
    {
        get { return numberOfEnemies; }
    }

    public float SpawnDelayTimer
    {
        get { return spawnDelayTimer; }
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
    }
}
