using Data.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data.Json.Colors_Patterns.Objects;

namespace Manager
{
    public class CardManager : MonoBehaviour
    {

        /*
         * 
         * A Manager for handling player cards and the deck.
         * 
         * 
         * **/

        public static GameManager GameManagerInstance;
        public List<GameObject> deck = new List<GameObject>();
        public List<GameObject> discardPile = new List<GameObject>();
        public Transform[] cardSlots; // an array of transforms for tracking slot positions
        public bool[] availableCardSlots; // track if card slots are available for the player's hand
        public GameObject PlayerCard;
        private GameObject GameDeck;

        private void Awake()
        {
            GameDeck = GameObject.Find("CardContainer");

            DontDestroyOnLoad(GameDeck);

        }
        // Start is called before the first frame update
        private void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        internal void PopulateDeck()
        {
            // TODO: This will allow repeated instantiation of the same cards in the deck. Don't destroy deck on scene change?
            ConfigParameter confParam = JConfigDeserializer.JConfig._out[0];
            List<OutputParameter> outParams = JDataDeserializer.JData._out;

            for (int i = 0; i < confParam._guids.Count; i++)
            {
                string currGuid = confParam._guids[i];
                foreach (OutputParameter outParam in outParams)
                {
                    if (outParam._guid == currGuid)
                    {
                        JParamHolder._currOutParam = outParam;
                        GameObject Card = Instantiate(PlayerCard, new Vector2(0, 0), Quaternion.identity);
                        Card.transform.SetParent(GameDeck.transform, false);
                        Card.GetComponent<BoxCollider2D>().size = new Vector2(1f, 1f);
                        deck.Add(Card);
                        break;
                    }
                }
            }
        }
        internal void EnableCardSlot(int i)
        {
            availableCardSlots[i] = true;
        }

        public void DrawCard()
        {
            if (deck.Count >= 1)
            {
                GameObject randCard = deck[Random.Range(0, deck.Count)];
                for (int i = 0; i < availableCardSlots.Length; i++)
                {
                    if (availableCardSlots[i] == true)
                    {
                        randCard.gameObject.SetActive(true);
                        randCard.transform.SetParent(cardSlots[i].transform, false);
                        randCard.transform.position = cardSlots[i].transform.position;
                        randCard.GetComponent<Card>().handSlotIndex = i;
                        availableCardSlots[i] = false;
                        deck.Remove(randCard);
                        return;
                    }
                }
            }
        }
    }
}

