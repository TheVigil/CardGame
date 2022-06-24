using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using RND = System.Random;

namespace Manager
{
    public class RuleManager : MonoBehaviour
    {
        /**
         * 
         * State Updater pattern for checking if cards fullfill the assigned rule on round end.
         * 
         */

        #region declarations
        private RuleState ruleState;
        private List<GameObject> exhibitObjects;
        public static event Action<RuleState> OnLevelStateChanged;
        private RND random = new RND();
        private GameObject RuleTextDisplay;

        /*
         * 
         * RulesDict
         * ---------------
         * A mapping of levels to the rule types available in that level.
         * 
         * Key: int -> the level number
         * Value: List<int> -> a list of integers corresponding to a rule.
         * 
         * Values are mapped as follows:
         * 
         * 0: Material
         * 1: Motif
         * 2: Artist
         * 3: Technique
         * 4: Style
         * 5: Elements (visual elements in image)
         * 6: Year (a year or span of years about the creation year of the art)
         * 
         * 
         */

        private Dictionary<int, List<int>> RulesDict
            = new Dictionary<int, List<int>>
            {
                {1, new List<int> { 0, 1, 2, 3} },
                {2, new List<int> { 2, 3, 4, 6} },
                {3, new List<int> { 2, 4, 6} }
            };

        public GameObject MaterialRule;
        public GameObject MotifRule;
        public GameObject ArtistRule;
        public GameObject TechniqueRule;
        public GameObject StyleRule;
        public GameObject ElementRule;
        public GameObject YearRule;
        public GameObject PedestalRule;

        public enum RuleState
        {
            assignRules,
            displayRule,
            checkRules,
        }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            exhibitObjects = new List<GameObject>();
            exhibitObjects.Add(GameObject.Find("Exhibit_0"));
            exhibitObjects.Add(GameObject.Find("Exhibit_1"));
            exhibitObjects.Add(GameObject.Find("Exhibit_2"));
            exhibitObjects.Add(GameObject.Find("Pedestal"));

            RuleTextDisplay = GameObject.Find("RulesTextDisplay");
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

        #region State Management
        public void UpdateRuleState(RuleState newRuleState)
        {
            ruleState = newRuleState;

            switch (ruleState)
            {
                case RuleState.assignRules:
                    AssignRules();
                    break;
                case RuleState.checkRules:
                    CheckRules();
                    break;
                case RuleState.displayRule:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region methods
        private void AssignRules()
        {
            foreach (var exhibitObject in exhibitObjects)
            {

                int currentLevel = GameManager.GameManagerInstance.CurrentLevel;

                TextMeshProUGUI ruleText = exhibitObject
                        .transform.GetChild(0)
                        .transform.GetChild(0)
                        .transform.GetChild(0)
                        .GetComponent<TextMeshProUGUI>();

                int randRuleType = random.Next(RulesDict[currentLevel][0], RulesDict[currentLevel][^1]); // use a pseudorandom int to select which rule type will be used.

                switch (randRuleType)
                {
                    case 0:
                        ruleText.text = "Material";
                        Instantiate(MaterialRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        break;
                    case 1:
                        ruleText.text = "Motiv";
                        Instantiate(MotifRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        break;
                    case 2:
                        ruleText.text = "Künstler";
                        Instantiate(ArtistRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        break;
                    case 3:
                        ruleText.text = "Technik";
                        Instantiate(TechniqueRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        break;
                    case 4:
                        ruleText.text = "Stil";
                        Instantiate(StyleRule,new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        break;
                    case 5:
                        ruleText.text = "Elemente";
                        Instantiate(ElementRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        break;
                    case 6:
                        ruleText.text = "Jahreszahl";
                        Instantiate(YearRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        break;
                    default:
                        break;
                }
            }
        }


        private void CheckRules()
        {
            foreach (var exhibitObj in exhibitObjects)
            {
                GameObject rule = exhibitObj.transform.GetChild(exhibitObj.transform.childCount - 1).gameObject;

                for (int i = 1; i < exhibitObj.transform.childCount - 1; i++)
                {
                    GameObject dropZone = exhibitObj.transform.GetChild(i).gameObject;
                    GameObject card = dropZone.transform.GetChild(0).gameObject;

                    //TODO: assert the card belongs to the rule
                    //rule.assert(card);
                }
            }
        }

        #endregion

    }
}

