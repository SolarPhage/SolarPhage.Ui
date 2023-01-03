module Dungeon.Infrastructure

open Fable.SimpleHttp
open Fable.SimpleJson
open Types

let dungeonUrl = $"{Api.apiUrl}/dungeon"
let dungeonIdUrl id = $"{Api.apiUrl}/dungeon/{id}"

let postDungeon dungeon = 
    async {
        let requestData = Json.stringify dungeon
        let! (statusCode, responseText) = Http.post dungeonUrl requestData

        let dungeonInfo = Json.parseAs<DungeonInfo> responseText

        return (statusCode, Result dungeonInfo)
    }

let getDungeon (dungeonId : int) = 
    async {
        let! (statusCode, responseText) = Http.get <| dungeonIdUrl dungeonId

        let dungeonInfo = Json.parseAs<DungeonInfo> responseText

        return (dungeonId, Result dungeonInfo)
    }