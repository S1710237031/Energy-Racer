﻿using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// manages the car shop scene
/// </summary>
public class carShop : MonoBehaviour
{
    public Text coinText;
    public Text buyText;
    public Button yesButton;
    public Button noButton;
    public Button[] carButtons;
    public Button[] upgradeButtons;
    public Button upgrade2Button;
    public Button upgrade3Button;
    public Text[] carTitles;
    public Text[] carCosts;
    public Text[] upgradeTitles;
    public Text[] upgradeCosts;
    public Sprite[] carImgs;
    public Sprite[] upgradeImgs;
    public Car[] cars;
    public Upgrade[] upgrades;
    public static Car activeCar;
    public Upgrade activeUpgrade;
    public string buttonTag;

    public Image[] carImages;
    public Image[] upgradeImages;

    /// <summary>
    /// display buttons
    /// </summary>
    void Start()
    {
        hideConfirmDialog();
        cars = new Car[3];
        upgrades = new Upgrade[3];
        createItems();
        GetFromPlayerPrefs();
        coinText.text = "$" + StartGame.coins;


        fillTextfields();
        for(int i = 0; i < carButtons.Length; i++)
        {
            Button button = carButtons[i].GetComponent<Button>();
            button.onClick.AddListener(selectItem);
        }

        for(int i = 0; i < upgradeButtons.Length; i++)
        {
            Button button = upgradeButtons[i].GetComponent<Button>();
            button.onClick.AddListener(selectItem);

        }
    }

