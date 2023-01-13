module Game.Views.GamePhotocastMenu

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
            prop.onClick (fun _ -> dispatch <| ChangePage GameCharacterMenu)
            prop.text "Equip"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage GameCharacterMenu)
            prop.text "Cancel"
        ]
    ]

let render (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter content (footer dispatch)