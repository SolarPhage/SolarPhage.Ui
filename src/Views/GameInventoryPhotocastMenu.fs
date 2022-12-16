module GameInventoryPhotocastMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        prop.className "buttons"
        prop.children [
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
    ]