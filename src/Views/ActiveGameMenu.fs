module ActiveGameMenu

open App.Types
open SharedTemplate
open Feliz

let content (state : Model) =
    [
        Html.h1 [
            prop.text state.Game.GameId
        ]
        Html.h1 [
            prop.text state.Game.MaxFloor
        ]
    ]

let footer (dispatch : Msg -> unit) = 
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

let render (state : Model) (dispatch: Msg -> unit) = 
    renderMainContentAndFooter (content state) (footer dispatch)

