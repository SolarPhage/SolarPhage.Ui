module Shop.Infrastructure

open Fable.SimpleHttp
open Fable.SimpleJson
open Types
open Shop.Types

let shopUrl = $"{Api.apiUrl}/shop"

let getShopItems () = 
    async {
        let! (statusCode, responseText) = Http.get shopUrl

        let shopItems = Json.parseAs<ShopItem list> responseText

        return Result shopItems
    }