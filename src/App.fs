module App

open Elmish
open Elmish.React

open App.Types
open Fable.Core.JsInterop
open Fable.Core
open Fable.SimpleHttp
open Fable.SimpleJson

importAll "./scss/main.scss"

[<Emit("process.env.APIURL")>]
let apiUrl : string = jsNative
let gamesUrl = apiUrl + "/game"

let getGames () = 
    async {
        let! (statusCode, responseText) = Http.get gamesUrl

        return Json.parseAs<Game list> responseText
    }

let init() = 
    { Count = 0; CurrentPage = MainMenu; Games = [] }, Cmd.none

let update (msg: Msg) (state: Model) = 
    match msg with
    | ChangePage page ->
        match page with
        | ActiveGameMenu -> { state with CurrentPage = page }, Cmd.ofMsg LoadGames
        | _ -> { state with CurrentPage = page }, Cmd.none
    | LoadGames ->
        state, Cmd.OfAsync.either getGames () LoadGamesCompleted FailedToLoad
    | LoadGamesCompleted games ->
        { state with Games = games }, Cmd.none
    | FailedToLoad error -> state, Cmd.none

let render (state: Model) (dispatch: Msg -> unit) = 
    match state.CurrentPage with
    | ActiveGameMenu -> ActiveGameMenu.render state dispatch
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