module GameInventoryMenu

open App.Types
open SharedTemplate
open Feliz

let content = 
    [
        Html.div [
            prop.text "test"
        ]
    ]

let footer (dispatch: Msg -> unit) = 
    [
        Html.button [
            prop.className[ "button" ]
            prop.text "Use"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage GameInventoryPhotocastMenu)
            prop.text "Equip"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage GameMenu)
            prop.text "Back"
        ]
    ]

let render (dispatch: Msg -> unit) = 
    renderMainContentAndFooter content (footer dispatch)