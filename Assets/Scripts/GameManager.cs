using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int deadliness = 0;
    public static GameManager Instance;
    private IGameState currentState;

     void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [SerializeField]
    private TextMeshProUGUI deadlinessText; 
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //SetState(new MainMenuState());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int updateDeadliness(int amount)
    {
        deadliness += amount;
        deadlinessText.text = "Deadliness: " + deadliness;
        return deadliness;
    }

    public void SetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetState(IGameState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }
        currentState = newState;
        currentState.OnEnter();
    }
}
