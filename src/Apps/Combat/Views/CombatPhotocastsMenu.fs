module Combat.Views.CombatPhotocastsMenu

open Messages
open Types
open Templates.Shared
open Feliz

let content = 
    [
        Html.div [
            prop.text "test"
        ]
    ]

let footer (dispatch: MainMessage -> unit) = 
    [
        Html.button [
            prop.className[ "button" ]
            prop.text "Move Up"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.text "Move Down"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage CombatMenu)
            prop.text "Back"
        ]
    ]

let render (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter content (footer dispatch)