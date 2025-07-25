using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    bool isGameStarted;
    public bool isNextToWaterOfLife;

    private UIManager uIManager;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);  // 중복된 게임매니저 제거
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        isGameStarted = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        uIManager = FindObjectOfType<UIManager>();
        uIManager.SetState(UIState.Start);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        isGameStarted = true;
        uIManager.SetState(UIState.Main);
    }

}
