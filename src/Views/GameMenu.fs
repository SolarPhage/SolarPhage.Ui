module GameMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage GameCharacterMenu)
            prop.text "Character"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage GameInventoryMenu)
            prop.text "Inventory"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage DungeonMenu)
            prop.text "Back"
        ]
    ]