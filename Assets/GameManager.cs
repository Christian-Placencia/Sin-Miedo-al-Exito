using UnityEngine;
// Library for scene manipulation (for Game Over).
using UnityEngine.SceneManagement;
// Library for text and button manipulation.
using TMPro;
using UnityEngine.UI;

// FUNCTION: This script handles score and fail states.
// NOTES:
// * This script uses singleton logic.
// * Singleton: A class that is (1) easily accesible from other scripts and (2) can only be instanced once at a time.

public class GameManager : MonoBehaviour
{
    // Inspector field for the Game Over Text.
    // [SerializeField] private GameObject gameOverText;

    // Inspector fields for stats.
    [SerializeField] private TMP_Text savingsText;
    [SerializeField] private TMP_Text salaryText;
    [SerializeField] private TMP_Text investmentText;
    [SerializeField] private TMP_Text expensesText;
    [SerializeField] private TMP_Text maxCreditText;
    [SerializeField] private TMP_Text pendingCreditText;
    [SerializeField] private TMP_Text dueCreditText;
    [SerializeField] private TMP_Text minCreditText;
    [SerializeField] private TMP_Text creditHistoryText;
    [SerializeField] private TMP_Text statusText;

    // Inspector fields for story interface.
    [SerializeField] private TMP_Text headerText;
    [SerializeField] private TMP_Text button1Text;
    [SerializeField] private TMP_Text button2Text;

    // Bool for fail states.
    public bool isInDebt;
    public bool isGameOver;

    // Stat counters.
    public float savings;
    public float salary;
    public float investment;
    public float expenses;
    public float maxCredit;
    public float pendingCredit;
    public float dueCredit;
    public float minCredit;
    public string creditHistory;
    public string status;

    // Creates a singleton GameManager instance and its getter.
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }


    // Awake is called before Start (the first frame update).
    void Awake()
    {
        // Singleton logic that ensures that only one instance exists at a time.
        if (instance == null)
            instance = this;
        else
            Destroy(instance);

        // Stat Initialization
        InitializeStats();
        UpdateStats();

        // Game Panel Initialization
        ClearStoryPanel();
    }

    // Update is called every frame.
    private void Update()
    {
        // Restarts the game when (1) the Left Mouse Button is clicked and (2) the game is over.
        // if (Input.GetMouseButtonDown(0) && isGameOver)
        //    RestartGame();
    }

    // GameOver displays the Game Over text and allows the player to restart.
    // It is declared as a public function so that it can be called from any other script.
    public void GameOver()
    {
        isGameOver = true;
        // gameOverText.SetActive(true);
    }

    // RestartGame resets the scene and allows the game to start anew.
    private void RestartGame()
    {
        // Reloads the active scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void InitializeStats()
    {
        savings = 0;
        salary = 100;
        investment = 0;
        expenses = 50;
        maxCredit = 500;
        pendingCredit = 0;
        dueCredit = 0;
        minCredit = 0;
        creditHistory = "Bueno";
        status = "Bajo";
    }

    private void UpdateStats()
    {
        savingsText.text = "$" + savings.ToString();
        salaryText.text = "$" + salary.ToString();
        investmentText.text = "$" + investment.ToString();
        expensesText.text = "$" + expenses.ToString();
        maxCreditText.text = "$" + maxCredit.ToString();
        pendingCreditText.text = "$" + pendingCredit.ToString();
        dueCreditText.text = "$" + dueCredit.ToString();
        minCreditText.text = "$" + minCredit.ToString();
        creditHistoryText.text = creditHistory;
        statusText.text = status;
    }

    // ChangeStat adds to a stat by a certain amount and displays the new value.
    public void ChangeStat(string stat, float amount = 0, string new_tag = "Bueno")
    {
        switch(stat)
        {
            case "savings":
                savings += amount;
                savingsText.text = "$" + savings.ToString();
                break;

            case "salary":
                salary += amount;
                salaryText.text = "$" + salary.ToString();
                break;

            case "investment":
                investment += amount;
                investmentText.text = "$" + investment.ToString();
                break;

            case "expenses":
                expenses += amount;
                expensesText.text = "$" + expenses.ToString();
                break;

            case "maxCredit":
                maxCredit += amount;
                maxCreditText.text = "$" + maxCredit.ToString();
                break;

            case "pendingCredit":
                pendingCredit += amount;
                pendingCreditText.text = "$" + pendingCredit.ToString();
                break;

            case "dueCredit":
                dueCredit += amount;
                dueCreditText.text = "$" + dueCredit.ToString();
                break;

            case "minCredit":
                minCredit += amount;
                minCreditText.text = "$" + minCredit.ToString();
                break;

            case "creditHistory":
                creditHistory = new_tag;
                creditHistoryText.text = creditHistory;
                break;

            case "status":
                status = new_tag;
                statusText.text = status;
                break;

            default:
                Debug.Log(stat + " not recognized.");
                break;
        }
    }
    public void ChangeHeader(string text)
    {
        headerText.text = text;
    }

    public void ChangeButton(int button, string text)
    {
        switch (button)
        {
            case 1:
                button1Text.text = text;
                break;

            case 2:
                button2Text.text = text;
                break;

            default:
                Debug.Log(button.ToString() + " not recognized.");
                break;
        }
    }

    public void ClearStoryPanel()
    {
        headerText.text = "";
        button1Text.text = "";
        button2Text.text = "";
    }
}