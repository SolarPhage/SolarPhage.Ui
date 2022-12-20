module App

open Elmish
open Elmish.React

open App.Types
open Fable.Core.JsInterop
open Fable.Core
open Fable.Core.JS
open Fable.SimpleHttp

importAll "./scss/main.scss"

[<Emit("process.env.APIURL")>]
let apiUrl : string = jsNative
let gamesUrl = apiUrl + "/game"

let x y = 
    async {
        let! (statusCode, responseText) = Http.get gamesUrl
        console.log(statusCode)
        console.log(responseText)
        return responseText
    }

let init() = 
    { Count = 0; CurrentPage = MainMenu }, Cmd.none

let update (msg: Msg) (state: Model) = 
    match msg with
    | Increment x ->
        { state with Count = state.Count + 1 }, Cmd.none
    
    | Decrement y ->
        { state with Count = state.Count - 1 }, Cmd.none

    | ChangePage page ->
        { state with CurrentPage = page }, Cmd.OfAsync.either x "test" Increment Decrement

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

Program.mkProgram init update render
|> Program.withReactSynchronous "elmish-app"
|> Program.run