using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using System;
using TMPro;

public class RuleSign : MonoBehaviour
{

    #region declarations
    private GameManager gameManager;
    private RuleManager ruleManager;
    private GameObject ruleSign;
    private Transform RulesText;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        RulesText = GameObject.Find("Canvas").transform.GetChild(1);
        gameManager = GameManager.GameManagerInstance;
        // ruleManager = gameManager.GetComponent<RuleManager>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region methods
    public void OnMouseDown()
    {
        DisplayRule();

    }

    public void OnMouseUp()
    {
        HideRule();
    }

    private void HideRule()
    {
        RulesText.gameObject.SetActive(false);
    }

    //TODO: this should be in the RuleManager, but I kept having a null ref error when trying to pass this.gameObject to the manager. . .
    private void DisplayRule()
    {
        Transform parent = gameObject.transform.parent;

        int children = gameObject.transform.parent.childCount;

        string name = parent.GetChild(children - 1).transform.name;

        //TODO: this should reflect the text of the individual rule 
        RulesText.gameObject.SetActive(true);
        RulesText.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = name;

    }

    #endregion



}
