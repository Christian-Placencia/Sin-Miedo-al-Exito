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
    //[SerializeField] private TMP_Text headerText;
    //[SerializeField] private Image image;
    //[SerializeField] private TMP_Text button1Text;
    //[SerializeField] private TMP_Text button2Text;
    //[SerializeField] private TMP_Text button3Text;

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
    public float credit;
    public int status;

    private float input;

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
        //InitializeStats();
        UpdateStats();

        // Game Panel Initialization
        // ClearStoryPanel();
    }

    // Update is called every frame.
    private void Update()
    {
        // Restarts the game when (1) the Left Mouse Button is clicked and (2) the game is over.
        // if (Input.GetMouseButtonDown(0) && isGameOver)
        //    RestartGame();
        if (pendingCredit > 30000)
        {
            LoadScene("BadEnding");
        }
    }

    public void ReadStringInput(string box_input)
    {
        input = float.Parse(box_input);
        Debug.Log(input.ToString());
    }

    // GameOver displays the Game Over text and allows the player to restart.
    // It is declared as a public function so that it can be called from any other script.
    public void GameOver()
    {
        isGameOver = true;
        //gameOverText.SetActive(true);
    }

    // RestartGame resets the scene and allows the game to start anew.
    private void RestartGame()
    {
        // Reloads the active scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // RestartGame resets the scene and allows the game to start anew.
    public void LoadScene(string scene)
    {
        // Reloads the active scene.
        SceneManager.LoadScene(scene);
    }

    //private void InitializeStats()
    //{
    //    savings = 0;
    //    salary = 100;
    //    investment = 0;
    //    expenses = 50;
    //    maxCredit = 500;
    //    pendingCredit = 0;
    //    dueCredit = 0;
    //    minCredit = 0;
    //    creditHistory = 0;
    //    status = 1;
    //}

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
        creditHistoryText.text = credit.ToString();
        statusText.text = status.ToString();
    }

    public void SetSalary(float amount = 0)
    {
        salary = amount;
        salaryText.text = "$" + salary.ToString();
    }

    // SAVINGS
    public void Pay(float amount)
    {
        if (amount > savings)
        {
            if (amount - savings > investment)
            {
                AddToCredit(amount - savings - investment);
                SetSavings(0);
                SetInvestment(0);
            }
            else
            {
                AddToInvestment(-(amount - savings));
                SetSavings(0);
            }
        }
        else
        {
            AddToSavings(-amount);
        }
    }

    public void AddToSavings(float amount)
    {
        savings += amount;
        savingsText.text = "$" + savings.ToString();
    }
    public void SetSavings(float amount)
    {
        savings = amount;
        savingsText.text = "$" + savings.ToString();
    }

    // INVESTMENT
    public void AddToInvestment(float amount)
    {
        investment += amount;
        investmentText.text = "$" + investment.ToString();
    }
    public void SetInvestment(float amount)
    {
        investment = amount;
        investmentText.text = "$" + investment.ToString();
    }
    public void InvestmentLow()
    {
        Pay(input);
        AddToInvestment(input * 1.06f);
    }
    public void InvestmentMed()
    {
        Pay(input);
        AddToInvestment(input * 1.12f);
    }
    public void InvestmentHigh()
    {
        Pay(input);
        AddToInvestment(input * 1.18f);
    }

    // MONTHLY EXPENSES
    public void PayExpenses()
    {
        Pay(expenses);
    }
    public void AddToExpenses(float amount)
    {
        expenses += amount;
        expensesText.text = "$" + expenses.ToString();
    }

    // CREDIT
    public void AddToCredit(float amount = 0)
    {
        credit += amount;
        creditHistoryText.text = "$" + credit.ToString();
    }

    public void SetCredit(float amount = 0)
    {
        credit = amount;
        creditHistoryText.text = "$" + credit.ToString();
    }
    public void CutoffDate()
    {
        AddToDueCredit(credit);
        credit = 0;
        creditHistoryText.text = "$" + credit.ToString();

        minCredit = (pendingCredit + dueCredit) * 0.10f;
        minCreditText.text = "$" + minCredit.ToString();
    }
    public void AddToDueCredit(float amount = 0)
    {
        dueCredit += amount;
        dueCreditText.text = "$" + dueCredit.ToString();
    }
    public void SetDueCredit(float amount = 0)
    {
        dueCredit = amount;
        dueCreditText.text = "$" + dueCredit.ToString();
    }
    public void AddToPendingCredit(float amount = 0)
    {
        pendingCredit += amount;
        pendingCreditText.text = "$" + pendingCredit.ToString();
    }
    public void PayCredit()
    {
        Pay(input);
        if(input > dueCredit)
        {
            AddToPendingCredit(-(input - dueCredit));
            SetDueCredit(0);
        }
        else
        {
            AddToDueCredit(-input);
        }
        if (input < minCredit)
        {
            AddToStatus(-1);
        }
        AddToPendingCredit(dueCredit);
        SetDueCredit(0);
        SetMinCredit(0);
    }
    public void ApplyInterest()
    {
        pendingCredit *= 1.2f;
        pendingCreditText.text = "$" + pendingCredit.ToString();
    }

    public void AddToMaxCredit(float amount = 0)
    {
        maxCredit += amount;
        maxCreditText.text = "$" + maxCredit.ToString();
    }

    // OTHER FUNCTIONS
    public void SetMinCredit(float amount = 0)
    {
        minCredit += amount;
        minCreditText.text = "$" + minCredit.ToString();
    }


    public void AddToStatus(int amount = 0)
    {
        status += amount;
        statusText.text = status.ToString();
    }
}