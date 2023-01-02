module GameCharacterMenu

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
            prop.onClick (fun _ -> dispatch <| ChangePage GamePhotocastMenu)
            prop.text "Change Photocasts"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage GameMenu)
            prop.text "Back"
        ]
    ]

let render (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter content (footer dispatch)
