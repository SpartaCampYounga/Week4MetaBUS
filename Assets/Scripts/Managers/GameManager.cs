using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    bool isGameStarted;
    public bool isNextToWaterOfLife;

    private UIManager uIManager;
    private PlayerController player;

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
    private void Start()
    {
        Init();
        uIManager.SetState(UIState.Start);
    }
    void Init()
    {
        uIManager = FindObjectOfType<UIManager>();
        player = FindObjectOfType<PlayerController>();
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

    public void EnterFlappyGame()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.transform.position.z);
        PlayerPrefs.SetInt("UIState", (int)uIManager.currentState);
        SceneManager.LoadScene("FlappyGameScene");    //미니게임 씬을 추가로 로드
    }
    public void ReturnFromFlappyGame()
    {
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            float playerX = PlayerPrefs.GetFloat("PlayerX");
            float playerY = PlayerPrefs.GetFloat("PlayerY");
            float playerZ = PlayerPrefs.GetFloat("PlayerZ");
            int uiState = PlayerPrefs.GetInt("UIState");
            UnityAction<Scene, LoadSceneMode> sceneLoadCallback = null;
            sceneLoadCallback = (scene, mode) =>
            {
                if (scene.name == "MainScene")
                {
                    Init();  //UIManager와 PlayerController를 초기화
                    if (player == null)
                    {
                        player = FindObjectOfType<PlayerController>();  //한번더 찾아봄.
                    }
                    else
                    {
                        player.transform.position = new Vector3(playerX, playerY, playerZ);
                    }
                    if (uIManager == null)
                    {
                        uIManager = FindObjectOfType<UIManager>();  //한번더 찾아봄.
                    }
                    else
                    {
                        uIManager.SetState((UIState)uiState);  //이전 UI 상태로 복원
                    }

                    UIManager.Instance.ShowScoreBoard();
                    SceneManager.sceneLoaded -= sceneLoadCallback;  //씬 로드 후 이벤트 제거
                }
            };
            SceneManager.sceneLoaded += sceneLoadCallback;
        }
        SceneManager.LoadScene("MainScene");  //메인 씬으로 돌아가기
        

        Debug.Log("Best Score from Return: " + PlayerPrefs.GetInt("BestScore"));
    }
}
