module Game.Views.GameInventoryPhotocastMenu

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
            prop.onClick (fun _ -> dispatch <| ChangePage GameInventoryMenu)
            prop.text "Equip"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage GameInventoryMenu)
            prop.text "Back"
        ]
    ]

let render (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter content (footer dispatch)