using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int movesLeft = 30;
    public int scoreGoal = 10000;
    public ScreenFader screenFader;
    public Text levelNameText;

    private Board m_board;

    private bool m_isReadyToBegin = false;
    private bool m_isGameOver = false;
    private bool m_isWinner = false;

    // Start is called before the first frame update
    void Start()
    {
        m_board = GameObject.FindObjectOfType<Board>().GetComponent<Board>();

        Scene scene = SceneManager.GetActiveScene();

        if (levelNameText != null)
        {
            levelNameText.text = scene.name;
        }

        StartCoroutine("ExecuteGameLoop");
    }

    private IEnumerator ExecuteGameLoop()
    {
        yield return StartCoroutine("StartGameRoutine");
        yield return StartCoroutine("PlayGameRoutine");
        yield return StartCoroutine("EndGameRoutine");
    }

    private IEnumerator StartGameRoutine()
    {
        while (!m_isReadyToBegin)
        {
            yield return null;
            yield return new WaitForSeconds(2f);
            m_isReadyToBegin = true;
        }

        if (screenFader != null)
        {
            screenFader.FadeOff();
        }

        yield return new WaitForSeconds(1f);

        if (m_board != null)
        {
            m_board.SetupBoard();
        }
    }

    private IEnumerator PlayGameRoutine()
    {
        while (!m_isGameOver)
        {
            yield return null;
        }
    }

    private IEnumerator EndGameRoutine()
    {
        if (m_isWinner)
        {
            Debug.Log("Winner");
        }
        else
        {
            Debug.Log("Loser");
        }
        yield return null;
    }



}
