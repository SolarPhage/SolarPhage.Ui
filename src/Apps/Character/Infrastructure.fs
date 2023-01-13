module Character.Infrastructure

open Fable.SimpleHttp
open Fable.SimpleJson
open Types


let charactersUrl = $"{Api.apiUrl}/character"
let characterUrl id = $"{Api.apiUrl}/character/{id}"

let getCharacters (userId : string) = 
    async {
        let! (statusCode, responseText) = Http.get <| characterUrl userId

        let characters = Json.parseAs<Character list> responseText

        return (userId, Result characters)
    }

let getCharacter (characterId : string) = 
    async {
        let! (statusCode, responseText) = Http.get <| characterUrl characterId

        let character = List.head (Json.parseAs<Character list> responseText)
        
        return (characterId, Result character)
    }

let createCharacter (character : Character) = 
    async {
        let! (statusCode, responseText) = Http.post charactersUrl <| Json.serialize character

        return (statusCode, Result responseText)
    }