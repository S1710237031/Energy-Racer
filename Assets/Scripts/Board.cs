using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

/// <summary>
/// the Board class stores information on the game board and all relevant data
/// </summary>
public class Board : MonoBehaviour
{
    public int width;
    public int height;
    public int offset;
    public GameObject tilePrefab;
    private BackgroundTile[,] allTiles;
    public GameObject[] dots;
    public GameObject[,] allDots;
    public int curScore;
    public int curPlayer2Score;
    public int neededScore;
    public Text levelText;
    public Text movesText;
    public Text neededScoreText;
    public Text curPlayerText;
    public int remainingMoves;
    public bool gameOver;
    public bool gameWon;
    public Slider slider;
    public Slider player2Slider;
    SceneSwitch switchScene;
    public static Car car;
    public static Upgrade upgrade;

    public static bool isMultiplayer;
    public static String curPlayer;

    public int clouds;
    public string city;
    public double hoursInADay;
    public double Clouds;
    public static int earnedCoins;
    public int curDistr;
    public int level;


    /// <summary>
    /// the game board is initialized, dots and background tiles are created
    /// </summary>
    void Start()
    {
        curPlayer = "Player 1";
        if (isMultiplayer)
        {
            curPlayerText.text = curPlayer;
        }
        else
        {
            //hide curPlayerText and second slider
            //curPlayerText.text = " ";
            player2Slider.gameObject.SetActive(false);
        }
        earnedCoins = 30;
        levelText.text = "coins: " + earnedCoins;

        width = 7;
        height = 7;
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];
        Setup(height, width, 30, 10, level);

