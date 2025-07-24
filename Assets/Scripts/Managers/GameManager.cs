using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isNextToWaterOfLife;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);  // 혹시 모를 게임매니저 복제 대응
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
