using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject CollectablesList;
    private GameObject[] BrokenBoardsList;
    private int TotalCollectables;
    private int AcquiredCollectables;
    private GameObject HUD;
    private GameObject LevelFinishScreen;
    private GameObject CheckpointNotice;
    private GameObject PauseScreen;
    [SerializeField]
    private TMP_Text CollectableHUDField;
    private GameObject FinishLine;
    public static bool LevelFinished;
    public static bool gamePaused;

    // Start is called before the first frame update
    void Start()
    {
        TotalCollectables = CollectablesList.transform.childCount;
        CollectableHUDField.text = AcquiredCollectables + " / " + TotalCollectables;
        BrokenBoardsList = GameObject.FindGameObjectsWithTag("BrokenBoard");
        HUD = GameObject.FindGameObjectWithTag("HUD");
        LevelFinishScreen = GameObject.FindGameObjectWithTag("LevelFinishScreen");
        LevelFinishScreen.SetActive(false);
        CheckpointNotice = GameObject.FindGameObjectWithTag("CheckpointNotice");
        CheckpointNotice.SetActive(false);
        PauseScreen = GameObject.FindGameObjectWithTag("PauseScreen");
        PauseScreen.SetActive(false);
        LevelFinished = false;
        Unpause();
        HUD.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelFinished) {
            LevelFinishScreen.SetActive(true);
            HUD.SetActive(false);
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        gamePaused = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        gamePaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void TogglePauseScreen() {
        if (gamePaused) {
            PauseScreen.SetActive(true);
        } else {
            PauseScreen.SetActive(false);
        }
    }

    public void QuitGame()
    {
        // Only works when running the built game, not in the editor
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AcquiredCollectable() 
    {
        AcquiredCollectables += 1;
        Debug.Log("Gems collected: " + AcquiredCollectables);
        CollectableHUDField.text = AcquiredCollectables + " / " + TotalCollectables;
    }

    public void ResetBrokenBoards() 
    {
        for (int i = 0; i < BrokenBoardsList.Length; i++) {
            BrokenBoardsList[i].GetComponent<BrokenBoardScript>().ResetBoardPosition();
        }
    }

    public IEnumerator ShowCheckpointNotice()
    {
        CheckpointNotice.SetActive(true);
        yield return new WaitForSeconds(2f);
        CheckpointNotice.SetActive(false);
    }
}
