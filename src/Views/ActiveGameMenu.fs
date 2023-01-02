module ActiveGameMenu

open Types
open Game.Types
open Messages
open Templates.Shared
open Feliz

let content (state : GameState) =
    [
        Html.h1 [
            prop.text state.Game.GameId
        ]
        Html.h1 [
            prop.text state.Game.MaxFloor
        ]
    ]

let footer (dispatch : MainMessage -> unit) = 
    [
        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage TownMenu)
            prop.text "Join"
        ]
        
        Html.button [
            prop.className[ "button" ]
            prop.text "Delete"
        ]
        
        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage MainMenu)
            prop.text "Back"
        ]
    ]

let render (state : GameState) (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter (content state) (footer dispatch)

