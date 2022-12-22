module GameMenu

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
            prop.onClick (fun _ -> dispatch <| ChangePage GameCharacterMenu)
            prop.text "Character"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage GameInventoryMenu)
            prop.text "Inventory"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage DungeonMenu)
            prop.text "Back"
        ]
    ]

let render (dispatch: Msg -> unit) = 
    renderMainContentAndFooter content (footer dispatch)