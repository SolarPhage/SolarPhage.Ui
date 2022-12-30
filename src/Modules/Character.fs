module App.Character

open App.Types.Character
open Elmish

let update (msg: Msg) (state: CharacterState) = 
    match msg with
    | ClearCharacter -> 
        { state with Character = { UserId = ""; CharacterId = 0 }}, Cmd.none
    | LoadCharacter (id, Types.Shared.Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.Character.getCharacter id LoadCharacter FailedToLoadCharacter
    | LoadCharacter (_, Types.Shared.Result character) ->
        { state with Character = character }, Cmd.none
    | LoadCharacters Types.Shared.Loading ->
        state, Cmd.OfAsync.either Infrastructure.Character.getCharacters () LoadCharacters FailedToLoadCharacter
    | LoadCharacters (Types.Shared.Result characters) ->
        { state with Characters = characters }, Cmd.none
    | UpdateCharacter character ->
        { state with Character = character }, Cmd.none
    | SubmitCharacter -> 
        state, Cmd.OfAsync.either Infrastructure.Character.createCharacter state.Character SubmitCharacterResponse FailedToLoadCharacter
    | SubmitCharacterResponse _ ->
        state, Cmd.ofMsg ClearCharacter