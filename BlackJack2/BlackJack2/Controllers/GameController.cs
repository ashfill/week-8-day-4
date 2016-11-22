﻿using BlackJack2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlackJack2.Controllers
{
    public class GameController : Controller
    {
        HttpClient client = new HttpClient();
        string url = "https://deckofcardsapi.com/api/deck";
        Deck currentDeck;
        //CardViewModel cvm = new CardViewModel();
        //Person player = new Person();
        //Person dealer = new Person();

        public GameController()
        {
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //cvm.cards = new List<Card>();
        }

        // GET: Game
        public async Task<ActionResult> Index()
        {
            if (cvm.deck_id == null)
            {
                HttpResponseMessage response = await client.GetAsync(url + "/new/shuffle/?deck_count=1");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    Deck deck = JsonConvert.DeserializeObject<Deck>(responseData);

                    cvm.deck_id = deck.deck_id;
                    cvm.remaining = deck.remaining;

                    return View(cvm);
                }
                return View("Error");
            }
            return View(cvm);
        }

        public async Task<ActionResult> DrawACard()
        {
            var deckId = Request.QueryString["deck_id"];

            HttpResponseMessage response = await client.GetAsync(url + "/" + deckId + "/draw/?count=1");

            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                CardViewModel cvm2 = JsonConvert.DeserializeObject<CardViewModel>(responseData);

                cvm.cards.Add(cvm2.cards[0]);
                cvm.deck_id = cvm2.deck_id;
                cvm.remaining = cvm2.remaining;

                return View(cvm);
            }
            return View("Error");
        }
    }
}