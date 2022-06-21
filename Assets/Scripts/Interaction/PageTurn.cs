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
    private GameObject Text1;
    private GameObject Text2;
    private GameObject Text3;
    private GameObject Text3b;
    private GameObject Text4;
    private GameObject Text4b;
    private GameObject Text5;

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

    private List<GameObject> TextObjects = new List<GameObject>();
    private List<Tuple<GameObject, GameObject>> CharacterTextObjects = new List<Tuple<GameObject, GameObject>>();

    private int PageCounter;
    private int CharactersCounter;

    public enum TutorialState
    {
        intro,
        characters,
        page3,
        page4,
        page5,
        page5b,
        page6,
        charactersBack,
    }
    #endregion

    #region unity methods
    private void Awake()
    {
        PageCounter = 0;
        CharactersCounter = 0;

        InitNavButtons();
        InitTextElementObjects();
        InitCharacterGameObjects();

        DeactivateTextElements();

        // hide the back button for the first page
        NavButtonBack.SetActive(false);
        StateForward();
    }
    #endregion

    #region public onPointerClick methods
    public void PageForward()
    {
        PageCounter++;
        StateForward();
    }

    public void PageBack()
    {
        PageCounter--;
        StateBack();
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
        TextObjects.Add(Text1 = GameObject.Find("Text1"));
        TextObjects.Add(Text2 = GameObject.Find("Text2"));
        TextObjects.Add(Text3 = GameObject.Find("Text3"));
        TextObjects.Add(Text3b = GameObject.Find("Text3b"));
        TextObjects.Add(Text4 = GameObject.Find("Text4"));
        TextObjects.Add(Text4b = GameObject.Find("Text4b"));
        TextObjects.Add(Text5 = GameObject.Find("Text5"));
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

        switch (newTutorialState)
        {
            case TutorialState.intro:
                SetUpIntro();
                break;
            case TutorialState.characters:
                SetCharactersForward(CharactersCounter);
                break;
            case TutorialState.charactersBack:
                SetCharactersBack();
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
            case TutorialState.page5b:
                SetUpPage5b();
                break;
            case TutorialState.page6:
                SetUpPage6();
                break;
            default:
                break;
        }

        OnTutorialStateChanged?.Invoke(newTutorialState);
    }

    private void StateForward()
    {
        switch (PageCounter)
        {
            case 0:
                NavButtonBack?.SetActive(false);
                UpdateTutorialState(TutorialState.intro);
                break;
            case 1:
                NavButtonBack?.SetActive(true);
                UpdateTutorialState(TutorialState.characters);
                break;
            case 2:
                UpdateTutorialState(TutorialState.characters);
                break;
            case 3:
                UpdateTutorialState(TutorialState.characters);
                break;
            case 4:
                UpdateTutorialState(TutorialState.characters);
                break;
            case 5:
                UpdateTutorialState(TutorialState.page3);
                break;
            case 6:
                UpdateTutorialState(TutorialState.page4);
                break;
            case 7:
                UpdateTutorialState(TutorialState.page5);
                break;
            case 8:
                UpdateTutorialState(TutorialState.page5b);
                break;
            case 9:
                UpdateTutorialState(TutorialState.page6);
                break;
            default:
                break;
        }
    }

    // this method should be removeable if refactored properly. . .
    private void StateBack()
    {
        switch (PageCounter)
        {
            case 8:
                Debug.Log("STATE NUM: " + PageCounter);
                UpdateTutorialState(TutorialState.page5b);
                break;
            case 7:
                Debug.Log("STATE NUM: " + PageCounter);
                UpdateTutorialState(TutorialState.page5);
                break;
            case 6:
                Debug.Log("STATE NUM: " + PageCounter);
                UpdateTutorialState(TutorialState.page4);
                break;
            case 5:
                Debug.Log("STATE NUM: " + PageCounter);
                UpdateTutorialState(TutorialState.page3);
                break;
            case 4:
                Debug.Log("STATE NUM: " + PageCounter);
                UpdateTutorialState(TutorialState.charactersBack);
                break;
            case 3:
                Debug.Log("STATE NUM: " + PageCounter);
                UpdateTutorialState(TutorialState.charactersBack);
                break;
            case 2:
                Debug.Log("STATE NUM: " + PageCounter);
                UpdateTutorialState(TutorialState.charactersBack);
                break;
            case 1:
                Debug.Log("STATE NUM: " + PageCounter);
                UpdateTutorialState(TutorialState.charactersBack);
                break;
            case 0:
                Debug.Log("STATE NUM: " + PageCounter);
                UpdateTutorialState(TutorialState.intro);
                break;
            default:
                break;
        }
    }
    #endregion

    #region PageSetup methods
    private void SetUpPage6()
    {
        DeactivateTextElements();
        NavButtonForward.SetActive(false); 
        TextObjects[6].SetActive(true);
    }

    private void SetUpPage5b()
    {
        DeactivateTextElements();
        TextObjects[5].SetActive(true);
    }

    private void SetUpPage5()
    {
        DeactivateTextElements();
        TextObjects[4].SetActive(true);
    }

    private void SetUpPage4()
    {
        DeactivateTextElements();
        TextObjects[3].SetActive(true);
    }

    private void SetUpPage3()
    {
        DeactivateTextElements();
        CharactersCounter = 5; // ensures we can move back through states properly with the counter
        TextObjects[2].SetActive(true);
    }

    private void SetCharactersForward(int counter)
    {

        if (counter == 0)
        {
            DeactivateTextElements();
            TextObjects[1].SetActive(true);
            CharacterTextObjects[counter].Item1.SetActive(true);
            CharacterTextObjects[counter].Item2.SetActive(true);
        }
        else
        {
            // deactivate the text objects for the previous character
            CharacterTextObjects[counter - 1].Item1.SetActive(false);
            CharacterTextObjects[counter - 1].Item2.SetActive(false);

            CharacterTextObjects[counter].Item1.SetActive(true);
            CharacterTextObjects[counter].Item2.SetActive(true);
        }

        CharactersCounter++;
    }

    private void SetCharactersBack()
    {
        switch (CharactersCounter)
        {
            //TODO: this case may never occur
            case 0:
                break;
            case 1:
                break;
            case 2:
                CharacterTextObjects[CharactersCounter - 1].Item1.SetActive(false);
                CharacterTextObjects[CharactersCounter - 1].Item2.SetActive(false);

                CharacterTextObjects[CharactersCounter - 2].Item1.SetActive(true);
                CharacterTextObjects[CharactersCounter - 2].Item2.SetActive(true);
                break;
            case 3:
                CharacterTextObjects[CharactersCounter - 1].Item1.SetActive(false);
                CharacterTextObjects[CharactersCounter - 1].Item2.SetActive(false);

                CharacterTextObjects[CharactersCounter - 2].Item1.SetActive(true);
                CharacterTextObjects[CharactersCounter - 2].Item2.SetActive(true);
                break;
            case 4:
                CharacterTextObjects[CharactersCounter - 1].Item1.SetActive(false);
                CharacterTextObjects[CharactersCounter - 1].Item2.SetActive(false);

                CharacterTextObjects[CharactersCounter - 2].Item1.SetActive(true);
                CharacterTextObjects[CharactersCounter - 2].Item2.SetActive(true);
                break;
            case 5:
                DeactivateTextElements();
                TextObjects[1].SetActive(true);
                CharacterTextObjects[CharactersCounter - 2].Item1.SetActive(true);
                CharacterTextObjects[CharactersCounter - 2].Item2.SetActive(true);
                break;
            default:
                break;
        }

        CharactersCounter--;

    }

    private void SetUpIntro()
    {
        CharactersCounter -= CharactersCounter;
        NavButtonBack.SetActive(false);
        DeactivateTextElements();
        TextObjects[0].SetActive(true);
    }

    private void DeactivateTextElements()
    {
        // clean the scene of active text meshes

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
    #endregion
}
