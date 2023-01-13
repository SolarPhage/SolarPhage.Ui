module Dungeon.App

open Messages
open Types
open Elmish

let update (msg: DungeonMessage) (state: DungeonState) = 
    match msg with
    | LoadDungeon (id, Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.getDungeon id LoadDungeon FailedToLoadDungeon
    | LoadDungeon (_, Result dungeon) ->
        { state with Dungeon = dungeon }, Cmd.none  
    | FailedToLoadDungeon x -> state, Cmd.none