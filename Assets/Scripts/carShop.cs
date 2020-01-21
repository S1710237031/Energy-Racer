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
    public Button car1Button;
    public Button car2Button;
    public Button car3Button;
    public Button upgrade1Button;
    public Button upgrade2Button;
    public Button upgrade3Button;
    private string buttonTag;
    public Text car1Title, car2Title, car3Title, car1Cost, car2Cost, car3Cost,
        upgrade1Title, upgrade2Title, upgrade3Title, upgrade1Cost, upgrade2Cost,
        upgrade3Cost;
    private int chosenUpgrade;
    public Car[] cars;
    public Upgrade[] upgrades;
    public Car activeCar;
    public Upgrade activeUpgrade;

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

        cars[0] = new Car("Standard Car", "standard car", 0, 0, true);
        cars[1] = new Car("Sports Car", "-2 needed moves", 200, 2, false);
        cars[2] = new Car("Super Car", "-3 needed moves", 400, 3, false);

        upgrades[0] = new Upgrade("Extra Move", "1 Move mehr", 75, 1, false);
        upgrades[1] = new Upgrade("Extra Move XL", "2 Moves mehr", 150, 2, false);
        upgrades[2] = new Upgrade("Extra Move XXL", "3 Moves mehr", 300, 3, false);
    }

    /// <summary>
    /// display info about upgrades
    /// </summary>
    void fillTextfields()
    {
        fillOutInfo(car1Title, car1Cost, cars[0]);
        fillOutInfo(car2Title, car2Cost, cars[1]);
        fillOutInfo(car3Title, car3Cost, cars[2]);
        fillOutInfo(upgrade1Title, upgrade1Cost, upgrades[0]);
        fillOutInfo(upgrade2Title, upgrade2Cost, upgrades[1]);
        fillOutInfo(upgrade3Title, upgrade3Cost, upgrades[2]);
    }
    /// <summary>
    /// method for filling the text fields for cars
    /// </summary>
    /// <param name="nameText"></param> text field for car name
    /// <param name="costText"></param> text field for car cost
    /// <param name="car"></param> chosen car object
    void fillOutInfo(Text nameText, Text costText, Car car)
    {
        nameText.text = car.carName;
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
    void fillOutInfo(Text nameText, Text costText, Upgrade upgrade)
    {
        nameText.text = upgrade.upgradeName;
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

        if (buttonTag == "1")
        {
            if (!cars[0].owned)
            {
                buyText.text = cars[0].carName + " tauschen?";
            }
            else
            {
                buyText.text = cars[0].carName + " verwenden?";
            }
        }
        if (buttonTag == "2")
        {
            if (!cars[1].owned)
            {
                buyText.text = cars[1].carName + " tauschen?";
            }
            else
            {
                buyText.text = cars[1].carName + " verwenden?";
            }
        }
        if (buttonTag == "3")
        {
            if (!cars[2].owned)
            {
                buyText.text = cars[2].carName + " tauschen?";
            }
            else
            {
                buyText.text = cars[2].carName + " verwenden?";
            }
        }
        if (buttonTag == "4")
        {
            if (!upgrades[0].owned)
            {
                buyText.text = upgrades[0].upgradeName + " tauschen?";
            }
            else
            {
                buyText.text = upgrades[0].upgradeName + " verwenden?";
            }
        }
        if (buttonTag == "5")
        {
            if (!upgrades[1].owned)
            {
                buyText.text = upgrades[1].upgradeName + " tauschen?";
            }
            else
            {
                buyText.text = upgrades[1].upgradeName + " verwenden?";
            }
        }
        if (buttonTag == "6")
        {
            if (!upgrades[2].owned)
            {
                buyText.text = upgrades[2].upgradeName + " tauschen?";
            }
            else
            {
                buyText.text = upgrades[2].upgradeName + " verwenden?";
            }
        }

        buyText.color = Color.black;
        buyText.gameObject.SetActive(true);

        Button yes = yesButton.GetComponent<Button>();
        if (buttonTag == "1")
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

    void buyCar(int i, Text carTitle, Text carCost)
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

        if (buttonTag == "1")
        {
            buyCar(0, car1Title, car1Cost);
        }
        else if (buttonTag == "2")
        {
            buyCar(1, car2Title, car2Cost);
        }
        else if (buttonTag == "3")
        {
            buyCar(2, car3Title, car3Cost);
        }
        else if (buttonTag == "4")
        {
            buyUpgrade(0, upgrade1Title, upgrade1Cost);
        }
        else if (buttonTag == "5")
        {
            buyUpgrade(1, upgrade2Title, upgrade2Cost);
        }
        else if (buttonTag == "6")
        {
            buyUpgrade(2, upgrade3Title, upgrade3Cost);
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


    /**
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
    public Text car1Title, car2Title, car3Title, car1Cost, car2Cost, car3Cost,
        upgrade1Title, upgrade2Title, upgrade3Title, upgrade1Cost, upgrade2Cost,
        upgrade3Cost;
    private int chosenUpgrade;
    public Car[] cars;

    // Start is called before the first frame update
    /// <summary>
    /// display buttons
    /// </summary>
    void Start()
    {

        coinText.text = "$" + StartGame.coins;
        hideConfirmDialog();
        createItems();
        fillTextfields();

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

    /// <summary>
    /// create all upgrades
    /// </summary>
    void createItems()
    {
        car1 = new Car("Standard Car", "standard car", 0, 0);
        car2 = new Car("Sports Car", "-2 needed moves", 200, 2);
        car3 = new Car("Super Car", "-3 needed moves", 400, 3);

        upgrade1 = new Upgrade("Extra Move", "1 zusätzlicher Zug", 75, 1);
        upgrade2 = new Upgrade("Extra Move XL", "2 zusätzliche Züge", 150, 2);
        upgrade3 = new Upgrade("Extra Move XXL", "3 zusätzliche Züge", 300, 3);
    }

    /// <summary>
    /// display info about upgrades
    /// </summary>
    void fillTextfields()
    {
        fillOutInfo(car1Title, car1Cost, car1);
        fillOutInfo(car2Title, car2Cost, car2);
        fillOutInfo(car3Title, car3Cost, car3);
        fillOutInfo(upgrade1Title, upgrade1Cost, upgrade1);
        fillOutInfo(upgrade2Title, upgrade2Cost, upgrade2);
        fillOutInfo(upgrade3Title, upgrade3Cost, upgrade3);

        car2Title.text = car2.carName;
        car2Cost.text = "$" + car2.cost;

        car3Title.text = car3.carName;
        car3Cost.text = "$" + car3.cost;

        upgrade1Title.text = upgrade1.upgradeName;
        upgrade1Cost.text = "$" + upgrade1.cost;

        upgrade2Title.text = upgrade2.upgradeName;
        upgrade2Cost.text = "$" + upgrade2.cost;

        upgrade3Title.text = upgrade3.upgradeName;
        upgrade3Cost.text = "$" + upgrade3.cost;
    }

    /// <summary>
    /// method for filling the text fields for cars
    /// </summary>
    /// <param name="nameText"></param> text field for car name
    /// <param name="costText"></param> text field for car cost
    /// <param name="car"></param> chosen car object
    void fillOutInfo(Text nameText, Text costText, Car car)
    {
        nameText.text = car.carName;
        if(car.cost == 0)
        {
            costText.text = "in Besitz";
        } else
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
    void fillOutInfo(Text nameText, Text costText, Upgrade upgrade)
    {
        nameText.text = upgrade.upgradeName;
        if (upgrade.cost == 0)
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

        if (buttonTag == "1")
        {
            if (car1.owned == "not owned")
            {
                buyText.text = car1.carName + " kaufen?";
            }
            else
            {
                buyText.text = car1.carName + " verwenden?";
            }
        }
        if (buttonTag == "2")
        {
            if (car2.owned == "not owned")
            {
                buyText.text = car2.carName + " kaufen?";
            }
            else
            {
                buyText.text = car2.carName + " verwenden?";
            }
        }
        if (buttonTag == "3")
        {
            if (car3.owned == "not owned")
            {
                buyText.text = car3.carName + " kaufen?";
            }
            else
            {
                buyText.text = car3.carName + " verwenden?";
            }
        }
        if (buttonTag == "4")
        {
            if (upgrade1.owned == "not owned")
            {
                buyText.text = upgrade1.upgradeName + " kaufen?";
            }
            else
            {
                buyText.text = upgrade1.upgradeName + " verwenden?";
            }
        }
        if (buttonTag == "5")
        {
            if (upgrade1.owned == "not owned")
            {
                buyText.text = upgrade2.upgradeName + " kaufen?";
            }
            else
            {
                buyText.text = upgrade2.upgradeName + " verwenden?";
            }
        }
        if (buttonTag == "6")
        {
            if (upgrade3.owned == "not owned")
            {
                buyText.text = upgrade3.upgradeName + " kaufen?";
            }
            else
            {
                buyText.text = upgrade3.upgradeName + " verwenden?";
            }
        }

        buyText.color = Color.black;
        buyText.gameObject.SetActive(true);

        Button yes = yesButton.GetComponent<Button>();
        yes.onClick.AddListener(buyItem);

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

    /// <summary>
    /// lets the user buy items
    /// </summary>
    void buyItem()
    {    
        if(buttonTag == "1")
        {
            if (validTransaction(car1.cost))
            {
                buyItem(car1);
                fillOutInfo(car1Title, car1Cost, car1);
            } else
            {
                warnAboutMoney();
            }
        } else if (buttonTag == "2")
        {
            if (validTransaction(car2.cost))
            {
                buyItem(car2);
                fillOutInfo(car2Title, car2Cost, car2);
            }
            else
            {
                warnAboutMoney();
            }
        }
        else if (buttonTag == "3")
        {
            if (validTransaction(car3.cost))
            {
                buyItem(car3);
                fillOutInfo(car3Title, car3Cost, car3);
            }
            else
            {
                warnAboutMoney();
            }
        }
        else if (buttonTag == "4")
        {
            if (validTransaction(upgrade1.cost))
            {
                buyItem(upgrade1);
                fillOutInfo(upgrade1Title, upgrade1Cost, upgrade1);
            }
            else
            {
                warnAboutMoney();
            }
        }
        else if (buttonTag == "5")
        {
            if (validTransaction(upgrade2.cost))
            {
                buyItem(upgrade2);
                fillOutInfo(upgrade2Title, upgrade2Cost, upgrade2);
            }
            else
            {
                warnAboutMoney();
            }
        }
        else if (buttonTag == "6")
        {
            if (validTransaction(upgrade3.cost))
            {
                buyItem(upgrade3);
                fillOutInfo(upgrade3Title, upgrade3Cost, upgrade3);
            }
            else
            {
                warnAboutMoney();
            }
        }
    }


    /// <summary>
    /// sets bought car to "owned"
    /// </summary>
    /// <param name="car"></param> the car
    void buyItem(Car car)
    {
        if (car.owned == "not owned")
        {
            updateCoins(car.cost);
            car.owned = "owned";
            car.cost = 0;
        }
        Board.car = car;
        if(car.owned == "owned")
        {
            buyText.text = car.carName + " ausgewählt!";
        }
    }

    /// <summary>
    /// sets bought upgrade to "owned"
    /// </summary>
    /// <param name="upgrade"></param> the upgrade
    void buyItem(Upgrade upgrade)
    {
        if (upgrade.owned == "not owned")
        {
            updateCoins(upgrade.cost);
            upgrade.owned = "owned";
            upgrade.cost = 0;
        }
        Board.upgrade = upgrade;
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
    bool validTransaction (int cost)
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
        coinText.text = "$" + StartGame.coins;
    }
    */
}
