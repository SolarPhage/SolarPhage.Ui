module App

open Elmish
open Elmish.React

open App.Types
open Fable.Core.JsInterop

importAll "./scss/main.scss"

let init() = { 
    Count = 0
    CurrentPage = MainMenu
    Character = { CharacterId = 0; UserId = ""; }
    Characters = []
    Dungeon = { DungeonId = 5; Level = 1}
    Game = { GameId = 5; MaxFloor = 5 }
    Games = [] 
    ShopItems = []}, Cmd.batch [Cmd.ofMsg (LoadGames Loading); Cmd.ofMsg (LoadCharacters Loading)]

let update (msg: Msg) (state: State) = 
    match msg with
    | LoadPage (page, command) -> { state with CurrentPage = page }, Cmd.ofMsg command
    | ChangePage page -> { state with CurrentPage = page }, Cmd.none
    | LoadCharacter (id, Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.Character.getCharacter id LoadCharacter FailedToLoad
    | LoadCharacter (_, Result character) ->
        { state with Character = character }, Cmd.none
    | LoadCharacters Loading ->
        state, Cmd.OfAsync.either Infrastructure.Character.getCharacters () LoadCharacters FailedToLoad
    | LoadCharacters (Result characters) ->
        { state with Characters = characters }, Cmd.none
    | LoadDungeon (id, Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.Dungeon.getDungeon id LoadDungeon FailedToLoad
    | LoadDungeon (_, Result dungeon) ->
        { state with Dungeon = dungeon }, Cmd.none  
    | LoadGame (id, Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.Game.getGame id LoadGame FailedToLoad
    | LoadGame (_, Result game) ->
        { state with Game = game }, Cmd.none        
    | LoadGames Loading ->
        state, Cmd.OfAsync.either Infrastructure.Game.getGames () LoadGames FailedToLoad
    | LoadGames (Result games) ->
        { state with Games = games }, Cmd.none
    | LoadShop Loading ->
        state, Cmd.OfAsync.either Infrastructure.Shop.getShopItems () LoadShop FailedToLoad
    | LoadShop (Result items) ->
        { state with ShopItems = items }, Cmd.none
    | FailedToLoad error -> state, Cmd.none

let render (state: State) (dispatch: Msg -> unit) = 
    match state.CurrentPage with
    | ActiveGameMenu _ -> ActiveGameMenu.render state dispatch
    | CharacterSelect _ -> CharacterSelect.render state dispatch
    | CombatMenu -> CombatMenu.render dispatch
    | CombatPhotocastsMenu -> CombatPhotocastsMenu.render dispatch
    | CombatPotionMenu -> CombatPotionMenu.render dispatch
    | CreateCharacter -> CreateCharacter.render dispatch
    | CreateGame -> CreateGame.render dispatch
    | DungeonMenu -> DungeonMenu.render state dispatch
    | GameCharacterMenu -> GameCharacterMenu.render dispatch
    | GameInventoryMenu -> GameInventoryMenu.render dispatch
    | GameInventoryPhotocastMenu -> GameInventoryPhotocastMenu.render dispatch
    | GameMenu -> GameMenu.render dispatch
    | GamePhotocastMenu -> GamePhotocastMenu.render dispatch
    | MainMenu -> MainMenu.render state dispatch
    | PostCombatMenu -> PostCombatMenu.render dispatch
    | ShopBuyItem -> ShopBuyItem.render dispatch
    | ShopInventoryItem -> ShopInventoryItem.render dispatch
    | ShopMenu -> ShopMenu.render state dispatch
    | TownMenu -> TownMenu.render state dispatch

Program.mkProgram init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run