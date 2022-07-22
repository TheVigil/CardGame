using Data.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using RND = System.Random;

namespace Manager
{
    public class RuleManager : MonoBehaviour
    {
        /**
         * 
         * State Updater pattern for assigning rules to each exhibit at the top of the level, as 
         * well as checking if cards fullfill the assigned rule on level end.
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
         * Value: SortedDictionary<int, List<string>> -> 
         *          Key: int -> integer corresponding to the mapping below
         *          Value: string -> list of strings corresponding to a rule.
         * 
         * Values are mapped as follows:
         * 
         * 0: Material
         * 1: Motif
         * 2: Birthplace
         * 3: Technique
         * 4: Style
         * 5: Year (a year or span of years about the creation year of the art)
         * 
         * 
         */

        private SortedDictionary<int, SortedDictionary<int, List<string>>> RulesDict
            = new SortedDictionary<int, SortedDictionary<int, List<string>>>
            {
                {1, new SortedDictionary<int, List<string>> {
                        {0, new List<string>{"Papier", "Leinwand", "Holz"}},
                        {1, new List<string>{ "Stillleben",
                                                "Pflanzen",
                                                "Pflanze",
                                                "Naturlandschaft",
                                                "Mensch",
                                                "Reiter",
                                                "Landschaft",
                                                "Boote",
                                                "Boot",
                                                "Abstrakt",
                                                "Tiere",
                                                "Tier",
                                                "Pferde",
                                                "Pferd",
                                                "Formen",
                                                "Form",
                                                "Muster",
                                                "Menschen",
                                                "Stadtlandschaft",
                                                "Gebäude",
                                                "Ländlich",
                                                "Bäume",
                                                "Baum",
                                                "Gans",
                                                "Nahrung",
                                                "Essen",
                                                "Kirschen",
                                                "Kirsche",
                                                "Tiger",
                                                "Meer",
                                                "Farben",
                                                "Abstrakte Landschaft",
                                                "Geometrie",
                                                "Taube",
                                                "Japanisch",
                                                "Japan",
                                                "Gebirge",
                                                "Wasserfall",
                                                "Hafen",
                                                "Küste",
                                                "Felsen"} },
                        {2, new List<string>{"16", "17", "18", "19", "20"}},
                    }
                },
                {2,  new SortedDictionary<int, List<string>>
                    {
                        {3, new List<string>{"Öl", "Aquarell", "Gezeichnet", "Lithographie", "Farbholzschnitt"}},
                        {4, new List<string>{"Impressionismus", "Romantik", "Klassizismus", "Ukiyo-e", "Konstrukivismus" }},
                        {5 ,new List<string>{"16", "17", "18", "19", "20"}},
                    } 
                },
                {3,  new SortedDictionary<int, List<string>>
                    {
                        {3, new List<string>{"Öl", "Aquarell", "Gezeichnet", "Lithographie", "Farbholzschnitt"}},
                        {4, new List<string>{"Impressionismus", "Romantik", "Klassizismus", "Ukiyo-e", "Konstrukivismus" }}, 
                        {5, new List<string>{"16", "17", "18", "19", "20"}},
                    } 
                }
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
            attachItem,
            detachItem,
        }
        #endregion

