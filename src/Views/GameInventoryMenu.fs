module GameInventoryMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.text "Use"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage GameInventoryPhotocastMenu)
            prop.text "Equip"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage GameMenu)
            prop.text "Back"
        ]
    ]