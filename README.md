# MetaBUS 프로젝트
Meta + Universe 가 아닌, Meta + Beginner's Unity Study Project의 의미를 담았습니다.

## 개요
Unity 기반의 탑다운 어드벤처 스타일 게임과 플래피 버드 스타일의 미니게임이 결합되었습니다.

## 주요 기능

- **탐험 및 상호작용**  
  플레이어는 캐릭터를 조작하여 맵을 탐험하고, 오브젝트(생명수)나 NPC(마법사)와 상호작용할 수 있습니다.

- **플래피 미니게임**  
  생명수와 상호작용 시 플래피 버드 스타일의 미니게임이 시작됩니다. 장애물을 피하며 점수를 획득할 수 있습니다.

- **점수 저장 및 표시**  
  미니게임에서 획득한 점수와 최고 점수는 PlayerPrefs를 통해 저장되며, UI를 통해 확인할 수 있습니다.

- **UI 시스템**  
  시작, 메인, 대화, 미니게임, 점수판 등 다양한 UI 상태를 지원합니다.

- **씬 전환 및 상태 복원**  
  메인 씬과 미니게임 씬 간의 전환 시 플레이어와 카메라 위치, UI 상태 등이 자동으로 저장/복원됩니다.

## 폴더 및 코드 구조

├── Entities/ # 플레이어, 카메라 등 캐릭터 및 엔티티  
│   ├── PlayerController.cs  
│   └── FollowCamera.cs   
├── Enums/ # Enum 정의  
│   └── UIState.cs  
├── FlappyGames/ # 플래피 미니게임 관련  
│   ├── BackgroundLooper.cs  
│   ├── FlappyGameManager.cs  
│   ├── FlappyPlayer.cs  
│   ├── FlappyUIManager.cs  
│   ├── Obstacle.cs  
│   └── FlappyUI/  
│       ├── FlappyEndUI.cs  
│       ├── FlappyGameUI.cs  
│       └── FlappyStartUI.cs  
├── Interactables/ # 상호작용 오브젝트  
│   └── WizzardTrigger.cs  
├── Managers/ # 게임, UI 등 싱글턴 관리  
│   ├── GameManager.cs  
│   └── UIManager.cs  
├── UI/ # UI 관련 클래스  
│   ├── BaseUI.cs  
│   ├── DialogueUI.cs  
│   ├── LeaderboardUI.cs  
│   ├── MainUI.cs  
│   ├── ScoreBoardUI.cs  
│   └── StartUI.cs  

## 플레이 방법

1. **게임 시작**: 메인 씬에서 시작 버튼을 눌러 게임을 시작합니다.
2. **탐험**: 캐릭터를 조작해 맵을 탐험하고, 상호작용 가능한 오브젝트나 NPC를 찾습니다.
3. **미니게임 진입**: 생명수와 상호작용하면 플래피 미니게임이 시작됩니다.
4. **점수 획득**: 장애물을 피하며 점수를 올립니다.
5. **복귀**: 미니게임 종료 후 메인 씬으로 돌아오며, 점수판이 표시됩니다.
6. **리더보드 확인**: 맵의 왼쪽에 보이지 않는 길을 헤쳐가면 보이는 마법사와 상호작용을 통해 리더보드를 확인할 수 있습니다.
