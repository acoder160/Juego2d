using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemigo")]
public class ScriptEnemigo : ScriptableObject
{
    [SerializeField] public int xMax;
    [SerializeField] public int xMin;
    
    [SerializeField] public float runSpeed;
    [SerializeField] public float jumpSpeed;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
