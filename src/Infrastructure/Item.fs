module Infrastructure.Item

open Fable.SimpleHttp
open Fable.SimpleJson
open App.Types

let itemIdUrl id = $"{Api.apiUrl}/item/{id}"

let getItem (itemId : int) = 
    async {
        let! (statusCode, responseText) = Http.get <| itemIdUrl itemId

        let itemInfo = Json.parseAs<Item> responseText

        return (itemId, Result itemInfo)
    }