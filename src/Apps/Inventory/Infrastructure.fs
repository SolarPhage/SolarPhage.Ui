module Inventory.Infrastructure

open Fable.SimpleHttp
open Fable.SimpleJson
open Types

let inventoryUrl = $"{Api.apiUrl}/inventory"

let putInventory inventory = 
    async {
        let requestData = Json.stringify inventory
        let! (statusCode, responseText) = Http.put inventoryUrl requestData

        let inventoryUpdate = Json.parseAs<InventoryUpdate> responseText

        return (statusCode, Result inventoryUpdate)
    }