using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class test : MonoBehaviour
{
    Image m_Image;

    Sprite icon_image;

    public Sprite[] spritesList;
    public Button[] buttons;
    Button btn;

    private GameObject timerText;
    Text meh;
    int score = 0;

    int i;
    float timer, countDown = 60f;

    void Start()
    {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();

        timerText = GameObject.Find("CountDownText");
        meh = timerText.GetComponent<Text>();

        //Button btns = buttons[0].GetComponent<Button>();
        //btns.onClick.AddListener(TaskOnClick);


        for (int a = 0; a < buttons.Length; a++)
            btn = buttons[a].GetComponent<Button>();
            btn.onClick.AddListener(TaskOnClick);
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
                timer = 3f;
                if (Mathf.RoundToInt(countDown) <= 40)
                    timer = 2f;
                else if (Mathf.RoundToInt(countDown) <= 20)
                    timer = 1f;
                else if (Mathf.RoundToInt(countDown) <= 10)
                    timer = 0.8f;
                i = UnityEngine.Random.Range(0, spritesList.Length);
                //Debug.Log(spritesList.Length);
                m_Image.sprite = spritesList[i];
                m_Image.color = new Color(m_Image.color.r, m_Image.color.g, m_Image.color.b, 255f);
                //Debug.Log(score);
            }
        }
        else
        {
            meh.text = "Final Score : " + score;
        }


    }

    void TaskOnClick()
    {
        if (i == 0)
            score += 1;
        Debug.Log(score);
    }

}
