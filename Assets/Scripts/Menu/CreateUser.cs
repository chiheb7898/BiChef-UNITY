using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreateUser : MonoBehaviour
{
    public TMP_InputField txt_username;
    public TMP_InputField txt_password;
    public TMP_InputField txt_mail;
    public TMP_Text controller;
    public TMP_InputField login_user;
    public TMP_InputField login_password;
    public GameObject signup;
    public GameObject signin;
    public GameObject menu_pannel;
    public GameObject home;
    public Toggle uiVibrationToggle;
    private string username;
    private string password;
    public TMP_Text invalid;
    public TMP_Text Scoretext;
    public GameObject Settings;
    private int score;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("login") == 0)
        {
            signup.SetActive(false);
            signin.SetActive(true);
        menu_pannel.SetActive(false);
        home.SetActive(false);
        }
        else {
            signin.SetActive(false);
            signup.SetActive(false);
            menu_pannel.SetActive(false);
            home.SetActive(true);
        }

    }
    private void Start()
    {
        username = PlayerPrefs.GetString("username");
        password = PlayerPrefs.GetString("password");
        score = PlayerPrefs.GetInt("score");
    }
    // Start is called before the first frame update
    public void createuser()
    {
        if (txt_username.text == "" || txt_password.text == "" || txt_mail.text == "")
        { controller.text = "your inputs is emplty";
            Debug.Log("test1");
        }
        else if (txt_password.text.Length < 5)
        {
            controller.text = "password is incorrect ";
            Debug.Log("test2");
        }

        else
        {
            Debug.Log("test2");
            PlayerPrefs.SetString("username", txt_username.text);
            PlayerPrefs.SetString("mail", txt_mail.text);
            PlayerPrefs.SetString("password", txt_password.text);
            PlayerPrefs.SetInt("score", 0);
            controller.text = "user created !! ";
            signup.SetActive(false);
            signin.SetActive(true);

        }

    }
    public void login()
    {
        if(login_user.text != "" || login_password.text != "" )
        {
            if (uiVibrationToggle.isOn)
            {
                PlayerPrefs.SetInt("login", 1);
                PlayerPrefs.SetString("username", login_user.text);
                PlayerPrefs.SetString("mail", txt_mail.text);
                PlayerPrefs.SetString("password", txt_password.text);
                PlayerPrefs.SetInt("score", 0);
                signin.SetActive(false);
                Scoretext.text = score.ToString();
                home.SetActive(true);
            }
            else
            {
                PlayerPrefs.SetString("username", login_user.text);
                PlayerPrefs.SetString("mail", "test");
                PlayerPrefs.SetString("password", "");
                PlayerPrefs.SetInt("score", 0);
                PlayerPrefs.SetInt("login", 1);
                Debug.Log("login true");
                signin.SetActive(false);
                Scoretext.text = score.ToString();
                home.SetActive(true);
            }
                }
        else
        {
            invalid.text = "username or password is invalid";
        }
    }
    public void play()
    {
        home.SetActive(false);
        menu_pannel.SetActive(true);
    }
    public void Setting()
    {
        Settings.SetActive(true);

    }
    public void logout()
    {
        PlayerPrefs.DeleteAll();
        Settings.SetActive(false);
        signin.SetActive(false);
        menu_pannel.SetActive(false);
        home.SetActive(false);
        signup.SetActive(true);
    }
    public void exit()
    {
        Application.Quit();
    }
}
