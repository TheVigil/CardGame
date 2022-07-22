using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using System;
using TMPro;

public class RuleSign : MonoBehaviour
{

    #region declarations
    //private GameManager gameManager;
    // private RuleManager ruleManager;
    // private GameObject ruleSign;
    private Transform RulesText;
    public string description;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        RulesText = GameObject.Find("Canvas").transform.GetChild(1);
        //gameManager = GameManager.GameManagerInstance;
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

    private void DisplayRule()
    {


        RulesText.gameObject.SetActive(true);
        RulesText.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = description;

    }

    #endregion



}