        if (remainingMoves == 1)
        {
            movesText.text = remainingMoves + " Zug übrig";
        }
        else
        {
            movesText.text = remainingMoves + " Züge übrig";
        }
    }

    /// <summary>
    /// set level difficulty, display remaining moves
    /// </summary>
    public void Update()
    {
        if (remainingMoves == 1)
        {
            movesText.text = remainingMoves + " Zug übrig";
        }
        else
        {
            movesText.text = remainingMoves + " Züge übrig";
        }
    }

    /// <summary>
    /// update needed score, moves, and set current score to 0.
    /// check if upgrade is activated
    /// fill the game board with dots
    /// </summary>
    /// <param name="boardHeight"></param> the game board height
    /// <param name="boardWidth"></param> the game board width
    /// <param name="startMoves"></param> the moves 
    /// <param name="scoreToReach"></param> needed score to win
    /// <param name="level"></param> 
    public void Setup(int boardHeight, int boardWidth, int startMoves, int scoreToReach, int level)
    {
        curScore = 0;
        neededScore = scoreToReach;
        remainingMoves = startMoves;

        slider.maxValue = neededScore;
        slider.value = 0;

        if (isMultiplayer)
        {
            player2Slider.maxValue = neededScore;
            player2Slider.value = 0;
        }

        if (upgrade != null)
        {
            remainingMoves += upgrade.bonusMoves;
        }

        if (car != null)
        {
            neededScore -= car.movesReduction;
        }

        width = boardWidth;
        height = boardHeight;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 tempPosition = new Vector2(i, j + offset);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPosition, Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = transform;
                backgroundTile.name = i + ", " + j;

                int dotToUse = SetDotToUse(level);

                int maxIter = 0;
                while (MatchesAt(i, j, dots[dotToUse]) && maxIter < 100)
                {
                    dotToUse = SetDotToUse(level);
                    maxIter++;
                }

                GameObject dot = Instantiate(dots[dotToUse], tempPosition, Quaternion.identity);
                dot.GetComponent<Dot>().col = i;
                dot.GetComponent<Dot>().row = j;

                dot.transform.parent = transform;
                dot.name = i + ", " + j;
                allDots[i, j] = dot;
            }
        }
    } // SetUp method

    /// <summary>
    /// sets the dot that is used for the game board
    /// </summary>
    /// <param name="_level"></param>
    /// <returns>a random dot</returns>
    private int SetDotToUse(int _level)
    {
        int dotToUse;
        if (_level == 1)
        {
            dotToUse = UnityEngine.Random.Range(0, dots.Length - 2);
        }
        else if (_level == 2)
        {
            dotToUse = UnityEngine.Random.Range(1, dots.Length - 2);
        }
        else if (_level == 3)
        {
            dotToUse = UnityEngine.Random.Range(1, dots.Length - 1);
        }
        else if (_level == 4)
        {
            dotToUse = UnityEngine.Random.Range(2, dots.Length - 1);
        }
        else if (_level == 5)
        {
            dotToUse = UnityEngine.Random.Range(2, dots.Length);
        }
        else
        {
            // completely random, when night time or no location
            dotToUse = UnityEngine.Random.Range(0, dots.Length);
        }
        return dotToUse;
    } // SetDotToUse method


    /// <summary>
    ///  checks if a certain piece is matched
    /// </summary>
    /// <param name="col"></param> piece's column
    /// <param name="row"></param> piece's row
    /// <param name="piece"></param> the piece
    /// <returns>true if the dot is matched</returns>
    private bool MatchesAt(int col, int row, GameObject piece)
    {
        if (col > 1 && row > 1)
        {
            if (allDots[col - 1, row].tag == piece.tag && allDots[col - 2, row].tag == piece.tag)
            {
                return true;
            }
            if (allDots[col, row - 1].tag == piece.tag && allDots[col, row - 2].tag == piece.tag)
            {
                return true;
            }
        }
        else if (col <= 1 || row <= 1)
        {
            if (row > 1)
            {
                if (allDots[col, row - 1].tag == piece.tag && allDots[col, row - 2].tag == piece.tag)
                {
                    return true;
                }
            }
            if (col > 1)
            {
                if (allDots[col - 1, row].tag == piece.tag && allDots[col - 2, row].tag == piece.tag)
                {
                    return true;
                }
            }
        }

        return false;
    }

    /// <summary>
    /// makes matched objects disappear
    /// </summary>
    /// <param name="col"></param> the column of matched piece
    /// <param name="row"></param> the row of matched piece
    private void DestroyMatchesAt(int col, int row)
    {
        if (allDots[col, row].GetComponent<Dot>().isMatched)
        {
            if (allDots[col, row].tag == "Battery" || allDots[col, row].tag == "Sun" ||
                allDots[col, row].tag == "Plug")
            {
                if (!isMultiplayer || curPlayer == "Player 1")
                {
                    curScore++;
                }
                else
                {
                    curPlayer2Score++;
                }
            }
            else if (allDots[col, row].tag == "Rain" || allDots[col, row].tag == "Cloud")
            {
                if (!isMultiplayer || curPlayer == "Player 1")
                {
                    curScore--;
                }
                else
                {
                    curPlayer2Score--;
                }
            }
            slider.value = curScore;
            if (isMultiplayer)
            {
                player2Slider.value = curPlayer2Score;
            }
            Destroy(allDots[col, row]);
            allDots[col, row] = null;
        }
    }
    /// <summary>
    /// destroys all matches on board
    /// check for win
    /// </summary>
    public void DestroyMatches()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i, j] != null)
                {
                    DestroyMatchesAt(i, j);
                    if (remainingMoves == 1)
                    {
                        movesText.text = "1 Zug übrig";
                    }
                    else
                    {
                        movesText.text = remainingMoves + " Züge übrig";
                    }
                    if (curScore >= neededScore)
                    {
                        SceneManager.LoadScene("GameWon");
                    }
                }
            }
        }
        StartCoroutine(DecreaseRowCo());
    }
    /// <summary>
    /// makes pieces fall down when match below disappears
    /// </summary>
    /// <returns></returns>
    private IEnumerator DecreaseRowCo()
    {
        int nullCount = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i, j] == null)
                {
                    nullCount++;
                }
                else if (nullCount > 0)
                {
                    allDots[i, j].GetComponent<Dot>().row -= nullCount;
                    allDots[i, j] = null;
                }

            }
            nullCount = 0;
        }
        yield return new WaitForSeconds(.4f);
        StartCoroutine(FillBoardCo());
    }

    /// <summary>
    /// spawns new pieces when match disappears
    /// </summary>
    private void RefillBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i, j] == null)
                {
                    Vector2 tempPos = new Vector2(i, j + offset);
                    int dotToUse = SetDotToUse(level);
                    GameObject piece = Instantiate(dots[dotToUse], tempPos, Quaternion.identity);
                    allDots[i, j] = piece;
                    piece.GetComponent<Dot>().col = i;
                    piece.GetComponent<Dot>().row = j;
                }
            }
        }

    }
    /// <summary>
    /// checks if there are matches on board
    /// </summary>
    /// <returns>true if matches on board, false if no matches</returns>
    private bool MatchesOnBoard()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (allDots[i, j] != null)
                {
                    if (allDots[i, j].GetComponent<Dot>().isMatched)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    /// <summary>
    /// destroys all matches that are still on board after refilling
    /// </summary>
    /// <returns></returns>
    private IEnumerator FillBoardCo()
    {
        RefillBoard();
        yield return new WaitForSeconds(.4f);

        while (MatchesOnBoard())
        {
            yield return new WaitForSeconds(.2f);
            DestroyMatches();
        }
        CheckGameOver();
    }
    /// <summary>
    /// checks if user lost
    /// </summary>
    public void CheckGameOver()
    {
        if (Board.isMultiplayer)
        {
            if (Board.curPlayer == "Player 1")
            {
                Board.curPlayer = "Player 2";
            }
            else
            {
                Board.curPlayer = "Player 1";
            }
            curPlayerText.text = Board.curPlayer;

            if (curScore >= neededScore || remainingMoves == 0 && curScore > curPlayer2Score)
            {
                SceneManager.LoadScene("MultiplayerWin");
            }
            else if (remainingMoves == 0 && curScore == curPlayer2Score && curScore < neededScore)
            {
                curPlayer = "Draw";
                SceneManager.LoadScene("MultiplayerWin");
            }
            else
            {
                SceneManager.LoadScene("MultiplayerWin");
            }
        }
        else
        {
            if (curScore >= neededScore)
            {
                SceneManager.LoadScene("GameWon");
                DistrictSelection.unlockedDistricts++;
            }
        }
        if (remainingMoves <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    /// <summary>
    /// manages coins
    /// </summary>
    public void updateCoins()
    {
        if (remainingMoves < 5)
        {
            earnedCoins = 10;
        }
        else if (remainingMoves <= 10 && remainingMoves >= 5)
        {
            earnedCoins = 20;
        }

        levelText.text = "coins: " + earnedCoins;
    }
}