        #region Unity Methods
        private void Awake()
        {

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
        public void UpdateRuleState(RuleState newRuleState, Transform exhibit, GameObject card)
        {
            ruleState = newRuleState;
            var x = exhibit;
            var y = card;
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
                case RuleState.attachItem:
                    AttachItem(x, y);
                    break;
                case RuleState.detachItem:
                    DetachItem();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region methods
        private void AssignRules()
        {
            exhibitObjects = new List<GameObject>();
            exhibitObjects.Add(GameObject.Find("Exhibit_0"));
            exhibitObjects.Add(GameObject.Find("Exhibit_1"));
            exhibitObjects.Add(GameObject.Find("Exhibit_2"));
            exhibitObjects.Add(GameObject.Find("Pedestal"));

            RuleTextDisplay = GameObject.Find("RulesTextDisplay");

            foreach (var exhibitObject in exhibitObjects)
            {
                if(exhibitObject.name == "Pedestal")
                {
                    AssignExhibitRules(1, exhibitObject);
                }
                else
                {
                    AssignExhibitRules(1, exhibitObject);
                }  
            }
        }

        private void AssignExhibitRules(int rulesCount, GameObject exhibitObject)
        {
            // we need to track the type of rules already assigned to the pedestal to ensure rule uniqueness
            List<int> ruleTypes = new List<int>();

            int currentLevel = GameManager.GameManagerInstance.GetLevel();

            while (ruleTypes.Count < rulesCount)
            {
                int randRuleType = GenerateRuleType(currentLevel);

                if (!ruleTypes.Contains(randRuleType))
                {
                    ruleTypes.Add(randRuleType); 
                }
            }

            TextMeshProUGUI ruleText = exhibitObject
                        .transform.GetChild(0)
                        .transform.GetChild(0)
                        .transform.GetChild(0)
                        .GetComponent<TextMeshProUGUI>();


            foreach (var randRuleType in ruleTypes)
            {
                switch (randRuleType)
                {
                    case 0:
                        ruleText.text = "Material";
                        Instantiate(MaterialRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        exhibitObject.GetComponentInChildren<MatRuleCard>().AssignRuleText(RulesDict[currentLevel][randRuleType]);
                        break;
                    case 1:
                        ruleText.text = "Motiv";
                        Instantiate(MotifRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        exhibitObject.GetComponentInChildren<ObjectRuleCard>().AssignRuleText(RulesDict[currentLevel][randRuleType]);
                        break;
                    case 2:
                        ruleText.text = "Geburtsjahrhundert";
                        Instantiate(ArtistRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        exhibitObject.GetComponentInChildren<ArtistRuleCard>().AssignRuleText(RulesDict[currentLevel][randRuleType]);
                        break;
                    case 3:
                        ruleText.text = "Technik";
                        Instantiate(TechniqueRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        exhibitObject.GetComponentInChildren<TechRuleCard>().AssignRuleText(RulesDict[currentLevel][randRuleType]);

                        break;
                    case 4:
                        ruleText.text = "Stil";
                        Instantiate(StyleRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        exhibitObject.GetComponentInChildren<StyleRuleCard>().AssignRuleText(RulesDict[currentLevel][randRuleType]);
                        break;
                    case 5:
                        ruleText.text = "Entstehungsjahrhundert";
                        Instantiate(YearRule, new Vector2(0, 0), Quaternion.identity).transform.SetParent(exhibitObject.transform);
                        exhibitObject.GetComponentInChildren<CreationRuleCard>().AssignRuleText(RulesDict[currentLevel][randRuleType]);
                        break;
                    default:
                        break;
                }
            }
        }

        private int GenerateRuleType(int currentLevel)
        {
           return random.Next(RulesDict[currentLevel].Keys.First(), RulesDict[currentLevel].Keys.Last() + 1);
        }

        private void AttachItem(Transform exhibit, GameObject card)
        {
            var rule = exhibit.transform.GetChild(exhibit.transform.childCount - 1);
            var item = card.GetComponent<ItemCard>();

            var matRule = rule.GetComponent<MatRuleCard>();
            var artistRule = rule.GetComponent<ArtistRuleCard>();
            var creationRule = rule.GetComponent<CreationRuleCard>();
            var techRule = rule.GetComponent<TechRuleCard>();
            var styleRule = rule.GetComponent<StyleRuleCard>();
            var elemRule = rule.GetComponent<ObjectRuleCard>();

            var ruleArray = new UnityEngine.Object[6] { matRule, artistRule, creationRule, techRule, styleRule, elemRule };

            foreach (var ruleCard in ruleArray)
            {
                if(ruleCard != null)
                {
                    string type = ruleCard.GetType().Name;

                    switch (type)
                    {
                        case "MatRuleCard":
                            MatRuleCard mrc = (MatRuleCard)ruleCard;
                            mrc.AttachItemToRule(item);
                            break;
                        case "ArtistRuleCard":
                            ArtistRuleCard arc = (ArtistRuleCard)ruleCard;
                            arc.AttachItemToRule(item);
                            break;
                        case "CreationRuleCard":
                            CreationRuleCard crc = (CreationRuleCard)ruleCard;
                            crc.AttachItemToRule(item);
                            break;
                        case "TechRuleCard":
                            TechRuleCard trc = (TechRuleCard)ruleCard;
                            trc.AttachItemToRule(item);
                            break;
                        case "StyleRuleCard":
                            StyleRuleCard src = (StyleRuleCard)ruleCard;
                            src.AttachItemToRule(item);
                            break;
                        case "ObjectRuleCard":
                            ObjectRuleCard erc = (ObjectRuleCard)ruleCard;
                            erc.AttachItemToRule(item);
                            break;
                        default:
                            break;
                    }
                }
            }

        }

        private void DetachItem()
        {
            throw new NotImplementedException();
        }

        private void CheckRules()
        {
            Debug.Log("CHECK RULES");
            foreach (var exhibit in exhibitObjects)
            {
                // sloppy, but I can't think of a more clever way to get the rule objects, since I neither know in advance which rules are assigned to the exhibit, nor how many. 

                var matRule = exhibit.GetComponentInChildren<MatRuleCard>();
                var artistRule = exhibit.GetComponentInChildren<ArtistRuleCard>();
                var creationRule = exhibit.GetComponentInChildren<CreationRuleCard>();
                var techRule = exhibit.GetComponentInChildren<TechRuleCard>();
                var styleRule = exhibit.GetComponentInChildren<StyleRuleCard>();
                var elemRule = exhibit.GetComponentInChildren<ObjectRuleCard>();

                var ruleArray = new UnityEngine.Object[6] { matRule, artistRule, creationRule, techRule, styleRule, elemRule };

                foreach (var ruleCard in ruleArray)
                {
                    if (ruleCard != null)
                    {
                        string type = ruleCard.GetType().Name;
                        switch (type)
                        {
                            case "MatRuleCard":
                                MatRuleCard mrc = (MatRuleCard)ruleCard;
                                mrc.AssertRuleViolation();
                                break;
                            case "ArtistRuleCard":
                                ArtistRuleCard arc = (ArtistRuleCard)ruleCard;
                                arc.AssertRuleViolation();
                                break;
                            case "CreationRuleCard":
                                CreationRuleCard crc = (CreationRuleCard)ruleCard;
                                crc.AssertRuleViolation();
                                break;
                            case "TechRuleCard":
                                TechRuleCard trc = (TechRuleCard)ruleCard;
                                trc.AssertRuleViolation();
                                break;
                            case "StyleRuleCard":
                                StyleRuleCard src = (StyleRuleCard)ruleCard;
                                src.AssertRuleViolation();
                                break;
                            case "ObjectRuleCard":
                                ObjectRuleCard erc = (ObjectRuleCard)ruleCard;
                                erc.AssertRuleViolation();
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        #endregion

    }
}

