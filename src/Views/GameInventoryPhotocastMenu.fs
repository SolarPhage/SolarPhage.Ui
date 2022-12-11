module GameInventoryPhotocastMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage GameInventoryMenu)
            prop.text "Equip"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage GameInventoryMenu)
            prop.text "Back"
        ]
    ]