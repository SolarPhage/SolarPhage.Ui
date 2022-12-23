module Infrastructure.Characters

open Fable.SimpleHttp
open Fable.SimpleJson
open App.Types

let charactersUrl = $"{Api.apiUrl}/character"
let characterUrl id = $"{Api.apiUrl}/character/{id}"

let getCharacters () = 
    async {
        let! (statusCode, responseText) = Http.get charactersUrl

        let characters = Json.parseAs<Character list> responseText

        return Result characters
    }

let getCharacter (characterId : int) = 
    async {
        let! (statusCode, responseText) = Http.get <| characterUrl characterId

        let character = Json.parseAs<Character> responseText

        return (characterId, Result character)
    }