module App

open Elmish
open Elmish.React

open App.Types
open Fable.Core.JsInterop

importAll "./scss/main.scss"

let init() = { 
    Count = 0
    CurrentPage = MainMenu
    Character = { Id = 0; Name = "test"; Level = 0; Enabled = false; Inventory = [] }
    Characters = []
    Game = { GameId = 5; MaxFloor = 5 }
    Games = [] }, Cmd.batch [Cmd.ofMsg (LoadGames Loading); Cmd.ofMsg (LoadCharacters Loading)]

let update (msg: Msg) (state: Model) = 
    match msg with
    | ChangePage page ->
        match page with
        | ActiveGameMenu id -> { state with CurrentPage = page }, Cmd.ofMsg (LoadGame (id, Loading))
        | CharacterSelect id -> { state with CurrentPage = page }, Cmd.ofMsg (LoadCharacter (id, Loading))
        | _ -> { state with CurrentPage = page }, Cmd.none
    | LoadCharacter (id, Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.Characters.getCharacter id LoadCharacter FailedToLoad
    | LoadCharacter (_, Result character) ->
        { state with Character = character }, Cmd.none
    | LoadCharacters Loading ->
        state, Cmd.OfAsync.either Infrastructure.Characters.getCharacters () LoadCharacters FailedToLoad
    | LoadCharacters (Result characters) ->
        { state with Characters = characters }, Cmd.none
    | LoadGame (id, Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.Games.getGame id LoadGame FailedToLoad
    | LoadGame (_, Result game) ->
        { state with Game = game }, Cmd.none        
    | LoadGames Loading ->
        state, Cmd.OfAsync.either Infrastructure.Games.getGames () LoadGames FailedToLoad
    | LoadGames (Result games) ->
        { state with Games = games }, Cmd.none
    | FailedToLoad error -> state, Cmd.none

let render (state: Model) (dispatch: Msg -> unit) = 
    match state.CurrentPage with
    | ActiveGameMenu _ -> ActiveGameMenu.render state dispatch
    | CharacterSelect _ -> CharacterSelect.render state dispatch
    | CombatMenu -> CombatMenu.render dispatch
    | CombatPhotocastsMenu -> CombatPhotocastsMenu.render dispatch
    | CombatPotionMenu -> CombatPotionMenu.render dispatch
    | CreateCharacter -> CreateCharacter.render dispatch
    | CreateGame -> CreateGame.render dispatch
    | DungeonMenu -> DungeonMenu.render dispatch
    | GameCharacterMenu -> GameCharacterMenu.render dispatch
    | GameInventoryMenu -> GameInventoryMenu.render dispatch
    | GameInventoryPhotocastMenu -> GameInventoryPhotocastMenu.render dispatch
    | GameMenu -> GameMenu.render dispatch
    | GamePhotocastMenu -> GamePhotocastMenu.render dispatch
    | MainMenu -> MainMenu.render state dispatch
    | PostCombatMenu -> PostCombatMenu.render dispatch
    | ShopBuyItem -> ShopBuyItem.render dispatch
    | ShopInventoryItem -> ShopInventoryItem.render dispatch
    | ShopMenu -> ShopMenu.render dispatch
    | TownMenu -> TownMenu.render dispatch

Program.mkProgram init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run