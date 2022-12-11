module GameCharacterMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage GamePhotocastMenu)
            prop.text "Change Photocasts"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage GameMenu)
            prop.text "Back"
        ]
    ]