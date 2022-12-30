module Infrastructure.Game

open Fable.SimpleHttp
open Fable.SimpleJson
open App.Types

let gamesUrl = $"{Api.apiUrl}/game"
let gameUrl id = $"{Api.apiUrl}/game/{id}"

let getGames () = 
    async {
        let! (statusCode, responseText) = Http.get gamesUrl

        let games = Json.parseAs<Game.Game list> responseText

        return Shared.Result games
    }

let getGame gameId = 
    async {
        let! (statusCode, responseText) = Http.get <| gameUrl gameId

        let game = Json.parseAs<Game.Game> responseText

        return (gameId, Shared.Result game)
    }