module Infrastructure.Character

open Fable.SimpleHttp
open Fable.SimpleJson
open App.Types
open Fable.Core.JS

let charactersUrl = $"{Api.apiUrl}/character"
let characterUrl id = $"{Api.apiUrl}/character/{id}"

let getCharacters () = 
    async {
        let! (statusCode, responseText) = Http.get charactersUrl

        let characters = Json.parseAs<Character list> responseText

        return Result characters
    }

let getCharacter (characterId : string) = 
    async {
        let! (statusCode, responseText) = Http.get <| characterUrl characterId

        let character = List.head (Json.parseAs<Character list> responseText)
        
        return (characterId, Result character)
    }