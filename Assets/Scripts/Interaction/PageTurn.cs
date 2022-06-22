using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurn : MonoBehaviour
{
    /**
     * 
     * This class is a finite state machine that "turns" the pages of the instruction manual.
     * Each state represents a page. The setup method builds the corresponding state/page
     * while tearing down the previous state/page.
     * 
     */

    #region declarations
    private GameObject NavButtonForward;
    private GameObject NavButtonBack;

    private GameObject CharacterSprite;
    private GameObject BannerSprite;


    private static event Action<TutorialState> OnTutorialStateChanged;
    private TutorialState tutorialState;
    private int StateIndex; // corresponds to the current state of the FSM: q0. . .q9

    private List<GameObject> TextObjects = new List<GameObject>();
    private List<Tuple<GameObject, GameObject>> CharacterTextObjects = new List<Tuple<GameObject, GameObject>>(); // Each character page consists of a header and body, so they are joined pairwise here.

    public enum TutorialState
    {
        // states are named colloqiually and not by index
        introPage, //q0 . . . 
        page1,
        page2,
        page3,
        page4,
        page5,
        page6,
        page7,
        page8,
        page9, //q9
    }
    #endregion

    #region unity methods
    private void Awake()
    {
        StateIndex = 0;

        InitNavButtons();
        InitTextElementObjects();
        InitCharacterGameObjects();
        CharacterSprite = GameObject.Find("CharacterSprite");
        BannerSprite = GameObject.Find("CharacterBannerSprite");

        // ensure screen is clear of unwanted text meshes
        DeactivateTextElements(0);

        // disable the sprites for characters for now
        CharacterSprite.SetActive(false);
        BannerSprite.SetActive(false);

        //Start the state machine at q0
        NewState();
    }
    #endregion

    #region public onPointerClick methods
    public void PageForward()
    {
        StateIndex++;
        NewState();
    }

    public void PageBack()
    {
        StateIndex--;
        NewState();
    }
    #endregion

    #region initialization methods
    private void InitNavButtons()
    {
        NavButtonForward = GameObject.Find("NavButtonForward");
        NavButtonBack = GameObject.Find("NavButtonBack");
    }

    private void InitTextElementObjects()
    {
        TextObjects.Add(GameObject.Find("IntroPage"));
        TextObjects.Add(GameObject.Find("Page1"));
        TextObjects.Add(GameObject.Find("Page2"));
        TextObjects.Add(GameObject.Find("Page3"));
        TextObjects.Add(GameObject.Find("Page4"));
        TextObjects.Add(GameObject.Find("Page5"));
        TextObjects.Add(GameObject.Find("Page6"));
    }

    private void InitCharacterGameObjects()
    {

        CharacterTextObjects.Add(Tuple.Create(GameObject.Find("MuseumswaerterHeader"), GameObject.Find("MuseumswaerterBody")));
        CharacterTextObjects.Add(Tuple.Create(GameObject.Find("MuseumdirektorinHeader"), GameObject.Find("MuseumdirektorinBody")));
        CharacterTextObjects.Add(Tuple.Create(GameObject.Find("KunstkennerHeader"), GameObject.Find("KunstkennerBody")));
        CharacterTextObjects.Add(Tuple.Create(GameObject.Find("MuseumsdiebinHeader"), GameObject.Find("MuseumsdiebinBody")));

    }
    #endregion

    #region State Manipulation
    private void UpdateTutorialState(TutorialState newTutorialState)
    {
        tutorialState = newTutorialState;

        switch (tutorialState)
        {
            case TutorialState.introPage:
                SetUpIntroPage();
                break;
            case TutorialState.page1:
                SetUpPage1();   
                break;
            case TutorialState.page2:
                SetUpPage2();
                break;
            case TutorialState.page3:
                SetUpPage3();
                break;
            case TutorialState.page4:
                SetUpPage4();
                break;
            case TutorialState.page5:
                SetUpPage5();
                break;
            case TutorialState.page6:
                SetUpPage6();
                break;
            case TutorialState.page7:
                SetUpPage7();
                break;
            case TutorialState.page8:
                SetUpPage8();
                break;
            case TutorialState.page9:
                SetUpPage9();
                break;
            default:
                break;
        }
        OnTutorialStateChanged?.Invoke(newTutorialState);
    }
    private void NewState()
    {
        switch (StateIndex)
        {
            case 0:
                UpdateTutorialState(TutorialState.introPage);
                break;
            case 1:
                UpdateTutorialState(TutorialState.page1);
                break;
            case 2:
                UpdateTutorialState(TutorialState.page2);
                break;
            case 3:
                UpdateTutorialState(TutorialState.page3);
                break;
            case 4:
                UpdateTutorialState(TutorialState.page4);
                break;
            case 5:
                UpdateTutorialState(TutorialState.page5);
                break;
            case 6:
                UpdateTutorialState(TutorialState.page6);
                break;
            case 7:
                UpdateTutorialState(TutorialState.page7);
                break;
            case 8:
                UpdateTutorialState(TutorialState.page8);
                break;
            case 9:
                UpdateTutorialState(TutorialState.page9);
                break;
            default:
                break;
        }
    }
    #endregion

    #region PageSetup methods
    private void SetUpIntroPage()
    {
        DeactivateTextElements(0);
        ToggleCharacterSprites(0);

        NavButtonBack.SetActive(false);

        TextObjects[0].SetActive(true);

    }

    private void ToggleCharacterSprites(int mode)
    {
        //Toggle the Sprites for characters

        if (mode == 0)
        {
            CharacterSprite.SetActive(false);
            BannerSprite.SetActive(false);
        }
        if(mode == 1)
        {
            CharacterSprite.SetActive(true);
            BannerSprite.SetActive(true);
        }
    }

    private void SetUpPage1()
    {
        DeactivateTextElements(0);
        ToggleCharacterSprites(1);

        NavButtonBack.SetActive(true);
        TextObjects[1].SetActive(true);

        // extra setup for character info
        ToggleCharacterSprites(1);

        CharacterSprite.GetComponent<SpriteRenderer>()
            .sprite = Resources.Load<Sprite>("CharacterSprites/character_museumswaerter");

        BannerSprite.GetComponent<SpriteRenderer>()
            .sprite = Resources.Load<Sprite>("CharacterSprites/sign_museumswaerter");

        CharacterTextObjects[0].Item1.SetActive(true);
        CharacterTextObjects[0].Item2.SetActive(true);

    }
    
    private void SetUpPage2()
    {
        DeactivateTextElements(1);
        ToggleCharacterSprites(1);

        // extra setup for character info
        CharacterSprite.GetComponent<SpriteRenderer>()
            .sprite = Resources.Load<Sprite>("CharacterSprites/character_museumsdirektor");

        BannerSprite.GetComponent<SpriteRenderer>()
            .sprite = Resources.Load<Sprite>("CharacterSprites/sign_museumsdirektor");

        CharacterTextObjects[1].Item1.SetActive(true);
        CharacterTextObjects[1].Item2.SetActive(true);

    }

    private void SetUpPage3()
    {
        DeactivateTextElements(1);
        ToggleCharacterSprites(1);

        // extra setup for character info
        CharacterSprite.GetComponent<SpriteRenderer>()
            .sprite = Resources.Load<Sprite>("CharacterSprites/character_kunstsammlerin");

        BannerSprite.GetComponent<SpriteRenderer>()
            .sprite = Resources.Load<Sprite>("CharacterSprites/sign_kunstsammlerin");

        CharacterTextObjects[2].Item1.SetActive(true);
        CharacterTextObjects[2].Item2.SetActive(true);
    }

    private void SetUpPage4()
    {
        DeactivateTextElements(1);
        ToggleCharacterSprites(1);

        TextObjects[1].SetActive(true); // for the way back

        // extra setup for character info
        CharacterSprite.GetComponent<SpriteRenderer>()
            .sprite = Resources.Load<Sprite>("CharacterSprites/character_kunstdiebin");

        BannerSprite.GetComponent<SpriteRenderer>()
            .sprite = Resources.Load<Sprite>("CharacterSprites/sign_kunstdiebin");

        CharacterTextObjects[3].Item1.SetActive(true);
        CharacterTextObjects[3].Item2.SetActive(true);
    }

    private void SetUpPage5()
    {
        ToggleCharacterSprites(0);
        DeactivateTextElements(0);
        TextObjects[2].SetActive(true);
    }

  
    private void SetUpPage6()
    {
        DeactivateTextElements(0);
        TextObjects[3].SetActive(true);
    }

    private void SetUpPage7()
    {
        DeactivateTextElements(0);
        TextObjects[4].SetActive(true);
    }

    private void SetUpPage8()
    {
        DeactivateTextElements(0);
        TextObjects[5].SetActive(true);
    }

    private void SetUpPage9()
    {
        DeactivateTextElements(0);
        NavButtonForward.SetActive(false);
        TextObjects[6].SetActive(true);
    }


    private void DeactivateTextElements(int mode)
    {
        /**
         *   Deactivate all active text mesh objects.
         *   
         *   Parameters
         *   ----------
         *   mode : int
         *       specifies what to deactivate. 
         *       0 -> deactivate everything 
         *       1 -> deactivate everything EXCEPT the intro text for the character pages.
         *          
         */

        if (mode == 0)
        {
            foreach (var textObject in TextObjects)
            {
                textObject.SetActive(false);
            }

            foreach (var characterTextObject in CharacterTextObjects)
            {
                characterTextObject.Item1.SetActive(false);
                characterTextObject.Item2.SetActive(false);
            }
        }        
        if(mode == 1)
        {
            foreach (var textObject in TextObjects)
            {
                if(textObject.name == "Page1")
                {
                    Debug.Log("hit");
                    continue;
                }
                else
                {
                    textObject.SetActive(false);
                }

                
            }

            foreach (var characterTextObject in CharacterTextObjects)
            {
                characterTextObject.Item1.SetActive(false);
                characterTextObject.Item2.SetActive(false);
            }
        }

    }
    #endregion
}
