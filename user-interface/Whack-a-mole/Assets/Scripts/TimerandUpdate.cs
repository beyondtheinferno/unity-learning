using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TimerandUpdate : MonoBehaviour
{
    // Outer Script referencing
    ScoreManager script;

    // Timer Text
    float countDown = 60f;
    private GameObject timerText;
    Text meh;

    // Randomizer
    float timer;
    public int i;

    // Sprites list and the sprite which is rendered
    public Sprite[] spritesList;
    Image spriteRendered;
    public Sprite empty;



    // Activated when button is clicked
    public void TaskOnClick()
    {
        if (i == 0)
        {
            script.score += 1;
            spriteRendered.sprite = empty;
        }
        //Debug.Log(script.score);
    }



    void Start()
    {
        //Reference of the script having the "score" variable
        script = GameObject.Find("GameManager").GetComponent<ScoreManager>();

        spriteRendered = GetComponent<Image>();
        timerText = GameObject.Find("CountDownText");
        meh = timerText.GetComponent<Text>();
    }



    void Update()
    {
        meh.text = "Time : " + Mathf.RoundToInt(countDown) + "s";
        countDown -= Time.deltaTime;

        if (countDown > 0)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                // Adjusting difficulty
                timer = 3f;
                if (Mathf.RoundToInt(countDown) <= 40)
                    timer = 2f;
                else if (Mathf.RoundToInt(countDown) <= 20)
                    timer = 1f;
                else if (Mathf.RoundToInt(countDown) <= 10)
                    timer = 0.8f;

                // Random index generation to select any one sprite from the given 5
                i = UnityEngine.Random.Range(0, spritesList.Length);
                spriteRendered.sprite = spritesList[i];
                spriteRendered.color = new Color(spriteRendered.color.r, spriteRendered.color.g, spriteRendered.color.b, 255f);
            }
        }

        else
            meh.text = "Final Score : " + script.score;
    }
}
