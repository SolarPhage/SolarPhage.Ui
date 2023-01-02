module Game.App

open Messages
open Types
open Elmish

let update (msg: GameMessage) (state: GameState) = 
    match msg with
    | LoadGame (id, Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.getGame id LoadGame FailedToLoadGame
    | LoadGame (_, Result game) ->
        { state with Game = game }, Cmd.none        
    | LoadGames Loading ->
        state, Cmd.OfAsync.either Infrastructure.getGames () LoadGames FailedToLoadGame
    | LoadGames (Result games) ->
        { state with Games = games }, Cmd.none
    | FailedToLoadGame ex -> state, Cmd.none