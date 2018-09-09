using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config")]
public class WaveConfig : ScriptableObject {

    [SerializeField] AnimationClip pathAnim;
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

    public AnimationClip PathAnim
    {
        get { return pathAnim; }
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
