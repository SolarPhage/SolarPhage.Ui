module Character.App

open Messages
open Types
open Elmish

let update (msg: CharacterMessage) (state: CharacterState) = 
    match msg with
    | ClearCharacter -> 
        { state with Character = { UserId = ""; CharacterId = 0 }}, Cmd.none
    | LoadCharacter (id, Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.getCharacter id LoadCharacter FailedToLoadCharacter
    | LoadCharacter (_, Result character) ->
        { state with Character = character }, Cmd.none
    | LoadCharacters Loading ->
        state, Cmd.OfAsync.either Infrastructure.getCharacters () LoadCharacters FailedToLoadCharacter
    | LoadCharacters (Result characters) ->
        { state with Characters = characters }, Cmd.none
    | UpdateCharacter character ->
        { state with Character = character }, Cmd.none
    | SubmitCharacter -> 
        state, Cmd.OfAsync.either Infrastructure.createCharacter state.Character SubmitCharacterResponse FailedToLoadCharacter
    | SubmitCharacterResponse _ ->
        state, Cmd.ofMsg ClearCharacter
    | FailedToLoadCharacter x -> state, Cmd.none