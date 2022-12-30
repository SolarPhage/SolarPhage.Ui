module App

open Elmish
open Elmish.React

open App.Types
open Fable.Core.JsInterop

importAll "./scss/main.scss"

let initCharacterState = 
    {
        Character.Character = { CharacterId = 0; UserId = ""; }
        Character.Characters = []
    }

let initGameState = 
    {
        Game.Game = { GameId = 5; MaxFloor = 5 }
        Game.Games = [] 
    }

let init() = { 
    Count = 0
    CurrentPage = MainMenu
    Dungeon = { DungeonId = 5; Level = 1}
    ShopItems = []
    CharacterState = initCharacterState
    GameState = initGameState}, Cmd.batch [Cmd.ofMsg (GameMsg (Game.LoadGames Shared.Loading)); Cmd.ofMsg (CharacterMsg (Character.LoadCharacters Shared.Loading))]
    
let update (msg: Msg) (state: State) = 
    match msg with
    | LoadPage (page, command) -> { state with CurrentPage = page }, Cmd.ofMsg command
    | ChangePage page -> { state with CurrentPage = page }, Cmd.none
    | CharacterMsg characterMsg -> 
        let (cState, cmd) = App.Character.update characterMsg state.CharacterState
        let appCmd = Cmd.map (fun x -> CharacterMsg x) cmd
        { state with CharacterState = cState }, appCmd
    | GameMsg gameMsg -> 
        let (gState, cmd) = App.Game.update gameMsg state.GameState
        let appCmd = Cmd.map (fun x -> GameMsg x) cmd
        { state with GameState = gState }, appCmd
    | LoadDungeon (id, Shared.Loading) -> 
        state, Cmd.OfAsync.either Infrastructure.Dungeon.getDungeon id LoadDungeon FailedToLoad
    | LoadDungeon (_, Shared.Result dungeon) ->
        { state with Dungeon = dungeon }, Cmd.none  
    | LoadShop Shared.Loading ->
        state, Cmd.OfAsync.either Infrastructure.Shop.getShopItems () LoadShop FailedToLoad
    | LoadShop (Shared.Result items) ->
        { state with ShopItems = items }, Cmd.none
    | FailedToLoad error -> state, Cmd.none

let render (state: State) (dispatch: Msg -> unit) = 
    match state.CurrentPage with
    | ActiveGameMenu _ -> ActiveGameMenu.render state.GameState dispatch
    | CharacterSelect _ -> CharacterSelect.render state.CharacterState dispatch
    | CombatMenu -> CombatMenu.render dispatch
    | CombatPhotocastsMenu -> CombatPhotocastsMenu.render dispatch
    | CombatPotionMenu -> CombatPotionMenu.render dispatch
    | CreateCharacter -> CreateCharacter.render state.CharacterState dispatch
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