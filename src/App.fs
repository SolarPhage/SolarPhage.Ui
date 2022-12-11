module App

open Elmish
open Elmish.React
open Feliz
open Fulma.Elmish
open Fable.React

open App.Types

open ActiveGameMenu
open CharacterSelect
open CombatMenu
open CreateCharacter
open CreateGame
open DungeonMenu
open GameCharacterMenu
open GameInventoryMenu
open GameInventoryPhotocastMenu
open GameMenu
open GamePhotocastMenu
open MainMenu
open PostCombatMenu
open ShopBuyItem
open ShopInventoryItem
open ShopMenu
open TownMenu

Fable.Core.JsInterop.importAll "./scss/main.scss"

let init() = 
    { Count = 0; CurrentPage = MainMenu }

let update (msg: Msg) (state: Model) : Model = 
    match msg with
    | Increment ->
        { state with Count = state.Count + 1 }
    
    | Decrement ->
        { state with Count = state.Count - 1 }

    | ChangePage page ->
        { state with CurrentPage = page }

let render (state: Model) (dispatch: Msg -> unit) = 
    match state.CurrentPage with
    | ActiveGameMenu -> ActiveGameMenu.render dispatch
    | CharacterSelect -> CharacterSelect.render dispatch
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
    | MainMenu -> MainMenu.render dispatch
    | PostCombatMenu -> PostCombatMenu.render dispatch
    | ShopBuyItem -> ShopBuyItem.render dispatch
    | ShopInventoryItem -> ShopInventoryItem.render dispatch
    | ShopMenu -> ShopMenu.render dispatch
    | TownMenu -> TownMenu.render dispatch

Program.mkSimple init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run