module Infrastructure.Shop

open Fable.SimpleHttp
open Fable.SimpleJson
open App.Types

let shopUrl = $"{Api.apiUrl}/shop"

let getShopItems () = 
    async {
        let! (statusCode, responseText) = Http.get shopUrl

        let shopItems = Json.parseAs<ShopItem list> responseText

        return Shared.Result shopItems
    }