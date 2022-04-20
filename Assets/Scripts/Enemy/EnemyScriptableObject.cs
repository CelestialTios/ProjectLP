using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject that holds the BASE STATS for an enemy. These can then be modified at creation time
/// </summary>
[CreateAssetMenu(fileName = "EnemyConfig", menuName = "ScriptableObject/EnemyConfig")]
public class EnemyScriptableObject : ScriptableObject
{
    public Sprite sprite;
    public float weight = 1f;

    #region FieldOfView
    [SerializeField] public Transform pfieldOfView;
    public int raycount = 20;
    public float fov = 30f;
    public float ViewDistance = 15f;
    #endregion

}
