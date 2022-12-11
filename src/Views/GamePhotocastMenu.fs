module GamePhotocastMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage GameCharacterMenu)
            prop.text "Equip"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage GameCharacterMenu)
            prop.text "Cancel"
        ]
    ]