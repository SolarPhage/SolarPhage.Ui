module App.Game

open App.Types.Game
open Elmish

let update (msg: Msg) (state: GameState) = 
    match msg with
    | LoadGame (id, Types.Shared.Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.Game.getGame id LoadGame FailedToLoadGame
    | LoadGame (_, Types.Shared.Result game) ->
        { state with Game = game }, Cmd.none        
    | LoadGames Types.Shared.Loading ->
        state, Cmd.OfAsync.either Infrastructure.Game.getGames () LoadGames FailedToLoadGame
    | LoadGames (Types.Shared.Result games) ->
        { state with Games = games }, Cmd.none
    | FailedToLoadGame ex -> state, Cmd.none