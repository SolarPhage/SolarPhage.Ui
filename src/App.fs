module App

open Elmish
open Elmish.React

open Messages
open Types
open Combat.Views
open Character.Views
open Character.Types
open Dungeon.Types
open Shop.Types
open Dungeon.Views
open Main.Views
open Shop.Views
open Game.Views
open Town.Views
open Game.Types
open Main.Types
open Fable.Core.JsInterop

importAll "./scss/main.scss"

let initCharacterState = 
    {
        Character = { CharacterId = 0; UserId = ""; }
        Characters = []
    }

let initDungeonState = 
    {
        Dungeon = { DungeonId = 5; Level = 1 }
    }

let initGameState = 
    {
        Game = { GameId = 5; MaxFloor = 5 }
        Games = [] 
    }

let initShopState = 
    {
        ShopItems = []
    }

let init() = 
    { 
        Count = 0
        CurrentPage = MainMenu
        DungeonState = initDungeonState
        ShopState = initShopState
        CharacterState = initCharacterState
        GameState = initGameState
    }, Cmd.batch [Cmd.ofMsg (GameMsg (LoadGames Loading)); Cmd.ofMsg (CharacterMsg (LoadCharacters ("230598sfljf", Loading)))]
    
let update (msg: MainMessage) (state: State) = 
    match msg with
    | LoadPage (page, command) -> { state with CurrentPage = page }, Cmd.ofMsg command
    | ChangePage page -> { state with CurrentPage = page }, Cmd.none
    | CharacterMsg characterMsg -> 
        let (cState, cmd) = Character.App.update characterMsg state.CharacterState
        let appCmd = Cmd.map (fun x -> CharacterMsg x) cmd
        { state with CharacterState = cState }, appCmd
    | DungeonMsg msg -> 
        let (dState, cmd) = Dungeon.App.update msg state.DungeonState
        let appCmd = Cmd.map (fun x -> DungeonMsg x) cmd
        { state with DungeonState = dState }, appCmd
    | GameMsg gameMsg -> 
        let (gState, cmd) = Game.App.update gameMsg state.GameState
        let appCmd = Cmd.map (fun x -> GameMsg x) cmd
        { state with GameState = gState }, appCmd
    | ShopMsg msg -> 
        let (sState, cmd) = Shop.App.update msg state.ShopState
        let appCmd = Cmd.map (fun x -> ShopMsg x) cmd
        { state with ShopState = sState }, appCmd   
    | FailedToLoad error -> state, Cmd.none

let render (state: State) (dispatch: MainMessage -> unit) = 
    match state.CurrentPage with
    | ActiveGameMenu _ -> ActiveGameMenu.render state.GameState dispatch
    | CharacterSelect _ -> CharacterSelect.render state.CharacterState dispatch
    | CombatMenu -> CombatMenu.render dispatch
    | CombatPhotocastsMenu -> CombatPhotocastsMenu.render dispatch
    | CombatPotionMenu -> CombatPotionMenu.render dispatch
    | CreateCharacter -> CreateCharacter.render state.CharacterState dispatch
    | CreateGame -> CreateGame.render dispatch
    | DungeonMenu -> DungeonMenu.render state.DungeonState dispatch
    | GameCharacterMenu -> GameCharacterMenu.render dispatch
    | GameInventoryMenu -> GameInventoryMenu.render dispatch
    | GameInventoryPhotocastMenu -> GameInventoryPhotocastMenu.render dispatch
    | GameMenu -> GameMenu.render dispatch
    | GamePhotocastMenu -> GamePhotocastMenu.render dispatch
    | MainMenu -> MainMenu.render state dispatch
    | PostCombatMenu -> PostCombatMenu.render dispatch
    | ShopBuyItem -> ShopBuyItem.render dispatch
    | ShopInventoryItem -> ShopInventoryItem.render dispatch
    | ShopMenu -> ShopMenu.render state.ShopState dispatch
    | TownMenu -> TownMenu.render state dispatch

Program.mkProgram init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run