    void GetFromPlayerPrefs()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            if (PlayerPrefs.GetString(cars[i].carName) == "owned")
            {
                cars[i].owned = true;
            }
        }

        for (int i = 0; i < upgrades.Length; i++)
        {
            if (PlayerPrefs.GetString(upgrades[i].upgradeName) == "owned")
            {
                upgrades[i].owned = true;
            }
        }

        activeCar = cars[PlayerPrefs.GetInt("activeCar")];
        activeUpgrade = upgrades[PlayerPrefs.GetInt("activeUpgrade")];
    }

    /// <summary>
    /// create all upgrades
    /// </summary>
    void createItems()
    {
        cars[0] = new Car("Standard Car", "standard car", 0, 0, true, carImgs[0]);
        cars[1] = new Car("Sports Car", "-2 needed moves", 200, 2, false, carImgs[1]);
        cars[2] = new Car("Super Car", "-3 needed moves", 400, 3, false, carImgs[2]);

        upgrades[0] = new Upgrade("Extra Move", "1 Move mehr", 75, 1, upgradeImgs[0], false);
        upgrades[1] = new Upgrade("Extra Move XL", "2 Moves mehr", 150, 2, upgradeImgs[1], false);
        upgrades[2] = new Upgrade("Extra Move XXL", "3 Moves mehr", 300, 3, upgradeImgs[2], false);
    }

    /// <summary>
    /// display info about upgrades
    /// </summary>
    void fillTextfields()
    {
        for (int i = 0; i < carTitles.Length; i++)
        {
            fillOutInfo(carTitles[i], carCosts[i], carImages[i], cars[i]);
        }

        for (int i = 0; i < upgradeTitles.Length; i++)
        {
            fillOutInfo(upgradeTitles[i], upgradeCosts[i], upgradeImages[i], upgrades[i]);
        }
    }
    /// <summary>
    /// method for filling the text fields for cars
    /// </summary>
    /// <param name="nameText"></param> text field for car name
    /// <param name="costText"></param> text field for car cost
    /// <param name="car"></param> chosen car object
    void fillOutInfo(Text nameText, Text costText, Image carImage, Car car)
    {
        nameText.text = car.carName;
        carImage.sprite = car.img;
        
        if (activeCar == car)
        {
            costText.text = "aktiv";
        }
        else if (car.owned)
        {
            costText.text = "in Besitz";
        }
        else
        {
            costText.text = "$" + car.cost;
        }
    }

    /// <summary>
    /// method for filling the text fields for upgrades
    /// </summary>
    /// <param name="nameText"></param> text field for upgrade name
    /// <param name="costText"></param> text field for upgrade cost
    /// <param name="car"></param> chosen car object
    void fillOutInfo(Text nameText, Text costText, Image upgradeImage, Upgrade upgrade)
    {
        nameText.text = upgrade.upgradeName;
        upgradeImage.sprite = upgrade.upgradeImg;
        if (activeUpgrade == upgrade)
        {
            costText.text = "aktiv";
        }
        else if (upgrade.owned)
        {
            costText.text = "in Besitz";
        }
        else
        {
            costText.text = "$" + upgrade.cost;
        }
    }

    /// <summary>
    /// checks if clicked item is owned, if not lets the user buy the item.
    /// if owned lets the user equip the item
    /// </summary>
    void selectItem()
    {
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);

        var selected = EventSystem.current.currentSelectedGameObject;
        buttonTag = selected.tag;
        var index = Convert.ToInt32(buttonTag) - 1;


        if (cars[index].owned)
        {
            buyText.text = cars[index].carName + " verwenden?";
        }
        else
        {
            buyText.text = cars[index].cost + " Münzen für " + cars[index].carName + " eintauschen?";
        }

        buyText.color = Color.black;
        buyText.gameObject.SetActive(true);

        Button yes = yesButton.GetComponent<Button>();
        if (index == 0)
        {
            buyText.color = Color.blue;
            buyText.text = "Auto bereits in Verwendung!";
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
        }
        else
        {
            yes.onClick.AddListener(buyItem);
        }

        Button no = noButton.GetComponent<Button>();
        no.onClick.AddListener(hideConfirmDialog);
    }

    /// <summary>
    /// hides the dialog that asks if the user wants to buy an item
    /// </summary>
    void hideConfirmDialog()
    {
        buyText.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }

    void buyCar(int i)
    {
        if (validTransaction(cars[i].cost) || cars[i].owned)
        {
            if (!cars[i].owned)
            {
                updateCoins(cars[i].cost);

            }
            addNewCar(cars[i]);
            activeCar = cars[i];
            PlayerPrefs.SetInt("activeCar", i);
            PlayerPrefs.Save();
            fillTextfields();
        }
        else
        {
            warnAboutMoney();
        }
    }

    void buyUpgrade(int i, Text upgradeTitle, Text upgradeCost)
    {
        if (validTransaction(upgrades[i].cost) || upgrades[i].owned)
        {
            if (!upgrades[i].owned)
            {
                updateCoins(upgrades[i].cost);


            }
            addNewUpgrade(upgrades[i]);
            activeUpgrade = upgrades[i];
            PlayerPrefs.SetInt("activeUpgrade", i);
            PlayerPrefs.Save();
            fillTextfields();

        }
        else
        {
            warnAboutMoney();
        }
    }

    /// <summary>
    /// lets the user buy items
    /// </summary>
    void buyItem()
    {
        if (buttonTag != null)
        {
            int index = Convert.ToInt32(buttonTag) - 1;
            if (index >= 0 && index < carTitles.Length)
            {
                buyCar(index);
            }
            if (index >= carTitles.Length && index < carTitles.Length + upgradeTitles.Length)
            {
                buyUpgrade(index, upgradeTitles[index], upgradeCosts[index]);
            }
        }
    }

    /// <summary>
    /// called if not enough money available to buy item
    /// </summary>
    void warnAboutMoney()
    {
        buyText.color = Color.red;
        buyText.text = "nicht genug Geld!";
    }

    /// <summary>
    /// checks if user can buy the item
    /// </summary>
    /// <param name="cost"></param>
    /// <returns></returns>
    bool validTransaction(int cost)
    {
        return StartGame.coins >= cost;
    }

    /// <summary>
    /// updates current coins after buying an item
    /// </summary>
    /// <param name="cost"></param>
    void updateCoins(int cost)
    {
        StartGame.coins -= cost;
        PlayerPrefs.SetInt("coins", StartGame.coins);
        PlayerPrefs.Save();
        coinText.text = "$" + StartGame.coins;
    }

    void AddCarsToPlayerPrefs()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i].owned == true)
            {
                PlayerPrefs.SetString(cars[i].carName, "owned");
                PlayerPrefs.Save();
            }
        }
    }

    void AddUpgradesToPlayerPrefs()
    {
        for (int i = 0; i < upgrades.Length; i++)
        {
            if (upgrades[i] != null)
            {
                PlayerPrefs.SetString(upgrades[i].upgradeName, "owned");
                PlayerPrefs.Save();
            }
        }
    }

    void addNewCar(Car car)
    {
        car.owned = true;
        AddCarsToPlayerPrefs();
    }

    void addNewUpgrade(Upgrade upgrade)
    {
        upgrade.owned = true;
        AddUpgradesToPlayerPrefs();
    }
}
