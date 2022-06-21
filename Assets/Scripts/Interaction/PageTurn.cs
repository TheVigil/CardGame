using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurn : MonoBehaviour
{

    /**
     * TODO: refactor with less spagehtti.
     *  
     *  Represent this a a state machine with states q0 . . . q9.
     *  
     *  Designate per state the active objects.
     *
     */

    /**
     * 
     * Use this to turn the pages of the tutorial text.
     * 
     */

    #region declarations
    private GameObject NavButtonForward;
    private GameObject NavButtonBack;

    // TextMesh objects containing the instructions of the game
    private GameObject IntroPage;
    private GameObject Page1;
    private GameObject Page2;
    private GameObject Page3;
    private GameObject Page4;
    private GameObject Page5;
    private GameObject Page6;

    // TextMesh Objects containging the descriptions of the choosable characters
    private GameObject MuseumswaerterHeader;
    private GameObject MuseumswaerterBody;

    private GameObject MuseumdirektorinHeader;
    private GameObject MuseumdirektorinBody;

    private GameObject KunstkennerHeader;
    private GameObject KunstkennerBody;

    private GameObject MuseumsdiebinHeader;
    private GameObject MuseumsdiebinBody;

    private static event Action<TutorialState> OnTutorialStateChanged;

    private TutorialState tutorialState;
    private int StateIndex; //q0 ... q9 of the state machine

    private List<GameObject> TextObjects = new List<GameObject>();
    private List<Tuple<GameObject, GameObject>> CharacterTextObjects = new List<Tuple<GameObject, GameObject>>();

    public enum TutorialState
    {
        introPage,
        page1,
        page2,
        page3,
        page4,
        page5,
        page6,
        page7,
        page8,
        page9,
    }
    #endregion

    #region unity methods
    private void Awake()
    {
        StateIndex = 0;

        InitNavButtons();
        InitTextElementObjects();
        InitCharacterGameObjects();

        // ensure screen is clear of unwanted text meshes
        DeactivateTextElements(0);

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
        TextObjects.Add(IntroPage = GameObject.Find("IntroPage"));
        TextObjects.Add(Page1 = GameObject.Find("Page1"));
        TextObjects.Add(Page2 = GameObject.Find("Page2"));
        TextObjects.Add(Page3 = GameObject.Find("Page3"));
        TextObjects.Add(Page4 = GameObject.Find("Page4"));
        TextObjects.Add(Page5 = GameObject.Find("Page5"));
        TextObjects.Add(Page6 = GameObject.Find("Page6"));
    }

    private void InitCharacterGameObjects()
    {

        CharacterTextObjects.Add(Tuple.Create(MuseumswaerterHeader = GameObject.Find("MuseumswaerterHeader"), MuseumswaerterBody = GameObject.Find("MuseumswaerterBody")));
        CharacterTextObjects.Add(Tuple.Create(MuseumdirektorinHeader = GameObject.Find("MuseumdirektorinHeader"), MuseumdirektorinBody = GameObject.Find("MuseumdirektorinBody")));
        CharacterTextObjects.Add(Tuple.Create(KunstkennerHeader = GameObject.Find("KunstkennerHeader"), KunstkennerBody = GameObject.Find("KunstkennerBody")));
        CharacterTextObjects.Add(Tuple.Create(MuseumsdiebinHeader = GameObject.Find("MuseumsdiebinHeader"), MuseumsdiebinBody = GameObject.Find("MuseumsdiebinBody")));

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

        NavButtonBack.SetActive(false);
        
        TextObjects[0].SetActive(true);

    }

    private void SetUpPage1()
    {
        NavButtonBack.SetActive(true);

        DeactivateTextElements(0);

        TextObjects[1].SetActive(true);

        // extra setup for character info
        CharacterTextObjects[0].Item1.SetActive(true);
        CharacterTextObjects[0].Item2.SetActive(true);

    }
    
    private void SetUpPage2()
    {
        DeactivateTextElements(1);

        // extra setup for character info
        CharacterTextObjects[1].Item1.SetActive(true);
        CharacterTextObjects[1].Item2.SetActive(true);

    }

    private void SetUpPage3()
    {
        DeactivateTextElements(1);

        // extra setup for character info
        CharacterTextObjects[2].Item1.SetActive(true);
        CharacterTextObjects[2].Item2.SetActive(true);
    }

    private void SetUpPage4()
    {
        DeactivateTextElements(1);

        // extra setup for character info
        CharacterTextObjects[3].Item1.SetActive(true);
        CharacterTextObjects[3].Item2.SetActive(true);
    }

    private void SetUpPage5()
    {
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
        // clean the scene of active text meshes. Needs to be called to deactivate game objects after variable assignment in Awake() call.

        if(mode == 0)
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
