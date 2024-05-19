using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_cam : MonoBehaviour
{
    public Animator animator;
    public GameObject main_menu;
    public GameObject settings_menu;
    public GameObject exit_menu;
    public GameObject loading;
    public GameObject scoreboard;
    public GameObject multi_menu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void move_to_menu_multi()
    {
        animator.SetBool("move_to_multiplayer_menu", true);
        main_menu.SetActive(false);
    }
    public void move_to_multiplayer()
    {
        animator.SetBool("move_to_multi", true);
        main_menu.SetActive(false);
    }
    public void move_to_start()
    {
        animator.SetBool("move_start", true);
        main_menu.SetActive(false);
    }
    public void move_to_settings()
    {
        animator.SetBool("move_settings", true);
        main_menu.SetActive(false);
    }    
    public void move_to_exit()
    {
        animator.SetBool("move_exit", true);
        main_menu.SetActive(false);
    }     
    public void move_to_scoreboard()
    {
        animator.SetBool("move_to_scoreboard", true);
        main_menu.SetActive(false);
    }
    public void show_setting()
    {
        settings_menu.SetActive(true);
    }
    public void show_exit()
    {
        exit_menu.SetActive(true);
    }
    public void show_main_menu()
    {
        main_menu.SetActive(true);
    }
    public void show_scoreboard()
    {
        scoreboard.SetActive(true);
    }
    public void show_multi_menu()
    {
        multi_menu.SetActive(true);
    }
    public void goback_settings()
    {
        animator.SetBool("move_idle_settings", true);
        settings_menu.SetActive(false);
    }
    public void goback_exit()
    {
        animator.SetBool("move_idle_exit", true);
        exit_menu.SetActive(false);
    }
    public void goback_scoreboard()
    {
        animator.SetBool("scoreboard_to_idle", true);
        scoreboard.SetActive(false);
    }
    public void show_loading()
    {
        loading.SetActive(true);
    } 
    public void reset() 
    {
        animator.SetBool("move_to_multiplayer_menu", false);
        animator.SetBool("move_to_multi", false);
        animator.SetBool("move_start", false);
        animator.SetBool("move_settings", false);
        animator.SetBool("move_exit", false); 
        animator.SetBool("move_to_scoreboard", false);
        animator.SetBool("move_idle_exit", false);
        animator.SetBool("scoreboard_to_idle", false);
        animator.SetBool("move_idle_settings", false);

    }
}
