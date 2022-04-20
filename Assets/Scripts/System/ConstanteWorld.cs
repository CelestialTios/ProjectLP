using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstanteWorld : MonoBehaviour
{
    #region Singleton
    public static ConstanteWorld instance;

    public void Awake()
    {
        if (instance != null && instance != this) { 
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        
    }
    #endregion

    public float characterSpeed;
    public LayerMask GroundLayer;
}
