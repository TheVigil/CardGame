using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using Data.Objects;

public class DropZone : MonoBehaviour
{

    
    private GameObject dropZone;
    private Collider2D dropZoneCollider;
    private GameManager gameManager;
    // TODO: this is where things start to get sloppy, sadly we ran out of time for code clean up and refactoring.
    private LevelManager levelManager;
    private RuleManager ruleManager;

    // Start is called before the first frame update
    void Start()
    {
        dropZone = gameObject;
        dropZoneCollider = gameObject.GetComponent<Collider2D>();
        gameManager = GameManager.GameManagerInstance;
        levelManager = gameManager.GetComponent<LevelManager>();
        ruleManager = gameManager.GetComponent<RuleManager>();
    }

    private void Update()
    {

    }

    public void DisableDropZoneCollider(GameObject card)
    {
        dropZoneCollider.enabled = false;
        ruleManager.UpdateRuleState(RuleManager.RuleState.attachItem, gameObject.transform.parent, card);
        levelManager.UpdateLevelState(LevelManager.LevelState.decreaseDrops);

        // TODO: this mess is only for debugging atm. move to RulesManager once all the rules are implemented!
       /* var matRule = gameObject.transform.parent.GetComponentInChildren<MatRuleCard>();
        var artistRule = gameObject.transform.parent.GetComponentInChildren<ArtistRuleCard>();
        var creationRule = gameObject.transform.parent.GetComponentInChildren<CreationRuleCard>();
        var techRule = gameObject.transform.parent.GetComponentInChildren<TechRuleCard>();
        var styleRule = gameObject.transform.parent.GetComponentInChildren<StyleRuleCard>();
        var elemRule = gameObject.transform.parent.GetComponentInChildren<ObjectRuleCard>();

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
        }*/
    }

    public void EnableDropZoneCollider(GameObject card)
    {
        dropZoneCollider.enabled = true;
        levelManager.UpdateLevelState(LevelManager.LevelState.increaseDrops);
        ruleManager.UpdateRuleState(RuleManager.RuleState.detachItem, gameObject.transform.parent, card);
    }


}
