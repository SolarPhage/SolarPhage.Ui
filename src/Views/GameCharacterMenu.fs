module GameCharacterMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        prop.className "buttons"
        prop.children [
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
    ]