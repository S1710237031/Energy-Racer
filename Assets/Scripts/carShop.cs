using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class carShop : MonoBehaviour
{
    public Text coinText;
    public Text buyText;
    public Button yesButton;
    public Button noButton;
    public Button car1Button;
    public Button car2Button;
    public Button car3Button;
    public Button upgrade1Button;
    public Button upgrade2Button;
    public Button upgrade3Button;
    public Car car1, car2, car3;
    public Upgrade upgrade1, upgrade2, upgrade3;
    private string buttonTag;

    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "$" + StartGame.coins;
        hideConfirmDialog();
        createItems();

        Button button = car1Button.GetComponent<Button>();
        button.onClick.AddListener(selectItem);

        button = car2Button.GetComponent<Button>();
        button.onClick.AddListener(selectItem);

        button = car3Button.GetComponent<Button>();
        button.onClick.AddListener(selectItem);

        button = upgrade1Button.GetComponent<Button>();
        button.onClick.AddListener(selectItem);

        button = upgrade2Button.GetComponent<Button>();
        button.onClick.AddListener(selectItem);

        button = upgrade3Button.GetComponent<Button>();
        button.onClick.AddListener(selectItem);
    }

    void createItems()
    {
        car1 = new Car("Fast Car", "-1 needed move", 100, 1);
        car2 = new Car("Sports Car", "-2 needed moves", 200, 2);
        car3 = new Car("Super Car", "-3 needed moves", 400, 3);

        upgrade1 = new Upgrade("Extra Move", "1 zusätzlicher Zug", 75, 1);
        upgrade2 = new Upgrade("Extra Move XL", "2 zusätzliche Züge", 150, 2);
        upgrade3 = new Upgrade("Extra Move XXL", "3 zusätzliche Züge", 300, 3);
    }

    void selectItem()
    {
        buyText.gameObject.SetActive(true);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);

        var selected = EventSystem.current.currentSelectedGameObject;
        buttonTag = selected.tag;

        Button yes = yesButton.GetComponent<Button>();
        yes.onClick.AddListener(buyItem);

        Button no = noButton.GetComponent<Button>();
        no.onClick.AddListener(hideConfirmDialog);

    }
    void hideConfirmDialog()
    {
        buyText.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }

    void buyItem()
    {
        
        if(buttonTag == "1")
        {
            if (validTransaction(car1.cost))
            {
                Board.car = car1;
                updateCoins(car1.cost);
            } else
            {
                buyText.text = "nicht genug Geld!";
            }
        } else if (buttonTag == "2")
        {
            if (validTransaction(car2.cost))
            {
                Board.car = car2;
                updateCoins(car2.cost);
            }
            else
            {
                buyText.text = "nicht genug Geld!";
            }
        }
        else if (buttonTag == "3")
        {
            if (validTransaction(car3.cost))
            {
                Board.car = car3;
                updateCoins(car3.cost);
            }
            else
            {
                buyText.text = "nicht genug Geld!";
            }
        }
        else if (buttonTag == "4")
        {
            if (validTransaction(upgrade1.cost))
            {
                Board.upgrade = upgrade1;
                updateCoins(upgrade1.cost);
            }
            else
            {
                buyText.text = "nicht genug Geld!";
            }
        }
        else if (buttonTag == "5")
        {
            if (validTransaction(upgrade2.cost))
            {
                Board.upgrade = upgrade2;
                updateCoins(upgrade2.cost);
            }
            else
            {
                buyText.text = "nicht genug Geld!";
            }
        }
        else if (buttonTag == "6")
        {
            if (validTransaction(upgrade3.cost))
            {
                Board.upgrade = upgrade3;
                updateCoins(upgrade3.cost);
            }
            else
            {
                buyText.text = "nicht genug Geld!";
            }
        }
    }

    bool validTransaction (int cost)
    {
        return StartGame.coins >= cost;
    }

    void updateCoins(int cost)
    {
        StartGame.coins -= cost;
        PlayerPrefs.SetInt("coins", StartGame.coins);
        coinText.text = "$" + StartGame.coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
