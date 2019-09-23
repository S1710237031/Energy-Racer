using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public int neededScore;
    public Text levelText;
    public Text movesText;
    public int remainingMoves;
    public bool gameOver;
    public bool gameWon;
    public Slider slider;
    SceneSwitch switchScene;
    public static Car car;
    public static Upgrade upgrade;

    public int clouds;
    public string city;
    public MonthObject[] monthsArray;
    public double hoursInADay;
    public double Clouds;
    public static int earnedCoins;
    public int curDistr;

    public Text testText;
    public int level;

    GameObject locationController;

    // Start is called before the first frame update
    void Start()
    {
        locationController = GameObject.Find("LocationController");
        LocationPermission permission = locationController.GetComponent<LocationPermission>();
        permission.Start();

        earnedCoins = 30;
        levelText.text = "coins: " + earnedCoins;

        LocationService locationService = locationController.GetComponent<LocationService>();
        StartCoroutine(locationService.GetDeviceLocation());

        width = 7;
        height = 7;
        allTiles = new BackgroundTile[width, height];
        allDots = new GameObject[width, height];

        // happens at end of weather coroutine 
        //Setup(7, 7, 20, 6, level);

        if (remainingMoves == 1)
        {
            movesText.text = remainingMoves + " Zug übrig";
        }
        else
        {
            movesText.text = remainingMoves + " Züge übrig";
        }
        slider.maxValue = neededScore;
        slider.value = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        if(level == 0)
        {
            LocationService locationService = locationController.GetComponent<LocationService>();
            level = locationService.levelDifficulty;
        }
        if (remainingMoves == 1)
        {
            movesText.text = remainingMoves + " Zug übrig";
        }
        else
        {
            movesText.text = remainingMoves + " Züge übrig";
        }
    }

    public void Setup(int boardHeight, int boardWidth, int startMoves, int scoreToReach, int level)
    {
        testText.text = "level: " + level;
        curScore = 0;
        neededScore = scoreToReach;
        remainingMoves = startMoves;

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

    private int SetDotToUse(int _level)
    {
        int dotToUse;
        if (_level == 1)
        {
            dotToUse = UnityEngine.Random.Range(0, dots.Length - 2);
            testText.text = "easy" + hoursInADay;
        }
        else if (_level == 2)
        {
            dotToUse = UnityEngine.Random.Range(1, dots.Length - 2);
            testText.text = "middle" + hoursInADay;
        }
        else if (_level == 3)
        {
            dotToUse = UnityEngine.Random.Range(1, dots.Length - 1);
            testText.text = "hard" + hoursInADay;
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

    private void DestroyMatchesAt(int col, int row)
    {
        if (allDots[col, row].GetComponent<Dot>().isMatched)
        {
            if (allDots[col, row].tag == "Battery" || allDots[col, row].tag == "Sun" ||
                allDots[col, row].tag == "Plug")
            {
                curScore++;
                slider.value = curScore;
            }
            else if (allDots[col, row].tag == "Rain" || allDots[col, row].tag == "Cloud")
            {
                curScore--;
                if (curScore < 0)
                {
                    curScore = 0;
                }
                slider.value = curScore;
            }

            Destroy(allDots[col, row]);
            allDots[col, row] = null;

        }
    }

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

    private IEnumerator FillBoardCo()
    {
        RefillBoard();
        yield return new WaitForSeconds(.4f);

        while (MatchesOnBoard())
        {
            yield return new WaitForSeconds(.2f);
            DestroyMatches();
        }
        checkGameOver();
    }

    public void checkGameOver()
    {
        if (curScore >= neededScore)
        {
            SceneManager.LoadScene("GameWon");
            DistrictSelection.unlockedDistricts++;
        }
        else if (remainingMoves <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

    }

    public void updateCoins()
    {
        if (remainingMoves <= 5)
        {
            earnedCoins = 10;
        }
        else if (remainingMoves <= 10 && remainingMoves > 5)
        {
            earnedCoins = 20;
        }

        levelText.text = "coins: " + earnedCoins;
    }
}